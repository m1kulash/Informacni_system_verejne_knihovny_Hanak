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
using System.Windows.Forms.DataVisualization.Charting;

namespace Library.UI
{
    public partial class Form1 : Form
    {
        // Reference na logické služby (Business vrstva)
        private BookService _bookService;
        private ReaderService _readerService;
        private LoanService _loanService;
        private ReservationService _reservationService;

        // Dynamicky vytvořená tabulka pro Bazar
        private DataGridView gridBazaar;

        public Form1()
        {
            InitializeComponent();

            // Inicializace služeb pro práci s daty
            _bookService = new BookService();
            _readerService = new ReaderService();
            _loanService = new LoanService();
            _reservationService = new ReservationService();

            // 1. Úprava designu: Posun tabulek, aby vzniklo místo na nová tlačítka
            FixLayoutPositions();

            // 2. Dynamické vytvoření prvků pro Fázi 2 (Bazar, Meziknihovní služby)
            CreatePhase2UI();

            // 3. Prvotní načtení dat do všech tabulek a statistik
            LoadBooks();
            LoadReaders();
            RefreshLoansTab();
            RefreshBazaar();
            RefreshDashboard();
        }

        // Metoda pro doladění pozic prvků (řeší překrývání v designu)
        private void FixLayoutPositions()
        {
            // Posun tabulek o kousek níž, aby uvolnily místo pro novou řadu tlačítek
            gridBooks.Top = 110;
            gridBooks.Height -= 40;

            gridLoans.Top = 100;
            gridLoans.Height -= 40;
        }

        // Vytvoření tlačítek a záložek, které nebyly v původním návrhu (Fáze 2)
        private void CreatePhase2UI()
        {
            // --- SEKCE KNIHY: Tlačítka pro Bazar a Meziknihovní výpůjčky ---
            Button btnDiscard = new Button() { Text = "📦 Vyřadit do Bazaru", Left = 15, Top = 65, Width = 150, Height = 35, ForeColor = Color.DarkOrange };
            btnDiscard.Click += btnDiscard_Click;
            tabBooks.Controls.Add(btnDiscard);
            btnDiscard.BringToFront(); // Zajištění viditelnosti nad tabulkou

            Button btnInterlib = new Button() { Text = "🌍 + Meziknihovní", Left = 175, Top = 65, Width = 150, Height = 35, ForeColor = Color.Purple };
            btnInterlib.Click += btnInterlib_Click;
            tabBooks.Controls.Add(btnInterlib);
            btnInterlib.BringToFront();

            // Ruční úprava pozice vyhledávacího pole v knihách
            lblSearchBooks.Left = 400; lblSearchBooks.Top = 72; lblSearchBooks.BringToFront();
            txtSearchBooks.Left = 460; txtSearchBooks.Top = 70; txtSearchBooks.Width = 200; txtSearchBooks.BringToFront();

            // --- SEKCE VÝPŮJČKY: Tlačítko pro rezervaci (frontu) ---
            Button btnReserve = new Button() { Text = "⏳ Zařadit do fronty", Left = 15, Top = 60, Width = 230, Height = 35, ForeColor = Color.Teal };
            btnReserve.Click += btnReserve_Click;
            tabLoans.Controls.Add(btnReserve);
            btnReserve.BringToFront();

            // --- NOVÁ ZÁLOŽKA BAZAR: Vytvoření celé záložky kódem ---
            TabPage tabBazaar = new TabPage("Bazar (Odkup)");
            Button btnBuy = new Button() { Text = "🛒 Odkoupit vybranou knihu", Left = 15, Top = 15, Width = 200, Height = 40, ForeColor = Color.Green };
            btnBuy.Click += btnBuy_Click;

            gridBazaar = new DataGridView() { Left = 6, Top = 70, Width = 880, Height = 395, SelectionMode = DataGridViewSelectionMode.FullRowSelect, ReadOnly = true, AllowUserToAddRows = false, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };

            tabBazaar.Controls.Add(btnBuy);
            tabBazaar.Controls.Add(gridBazaar);
            tabControl1.TabPages.Add(tabBazaar);
        }

