namespace IS.Knihovna.UI.WinForms
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUzivatel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeslo = new System.Windows.Forms.TextBox();
            this.lblChyba = new System.Windows.Forms.Label();
            this.btnPrihlasit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Uživatelské jméno:";
            // 
            // txtUzivatel
            // 
            this.txtUzivatel.Location = new System.Drawing.Point(29, 55);
            this.txtUzivatel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtUzivatel.Name = "txtUzivatel";
            this.txtUzivatel.Size = new System.Drawing.Size(318, 29);
            this.txtUzivatel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Heslo:";
            // 
            // txtHeslo
            // 
            this.txtHeslo.Location = new System.Drawing.Point(29, 135);
            this.txtHeslo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtHeslo.Name = "txtHeslo";
            this.txtHeslo.PasswordChar = '•';
            this.txtHeslo.Size = new System.Drawing.Size(318, 29);
            this.txtHeslo.TabIndex = 3;
            // 
            // lblChyba
            // 
            this.lblChyba.AutoSize = true;
            this.lblChyba.ForeColor = System.Drawing.Color.Red;
            this.lblChyba.Location = new System.Drawing.Point(29, 177);
            this.lblChyba.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblChyba.Name = "lblChyba";
            this.lblChyba.Size = new System.Drawing.Size(243, 24);
            this.lblChyba.TabIndex = 4;
            this.lblChyba.Text = "Neplatné přihlašovací údaje";
            this.lblChyba.Visible = false;
            // 
            // btnPrihlasit
            // 
            this.btnPrihlasit.Location = new System.Drawing.Point(213, 225);
            this.btnPrihlasit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPrihlasit.Name = "btnPrihlasit";
            this.btnPrihlasit.Size = new System.Drawing.Size(138, 42);
            this.btnPrihlasit.TabIndex = 5;
            this.btnPrihlasit.Text = "Přihlásit se";
            this.btnPrihlasit.UseVisualStyleBackColor = true;
            this.btnPrihlasit.Click += new System.EventHandler(this.btnPrihlasit_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 311);
            this.Controls.Add(this.btnPrihlasit);
            this.Controls.Add(this.lblChyba);
            this.Controls.Add(this.txtHeslo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUzivatel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "LoginForm";
            this.Text = "Přihlášení knihovníka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUzivatel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeslo;
        private System.Windows.Forms.Label lblChyba;
        private System.Windows.Forms.Button btnPrihlasit;
    }
}