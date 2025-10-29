- **UI (WinForms)**: formuláře, validace vstupu, zobrazení chyb.  
- **Business logika**: pravidla (výpočet termínu, poplatků, rezervace FIFO, blokace při dluhu).  
- **Datová vrstva (EF6)**: DbContext, mapování entit, migrace.  
- **Doménové modely (POCO)**: Titul, Autor, Žánr, Vydavatel, Exemplář, Čtenář, Výpůjčka, Rezervace, Upomínka, Platba.  

Použité technologie: .NET Framework 4.8, WinForms, Entity Framework 6.4, SQL Server Express LocalDB.

---

# Doménové modely (návrhové třídy)
```csharp
public class Titul {
    public int TitulID { get; set; }
    public string Nazev { get; set; }
    public string ISBN { get; set; }
    public short? RokVydani { get; set; }
    public string Nosic { get; set; }
    public string StrucnyObsah { get; set; }
    public int VydavatelID { get; set; }
}

public class Ctenar {
    public int CtenarID { get; set; }
    public string CisloPrukazky { get; set; }
    public string Jmeno { get; set; }
    public string Prijmeni { get; set; }
    public DateTime? DatumNarozeni { get; set; }
    public string Pohlavi { get; set; }
    public string Vzdelani { get; set; }
    public bool Aktivni { get; set; }
}
