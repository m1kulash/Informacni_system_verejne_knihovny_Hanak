using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using IS.Knihovna.Data;
using IS.Knihovna.Domain.Entities;

namespace IS.Knihovna.Services
{
    public class RezervaceService
    {
        private readonly KnihovnaContext _context;

        public RezervaceService(KnihovnaContext context) => _context = context;

        // Vytvoření nové rezervace do fronty
        public void RezervovatTitul(int ctenarId, int titulId)
        {
            // Zjistíme, kolik lidí už na tento titul čeká, abychom určili pořadí
            int aktualniPocetRezervaci = _context.Rezervace
                .Count(r => r.TitulID == titulId && r.Stav == "Čeká");

            var rezervace = new Rezervace
            {
                CtenarID = ctenarId,
                TitulID = titulId,
                DatumVytvoreni = DateTime.Now,
                Poradi = aktualniPocetRezervaci + 1, // Čtenář jde na konec fronty
                Stav = "Čeká"
            };

            _context.Rezervace.Add(rezervace);
            _context.SaveChanges();
        }

        // Metoda, která se zavolá při vrácení knihy, aby informovala prvního ve frontě
        public void VyriditRezervaci(int titulId)
        {
            // Najdeme prvního čtenáře v pořadí pro daný titul
            var prvniRezervace = _context.Rezervace
                .Where(r => r.TitulID == titulId && r.Stav == "Čeká")
                .OrderBy(r => r.Poradi)
                .FirstOrDefault();

            if (prvniRezervace != null)
            {
                prvniRezervace.Stav = "Připraveno";
                // Nastavení expirace pro vyzvednutí (např. 7 dní)
                prvniRezervace.ExpiraceVydeje = DateTime.Now.AddDays(7);
                _context.SaveChanges();
            }
        }

        // Zrušení rezervace (např. čtenář si to rozmyslel)
        public void ZrusitRezervaci(int rezervaceId)
        {
            var rezervace = _context.Rezervace.Find(rezervaceId);
            if (rezervace != null)
            {
                int titulId = rezervace.TitulID;
                int smazanePoradi = rezervace.Poradi;

                _context.Rezervace.Remove(rezervace);
                _context.SaveChanges();

                // Přepočítání pořadí pro ostatní čekající ve frontě
                var ostatniRezervace = _context.Rezervace
                    .Where(r => r.TitulID == titulId && r.Poradi > smazanePoradi && r.Stav == "Čeká")
                    .ToList();

                foreach (var r in ostatniRezervace)
                {
                    r.Poradi--;
                }
                _context.SaveChanges();
            }
        }
    }
}