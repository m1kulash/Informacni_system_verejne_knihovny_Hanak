using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        // --- Kdo si knihu rezervuje ---
        public int ReaderId { get; set; }

        [ForeignKey("ReaderId")]
        public virtual Reader Reader { get; set; }


        // --- O jakou knihu jde ---
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }


        // --- Kdy se čtenář zařadil do fronty ---
        public DateTime ReservationDate { get; set; }
    }
}