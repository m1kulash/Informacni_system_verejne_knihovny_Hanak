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
        private BookService _service; // Odkaz na logiku pro práci s knihami

        public AddBookForm()
        {
            InitializeComponent();
            _service = new BookService();

            // Nastavení výběrových polí (ComboBoxů) tak, aby do nich šlo i volně psát
            comboAuthor.DropDownStyle = ComboBoxStyle.DropDown;
            comboGenre.DropDownStyle = ComboBoxStyle.DropDown;
            comboPublisher.DropDownStyle = ComboBoxStyle.DropDown;

            LoadDataForComboBoxes(); // Načtení existujících dat při startu okna
        }

        // Naplnění výběrových polí daty z databáze (Autoři, Žánry, Vydavatelé)
        private void LoadDataForComboBoxes()
        {
            // Nastavení zdroje dat pro Autora + zapnutí našeptávání (Autocomplete)
            comboAuthor.DataSource = _service.GetAuthors();
            comboAuthor.DisplayMember = "FullName"; // Co uživatel uvidí
            comboAuthor.ValueMember = "Id";         // Skrytý klíč pro databázi
            comboAuthor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAuthor.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Nastavení pro Žánr
            comboGenre.DataSource = _service.GetGenres();
            comboGenre.DisplayMember = "Name";
            comboGenre.ValueMember = "Id";
            comboGenre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboGenre.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Nastavení pro Vydavatele
            comboPublisher.DataSource = _service.GetPublishers();
            comboPublisher.DisplayMember = "Name";
            comboPublisher.ValueMember = "Id";
            comboPublisher.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPublisher.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // Logika pro uložení nové knihy po kliknutí na tlačítko
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Základní kontrola (validace), zda uživatel nezapomněl na název
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Vyplň název knihy!");
                    return;
                }

                // Získání textu z ComboBoxů (může to být vybraný prvek nebo nově napsaný text)
                string authorName = comboAuthor.Text;
                string genreName = comboGenre.Text;
                string publisherName = comboPublisher.Text;

                // Kontrola povinných polí
                if (string.IsNullOrWhiteSpace(authorName) || string.IsNullOrWhiteSpace(genreName))
                {
                    MessageBox.Show("Vyplň autora a žánr!");
                    return;
                }

                // Volání "chytré" metody, která si sama poradí s vytvořením autora/žánru, pokud neexistují
                _service.AddBookSmart(
                    txtTitle.Text,
                    (int)numYear.Value, // Hodnota z numerického pole pro rok
                    txtDescription.Text,
                    authorName,
                    genreName,
                    publisherName
                );

                MessageBox.Show("Kniha úspěšně přidána!");
                this.Close(); // Zavření okna po úspěšném uložení
            }
            catch (Exception ex)
            {
                // Zachycení a zobrazení chyby v případě problému s databází
                MessageBox.Show("Chyba při ukládání: " + ex.Message);
            }
        }
    }
}