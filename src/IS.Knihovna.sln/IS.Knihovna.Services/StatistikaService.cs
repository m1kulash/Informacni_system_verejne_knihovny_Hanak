using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Knihovna.Data;

namespace IS.Knihovna.Services
{
    public class StatistikaService
    {
        private readonly KnihovnaContext _context;

        public StatistikaService(KnihovnaContext context) => _context = context;

        // Počet výpůjček podle žánru
        public Dictionary<string, int> GetVypujckyDleZanru()
        {
            var data = _context.Vypujcky
                .Where(v => v.Stav == "Probíhá" || v.Stav == "Vráceno")
                .SelectMany(v => v.Exemplar.Titul.Zanry)
                .GroupBy(z => z.Nazev)
                .Select(g => new { Zanr = g.Key, Pocet = g.Count() })
                .ToDictionary(k => k.Zanr, v => v.Pocet);

            return data;
        }

        // Počet výpůjček podle věku čtenáře (věková struktura)
        public Dictionary<string, int> GetVypujckyDleVeku()
        {
            var dnes = DateTime.Today;
            var ctenariVypujcky = _context.Vypujcky
                .Include("Ctenar")
                .ToList();

            var skupiny = ctenariVypujcky
                .GroupBy(v => {
                    if (!v.Ctenar.DatumNarozeni.HasValue) return "Neznámý věk";
                    int vek = dnes.Year - v.Ctenar.DatumNarozeni.Value.Year;
                    if (v.Ctenar.DatumNarozeni.Value.Date > dnes.AddYears(-vek)) vek--;

                    if (vek < 15) return "Děti (0-14)";
                    if (vek < 26) return "Studenti (15-25)";
                    if (vek < 60) return "Dospělí (26-59)";
                    return "Senioři (60+)";
                })
                .ToDictionary(g => g.Key, g => g.Count());

            return skupiny;
        }
    }
}
