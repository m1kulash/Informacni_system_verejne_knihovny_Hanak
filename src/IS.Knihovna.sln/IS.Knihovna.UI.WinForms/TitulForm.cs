using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Důležité: Přidání odkazů na naše vrstvy
using IS.Knihovna.Data;
using IS.Knihovna.Domain.Entities;
using IS.Knihovna.Services;

namespace IS.Knihovna.UI.WinForms
{
    public partial class TitulForm : Form
    {
        // Reference na službu pro práci s knihami
        private readonly TitulService _titulService;

        public TitulForm()
        {
            InitializeComponent();

            // Inicializace databázového kontextu a služby
            var context = new KnihovnaContext();
            _titulService = new TitulService(context);

            // Nastavení sloupců tabulky (pokud nejsou nastaveny v Designeru)
            // Doporučuji ale sloupce nastavit přímo v Designeru pro lepší kontrolu
            dgvTituly.AutoGenerateColumns = false;

            // Načtení dat při spuštění formuláře
            NactiTituly();
        }

        // Metoda pro načtení a zobrazení dat
        private void NactiTituly()
        {
            try
            {
                var tituly = _titulService.GetVsechnyTituly();

                // Upravíme data pro zobrazení (např. seznam autorů převedeme na jeden text)
                var dataProTabulku = tituly.Select(t => new
                {
                    t.TitulID,
                    t.Nazev,
                    t.ISBN,
                    t.RokVydani,
                    t.Nosic,
                    // Spojíme jména všech autorů do jednoho řetězce odděleného čárkou
                    Autor = string.Join(", ", t.Autori.Select(a => $"{a.Prijmeni} {a.Jmeno}")),
                    // Totéž pro žánry
                    Zanr = string.Join(", ", t.Zanry.Select(z => z.Nazev)),
                    // Zobrazíme název vydavatele (ošetření null)
                    Vydavatel = t.Vydavatel?.Nazev ?? "",
                    PocetExemplaru = t.Exemplare.Count
                }).ToList();

                dgvTituly.DataSource = null;
                dgvTituly.DataSource = dataProTabulku;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání titulů: " + ex.Message);
            }
        }

        private void btnPridat_Click(object sender, EventArgs e)
        {
            // Zde budeme volat dialogové okno pro přidání (vytvoříme v dalším kroku)
            // Příklad:
            // var editForm = new TitulEditForm();
            // if (editForm.ShowDialog() == DialogResult.OK) NactiTituly();

            MessageBox.Show("Funkce pro přidání knihy bude aktivní, až vytvoříme editovací okno (TitulEditForm).", "Info");
        }

        private void btnUpravit_Click(object sender, EventArgs e)
        {
            if (dgvTituly.SelectedRows.Count > 0)
            {
                // int id = (int)dgvTituly.SelectedRows[0].Cells["TitulID"].Value;
                // Otevření editace pro dané ID...
                MessageBox.Show("Funkce úpravy bude aktivní, až vytvoříme editovací okno.", "Info");
            }
            else
            {
                MessageBox.Show("Vyberte knihu k úpravě.");
            }
        }

        private void btnSmazat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mazání titulů vyžaduje kontrolu, zda nejsou půjčené (implementujeme později).");
        }

        private void btnVyhledat_Click(object sender, EventArgs e)
        {
            try
            {
                // Předpokládám, že na formuláři je TextBox jménem txtVyhledat
                // string dotaz = txtVyhledat.Text;
                // var vysledky = _titulService.HledejTituly(dotaz);
                // ... aktualizace DataSource ...
                MessageBox.Show("Vyhledávání připravíme po dokončení základního seznamu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }

        private void btnObnovit_Click(object sender, EventArgs e)
        {
            // Tlačítko Obnovit nyní skutečně funguje
            NactiTituly();
        }
    }
}