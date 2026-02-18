using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class Loan
    {
        public int Id { get; set; }

        public DateTime LoanDate { get; set; } // Kdy si půjčil

        public DateTime DueDate { get; set; } // Kdy má vrátit

        public DateTime? ReturnDate { get; set; } // Kdy vrátil (pokud null, stále má půjčeno)

        public decimal FineAmount { get; set; } // Pokuta za zpoždění

        // --- VAZBY ---

        public int ReaderId { get; set; }
        [ForeignKey("ReaderId")]
        public virtual Reader Reader { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}