using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Description { get; set; } // Stručný obsah

        public string MediaType { get; set; } // Nosič: Kniha, CD, DVD...

        // --- A. VYŘAZENÍ A ODKUP ---
        public bool IsDeleted { get; set; } // "Vyřazeno" - true/false
        public decimal? SalePrice { get; set; } // Cena pro odkoupení zaregistrovaným čtenářem

        // --- B. MEZIKNIHOVNÍ VÝPŮJČKA (NOVÉ) ---
        public bool IsInterlibrary { get; set; } // true = titul zapůjčený od jiné knihovny
        public decimal? InterlibraryFee { get; set; } // Poplatek za meziknihovní výpůjčku (např. 50 Kč)

        // --- VAZBY (Cizí klíče) ---

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }

        // --- KOLEKCE (vztah 1:N) ---
        public virtual ICollection<Loan> Loans { get; set; }

        // Vazba na frontu čtenářů
        public virtual ICollection<Reservation> Reservations { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}