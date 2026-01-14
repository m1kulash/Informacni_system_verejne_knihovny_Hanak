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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnPrihlasit_Click(object sender, EventArgs e)
        {
            string uzivatel = txtUzivatel.Text;
            string heslo = txtHeslo.Text;

            // Zjednodušené testovací přihlášení
            if (uzivatel == "admin" && heslo == "1234")
            {
                MessageBox.Show("Přihlášení bylo úspěšné.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Otevře hlavní formulář
                MainForm mainForm = new MainForm();
                mainForm.Show();

                this.Hide(); // Skryje login okno
            }
            else
            {
                lblChyba.Text = "Neplatné přihlašovací údaje.";
                lblChyba.Visible = true;
            }
        }
    }
}
