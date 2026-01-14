using System;
using System.Collections.Generic;
using System.Linq;
using IS.Knihovna.Data;
using IS.Knihovna.Domain.Entities;
using System.Data.Entity;

// Přidejte explicitní alias pro typ Objednavka z IS.Knihovna.Domain.Entities
using ObjednavkaEntity = IS.Knihovna.Domain.Entities.Objednavka;

namespace IS.Knihovna.Services
{
    public class ObjednavkaService
    {
        private readonly KnihovnaContext _context;

        public ObjednavkaService(KnihovnaContext context) => _context = context;

        public List<ObjednavkaEntity> GetVsechnyObjednavky()
        {
            // Explicitní projekce na typ z IS.Knihovna.Domain.Entities
            return _context.Objednavky
                .Include(o => o.Vydavatel)
                .OrderByDescending(o => o.DatumVytvoreni)
                .Select(o => new ObjednavkaEntity
                {
                    ObjednavkaID = o.Id,
                    VydavatelID = o.Vydavatel != null ? o.Vydavatel.VydavatelID : (int?)null,
                    DatumVytvoreni = o.DatumVytvoreni,
                    Stav = o.Stav,
                    Vydavatel = o.Vydavatel 
                })
                .ToList();
        }

        public void VytvoritObjednavku(ObjednavkaEntity objednavka)
        {
            // Vytvoření instance typu IS.Knihovna.Data.Objednavka
            var novaObjednavka = new IS.Knihovna.Data.Objednavka
            {
                DatumVytvoreni = DateTime.Now,
                Stav = "Nová",
                Vydavatel = objednavka.Vydavatel
                // Pokud je potřeba, doplňte další mapování vlastností
            };

            _context.Objednavky.Add(novaObjednavka);
            _context.SaveChanges();
        }

        public void ZmenitStav(int id, string novyStav)
        {
            var obj = _context.Objednavky.Find(id);
            if (obj != null)
            {
                obj.Stav = novyStav;
                // Pokud je vyřízeno, logicky bychom měli asi vytvořit i nový Titul v systému, 
                // ale to pro KB2 stačí řešit ručně nebo komentářem.
                _context.SaveChanges();
            }
        }
    }
}