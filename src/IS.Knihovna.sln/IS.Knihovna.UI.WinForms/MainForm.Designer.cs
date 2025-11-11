namespace IS.Knihovna.UI.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelObsah = new System.Windows.Forms.Panel();
            this.btnOdhlasit = new System.Windows.Forms.Button();
            this.btnStatistiky = new System.Windows.Forms.Button();
            this.btnUpominky = new System.Windows.Forms.Button();
            this.btnRezervace = new System.Windows.Forms.Button();
            this.btnVypujcky = new System.Windows.Forms.Button();
            this.btnCtenari = new System.Windows.Forms.Button();
            this.btnKnihy = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.LightGray;
            this.panelMenu.Controls.Add(this.btnOdhlasit);
            this.panelMenu.Controls.Add(this.btnStatistiky);
            this.panelMenu.Controls.Add(this.btnUpominky);
            this.panelMenu.Controls.Add(this.btnRezervace);
            this.panelMenu.Controls.Add(this.btnVypujcky);
            this.panelMenu.Controls.Add(this.btnCtenari);
            this.panelMenu.Controls.Add(this.btnKnihy);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 545);
            this.panelMenu.TabIndex = 1;
            // 
            // panelObsah
            // 
            this.panelObsah.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelObsah.Location = new System.Drawing.Point(200, 0);
            this.panelObsah.Name = "panelObsah";
            this.panelObsah.Size = new System.Drawing.Size(808, 545);
            this.panelObsah.TabIndex = 2;
            // 
            // btnOdhlasit
            // 
            this.btnOdhlasit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdhlasit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdhlasit.Image = global::IS.Knihovna.UI.WinForms.Properties.Resources.logout;
            this.btnOdhlasit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOdhlasit.Location = new System.Drawing.Point(12, 282);
            this.btnOdhlasit.Name = "btnOdhlasit";
            this.btnOdhlasit.Size = new System.Drawing.Size(182, 39);
            this.btnOdhlasit.TabIndex = 6;
            this.btnOdhlasit.Text = "Odhlásit se";
            this.btnOdhlasit.UseVisualStyleBackColor = true;
            this.btnOdhlasit.Click += new System.EventHandler(this.btnOdhlasit_Click);
            // 
            // btnStatistiky
            // 
            this.btnStatistiky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistiky.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStatistiky.Image = global::IS.Knihovna.UI.WinForms.Properties.Resources.graph;
            this.btnStatistiky.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistiky.Location = new System.Drawing.Point(12, 237);
            this.btnStatistiky.Name = "btnStatistiky";
            this.btnStatistiky.Size = new System.Drawing.Size(182, 39);
            this.btnStatistiky.TabIndex = 5;
            this.btnStatistiky.Text = "Statistiky";
            this.btnStatistiky.UseVisualStyleBackColor = true;
            this.btnStatistiky.Click += new System.EventHandler(this.btnStatistiky_Click);
            // 
            // btnUpominky
            // 
            this.btnUpominky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpominky.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUpominky.Image = global::IS.Knihovna.UI.WinForms.Properties.Resources.bell;
            this.btnUpominky.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpominky.Location = new System.Drawing.Point(12, 192);
            this.btnUpominky.Name = "btnUpominky";
            this.btnUpominky.Size = new System.Drawing.Size(182, 39);
            this.btnUpominky.TabIndex = 4;
            this.btnUpominky.Text = "Upomínky";
            this.btnUpominky.UseVisualStyleBackColor = true;
            this.btnUpominky.Click += new System.EventHandler(this.btnUpominky_Click);
            // 
            // btnRezervace
            // 
            this.btnRezervace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRezervace.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRezervace.Image = global::IS.Knihovna.UI.WinForms.Properties.Resources.booking;
            this.btnRezervace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRezervace.Location = new System.Drawing.Point(12, 147);
            this.btnRezervace.Name = "btnRezervace";
            this.btnRezervace.Size = new System.Drawing.Size(182, 39);
            this.btnRezervace.TabIndex = 3;
            this.btnRezervace.Text = "Rezervace";
            this.btnRezervace.UseVisualStyleBackColor = true;
            this.btnRezervace.Click += new System.EventHandler(this.btnRezervace_Click);
            // 
            // btnVypujcky
            // 
            this.btnVypujcky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVypujcky.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVypujcky.Image = global::IS.Knihovna.UI.WinForms.Properties.Resources.borrowing;
            this.btnVypujcky.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVypujcky.Location = new System.Drawing.Point(12, 102);
            this.btnVypujcky.Name = "btnVypujcky";
            this.btnVypujcky.Size = new System.Drawing.Size(182, 39);
            this.btnVypujcky.TabIndex = 2;
            this.btnVypujcky.Text = "Výpůjčky";
            this.btnVypujcky.UseVisualStyleBackColor = true;
            this.btnVypujcky.Click += new System.EventHandler(this.btnVypujcky_Click);
            // 
            // btnCtenari
            // 
            this.btnCtenari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCtenari.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCtenari.Image = global::IS.Knihovna.UI.WinForms.Properties.Resources.users;
            this.btnCtenari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCtenari.Location = new System.Drawing.Point(12, 57);
            this.btnCtenari.Name = "btnCtenari";
            this.btnCtenari.Size = new System.Drawing.Size(182, 39);
            this.btnCtenari.TabIndex = 1;
            this.btnCtenari.Text = "Čtenáři";
            this.btnCtenari.UseVisualStyleBackColor = true;
            this.btnCtenari.Click += new System.EventHandler(this.btnCtenari_Click);
            // 
            // btnKnihy
            // 
            this.btnKnihy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKnihy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKnihy.Image = global::IS.Knihovna.UI.WinForms.Properties.Resources.book;
            this.btnKnihy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKnihy.Location = new System.Drawing.Point(12, 12);
            this.btnKnihy.Name = "btnKnihy";
            this.btnKnihy.Size = new System.Drawing.Size(182, 39);
            this.btnKnihy.TabIndex = 0;
            this.btnKnihy.Text = "Knihy";
            this.btnKnihy.UseVisualStyleBackColor = true;
            this.btnKnihy.Click += new System.EventHandler(this.btnKnihy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 545);
            this.Controls.Add(this.panelObsah);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainForm";
            this.Text = "Hlavní okno";
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnKnihy;
        private System.Windows.Forms.Panel panelObsah;
        private System.Windows.Forms.Button btnCtenari;
        private System.Windows.Forms.Button btnVypujcky;
        private System.Windows.Forms.Button btnRezervace;
        private System.Windows.Forms.Button btnUpominky;
        private System.Windows.Forms.Button btnStatistiky;
        private System.Windows.Forms.Button btnOdhlasit;
    }
}