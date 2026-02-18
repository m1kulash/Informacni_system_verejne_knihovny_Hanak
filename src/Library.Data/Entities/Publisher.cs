using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return Name; // Vypiš název vydavatele
        }
    }
}