        // --- 1. SEKCE DASHBOARD: Statistiky a Grafy ---
        private void btnRefreshDashboard_Click(object sender, EventArgs e) { RefreshDashboard(); MessageBox.Show("Statistiky aktualizovány."); }

        private void RefreshDashboard()
        {
            try
            {
                // Výpočet základních čísel pro Labely
                var books = _bookService.GetAllBooks();
                lblStatsBooks.Text = books.Count.ToString();

                var readers = _readerService.GetAllReaders();
                lblStatsReaders.Text = readers.Count.ToString();

                var loans = _loanService.GetActiveLoans();
                lblStatsLoans.Text = loans.Count.ToString();

                // Suma všech pokut z historie (použití nullable decimal pro ošetření prázdných hodnot)
                var history = _loanService.GetLoanHistory();
                decimal totalFines = history.Sum(h => (decimal?)h.FineAmount) ?? 0;
                lblStatsFines.Text = totalFines.ToString() + " Kč";

                // LOGIKA PRO GRAF (POŽADAVEK FÁZE 2)
                int totalBooks = books.Count;
                int borrowedBooks = loans.Count;
                int availableBooks = totalBooks - borrowedBooks;

                chartBooks.Series.Clear();
                Series series = new Series("Knihy") { ChartType = SeriesChartType.Pie }; // Koláčový graf
                series.Points.AddXY($"Dostupné ({availableBooks})", availableBooks);
                series.Points.AddXY($"Půjčené ({borrowedBooks})", borrowedBooks);
                series.Points[0].Color = Color.LightGreen;
                series.Points[1].Color = Color.LightCoral;

                chartBooks.Series.Add(series);
                chartBooks.Titles.Clear();
                chartBooks.Titles.Add("Stav knižního fondu");
            }
            catch (Exception ex) { MessageBox.Show("Chyba statistik: " + ex.Message); }
        }

