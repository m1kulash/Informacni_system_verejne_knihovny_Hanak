namespace Library.UI
{
    partial class AddBookForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboAuthor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboGenre = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboPublisher = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.Text = "Název knihy:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(150, 27);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 22);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.Text = "Rok vydání:";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(150, 68);
            this.numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 22);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.Text = "Autor:";
            // 
            // comboAuthor
            // 
            this.comboAuthor.FormattingEnabled = true;
            this.comboAuthor.Location = new System.Drawing.Point(150, 107);
            this.comboAuthor.Name = "comboAuthor";
            this.comboAuthor.Size = new System.Drawing.Size(200, 24);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.Text = "Žánr:";
            // 
            // comboGenre
            // 
            this.comboGenre.FormattingEnabled = true;
            this.comboGenre.Location = new System.Drawing.Point(150, 147);
            this.comboGenre.Name = "comboGenre";
            this.comboGenre.Size = new System.Drawing.Size(200, 24);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.Text = "Vydavatel:";
            // 
            // comboPublisher
            // 
            this.comboPublisher.FormattingEnabled = true;
            this.comboPublisher.Location = new System.Drawing.Point(150, 187);
            this.comboPublisher.Name = "comboPublisher";
            this.comboPublisher.Size = new System.Drawing.Size(200, 24);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.Text = "Popis:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(150, 227);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.Text = "ULOŽIT";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddBookForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboPublisher);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboGenre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboAuthor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Name = "AddBookForm";
            this.Text = "Přidat novou knihu";
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6;
        private System.Windows.Forms.TextBox txtTitle, txtDescription;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.ComboBox comboAuthor, comboGenre, comboPublisher;
        private System.Windows.Forms.Button btnSave;
    }
}