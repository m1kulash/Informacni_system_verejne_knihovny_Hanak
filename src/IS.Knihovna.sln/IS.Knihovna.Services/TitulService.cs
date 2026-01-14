using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using IS.Knihovna.Data;
using IS.Knihovna.Domain.Entities;

namespace IS.Knihovna.Services
{
    public class TitulService
    {
        private readonly KnihovnaContext _context;

        public TitulService(KnihovnaContext context) => _context = context;

        // Načte všechny tituly i s jejich autory a žánry pro zobrazení v seznamu
        public List<Titul> GetVsechnyTituly()
        {
            return _context.Tituly
                .Include(t => t.Autori)
                .Include(t => t.Zanry)
                .Include(t => t.Vydavatel)
                .OrderBy(t => t.Nazev)
                .ToList();
        }

        // Uloží nový nebo aktualizuje stávající titul
        public void UlozTitul(Titul titul, List<int> autorIds, List<int> zanrIds)
        {
            if (titul.TitulID == 0)
            {
                // Nový titul: Přidáme vazby na vybrané autory a žánry
                titul.Autori = _context.Autori.Where(a => autorIds.Contains(a.AutorID)).ToList();
                titul.Zanry = _context.Zanry.Where(z => zanrIds.Contains(z.ZanrID)).ToList();
                _context.Tituly.Add(titul);
            }
            else
            {
                // Aktualizace: Musíme načíst původní verzi z DB včetně vazeb
                var existujiciTitul = _context.Tituly
                    .Include(t => t.Autori)
                    .Include(t => t.Zanry)
                    .FirstOrDefault(t => t.TitulID == titul.TitulID);

                if (existujiciTitul != null)
                {
                    // Aktualizace základních polí
                    _context.Entry(existujiciTitul).CurrentValues.SetValues(titul);

                    // Aktualizace autorů (vymazat staré, přidat nové)
                    existujiciTitul.Autori.Clear();
                    var noviAutori = _context.Autori.Where(a => autorIds.Contains(a.AutorID)).ToList();
                    foreach (var autor in noviAutori) existujiciTitul.Autori.Add(autor);

                    // Aktualizace žánrů
                    existujiciTitul.Zanry.Clear();
                    var noveZanry = _context.Zanry.Where(z => zanrIds.Contains(z.ZanrID)).ToList();
                    foreach (var zanr in noveZanry) existujiciTitul.Zanry.Add(zanr);
                }
            }
            _context.SaveChanges(); // Uložení všech změn
        }

        // Vyhledávání podle názvu nebo ISBN (požadavek ze zadání)
        public List<Titul> HledejTituly(string text)
        {
            return _context.Tituly
                .Include(t => t.Autori)
                .Where(t => t.Nazev.Contains(text) || t.ISBN.Contains(text))
                .ToList();
        }

        public List<Titul> FiltrujTituly(string nazev, string autor, string zanr, int? rokOd, int? rokDo)
        {
            var query = _context.Tituly
                .Include(t => t.Autori)
                .Include(t => t.Zanry)
                .Include(t => t.Vydavatel)
                .AsQueryable();

            if (!string.IsNullOrEmpty(nazev))
                query = query.Where(t => t.Nazev.Contains(nazev) || t.ISBN.Contains(nazev));

            if (!string.IsNullOrEmpty(autor))
                query = query.Where(t => t.Autori.Any(a => a.Prijmeni.Contains(autor) || a.Jmeno.Contains(autor)));

            if (!string.IsNullOrEmpty(zanr))
                query = query.Where(t => t.Zanry.Any(z => z.Nazev.Contains(zanr)));

            if (rokOd.HasValue)
                query = query.Where(t => t.RokVydani >= rokOd.Value);

            if (rokDo.HasValue)
                query = query.Where(t => t.RokVydani <= rokDo.Value);

            return query.ToList();
        }

        // Metoda pro vyřazení titulu (prodej)
        public void VyraditExemplar(int exemplarId, bool prodejCtenari, decimal cena)
        {
            var exemplar = _context.Exemplare.Find(exemplarId);
            if (exemplar != null)
            {
                exemplar.Stav = prodejCtenari ? "Prodáno" : "Vyřazeno";
                // Pokud je to prodej, můžeme rovnou vytvořit záznam o platbě, 
                // ale pro jednoduchost stačí změna stavu.
                _context.SaveChanges();
            }
        }
    }
}