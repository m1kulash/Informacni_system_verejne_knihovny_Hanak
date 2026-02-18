using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        // Celé jméno
        public string FullName => $"{FirstName} {LastName}";

        // Vazba: Jeden autor má napsaných více knih
        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}