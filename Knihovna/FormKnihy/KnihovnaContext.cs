using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FormKnihy.Models;

namespace FormKnihy
{
    internal class KnihovnaContext : DbContext
    {
        public KnihovnaContext() : base("name=KnihovnaDB")
        {
        }

        // Definice tabulek
        public DbSet<Kniha> Knihy { get; set; }
        public DbSet<Ctenar> Ctenari { get; set; }
    }
}
