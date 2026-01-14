using IS.Knihovna.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Knihovna.Data
{
    public class KnihovnaContext : DbContext
    {
        // Konstruktor - určuje, který connection string se použije z App.config
        public KnihovnaContext() : base("name=KnihovnaDb")
        {
        }

        // DbSety - představují tabulky v databázi
        public DbSet<Titul> Tituly { get; set; }
        public DbSet<Autor> Autori { get; set; }
        public DbSet<Zanr> Zanry { get; set; }
        public DbSet<Vydavatel> Vydavatele { get; set; }
        public DbSet<Exemplar> Exemplare { get; set; }
        public DbSet<Ctenar> Ctenari { get; set; }
        public DbSet<Vypujcka> Vypujcky { get; set; }
        public DbSet<Rezervace> Rezervace { get; set; }
        public DbSet<Upominka> Upominky { get; set; }
        public DbSet<Platba> Platby { get; set; }

        // Konfigurace vztahů mezi entitami
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Titul <-> Autor (N:N)
            modelBuilder.Entity<Titul>()
                .HasMany(t => t.Autori)
                .WithMany(a => a.Tituly)
                .Map(m =>
                {
                    m.ToTable("TitulAutor");
                    m.MapLeftKey("TitulID");
                    m.MapRightKey("AutorID");
                });

            // Titul <-> Žánr (N:N)
            modelBuilder.Entity<Titul>()
                .HasMany(t => t.Zanry)
                .WithMany(z => z.Tituly)
                .Map(m =>
                {
                    m.ToTable("TitulZanr");
                    m.MapLeftKey("TitulID");
                    m.MapRightKey("ZanrID");
                });

            // Výpůjčka 1 <-> 0..1 Upomínka (řešení EF chyby)
            modelBuilder.Entity<Vypujcka>()
                .HasOptional(v => v.Upominka)
                .WithRequired(u => u.Vypujcka);

            base.OnModelCreating(modelBuilder);
        }
    }
}
