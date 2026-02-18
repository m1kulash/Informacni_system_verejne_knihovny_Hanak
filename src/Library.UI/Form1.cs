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
    public partial class Form1 : Form
    {
        private BookService _bookService;
        private ReaderService _readerService;
        private LoanService _loanService;

        public Form1()
        {
            InitializeComponent();
            _bookService = new BookService();
            _readerService = new ReaderService();
            _loanService = new LoanService();

            // Načteme data
            LoadBooks();
            LoadReaders();
            RefreshLoansTab();
            RefreshDashboard();
        }

        // --- 1. SEKCE DASHBOARD ---
        private void btnRefreshDashboard_Click(object sender, EventArgs e)
        {
            RefreshDashboard();
            MessageBox.Show("Statistiky byly aktualizovány.");
        }

        private void RefreshDashboard()
        {
            try
            {
                var books = _bookService.GetAllBooks();
                lblStatsBooks.Text = books.Count.ToString();

                var readers = _readerService.GetAllReaders();
                lblStatsReaders.Text = readers.Count.ToString();

                var loans = _loanService.GetActiveLoans();
                lblStatsLoans.Text = loans.Count.ToString();

                var history = _loanService.GetLoanHistory();
                decimal totalFines = history.Sum(h => h.FineAmount);
                lblStatsFines.Text = totalFines.ToString() + " Kč";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání statistik: " + ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabDashboard) RefreshDashboard();
            else if (tabControl1.SelectedTab == tabLoans) RefreshLoansTab();
            else if (tabControl1.SelectedTab == tabHistory) RefreshHistoryTab();
        }

        // --- 2. SEKCE KNIHY ---
        private void btnLoadBooks_Click(object sender, EventArgs e) { LoadBooks(); }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var form = new AddBookForm();
            form.ShowDialog();
            LoadBooks();
        }

        // --- NOVÉ: ODSTRANĚNÍ KNIHY ---
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridBooks.SelectedRows.Count > 0)
                {
                    // Získáme ID vybrané knihy
                    int bookId = (int)gridBooks.SelectedRows[0].Cells["Id"].Value;
                    string bookTitle = gridBooks.SelectedRows[0].Cells["Title"].Value.ToString();

                    // Zeptáme se uživatele
                    var result = MessageBox.Show($"Opravdu chceš smazat knihu '{bookTitle}'?\nTato akce je nevratná.",
                        "Potvrzení smazání", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _bookService.DeleteBook(bookId);
                        MessageBox.Show("Kniha byla odstraněna.");
                        LoadBooks(); // Obnovit seznam
                    }
                }
                else
                {
                    MessageBox.Show("Nejdřív vyber knihu v tabulce.");
                }
            }
            catch (Exception ex)
            {
                // Pokud je kniha půjčená, databáze nedovolí smazání a vyhodí chybu (Constraint exception)
                MessageBox.Show("Chyba při mazání: " + ex.Message + "\n\n(Možná je kniha stále půjčená?)");
            }
        }

        private void LoadBooks()
        {
            try
            {
                _bookService.CreateTestData();
                gridBooks.DataSource = _bookService.GetAllBooks();

                // Design úpravy
                if (gridBooks.Columns["Id"] != null) gridBooks.Columns["Id"].Visible = false;
                if (gridBooks.Columns["AuthorId"] != null) gridBooks.Columns["AuthorId"].Visible = false;
                if (gridBooks.Columns["GenreId"] != null) gridBooks.Columns["GenreId"].Visible = false;
                if (gridBooks.Columns["PublisherId"] != null) gridBooks.Columns["PublisherId"].Visible = false;
                if (gridBooks.Columns["IsDeleted"] != null) gridBooks.Columns["IsDeleted"].Visible = false;
                if (gridBooks.Columns["MediaType"] != null) gridBooks.Columns["MediaType"].Visible = false;

                if (gridBooks.Columns["Title"] != null) { gridBooks.Columns["Title"].HeaderText = "Název knihy"; gridBooks.Columns["Title"].DisplayIndex = 0; }
                if (gridBooks.Columns["Author"] != null) { gridBooks.Columns["Author"].HeaderText = "Autor"; gridBooks.Columns["Author"].DisplayIndex = 1; }
                if (gridBooks.Columns["Genre"] != null) gridBooks.Columns["Genre"].HeaderText = "Žánr";
                if (gridBooks.Columns["Year"] != null) gridBooks.Columns["Year"].HeaderText = "Rok";
                if (gridBooks.Columns["Publisher"] != null) gridBooks.Columns["Publisher"].HeaderText = "Vydavatel";
                if (gridBooks.Columns["Description"] != null) gridBooks.Columns["Description"].HeaderText = "Popis";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtSearchBooks_TextChanged(object sender, EventArgs e)
        {
            try { gridBooks.DataSource = _bookService.SearchBooks(txtSearchBooks.Text); }
            catch { }
        }

        // --- 3. SEKCE ČTENÁŘI ---
        private void btnLoadReaders_Click(object sender, EventArgs e) { LoadReaders(); }

        private void btnAddReader_Click(object sender, EventArgs e)
        {
            var form = new AddReaderForm();
            form.ShowDialog();
            LoadReaders();
        }

        private void LoadReaders()
        {
            try
            {
                _readerService.CreateTestReader();
                gridReaders.DataSource = _readerService.GetAllReaders();

                if (gridReaders.Columns["Id"] != null) gridReaders.Columns["Id"].Visible = false;
                if (gridReaders.Columns["Loans"] != null) gridReaders.Columns["Loans"].Visible = false;

                if (gridReaders.Columns["FirstName"] != null) gridReaders.Columns["FirstName"].HeaderText = "Jméno";
                if (gridReaders.Columns["LastName"] != null) gridReaders.Columns["LastName"].HeaderText = "Příjmení";
                if (gridReaders.Columns["Email"] != null) gridReaders.Columns["Email"].HeaderText = "E-mail";
                if (gridReaders.Columns["DateOfBirth"] != null) gridReaders.Columns["DateOfBirth"].HeaderText = "Datum narození";
                if (gridReaders.Columns["Gender"] != null) gridReaders.Columns["Gender"].HeaderText = "Pohlaví";
                if (gridReaders.Columns["EducationLevel"] != null) gridReaders.Columns["EducationLevel"].HeaderText = "Vzdělání";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtSearchReaders_TextChanged(object sender, EventArgs e)
        {
            try { gridReaders.DataSource = _readerService.SearchReaders(txtSearchReaders.Text); }
            catch { }
        }

        // --- 4. SEKCE VÝPŮJČKY ---
        private void RefreshLoansTab()
        {
            try
            {
                comboLoanReader.DataSource = _readerService.GetAllReaders();
                comboLoanReader.DisplayMember = "LastName";
                comboLoanReader.ValueMember = "Id";

                comboLoanBook.DataSource = _bookService.GetAllBooks();
                comboLoanBook.DisplayMember = "Title";
                comboLoanBook.ValueMember = "Id";

                gridLoans.DataSource = _loanService.GetActiveLoans();

                if (gridLoans.Columns["Id"] != null) gridLoans.Columns["Id"].Visible = false;
                if (gridLoans.Columns["ReaderId"] != null) gridLoans.Columns["ReaderId"].Visible = false;
                if (gridLoans.Columns["BookId"] != null) gridLoans.Columns["BookId"].Visible = false;
                if (gridLoans.Columns["ReturnDate"] != null) gridLoans.Columns["ReturnDate"].Visible = false;
                if (gridLoans.Columns["FineAmount"] != null) gridLoans.Columns["FineAmount"].Visible = false;

                if (gridLoans.Columns["Reader"] != null) gridLoans.Columns["Reader"].HeaderText = "Čtenář";
                if (gridLoans.Columns["Book"] != null) gridLoans.Columns["Book"].HeaderText = "Kniha";
                if (gridLoans.Columns["LoanDate"] != null) gridLoans.Columns["LoanDate"].HeaderText = "Půjčeno dne";
                if (gridLoans.Columns["DueDate"] != null) gridLoans.Columns["DueDate"].HeaderText = "Vrátit do";
            }
            catch (Exception ex) { MessageBox.Show("Chyba výpůjček: " + ex.Message); }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboLoanReader.SelectedValue == null || comboLoanBook.SelectedValue == null) return;

                int readerId = (int)comboLoanReader.SelectedValue;
                int bookId = (int)comboLoanBook.SelectedValue;

                _loanService.BorrowBook(readerId, bookId);

                MessageBox.Show("Kniha úspěšně půjčena!");
                RefreshLoansTab();
            }
            catch (Exception ex) { MessageBox.Show("Chyba: " + ex.Message); }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridLoans.SelectedRows.Count > 0)
                {
                    int loanId = (int)gridLoans.SelectedRows[0].Cells["Id"].Value;
                    decimal fine = _loanService.ReturnBook(loanId);
                    RefreshLoansTab();

                    if (fine > 0) MessageBox.Show($"⚠️ POZOR! Kniha vrácena pozdě.\n\nPokuta činí: {fine} Kč", "Pokuta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else MessageBox.Show("Kniha v pořádku vrácena. Bez pokuty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Vyber řádek v tabulce, který chceš vrátit.");
            }
            catch (Exception ex) { MessageBox.Show("Chyba: " + ex.Message); }
        }

        // --- 5. SEKCE HISTORIE ---
        private void btnRefreshHistory_Click(object sender, EventArgs e) { RefreshHistoryTab(); }

        private void RefreshHistoryTab()
        {
            try
            {
                gridHistory.DataSource = _loanService.GetLoanHistory();

                if (gridHistory.Columns["Id"] != null) gridHistory.Columns["Id"].Visible = false;
                if (gridHistory.Columns["ReaderId"] != null) gridHistory.Columns["ReaderId"].Visible = false;
                if (gridHistory.Columns["BookId"] != null) gridHistory.Columns["BookId"].Visible = false;

                if (gridHistory.Columns["Reader"] != null) gridHistory.Columns["Reader"].HeaderText = "Čtenář";
                if (gridHistory.Columns["Book"] != null) gridHistory.Columns["Book"].HeaderText = "Kniha";
                if (gridHistory.Columns["LoanDate"] != null) gridHistory.Columns["LoanDate"].HeaderText = "Půjčeno";
                if (gridHistory.Columns["DueDate"] != null) gridHistory.Columns["DueDate"].HeaderText = "Termín";
                if (gridHistory.Columns["ReturnDate"] != null) gridHistory.Columns["ReturnDate"].HeaderText = "Vráceno dne";
                if (gridHistory.Columns["FineAmount"] != null) gridHistory.Columns["FineAmount"].HeaderText = "Pokuta (Kč)";
            }
            catch (Exception ex) { MessageBox.Show("Chyba historie: " + ex.Message); }
        }
    }
}