using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class Reader
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; } // Pro upomínky

        public DateTime DateOfBirth { get; set; } // Věk se dopočítá

        public string Gender { get; set; } // Muž / Žena

        public string EducationLevel { get; set; } // ZŠ, SŠ, VŠ...

        public virtual ICollection<Loan> Loans { get; set; }
    }
}