using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Knihovna.UI.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        // 🟦 Pomocná metoda pro načtení formuláře do panelu
        private void OtevriFormular(Form formular)
        {
            
            // Vyčistí panelObsah před otevřením nového formuláře
            panelObsah.Controls.Clear();

            // Nastaví formulář jako vnořený do panelu
            formular.TopLevel = false;
            formular.FormBorderStyle = FormBorderStyle.None;
            formular.Dock = DockStyle.Fill;

            // Přidá do panelu a zobrazí
            panelObsah.Controls.Add(formular);
            formular.Show();
            MessageBox.Show("Otevírám formulář: " + formular.Name);
        }

        // 🟩 Tlačítka – otevření jednotlivých formulářů
        private void btnKnihy_Click(object sender, EventArgs e)
        {
            OtevriFormular(new TitulForm());
        }

        private void btnCtenari_Click(object sender, EventArgs e)
        {
            OtevriFormular(new CtenarForm());
        }

        private void btnVypujcky_Click(object sender, EventArgs e)
        {
            OtevriFormular(new VypujckyForm());
        }

        private void btnRezervace_Click(object sender, EventArgs e)
        {
            OtevriFormular(new RezervaceForm());
        }

        private void btnUpominky_Click(object sender, EventArgs e)
        {
            OtevriFormular(new UpominkyForm());
        }

        private void btnStatistiky_Click(object sender, EventArgs e)
        {
            OtevriFormular(new StatistikyForm());
        }

        private void btnOdhlasit_Click(object sender, EventArgs e)
        {
            // Vrátí uživatele na LoginForm
            this.Close();
        }
    }
}
