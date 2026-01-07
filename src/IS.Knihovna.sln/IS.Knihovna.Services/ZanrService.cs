using System;
using System.Collections.Generic;
using System.Linq;
using IS.Knihovna.Data;
using IS.Knihovna.Domain.Entities;

namespace IS.Knihovna.Services
{
    public class ZanrService
    {
        private readonly KnihovnaContext _context;

        public ZanrService(KnihovnaContext context) => _context = context;

        // Přidá nový žánr, pokud už v databázi neexistuje
        public void PridejZanr(Zanr zanr)
        {
            if (_context.Zanry.Any(z => z.Nazev == zanr.Nazev))
                throw new Exception("Žánr již existuje.");

            _context.Zanry.Add(zanr);
            _context.SaveChanges();
        }

        // Vrátí seznam všech žánrů seřazený podle názvu
        public List<Zanr> GetVsechnyZanry() => _context.Zanry.OrderBy(z => z.Nazev).ToList();
    }
}