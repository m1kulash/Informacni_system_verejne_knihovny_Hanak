using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using IS.Knihovna.Data;
using IS.Knihovna.Domain.Entities;

namespace IS.Knihovna.Services
{
    public class CtenarService
    {
        private readonly KnihovnaContext _context;

        public CtenarService(KnihovnaContext context) => _context = context;

        // Načte seznam všech čtenářů seřazený podle příjmení
        public List<Ctenar> GetVsechnyCtenare()
        {
            return _context.Ctenari.OrderBy(c => c.Prijmeni).ToList();
        }

        // Registruje nového čtenáře a kontroluje unikátnost čísla průkazky
        public void RegistrujCtenare(Ctenar ctenar)
        {
            // Kontrola, zda již v systému není čtenář se stejným číslem průkazky
            if (_context.Ctenari.Any(c => c.CisloPrukazky == ctenar.CisloPrukazky))
                throw new Exception("Čtenář s tímto číslem průkazky již existuje.");

            _context.Ctenari.Add(ctenar);
            _context.SaveChanges();
        }

        // Aktualizuje údaje stávajícího čtenáře (věk, vzdělání, pohlaví atd.)
        public void AktualizujCtenare(Ctenar ctenar)
        {
            _context.Entry(ctenar).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Vyhledá čtenáře podle jména, příjmení nebo čísla průkazky
        public List<Ctenar> HledejCtenare(string text)
        {
            return _context.Ctenari
                .Where(c => c.Jmeno.Contains(text) ||
                            c.Prijmeni.Contains(text) ||
                            c.CisloPrukazky.Contains(text))
                .ToList();
        }

        // Provede "měkké" smazání - čtenáře pouze deaktivuje, aby zůstala zachována historie výpůjček
        public void DeaktivujCtenare(int ctenarId)
        {
            var ctenar = _context.Ctenari.Find(ctenarId);
            if (ctenar != null)
            {
                ctenar.Aktivni = false; // Nastavení příznaku Aktivni na false
                _context.SaveChanges();
            }
        }
    }
}