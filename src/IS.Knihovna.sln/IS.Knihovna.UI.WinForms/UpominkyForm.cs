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
    public partial class UpominkyForm : Form
    {
        public UpominkyForm()
        {
            InitializeComponent();
        }
        private void btnPridat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funkce Přidat bude přidána v KB2.");
        }

        private void btnUpravit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funkce Upravit bude přidána v KB2.");
        }

        private void btnSmazat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funkce Smazat bude přidána v KB2.");
        }

        private void btnVyhledat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funkce Vyhledat bude přidána v KB2.");
        }

        private void btnObnovit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Obnovení seznamu bude břidána v KB2 (zatím prázdné).");
        }
    }
}
