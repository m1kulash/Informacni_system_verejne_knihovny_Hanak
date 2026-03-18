using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Library.Data.Entities;

namespace Library.Data
{
    // Hlavní třída, která ovládá celou databázi
    public class LibraryContext : DbContext
    {
        // Seznamy (tabulky), které se vytvoří v SQL databázi
        public DbSet<Book> Books { get; set; }           // Tabulka knih
        public DbSet<Author> Authors { get; set; }       // Tabulka autorů
        public DbSet<Genre> Genres { get; set; }         // Tabulka žánrů
        public DbSet<Publisher> Publishers { get; set; } // Tabulka vydavatelů
        public DbSet<Reader> Readers { get; set; }       // Tabulka čtenářů
        public DbSet<Loan> Loans { get; set; }           // Tabulka výpůjček

        //Tabulka pro frontu na vypůjčené knihy
        public DbSet<Reservation> Reservations { get; set; }

        // Nastavení připojení k databázi
        public LibraryContext() : base("name=LibraryConnection")
        {
            // Vypnutí automatického načítání (pro vyšší rychlost programu)
            this.Configuration.LazyLoadingEnabled = false;

            // Pravidlo: Pokud změním v kódu sloupce, databáze se sama aktualizuje
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryContext>());
        }
    }
}