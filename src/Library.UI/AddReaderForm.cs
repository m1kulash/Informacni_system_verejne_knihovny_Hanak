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
    public partial class AddReaderForm : Form
    {
        private ReaderService _service; // Odkaz na logickou vrstvu pro správu čtenářů

        public AddReaderForm()
        {
            InitializeComponent();
            _service = new ReaderService();

            // NASTAVENÍ UX: Předvolíme první položky v roletkách (ComboBoxech)
            // Tím zajistíme, že uživatel nemusí nic vybírat, pokud mu vyhovuje výchozí volba
            if (comboGender.Items.Count > 0) comboGender.SelectedIndex = 0;
            if (comboEducation.Items.Count > 0) comboEducation.SelectedIndex = 0;
        }

        // Metoda obsluhující tlačítko pro uložení dat
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACE: Kontrola, zda jsou vyplněna klíčová pole (Jméno a Příjmení)
                // Používáme IsNullOrWhiteSpace pro zachycení prázdných řetězců i pouhých mezer
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Jméno a příjmení jsou povinné údaje!", "Chyba validace", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // VOLÁNÍ BUSINESS VRSTVY: Předáváme sesbíraná data ze všech prvků formuláře
                _service.AddReader(
                    txtFirstName.Text.Trim(), // .Trim() odstraní nechtěné mezery na začátku/konci
                    txtLastName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    dateBirth.Value,          // Hodnota z kalendáře (DateTimePicker)
                    comboGender.Text,         // Vybraný text z roletky pohlaví
                    comboEducation.Text       // Vybraný text z roletky vzdělání
                );

                // Zpětná vazba uživateli
                MessageBox.Show("Registrace čtenáře proběhla úspěšně.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // Automatické zavření okna po úspěšné operaci
            }
            catch (Exception ex)
            {
                // Zachycení chyb (např. unikátní e-mail, pokud by to databáze vyžadovala)
                MessageBox.Show("Nastala chyba při registraci: " + ex.Message, "Chyba systému", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}