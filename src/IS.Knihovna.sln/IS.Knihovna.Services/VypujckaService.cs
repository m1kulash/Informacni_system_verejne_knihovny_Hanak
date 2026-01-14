using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using IS.Knihovna.Data;
using IS.Knihovna.Domain.Entities;

namespace IS.Knihovna.Services
{
    public class VypujckaService
    {
        private readonly KnihovnaContext _context;

        public VypujckaService(KnihovnaContext context) => _context = context;

        // Metoda pro vytvoření nové výpůjčky
        public void PujcitKnihu(int ctenarId, int exemplarId)
        {
            // Kontrola, zda je čtenář aktivní
            var ctenar = _context.Ctenari.Find(ctenarId);
            if (ctenar == null || !ctenar.Aktivni)
                throw new Exception("Čtenář není aktivní nebo neexistuje.");

            // Kontrola, zda je exemplář volný
            var exemplar = _context.Exemplare.Find(exemplarId);
            if (exemplar == null || exemplar.Stav != "Dostupný")
                throw new Exception("Kniha není k dispozici.");

            // Vytvoření záznamu o výpůjčce
            var vypujcka = new Vypujcka
            {
                CtenarID = ctenarId,
                ExemplarID = exemplarId,
                DatumVypujceni = DateTime.Now,
                DatumVraceniPlan = DateTime.Now.AddDays(30), // Výpočet termínu (standardně 30 dní)
                Stav = "Probíhá"
            };

            // Změna stavu knihy na "Půjčeno"
            exemplar.Stav = "Půjčeno";

            _context.Vypujcky.Add(vypujcka);
            _context.SaveChanges();
        }

        // Metoda pro vrácení knihy a případný výpočet upomínky
        public void VratitKnihu(int vypujckaId)
        {
            var vypujcka = _context.Vypujcky.Include(v => v.Exemplar).FirstOrDefault(v => v.VypujckaID == vypujckaId);
            if (vypujcka == null) return;

            vypujcka.DatumVraceniSkut = DateTime.Now; // Skutečné datum vrácení
            vypujcka.Stav = "Vráceno";
            vypujcka.Exemplar.Stav = "Dostupný";

            // Logika pro automatické vyhotovení upomínky při zpoždění
            if (vypujcka.DatumVraceniSkut > vypujcka.DatumVraceniPlan)
            {
                TimeSpan zpozdeni = vypujcka.DatumVraceniSkut.Value - vypujcka.DatumVraceniPlan;
                decimal pokuta = (decimal)zpozdeni.TotalDays * 5; // Poplatek 5 Kč za každý den zpoždění

                var upominka = new Upominka
                {
                    VypujckaID = vypujcka.VypujckaID,
                    Castka = pokuta,
                    Duvod = "Opožděné vrácení",
                    DatumVystaveni = DateTime.Now,
                    Uhradeno = false
                };
                _context.Upominky.Add(upominka);
            }

            _context.SaveChanges();
        }

        // Seznam aktuálně zapůjčených knih (pro přehledy)
        public List<Vypujcka> GetAktualniVypujcky()
        {
            return _context.Vypujcky
                .Include(v => v.Ctenar)
                .Include(v => v.Exemplar.Titul)
                .Where(v => v.Stav == "Probíhá")
                .ToList();
        }
    }
}