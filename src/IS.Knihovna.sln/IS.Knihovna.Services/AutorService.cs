using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using IS.Knihovna.Data;
using IS.Knihovna.Domain.Entities;

namespace IS.Knihovna.Services
{
    public class AutorService
    {
        private readonly KnihovnaContext _context;

        public AutorService(KnihovnaContext context) => _context = context;

        // Přidání autora s kontrolou duplicity
        public void PridejAutora(Autor autor)
        {
            if (_context.Autori.Any(a => a.Jmeno == autor.Jmeno && a.Prijmeni == autor.Prijmeni))
                throw new Exception("Autor již existuje.");

            _context.Autori.Add(autor);
            _context.SaveChanges();
        }

        // Seznam všech autorů seřazený podle příjmení
        public List<Autor> GetVsechnyAutory() => _context.Autori.OrderBy(a => a.Prijmeni).ToList();

        // Aktualizace existujícího záznamu
        public void AktualizujAutora(Autor autor)
        {
            _context.Entry(autor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Smazání autora podle ID
        public void SmazAutora(int id)
        {
            var autor = _context.Autori.Find(id);
            if (autor != null)
            {
                _context.Autori.Remove(autor);
                _context.SaveChanges();
            }
        }
    }
}