using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Např. Detektivka, Sci-fi

        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return Name; // Vypiš prostě název žánru
        }
    }
}