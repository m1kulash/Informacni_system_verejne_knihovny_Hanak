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
        private BookService _service;

        public AddBookForm()
        {
            InitializeComponent();
            _service = new BookService();

            // --- KROK 1: OPRAVA CHYBY ---
            // Nejdříve musíme povolit psaní do roletky (DropDown)
            // Pokud bychom to neudělali a nastavili AutoCompleteMode, vyhodí to chybu.
            comboAuthor.DropDownStyle = ComboBoxStyle.DropDown;
            comboGenre.DropDownStyle = ComboBoxStyle.DropDown;
            comboPublisher.DropDownStyle = ComboBoxStyle.DropDown;

            // --- KROK 2: Až teď načteme data a zapneme našeptávání ---
            LoadDataForComboBoxes();
        }

        private void LoadDataForComboBoxes()
        {
            // Autor
            comboAuthor.DataSource = _service.GetAuthors();
            comboAuthor.DisplayMember = "FullName";
            comboAuthor.ValueMember = "Id";
            comboAuthor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAuthor.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Žánr
            comboGenre.DataSource = _service.GetGenres();
            comboGenre.DisplayMember = "Name";
            comboGenre.ValueMember = "Id";
            comboGenre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboGenre.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Vydavatel
            comboPublisher.DataSource = _service.GetPublishers();
            comboPublisher.DisplayMember = "Name";
            comboPublisher.ValueMember = "Id";
            comboPublisher.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPublisher.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validace názvu
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Vyplň název knihy!");
                    return;
                }

                // Získáme texty přímo z roletek (to, co uživatel napsal nebo vybral)
                string authorName = comboAuthor.Text;
                string genreName = comboGenre.Text;
                string publisherName = comboPublisher.Text;

                // Kontrola, zda je něco vyplněno
                if (string.IsNullOrWhiteSpace(authorName) || string.IsNullOrWhiteSpace(genreName))
                {
                    MessageBox.Show("Vyplň autora a žánr!");
                    return;
                }

                // Zavoláme chytrou metodu pro uložení (která případně vytvoří nového autora)
                _service.AddBookSmart(
                    txtTitle.Text,
                    (int)numYear.Value,
                    txtDescription.Text,
                    authorName,
                    genreName,
                    publisherName
                );

                MessageBox.Show("Kniha úspěšně přidána!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při ukládání: " + ex.Message);
            }
        }
    }
}