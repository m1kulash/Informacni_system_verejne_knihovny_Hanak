using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormKnihy.Models
{
    internal class Kniha
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nazev { get; set; }
        public string Autor { get; set; }
        public string Zanr { get; set; }
        public string Vydavatel { get; set; }
        public int RokVydani { get; set; }
        public string Nosic { get; set; }
        public string Obsah { get; set; }
        public bool JeVyrazena { get; set; } = false;
    }
}
