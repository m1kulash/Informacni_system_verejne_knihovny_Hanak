using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Business;
using Library.Data.Entities;

namespace Library.UI
{
    public partial class AddBookForm : Form
    {
        private BookService _service; // Reference na business logiku

        public AddBookForm()
        {
            InitializeComponent();
            _service = new BookService();

            // NASTAVENÍ UX: ComboBoxy přepneme na DropDown, aby do nich šlo i volně psát
            // To je klíčové pro naši "SmartAdd" logiku, která umí vytvořit nového autora za běhu
            comboAuthor.DropDownStyle = ComboBoxStyle.DropDown;
            comboGenre.DropDownStyle = ComboBoxStyle.DropDown;
            comboPublisher.DropDownStyle = ComboBoxStyle.DropDown;

            LoadDataForComboBoxes(); // Načtení existujících dat z DB do nabídek
        }

        // Metoda pro naplnění našeptávačů (Autoři, Žánry, Vydavatelé)
        private void LoadDataForComboBoxes()
        {
            // Nastavení Autora + aktivace našeptávání (Autocomplete)
            // Uživatel začne psát "Čap..." a systém mu sám nabídne Karla Čapka
            comboAuthor.DataSource = _service.GetAuthors();
            comboAuthor.DisplayMember = "FullName";
            comboAuthor.ValueMember = "Id";
            comboAuthor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAuthor.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Stejné nastavení pro Žánr
            comboGenre.DataSource = _service.GetGenres();
            comboGenre.DisplayMember = "Name";
            comboGenre.ValueMember = "Id";
            comboGenre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboGenre.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Stejné nastavení pro Vydavatele
            comboPublisher.DataSource = _service.GetPublishers();
            comboPublisher.DisplayMember = "Name";
            comboPublisher.ValueMember = "Id";
            comboPublisher.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPublisher.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // Obsluha tlačítka pro uložení
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACE: Kontrola povinných polí na straně klienta (UI)
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Chybí název knihy!", "Validace", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Získání textu přímo z ComboBoxů (ignorujeme ID, zajímá nás text, který tam je napsaný)
                string authorName = comboAuthor.Text;
                string genreName = comboGenre.Text;
                string publisherName = comboPublisher.Text;

                if (string.IsNullOrWhiteSpace(authorName) || string.IsNullOrWhiteSpace(genreName))
                {
                    MessageBox.Show("Autor a žánr musí být vyplněni!", "Validace", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // VOLÁNÍ BUSINESS LOGIKY: Předáváme data "chytré" metodě AddBookSmart
                // Ta se postará o to, aby nevznikali duplicitní autoři v databázi
                _service.AddBookSmart(
                    txtTitle.Text,
                    (int)numYear.Value,
                    txtDescription.Text,
                    authorName,
                    genreName,
                    publisherName
                );

                MessageBox.Show("Kniha byla úspěšně uložena do fondu.", "Úspěch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Po uložení okno zavřeme a vrátíme se do hlavního přehledu
            }
            catch (Exception ex)
            {
                // Globální ošetření chyb (např. výpadek spojení s DB)
                MessageBox.Show("Nastala neočekávaná chyba: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}