using System;
using System.Collections.Generic;
using System.Linq;
using IS.Knihovna.Data;
using IS.Knihovna.Domain.Entities;

namespace IS.Knihovna.Services
{
    public class ExemplarService
    {
        private readonly KnihovnaContext _context;

        public ExemplarService(KnihovnaContext context) => _context = context;

        // Přidá nový fyzický kus knihy do evidence
        public void PridejExemplar(Exemplar exemplar)
        {
            // Každý kus musí mít unikátní inventární číslo
            if (_context.Exemplare.Any(e => e.InventarniCislo == exemplar.InventarniCislo))
                throw new Exception("Inventární číslo již existuje.");

            _context.Exemplare.Add(exemplar);
            _context.SaveChanges();
        }

        // Získá všechny kusy pro konkrétní knihu (titul)
        public List<Exemplar> GetExemplareProTitul(int titulId)
        {
            return _context.Exemplare
                .Where(e => e.TitulID == titulId)
                .ToList();
        }
    }
}