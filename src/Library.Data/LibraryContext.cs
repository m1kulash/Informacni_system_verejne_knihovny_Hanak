using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Library.Data.Entities;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}