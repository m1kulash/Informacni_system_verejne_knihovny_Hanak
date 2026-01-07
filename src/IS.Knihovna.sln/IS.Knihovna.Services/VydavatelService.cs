using System;
using System.Collections.Generic;
using System.Linq;
using IS.Knihovna.Data;
using IS.Knihovna.Domain.Entities;

namespace IS.Knihovna.Services
{
    public class VydavatelService
    {
        private readonly KnihovnaContext _context;

        public VydavatelService(KnihovnaContext context) => _context = context;

        // Přidá nového vydavatele, pokud má unikátní název
        public void PridejVydavatele(Vydavatel vydavatel)
        {
            if (_context.Vydavatele.Any(v => v.Nazev == vydavatel.Nazev))
                throw new Exception("Vydavatel již existuje.");

            _context.Vydavatele.Add(vydavatel);
            _context.SaveChanges();
        }

        // Vrátí seznam všech vydavatelů seřazený podle názvu
        public List<Vydavatel> GetVsechnyVydavatele() => _context.Vydavatele.OrderBy(v => v.Nazev).ToList();
    }
}