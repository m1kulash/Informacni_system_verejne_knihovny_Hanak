namespace Library.UI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.chartBooks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblStatsFines = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStatsLoans = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStatsReaders = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatsBooks = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefreshDashboard = new System.Windows.Forms.Button();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.lblSearchBooks = new System.Windows.Forms.Label();
            this.txtSearchBooks = new System.Windows.Forms.TextBox();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnLoadBooks = new System.Windows.Forms.Button();
            this.gridBooks = new System.Windows.Forms.DataGridView();
            this.tabReaders = new System.Windows.Forms.TabPage();
            this.lblSearchReaders = new System.Windows.Forms.Label();
            this.txtSearchReaders = new System.Windows.Forms.TextBox();
            this.btnAddReader = new System.Windows.Forms.Button();
            this.btnLoadReaders = new System.Windows.Forms.Button();
            this.gridReaders = new System.Windows.Forms.DataGridView();
            this.tabLoans = new System.Windows.Forms.TabPage();
            this.btnReminders = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.gridLoans = new System.Windows.Forms.DataGridView();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboLoanBook = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLoanReader = new System.Windows.Forms.ComboBox();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.btnRefreshHistory = new System.Windows.Forms.Button();
            this.gridHistory = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBooks)).BeginInit();
            this.tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).BeginInit();
            this.tabReaders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReaders)).BeginInit();
            this.tabLoans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoans)).BeginInit();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDashboard);
            this.tabControl1.Controls.Add(this.tabBooks);
            this.tabControl1.Controls.Add(this.tabReaders);
            this.tabControl1.Controls.Add(this.tabLoans);
            this.tabControl1.Controls.Add(this.tabHistory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 500);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabDashboard
            // 
            this.tabDashboard.Controls.Add(this.chartBooks);
            this.tabDashboard.Controls.Add(this.lblStatsFines);
            this.tabDashboard.Controls.Add(this.label8);
            this.tabDashboard.Controls.Add(this.lblStatsLoans);
            this.tabDashboard.Controls.Add(this.label6);
            this.tabDashboard.Controls.Add(this.lblStatsReaders);
            this.tabDashboard.Controls.Add(this.label4);
            this.tabDashboard.Controls.Add(this.lblStatsBooks);
            this.tabDashboard.Controls.Add(this.label3);
            this.tabDashboard.Controls.Add(this.btnRefreshDashboard);
            this.tabDashboard.Location = new System.Drawing.Point(4, 25);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(892, 471);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "Přehled (Dashboard)";
            this.tabDashboard.UseVisualStyleBackColor = true;
            // 
            // chartBooks
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBooks.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBooks.Legends.Add(legend1);
            this.chartBooks.Location = new System.Drawing.Point(500, 120);
            this.chartBooks.Name = "chartBooks";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBooks.Series.Add(series1);
            this.chartBooks.Size = new System.Drawing.Size(350, 300);
            this.chartBooks.TabIndex = 9;
            this.chartBooks.Text = "chart1";
            // 
            // lblStatsFines
            // 
            this.lblStatsFines.AutoSize = true;
            this.lblStatsFines.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatsFines.ForeColor = System.Drawing.Color.Red;
            this.lblStatsFines.Location = new System.Drawing.Point(300, 210);
            this.lblStatsFines.Name = "lblStatsFines";
            this.lblStatsFines.Size = new System.Drawing.Size(89, 39);
            this.lblStatsFines.TabIndex = 0;
            this.lblStatsFines.Text = "0 Kč";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(300, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "Vybrané pokuty:";
            // 
            // lblStatsLoans
            // 
            this.lblStatsLoans.AutoSize = true;
            this.lblStatsLoans.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatsLoans.ForeColor = System.Drawing.Color.Orange;
            this.lblStatsLoans.Location = new System.Drawing.Point(50, 210);
            this.lblStatsLoans.Name = "lblStatsLoans";
            this.lblStatsLoans.Size = new System.Drawing.Size(37, 39);
            this.lblStatsLoans.TabIndex = 2;
            this.lblStatsLoans.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(50, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "Aktuálně půjčeno:";
            // 
            // lblStatsReaders
            // 
            this.lblStatsReaders.AutoSize = true;
            this.lblStatsReaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatsReaders.ForeColor = System.Drawing.Color.Green;
            this.lblStatsReaders.Location = new System.Drawing.Point(300, 80);
            this.lblStatsReaders.Name = "lblStatsReaders";
            this.lblStatsReaders.Size = new System.Drawing.Size(37, 39);
            this.lblStatsReaders.TabIndex = 4;
            this.lblStatsReaders.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(300, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Počet čtenářů:";
            // 
            // lblStatsBooks
            // 
            this.lblStatsBooks.AutoSize = true;
            this.lblStatsBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatsBooks.ForeColor = System.Drawing.Color.Blue;
            this.lblStatsBooks.Location = new System.Drawing.Point(50, 80);
            this.lblStatsBooks.Name = "lblStatsBooks";
            this.lblStatsBooks.Size = new System.Drawing.Size(37, 39);
            this.lblStatsBooks.TabIndex = 6;
            this.lblStatsBooks.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(50, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Počet knih:";
            // 
            // btnRefreshDashboard
            // 
            this.btnRefreshDashboard.Location = new System.Drawing.Point(550, 50);
            this.btnRefreshDashboard.Name = "btnRefreshDashboard";
            this.btnRefreshDashboard.Size = new System.Drawing.Size(150, 50);
            this.btnRefreshDashboard.TabIndex = 8;
            this.btnRefreshDashboard.Text = "🔄 Aktualizovat";
            this.btnRefreshDashboard.Click += new System.EventHandler(this.btnRefreshDashboard_Click);
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.btnDeleteBook);
            this.tabBooks.Controls.Add(this.lblSearchBooks);
            this.tabBooks.Controls.Add(this.txtSearchBooks);
            this.tabBooks.Controls.Add(this.btnAddBook);
            this.tabBooks.Controls.Add(this.btnLoadBooks);
            this.tabBooks.Controls.Add(this.gridBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 25);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabBooks.Size = new System.Drawing.Size(892, 471);
            this.tabBooks.TabIndex = 1;
            this.tabBooks.Text = "Knihy";
            this.tabBooks.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteBook.Location = new System.Drawing.Point(340, 15);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteBook.TabIndex = 5;
            this.btnDeleteBook.Text = "🗑️ Odstranit knihu";
            this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
            // 
            // lblSearchBooks
            // 
            this.lblSearchBooks.AutoSize = true;
            this.lblSearchBooks.Location = new System.Drawing.Point(530, 27);
            this.lblSearchBooks.Name = "lblSearchBooks";
            this.lblSearchBooks.Size = new System.Drawing.Size(53, 17);
            this.lblSearchBooks.TabIndex = 0;
            this.lblSearchBooks.Text = "Hledat:";
            // 
            // txtSearchBooks
            // 
            this.txtSearchBooks.Location = new System.Drawing.Point(590, 24);
            this.txtSearchBooks.Name = "txtSearchBooks";
            this.txtSearchBooks.Size = new System.Drawing.Size(200, 22);
            this.txtSearchBooks.TabIndex = 1;
            this.txtSearchBooks.TextChanged += new System.EventHandler(this.txtSearchBooks_TextChanged);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(180, 15);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(150, 40);
            this.btnAddBook.TabIndex = 2;
            this.btnAddBook.Text = "+ Přidat knihu";
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnLoadBooks
            // 
            this.btnLoadBooks.Location = new System.Drawing.Point(15, 15);
            this.btnLoadBooks.Name = "btnLoadBooks";
            this.btnLoadBooks.Size = new System.Drawing.Size(150, 40);
            this.btnLoadBooks.TabIndex = 3;
            this.btnLoadBooks.Text = "Obnovit knihy";
            this.btnLoadBooks.Click += new System.EventHandler(this.btnLoadBooks_Click);
            // 
            // gridBooks
            // 
            this.gridBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBooks.Location = new System.Drawing.Point(6, 70);
            this.gridBooks.Name = "gridBooks";
            this.gridBooks.RowHeadersWidth = 51;
            this.gridBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridBooks.Size = new System.Drawing.Size(880, 395);
            this.gridBooks.TabIndex = 4;
            // 
            // tabReaders
            // 
            this.tabReaders.Controls.Add(this.lblSearchReaders);
            this.tabReaders.Controls.Add(this.txtSearchReaders);
            this.tabReaders.Controls.Add(this.btnAddReader);
            this.tabReaders.Controls.Add(this.btnLoadReaders);
            this.tabReaders.Controls.Add(this.gridReaders);
            this.tabReaders.Location = new System.Drawing.Point(4, 25);
            this.tabReaders.Name = "tabReaders";
            this.tabReaders.Padding = new System.Windows.Forms.Padding(3);
            this.tabReaders.Size = new System.Drawing.Size(892, 471);
            this.tabReaders.TabIndex = 2;
            this.tabReaders.Text = "Čtenáři";
            this.tabReaders.UseVisualStyleBackColor = true;
            // 
            // lblSearchReaders
            // 
            this.lblSearchReaders.AutoSize = true;
            this.lblSearchReaders.Location = new System.Drawing.Point(400, 27);
            this.lblSearchReaders.Name = "lblSearchReaders";
            this.lblSearchReaders.Size = new System.Drawing.Size(53, 17);
            this.lblSearchReaders.TabIndex = 0;
            this.lblSearchReaders.Text = "Hledat:";
            // 
            // txtSearchReaders
            // 
            this.txtSearchReaders.Location = new System.Drawing.Point(460, 24);
            this.txtSearchReaders.Name = "txtSearchReaders";
            this.txtSearchReaders.Size = new System.Drawing.Size(200, 22);
            this.txtSearchReaders.TabIndex = 1;
            this.txtSearchReaders.TextChanged += new System.EventHandler(this.txtSearchReaders_TextChanged);
            // 
            // btnAddReader
            // 
            this.btnAddReader.Location = new System.Drawing.Point(180, 15);
            this.btnAddReader.Name = "btnAddReader";
            this.btnAddReader.Size = new System.Drawing.Size(150, 40);
            this.btnAddReader.TabIndex = 2;
            this.btnAddReader.Text = "+ Registrovat čtenáře";
            this.btnAddReader.Click += new System.EventHandler(this.btnAddReader_Click);
            // 
            // btnLoadReaders
            // 
            this.btnLoadReaders.Location = new System.Drawing.Point(15, 15);
            this.btnLoadReaders.Name = "btnLoadReaders";
            this.btnLoadReaders.Size = new System.Drawing.Size(150, 40);
            this.btnLoadReaders.TabIndex = 3;
            this.btnLoadReaders.Text = "Obnovit čtenáře";
            this.btnLoadReaders.Click += new System.EventHandler(this.btnLoadReaders_Click);
            // 
            // gridReaders
            // 
            this.gridReaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridReaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReaders.Location = new System.Drawing.Point(6, 70);
            this.gridReaders.Name = "gridReaders";
            this.gridReaders.RowHeadersWidth = 51;
            this.gridReaders.Size = new System.Drawing.Size(880, 395);
            this.gridReaders.TabIndex = 4;
            // 
            // tabLoans
            // 
            this.tabLoans.Controls.Add(this.btnReminders);
            this.tabLoans.Controls.Add(this.btnReturn);
            this.tabLoans.Controls.Add(this.gridLoans);
            this.tabLoans.Controls.Add(this.btnBorrow);
            this.tabLoans.Controls.Add(this.label2);
            this.tabLoans.Controls.Add(this.comboLoanBook);
            this.tabLoans.Controls.Add(this.label1);
            this.tabLoans.Controls.Add(this.comboLoanReader);
            this.tabLoans.Location = new System.Drawing.Point(4, 25);
            this.tabLoans.Name = "tabLoans";
            this.tabLoans.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoans.Size = new System.Drawing.Size(892, 471);
            this.tabLoans.TabIndex = 3;
            this.tabLoans.Text = "Výpůjční pult";
            this.tabLoans.UseVisualStyleBackColor = true;
            // 
            // btnReminders
            // 
            this.btnReminders.Location = new System.Drawing.Point(580, 30);
            this.btnReminders.Name = "btnReminders";
            this.btnReminders.Size = new System.Drawing.Size(200, 30);
            this.btnReminders.TabIndex = 7;
            this.btnReminders.Text = "🔔 Vygenerovať upomienky";
            this.btnReminders.UseVisualStyleBackColor = true;
            this.btnReminders.Click += new System.EventHandler(this.btnReminders_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Location = new System.Drawing.Point(740, 420);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(130, 40);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "Vrátit vybranou";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // gridLoans
            // 
            this.gridLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLoans.Location = new System.Drawing.Point(6, 80);
            this.gridLoans.Name = "gridLoans";
            this.gridLoans.RowHeadersWidth = 51;
            this.gridLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLoans.Size = new System.Drawing.Size(880, 320);
            this.gridLoans.TabIndex = 1;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(450, 30);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(120, 30);
            this.btnBorrow.TabIndex = 2;
            this.btnBorrow.Text = "Půjčit";
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kniha:";
            // 
            // comboLoanBook
            // 
            this.comboLoanBook.FormattingEnabled = true;
            this.comboLoanBook.Location = new System.Drawing.Point(230, 35);
            this.comboLoanBook.Name = "comboLoanBook";
            this.comboLoanBook.Size = new System.Drawing.Size(200, 24);
            this.comboLoanBook.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Čtenář:";
            // 
            // comboLoanReader
            // 
            this.comboLoanReader.FormattingEnabled = true;
            this.comboLoanReader.Location = new System.Drawing.Point(15, 35);
            this.comboLoanReader.Name = "comboLoanReader";
            this.comboLoanReader.Size = new System.Drawing.Size(200, 24);
            this.comboLoanReader.TabIndex = 6;
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.btnRefreshHistory);
            this.tabHistory.Controls.Add(this.gridHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 25);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(892, 471);
            this.tabHistory.TabIndex = 4;
            this.tabHistory.Text = "Historie";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // btnRefreshHistory
            // 
            this.btnRefreshHistory.Location = new System.Drawing.Point(15, 15);
            this.btnRefreshHistory.Name = "btnRefreshHistory";
            this.btnRefreshHistory.Size = new System.Drawing.Size(150, 40);
            this.btnRefreshHistory.TabIndex = 0;
            this.btnRefreshHistory.Text = "Obnovit historii";
            this.btnRefreshHistory.Click += new System.EventHandler(this.btnRefreshHistory_Click);
            // 
            // gridHistory
            // 
            this.gridHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistory.Location = new System.Drawing.Point(6, 70);
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.ReadOnly = true;
            this.gridHistory.RowHeadersWidth = 51;
            this.gridHistory.Size = new System.Drawing.Size(880, 395);
            this.gridHistory.TabIndex = 1;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Informační Systém Veřejné Knihovny";
            this.tabControl1.ResumeLayout(false);
            this.tabDashboard.ResumeLayout(false);
            this.tabDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBooks)).EndInit();
            this.tabBooks.ResumeLayout(false);
            this.tabBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).EndInit();
            this.tabReaders.ResumeLayout(false);
            this.tabReaders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReaders)).EndInit();
            this.tabLoans.ResumeLayout(false);
            this.tabLoans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoans)).EndInit();
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.Label lblStatsBooks;
        private System.Windows.Forms.Label lblStatsReaders;
        private System.Windows.Forms.Label lblStatsLoans;
        private System.Windows.Forms.Label lblStatsFines;
        private System.Windows.Forms.Label label3, label4, label6, label8;
        private System.Windows.Forms.Button btnRefreshDashboard;

        // --- NOVÉ: Pridaný graf ---
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBooks;

        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.TabPage tabReaders;
        private System.Windows.Forms.TabPage tabLoans;
        private System.Windows.Forms.TabPage tabHistory;

        private System.Windows.Forms.DataGridView gridBooks;
        private System.Windows.Forms.Button btnLoadBooks;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.DataGridView gridReaders;
        private System.Windows.Forms.Button btnLoadReaders;
        private System.Windows.Forms.Button btnAddReader;
        private System.Windows.Forms.ComboBox comboLoanReader;
        private System.Windows.Forms.ComboBox comboLoanBook;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.DataGridView gridLoans;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchBooks;
        private System.Windows.Forms.Label lblSearchBooks;
        private System.Windows.Forms.TextBox txtSearchReaders;
        private System.Windows.Forms.Label lblSearchReaders;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.Button btnRefreshHistory;
        private System.Windows.Forms.Button btnDeleteBook;

        // --- NOVÉ: Pridané tlačidlo upomienok ---
        private System.Windows.Forms.Button btnReminders;
    }
}