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
        private ReaderService _service; // Odkaz na logiku pro práci se čtenáři

        public AddReaderForm()
        {
            InitializeComponent();
            _service = new ReaderService();

            // Nastavení výchozích hodnot v roletkách (aby políčka nebyla prázdná)
            comboGender.SelectedIndex = 0;
            comboEducation.SelectedIndex = 0;
        }

        // Tlačítko pro uložení nového čtenáře
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Základní kontrola: Jméno a příjmení nesmí zůstat prázdné
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Jméno a příjmení jsou povinné!");
                    return;
                }

                // Volání služby, která vytvoří záznam v databázi
                _service.AddReader(
                    txtFirstName.Text,   // Text z políčka Jméno
                    txtLastName.Text,    // Text z políčka Příjmení
                    txtEmail.Text,       // Text z políčka E-mail
                    dateBirth.Value,     // Vybrané datum z kalendáře
                    comboGender.Text,    // Vybrané pohlaví z roletky
                    comboEducation.Text  // Vybrané vzdělání z roletky
                );

                // Informace o úspěchu a zavření okna
                MessageBox.Show("Čtenář úspěšně zaregistrován!");
                this.Close();
            }
            catch (Exception ex)
            {
                // Pokud se něco pokazí (třeba chyba v DB), vypíše se hláška
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }
    }
}