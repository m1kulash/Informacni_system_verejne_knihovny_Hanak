using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Knihovna.Domain.Entities
{
    public class Titul
    {
        public int TitulID { get; set; }
        public string Nazev { get; set; }
        public string ISBN { get; set; }
        public short? RokVydani { get; set; }
        public string Nosic { get; set; }
        public string StrucnyObsah { get; set; }
        public int VydavatelID { get; set; }

        public virtual Vydavatel Vydavatel { get; set; }
        public virtual ICollection<Exemplar> Exemplare { get; set; }
        public virtual ICollection<Autor> Autori { get; set; }
        public virtual ICollection<Zanr> Zanry { get; set; }
    }

    public class Autor
    {
        public int AutorID { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }

        public virtual ICollection<Titul> Tituly { get; set; }
    }

    public class Zanr
    {
        public int ZanrID { get; set; }
        public string Nazev { get; set; }

        public virtual ICollection<Titul> Tituly { get; set; }
    }

    public class Vydavatel
    {
        public int VydavatelID { get; set; }
        public string Nazev { get; set; }

        public virtual ICollection<Titul> Tituly { get; set; }
    }

    public class Exemplar
    {
        public int ExemplarID { get; set; }
        public int TitulID { get; set; }
        public string InventarniCislo { get; set; }
        public string Stav { get; set; }

        public virtual Titul Titul { get; set; }
    }

    public class Ctenar
    {
        public int CtenarID { get; set; }
        public string CisloPrukazky { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime? DatumNarozeni { get; set; }
        public string Pohlavi { get; set; }
        public string Vzdelani { get; set; }
        public bool Aktivni { get; set; } = true;

        public virtual ICollection<Vypujcka> Vypujcky { get; set; }
        public virtual ICollection<Rezervace> Rezervace { get; set; }
    }

    public class Vypujcka
    {
        public int VypujckaID { get; set; }
        public int ExemplarID { get; set; }
        public int CtenarID { get; set; }
        public DateTime DatumVypujceni { get; set; }
        public DateTime DatumVraceniPlan { get; set; }
        public DateTime? DatumVraceniSkut { get; set; }
        public string Stav { get; set; }

        public virtual Exemplar Exemplar { get; set; }
        public virtual Ctenar Ctenar { get; set; }
        public virtual Upominka Upominka { get; set; }
    }

    public class Rezervace
    {
        public int RezervaceID { get; set; }
        public int TitulID { get; set; }
        public int CtenarID { get; set; }
        public DateTime DatumVytvoreni { get; set; }
        public int Poradi { get; set; }
        public string Stav { get; set; }
        public DateTime? ExpiraceVydeje { get; set; }

        public virtual Titul Titul { get; set; }
        public virtual Ctenar Ctenar { get; set; }
    }

    public class Upominka
    {
        public int UpominkaID { get; set; }
        public int VypujckaID { get; set; }
        public decimal Castka { get; set; }
        public string Duvod { get; set; }
        public DateTime DatumVystaveni { get; set; }
        public bool Uhradeno { get; set; }

        public virtual Vypujcka Vypujcka { get; set; }
        public virtual ICollection<Platba> Platby { get; set; }
    }

    public class Platba
    {
        public int PlatbaID { get; set; }
        public int UpominkaID { get; set; }
        public DateTime DatumPlatby { get; set; }
        public decimal Castka { get; set; }
        public string Zpusob { get; set; }

        public virtual Upominka Upominka { get; set; }
    }
}
