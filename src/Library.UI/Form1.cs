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
        // Reference na business služby - oddělení logiky od uživatelského rozhraní
        private BookService _bookService;
        private ReaderService _readerService;
        private LoanService _loanService;
        private ReservationService _reservationService;

        // Tabulka pro bazar, kterou vytváříme dynamicky (není v Designeru)
        private DataGridView gridBazaar;

        public Form1()
        {
            InitializeComponent();

            // Inicializace všech služeb při startu aplikace
            _bookService = new BookService();
            _readerService = new ReaderService();
            _loanService = new LoanService();
            _reservationService = new ReservationService();

            // --- SEEDING: Automatické naplnění databáze ukázkovými daty ---
            try
            {
                _bookService.SeedBooks();
                _readerService.SeedReaders();
            }
            catch (Exception ex)
            {
                // Ošetření chyby při inicializaci - uživatel je varován, ale program nespadne
                MessageBox.Show("Chyba při plnění testovacích dat: " + ex.Message, "Inicializace dat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Úprava vzhledu a přidání dynamických prvků
            FixLayoutPositions();
            InitializeExtendedModules();

            // Prvotní načtení dat do všech tabulek a grafů
            LoadBooks();
            LoadReaders();
            RefreshLoansTab();
            RefreshBazaar();
            RefreshDashboard();
        }

        // Metoda pro doladění pozic prvků (řeší překrývání tabulek a tlačítek)
        private void FixLayoutPositions()
        {
            gridBooks.Top = 110;
            gridBooks.Height -= 40;
            gridLoans.Top = 100;
            gridLoans.Height -= 40;
        }

        // Dynamické vytváření UI prvků - ukázka programového řízení vzhledu (mimo Designer)
        private void InitializeExtendedModules()
        {
            // --- SEKCE KNIHY: Přesné rozmístění lišty ---
            btnLoadBooks.Left = 15; btnLoadBooks.Top = 15;
            btnAddBook.Left = 175; btnAddBook.Top = 15;

            // Tlačítko pro vyřazení do bazaru - nastavení oranžové barvy pro odlišení
            Button btnDiscard = new Button() { Text = "📦 Vyřadit do Bazaru", Left = 15, Top = 65, Width = 150, Height = 35, ForeColor = Color.DarkOrange };
            btnDiscard.Click += btnDiscard_Click;
            tabBooks.Controls.Add(btnDiscard);
            btnDiscard.BringToFront();

            // Simulace meziknihovní výpůjčky (externí zdroje)
            Button btnInterlib = new Button() { Text = "🌍 + Meziknihovní", Left = 175, Top = 65, Width = 150, Height = 35, ForeColor = Color.Purple };
            btnInterlib.Click += btnInterlib_Click;
            tabBooks.Controls.Add(btnInterlib);
            btnInterlib.BringToFront();

            lblSearchBooks.Left = 400; lblSearchBooks.Top = 72;
            txtSearchBooks.Left = 460; txtSearchBooks.Top = 70; txtSearchBooks.Width = 250;

            // --- SEKCE ČTENÁŘI: Zarovnání a přidání smazání ---
            btnLoadReaders.Left = 15; btnLoadReaders.Top = 15; btnLoadReaders.Width = 160;
            btnAddReader.Left = 190; btnAddReader.Top = 15; btnAddReader.Width = 160;

            // Tlačítko pro smazání čtenáře - výrazná červená barva (nebezpečná operace)
            Button btnDeleteReader = new Button() { Text = "❌ Smazat čtenáře", Left = 365, Top = 15, Width = 150, Height = 35, ForeColor = Color.Red };
            btnDeleteReader.Click += btnDeleteReader_Click;
            tabReaders.Controls.Add(btnDeleteReader);
            btnDeleteReader.BringToFront();

            lblSearchReaders.Left = 550; lblSearchReaders.Top = 22;
            txtSearchReaders.Left = 610; txtSearchReaders.Top = 20; txtSearchReaders.Width = 220;

            // --- SEKCE VÝPŮJČKY ---
            Button btnReserve = new Button() { Text = "⏳ Zařadit do fronty", Left = 15, Top = 60, Width = 230, Height = 35, ForeColor = Color.Teal };
            btnReserve.Click += btnReserve_Click;
            tabLoans.Controls.Add(btnReserve);
            btnReserve.BringToFront();

            // --- SEKCE BAZAR: Dynamické vytvoření celé záložky ---
            TabPage tabBazaar = new TabPage("Bazar (Odkup)");
            Button btnBuy = new Button() { Text = "🛒 Odkoupit vybranou knihu", Left = 15, Top = 15, Width = 200, Height = 40, ForeColor = Color.Green };
            btnBuy.Click += btnBuy_Click;

            gridBazaar = new DataGridView() { Left = 6, Top = 70, Width = 880, Height = 395, SelectionMode = DataGridViewSelectionMode.FullRowSelect, ReadOnly = true, AllowUserToAddRows = false, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };

            tabBazaar.Controls.Add(btnBuy);
            tabBazaar.Controls.Add(gridBazaar);
            tabControl1.TabPages.Add(tabBazaar);
        }

        // --- DASHBOARD: Přehled statistik a vizualizace dat ---
        private void btnRefreshDashboard_Click(object sender, EventArgs e) { RefreshDashboard(); MessageBox.Show("Všechny statistiky a grafy byly úspěšně aktualizovány na základě nejnovějších dat v systému.",
                                                                                                                    "Aktualizace Dashboardu",
                                                                                                                    MessageBoxButtons.OK,
                                                                                                                    MessageBoxIcon.Information);
        }

        private void RefreshDashboard()
        {
            try
            {
                // Získání dat pro textové popisky
                var books = _bookService.GetAllBooks();
                lblStatsBooks.Text = books.Count.ToString();
                var readers = _readerService.GetAllReaders();
                lblStatsReaders.Text = readers.Count.ToString();
                var loans = _loanService.GetActiveLoans();
                lblStatsLoans.Text = loans.Count.ToString();

                // Agregace pokut z historie (ukázka LINQ Sum)
                var history = _loanService.GetLoanHistory();
                decimal totalFines = history.Sum(h => (decimal?)h.FineAmount) ?? 0;
                lblStatsFines.Text = totalFines.ToString() + " Kč";

                // Výpočet dat pro koláčový graf
                int totalBooks = books.Count;
                int borrowedBooks = loans.Count;
                int availableBooks = totalBooks - borrowedBooks;

                // Vykreslení grafu pomocí komponenty Chart
                chartBooks.Series.Clear();
                Series series = new Series("Knihy") { ChartType = SeriesChartType.Pie };
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

        // Automatické obnovení dat při přepnutí záložky (Lazy Loading dat do UI)
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabDashboard) RefreshDashboard();
            else if (tabControl1.SelectedTab == tabLoans) RefreshLoansTab();
            else if (tabControl1.SelectedTab == tabHistory) RefreshHistoryTab();
            else if (tabControl1.SelectedTab != null && tabControl1.SelectedTab.Text == "Bazar (Odkup)") RefreshBazaar();
        }

        // --- KNIHY: CRUD operace a správa fondu ---
        private void btnLoadBooks_Click(object sender, EventArgs e) { LoadBooks(); }
        private void btnAddBook_Click(object sender, EventArgs e) { new AddBookForm().ShowDialog(); LoadBooks(); }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            try { if (gridBooks.SelectedRows.Count > 0) { int bookId = (int)gridBooks.SelectedRows[0].Cells["Id"].Value; _bookService.DeleteBook(bookId); LoadBooks(); } }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            // Vyřazení vybrané knihy do bazarové sekce
            if (gridBooks.SelectedRows.Count > 0)
            {
                int id = (int)gridBooks.SelectedRows[0].Cells["Id"].Value;
                _bookService.DiscardBook(id, 50);
                LoadBooks(); RefreshBazaar();
                MessageBox.Show("Kniha vyřazena do bazaru.", "Správa fondu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInterlib_Click(object sender, EventArgs e)
        {
            // Simulace vytvoření záznamu pro meziknihovní výpůjčku přímo přes DB kontext
            using (var context = new Library.Data.LibraryContext())
            {
                var author = context.Authors.FirstOrDefault() ?? new Library.Data.Entities.Author { FirstName = "Externí", LastName = "Autor" };
                var genre = context.Genres.FirstOrDefault() ?? new Library.Data.Entities.Genre { Name = "Naučná" };
                var publisher = context.Publishers.FirstOrDefault() ?? new Library.Data.Entities.Publisher { Name = "Cizí Knihovna" };
                var book = new Library.Data.Entities.Book { Title = "Meziknihovní titul", Year = 2024, IsInterlibrary = true, InterlibraryFee = 150, Author = author, Genre = genre, Publisher = publisher };
                context.Books.Add(book); context.SaveChanges(); LoadBooks();
            }
        }

        private void LoadBooks()
        {
            try
            {
                gridBooks.DataSource = _bookService.GetAllBooks();
                // Skrytí technických sloupců, které uživatel nepotřebuje vidět
                string[] toHide = { "Id", "AuthorId", "GenreId", "PublisherId", "IsDeleted", "MediaType", "SalePrice", "Loans", "Reservations" };
                foreach (var col in toHide) if (gridBooks.Columns[col] != null) gridBooks.Columns[col].Visible = false;

                // Počeštění záhlaví tabulky (Lokalizace)
                if (gridBooks.Columns["Title"] != null) gridBooks.Columns["Title"].HeaderText = "Název knihy";
                if (gridBooks.Columns["Author"] != null) gridBooks.Columns["Author"].HeaderText = "Autor";
                if (gridBooks.Columns["Year"] != null) gridBooks.Columns["Year"].HeaderText = "Rok vydání";
                if (gridBooks.Columns["Description"] != null) gridBooks.Columns["Description"].HeaderText = "Popis";
                if (gridBooks.Columns["Genre"] != null) gridBooks.Columns["Genre"].HeaderText = "Žánr";
                if (gridBooks.Columns["Publisher"] != null) gridBooks.Columns["Publisher"].HeaderText = "Vydavatel";
                if (gridBooks.Columns["IsInterlibrary"] != null) gridBooks.Columns["IsInterlibrary"].HeaderText = "Meziknihovní?";
                if (gridBooks.Columns["InterlibraryFee"] != null) gridBooks.Columns["InterlibraryFee"].HeaderText = "Poplatek (Kč)";
            }
            catch { }
        }

        // Dynamické vyhledávání v reálném čase (událost TextChanged)
        private void txtSearchBooks_TextChanged(object sender, EventArgs e) { try { gridBooks.DataSource = _bookService.SearchBooks(txtSearchBooks.Text); } catch { } }

        // --- BAZAR: Správa prodeje vyřazených knih ---
        private void RefreshBazaar()
        {
            try
            {
                gridBazaar.DataSource = _bookService.GetDiscardedBooks();
                string[] toHide = { "Id", "AuthorId", "GenreId", "PublisherId", "IsDeleted", "MediaType", "IsInterlibrary", "InterlibraryFee", "Description", "Year", "Loans", "Reservations" };
                foreach (var col in toHide) if (gridBazaar.Columns[col] != null) gridBazaar.Columns[col].Visible = false;
                if (gridBazaar.Columns["Title"] != null) gridBazaar.Columns["Title"].HeaderText = "Název vyřazené knihy";
                if (gridBazaar.Columns["SalePrice"] != null) gridBazaar.Columns["SalePrice"].HeaderText = "Cena k odkupu (Kč)";
                if (gridBazaar.Columns["Title"] != null) gridBazaar.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch { }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            // Definitivní smazání knihy po jejím zakoupení v bazaru
            if (gridBazaar.SelectedRows.Count > 0)
            {
                int id = (int)gridBazaar.SelectedRows[0].Cells["Id"].Value;
                _bookService.BuyDiscardedBook(id);
                RefreshBazaar();
                MessageBox.Show("Kniha byla úspěšně odkoupena a trvale odstraněna z evidence bazaru.",
                "Bazar - Odkup",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        // --- ČTENÁŘI: Správa uživatelské základny ---
        private void btnLoadReaders_Click(object sender, EventArgs e) { LoadReaders(); }
        private void btnAddReader_Click(object sender, EventArgs e) { new AddReaderForm().ShowDialog(); LoadReaders(); }

        private void btnDeleteReader_Click(object sender, EventArgs e)
        {
            // Smazání čtenáře s potvrzovacím dialogem (ochrana dat)
            if (gridReaders.SelectedRows.Count > 0)
            {
                int readerId = (int)gridReaders.SelectedRows[0].Cells["Id"].Value;
                string lastName = gridReaders.SelectedRows[0].Cells["LastName"].Value.ToString();
                var confirm = MessageBox.Show($"Opravdu chcete smazat čtenáře {lastName}?", "Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _readerService.DeleteReader(readerId);
                        LoadReaders(); RefreshDashboard();
                        MessageBox.Show("Záznam čtenáře byl úspěšně a trvale odstraněn z databáze.",
                    "Správa čtenářů",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else {
                MessageBox.Show("Není vybrán žádný záznam. Prosím, nejdříve označte v tabulce čtenáře, kterého si přejete smazat.",
                "Smazání čtenáře",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        private void LoadReaders()
        {
            try
            {
                gridReaders.DataSource = _readerService.GetAllReaders();
                if (gridReaders.Columns["Id"] != null) gridReaders.Columns["Id"].Visible = false;
                // Lokalizace záhlaví čtenářů
                if (gridReaders.Columns["FirstName"] != null) gridReaders.Columns["FirstName"].HeaderText = "Jméno";
                if (gridReaders.Columns["LastName"] != null) gridReaders.Columns["LastName"].HeaderText = "Příjmení";
                if (gridReaders.Columns["DateOfBirth"] != null) gridReaders.Columns["DateOfBirth"].HeaderText = "Datum narození";
                if (gridReaders.Columns["Gender"] != null) gridReaders.Columns["Gender"].HeaderText = "Pohlaví";
                if (gridReaders.Columns["EducationLevel"] != null) gridReaders.Columns["EducationLevel"].HeaderText = "Vzdělání";
                if (gridReaders.Columns["Loans"] != null) gridReaders.Columns["Loans"].HeaderText = "Výpůjčky";
                if (gridReaders.Columns["Email"] != null) gridReaders.Columns["Email"].HeaderText = "E-mail";
            }
            catch { }
        }

        private void txtSearchReaders_TextChanged(object sender, EventArgs e) { try { gridReaders.DataSource = _readerService.SearchReaders(txtSearchReaders.Text); } catch { } }

        // --- VÝPŮJČNÍ PULT: Hlavní procesy knihovny ---
        private void RefreshLoansTab()
        {
            try
            {
                // Plnění výběrových ComboBoxů pro novou výpůjčku
                comboLoanReader.DataSource = _readerService.GetAllReaders();
                comboLoanReader.DisplayMember = "LastName"; comboLoanReader.ValueMember = "Id";

                comboLoanBook.DataSource = _bookService.GetAllBooks();
                comboLoanBook.DisplayMember = "Title"; comboLoanBook.ValueMember = "Id";

                gridLoans.DataSource = _loanService.GetActiveLoans();
                string[] toHide = { "Id", "ReaderId", "BookId", "ReturnDate", "FineAmount" };
                foreach (var col in toHide) if (gridLoans.Columns[col] != null) gridLoans.Columns[col].Visible = false;

                if (gridLoans.Columns["Reader"] != null) gridLoans.Columns["Reader"].HeaderText = "Čtenář";
                if (gridLoans.Columns["Book"] != null) gridLoans.Columns["Book"].HeaderText = "Kniha";
                if (gridLoans.Columns["LoanDate"] != null) gridLoans.Columns["LoanDate"].HeaderText = "Datum vypůjčení";
                if (gridLoans.Columns["DueDate"] != null) gridLoans.Columns["DueDate"].HeaderText = "Vrátit do";
            }
            catch { }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (comboLoanReader.SelectedValue == null || comboLoanBook.SelectedValue == null) return;
            int selectedBookId = (int)comboLoanBook.SelectedValue;
            var activeLoans = _loanService.GetActiveLoans();

            // Validace: Systém nedovolí půjčit knihu, kterou už má někdo jiný
            if (activeLoans.Any(l => l.BookId == selectedBookId))
            {
                MessageBox.Show("Tuto knihu nelze půjčit, protože ji má momentálně jiný čtenář. Použijte tlačítko 'Zařadit do fronty'.", "Kniha je vypůjčena", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try { _loanService.BorrowBook((int)comboLoanReader.SelectedValue, (int)comboLoanBook.SelectedValue); RefreshLoansTab(); RefreshDashboard(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboLoanReader.SelectedValue == null || comboLoanBook.SelectedValue == null) return;
                _reservationService.AddReservation((int)comboLoanReader.SelectedValue, (int)comboLoanBook.SelectedValue);
                MessageBox.Show("Rezervace knihy byla úspěšně vytvořena a čtenář byl zařazen do pořadníku na první volné místo.",
                "Rezervační systém",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (gridLoans.SelectedRows.Count > 0)
            {
                int loanId = (int)gridLoans.SelectedRows[0].Cells["Id"].Value;
                int bookId = (int)gridLoans.SelectedRows[0].Cells["BookId"].Value;
                try
                {
                    // 1. Krok: Zpracování vrácení a výpočet případné pokuty
                    _loanService.ReturnBook(loanId);

                    // 2. Krok: Automatická kontrola rezervační fronty (FIFO logika)
                    var queue = _reservationService.GetQueueForBook(bookId);
                    var nextReader = queue.FirstOrDefault();

                    if (nextReader != null)
                    {
                        // Pokud někdo na knihu čeká, nabídneme okamžité předání
                        var result = MessageBox.Show($"Kniha byla vrácena. Čtenář {nextReader.Reader.LastName} je první ve frontě. Chcete mu knihu rovnou půjčit?", "Rezervace nalezena", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _loanService.BorrowBook(nextReader.ReaderId, bookId);
                            _reservationService.RemoveReservation(nextReader.Id);
                            MessageBox.Show($"Rezervace byla úspěšně vyřízena. Kniha byla ihned zapůjčena dalšímu čekateli v pořadí: {nextReader.Reader.FirstName} {nextReader.Reader.LastName}.",
                            "Vyřízení rezervace",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                    }
                    else {
                        MessageBox.Show("Kniha byla úspěšně vrácena do fondu. V rezervační frontě není žádný další zájemce, titul je tedy nyní volně dostupný pro další výpůjčky.",
                        "Vrácení knihy",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    }

                    RefreshLoansTab(); RefreshDashboard();
                }
                catch (Exception ex) { MessageBox.Show("Chyba při zpracování vrácení: " + ex.Message); }
            }
            else {
                MessageBox.Show("Nebyl vybrán žádný záznam k vrácení. Prosím, nejdříve označte v tabulce aktivní výpůjčku, kterou si přejete ukončit.",
                "Vrácení knihy",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        // Seznam dlužníků (Upomínky) - filtrace aktivních výpůjček po termínu
        private void btnReminders_Click(object sender, EventArgs e)
        {
            var loans = _loanService.GetActiveLoans();
            string msg = "Seznam dlužníků:\n";
            int count = 0;
            foreach (var l in loans)
            {
                if (DateTime.Now > l.DueDate)
                {
                    msg += $"{l.Reader.LastName} - {l.Book.Title}\n";
                    count++;
                }
            }
            if (count > 0) MessageBox.Show(msg,
                "Seznam dlužníků po termínu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            else MessageBox.Show("Všechny aktivní výpůjčky jsou v pořádku. Aktuálně nebyly nalezeny žádné knihy s prošlou lhůtou pro vrácení.",
                "Kontrola upomínek",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // --- HISTORIE: Archivace proběhlých transakcí ---
        private void btnRefreshHistory_Click(object sender, EventArgs e) { RefreshHistoryTab(); }

        private void RefreshHistoryTab()
        {
            try
            {
                gridHistory.DataSource = _loanService.GetLoanHistory();
                string[] toHide = { "Id", "ReaderId", "BookId" };
                foreach (var col in toHide) if (gridHistory.Columns[col] != null) gridHistory.Columns[col].Visible = false;

                if (gridHistory.Columns["Reader"] != null) gridHistory.Columns["Reader"].HeaderText = "Čtenář";
                if (gridHistory.Columns["Book"] != null) gridHistory.Columns["Book"].HeaderText = "Kniha";
                if (gridHistory.Columns["LoanDate"] != null) gridHistory.Columns["LoanDate"].HeaderText = "Datum vypůjčení";
                if (gridHistory.Columns["DueDate"] != null) gridHistory.Columns["DueDate"].HeaderText = "Termín vrácení";
                if (gridHistory.Columns["ReturnDate"] != null) gridHistory.Columns["ReturnDate"].HeaderText = "Skutečně vráceno";
                if (gridHistory.Columns["FineAmount"] != null) gridHistory.Columns["FineAmount"].HeaderText = "Pokuta (Kč)";

                // Automatické přizpůsobení šířky sloupců podle obsahu
                gridHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch { }
        }
    }
}