        // Automatické obnovení dat při přepnutí záložky
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabDashboard) RefreshDashboard();
            else if (tabControl1.SelectedTab == tabLoans) RefreshLoansTab();
            else if (tabControl1.SelectedTab == tabHistory) RefreshHistoryTab();
            else if (tabControl1.SelectedTab != null && tabControl1.SelectedTab.Text == "Bazar (Odkup)") RefreshBazaar();
        }

        // --- 2. SEKCE KNIHY: Správa fondu ---
        private void btnLoadBooks_Click(object sender, EventArgs e) { LoadBooks(); }
        private void btnAddBook_Click(object sender, EventArgs e) { new AddBookForm().ShowDialog(); LoadBooks(); }

        // Smazání knihy
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (gridBooks.SelectedRows.Count > 0)
            {
                int bookId = (int)gridBooks.SelectedRows[0].Cells["Id"].Value;
                _bookService.DeleteBook(bookId); LoadBooks();
            }
        }

        // Vyřazení do Bazaru (Soft delete)
        private void btnDiscard_Click(object sender, EventArgs e)
        {
            if (gridBooks.SelectedRows.Count > 0)
            {
                int id = (int)gridBooks.SelectedRows[0].Cells["Id"].Value;
                _bookService.DiscardBook(id, 50); // Nastavení snížené ceny na 50 Kč
                LoadBooks(); RefreshBazaar();
                MessageBox.Show("Kniha vyřazena do bazaru.");
            }
        }

        // Zaevidování titulu z jiné knihovny (Meziknihovní služba)
        private void btnInterlib_Click(object sender, EventArgs e)
        {
            using (var context = new Library.Data.LibraryContext())
            {
                // Vytvoření testovacího záznamu pro ukázku funkčnosti poplatků
                var author = context.Authors.FirstOrDefault() ?? new Library.Data.Entities.Author { FirstName = "Externí", LastName = "Autor" };
                var genre = context.Genres.FirstOrDefault() ?? new Library.Data.Entities.Genre { Name = "Naučná" };
                var publisher = context.Publishers.FirstOrDefault() ?? new Library.Data.Entities.Publisher { Name = "Cizí Knihovna" };

                var book = new Library.Data.Entities.Book
                {
                    Title = "Meziknihovní titul",
                    Year = 2024,
                    IsInterlibrary = true,
                    InterlibraryFee = 150, // Nastavení poplatku
                    Author = author,
                    Genre = genre,
                    Publisher = publisher
                };
                context.Books.Add(book); context.SaveChanges(); LoadBooks();
            }
        }

        // Načtení a formátování tabulky knih
        private void LoadBooks()
        {
            try
            {
                gridBooks.DataSource = _bookService.GetAllBooks();

                // Skrytí technických ID sloupců (POŽADAVEK NA ČISTOTU UI)
                string[] toHide = { "Id", "AuthorId", "GenreId", "PublisherId", "IsDeleted", "MediaType", "SalePrice", "Loans", "Reservations" };
                foreach (var col in toHide) if (gridBooks.Columns[col] != null) gridBooks.Columns[col].Visible = false;

                // Lokalizace záhlaví do češtiny
                if (gridBooks.Columns["Title"] != null) gridBooks.Columns["Title"].HeaderText = "Název knihy";
                if (gridBooks.Columns["Author"] != null) gridBooks.Columns["Author"].HeaderText = "Autor";
                if (gridBooks.Columns["Year"] != null) gridBooks.Columns["Year"].HeaderText = "Rok vydání";
                if (gridBooks.Columns["IsInterlibrary"] != null) gridBooks.Columns["IsInterlibrary"].HeaderText = "Meziknihovní?";
                if (gridBooks.Columns["InterlibraryFee"] != null) gridBooks.Columns["InterlibraryFee"].HeaderText = "Poplatek (Kč)";
            }
            catch { }
        }

        // Dynamické vyhledávání při psaní do textového pole
        private void txtSearchBooks_TextChanged(object sender, EventArgs e) { try { gridBooks.DataSource = _bookService.SearchBooks(txtSearchBooks.Text); } catch { } }

        // --- 3. SEKCE BAZAR: Výprodej vyřazených knih ---
        private void RefreshBazaar()
        {
            try
            {
                gridBazaar.DataSource = _bookService.GetDiscardedBooks();

                // Úprava vzhledu bazarové tabulky
                string[] toHide = { "Id", "AuthorId", "GenreId", "PublisherId", "IsDeleted", "MediaType", "IsInterlibrary", "InterlibraryFee", "Description", "Year", "Loans", "Reservations" };
                foreach (var col in toHide) if (gridBazaar.Columns[col] != null) gridBazaar.Columns[col].Visible = false;

                if (gridBazaar.Columns["Title"] != null) gridBazaar.Columns["Title"].HeaderText = "Název vyřazené knihy";
                if (gridBazaar.Columns["SalePrice"] != null) gridBazaar.Columns["SalePrice"].HeaderText = "Cena k odkupu (Kč)";
                if (gridBazaar.Columns["Title"] != null) gridBazaar.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch { }
        }

        // Odkoupení knihy čtenářem (odstranění z bazaru)
        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (gridBazaar.SelectedRows.Count > 0)
            {
                int id = (int)gridBazaar.SelectedRows[0].Cells["Id"].Value;
                _bookService.BuyDiscardedBook(id); RefreshBazaar(); MessageBox.Show("Odkoupeno.");
            }
        }

        // --- 4. SEKCE ČTENÁŘI ---
        private void btnLoadReaders_Click(object sender, EventArgs e) { LoadReaders(); }
        private void btnAddReader_Click(object sender, EventArgs e) { new AddReaderForm().ShowDialog(); LoadReaders(); }
        private void LoadReaders()
        {
            try
            {
                gridReaders.DataSource = _readerService.GetAllReaders();
                if (gridReaders.Columns["Id"] != null) gridReaders.Columns["Id"].Visible = false;
                if (gridReaders.Columns["LastName"] != null) gridReaders.Columns["LastName"].HeaderText = "Příjmení";
            }
            catch { }
        }

        private void txtSearchReaders_TextChanged(object sender, EventArgs e) { try { gridReaders.DataSource = _readerService.SearchReaders(txtSearchReaders.Text); } catch { } }

        // --- 5. SEKCE VÝPŮJČKY: Realizace půjčování a vracení ---
        private void RefreshLoansTab()
        {
            try
            {
                // Naplnění výběrových polí (ComboBoxů)
                comboLoanReader.DataSource = _readerService.GetAllReaders();
                comboLoanReader.DisplayMember = "LastName"; comboLoanReader.ValueMember = "Id";

                comboLoanBook.DataSource = _bookService.GetAllBooks();
                comboLoanBook.DisplayMember = "Title"; comboLoanBook.ValueMember = "Id";

                gridLoans.DataSource = _loanService.GetActiveLoans();

                // Úprava sloupců tabulky výpůjček
                string[] toHide = { "Id", "ReaderId", "BookId", "ReturnDate", "FineAmount" };
                foreach (var col in toHide) if (gridLoans.Columns[col] != null) gridLoans.Columns[col].Visible = false;

                if (gridLoans.Columns["Reader"] != null) gridLoans.Columns["Reader"].HeaderText = "Čtenář";
                if (gridLoans.Columns["Book"] != null) gridLoans.Columns["Book"].HeaderText = "Kniha";
                if (gridLoans.Columns["DueDate"] != null) gridLoans.Columns["DueDate"].HeaderText = "Vrátit do";
            }
            catch { }
        }

        // Půjčení knihy
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (comboLoanReader.SelectedValue == null || comboLoanBook.SelectedValue == null) return;
            _loanService.BorrowBook((int)comboLoanReader.SelectedValue, (int)comboLoanBook.SelectedValue);
            RefreshLoansTab(); RefreshDashboard();
        }

        // Zařazení čtenáře do fronty (Rezervace)
        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (comboLoanReader.SelectedValue == null || comboLoanBook.SelectedValue == null) return;
            _reservationService.AddReservation((int)comboLoanReader.SelectedValue, (int)comboLoanBook.SelectedValue);
            MessageBox.Show("Rezervace OK.");
        }

        // Vrácení vybrané knihy
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (gridLoans.SelectedRows.Count > 0)
            {
                int id = (int)gridLoans.SelectedRows[0].Cells["Id"].Value;
                _loanService.ReturnBook(id); RefreshLoansTab(); RefreshDashboard();
            }
        }

        // AUTOMATICKÉ UPOMÍNKY (POŽADAVEK FÁZE 2)
        private void btnReminders_Click(object sender, EventArgs e)
        {
            var loans = _loanService.GetActiveLoans();
            string msg = "Seznam upomínek (po termínu):\n";
            int count = 0;
            foreach (var l in loans)
            {
                if (DateTime.Now > l.DueDate) // Kontrola, zda už uplynul termín
                {
                    msg += $"{l.Reader.LastName} - {l.Book.Title}\n";
                    count++;
                }
            }
            if (count > 0) MessageBox.Show(msg); else MessageBox.Show("Žádné upomínky.");
        }

        // --- 6. SEKCE HISTORIE: Přehled všech proběhlých akcí ---
        private void btnRefreshHistory_Click(object sender, EventArgs e) { RefreshHistoryTab(); }

        private void RefreshHistoryTab()
        {
            try
            {
                gridHistory.DataSource = _loanService.GetLoanHistory();
                string[] toHide = { "Id", "ReaderId", "BookId" };
                foreach (var col in toHide) if (gridHistory.Columns[col] != null) gridHistory.Columns[col].Visible = false;

                if (gridHistory.Columns["FineAmount"] != null) gridHistory.Columns["FineAmount"].HeaderText = "Pokuta (Kč)";
            }
            catch { }
        }
    }
}