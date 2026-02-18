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

namespace Library.UI
{
    public partial class AddReaderForm : Form
    {
        private ReaderService _service;

        public AddReaderForm()
        {
            InitializeComponent();
            _service = new ReaderService();

            // Předvybereme první hodnoty v roletkách, ať nejsou prázdné
            comboGender.SelectedIndex = 0;
            comboEducation.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Jméno a příjmení jsou povinné!");
                    return;
                }

                _service.AddReader(
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtEmail.Text,
                    dateBirth.Value,
                    comboGender.Text,
                    comboEducation.Text
                );

                MessageBox.Show("Čtenář úspěšně zaregistrován!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }
    }
}