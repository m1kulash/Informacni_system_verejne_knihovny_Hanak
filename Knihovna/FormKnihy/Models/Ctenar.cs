using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormKnihy.Models
{
    internal class Ctenar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Jmeno { get; set; }
        [Required]
        public string Prijmeni { get; set; }
        public DateTime DatumNarozeni { get; set; }
        public string Pohlavi { get; set; }
        public string Vzdelani { get; set; }
        public string Email { get; set; }
    }
}
