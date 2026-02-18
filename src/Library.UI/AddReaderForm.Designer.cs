namespace Library.UI
{
    partial class AddReaderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateBirth = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboGender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboEducation = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Labels & Inputs
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Text = "Jméno:";
            this.txtFirstName.Location = new System.Drawing.Point(150, 27); this.txtFirstName.Size = new System.Drawing.Size(200, 22);

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Text = "Příjmení:";
            this.txtLastName.Location = new System.Drawing.Point(150, 67); this.txtLastName.Size = new System.Drawing.Size(200, 22);

            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Text = "Email:";
            this.txtEmail.Location = new System.Drawing.Point(150, 107); this.txtEmail.Size = new System.Drawing.Size(200, 22);

            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(30, 150);
            this.label4.Text = "Datum narození:";
            this.dateBirth.Location = new System.Drawing.Point(150, 147); this.dateBirth.Size = new System.Drawing.Size(200, 22);
            this.dateBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(30, 190);
            this.label5.Text = "Pohlaví:";
            this.comboGender.Location = new System.Drawing.Point(150, 187); this.comboGender.Size = new System.Drawing.Size(200, 24);
            this.comboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGender.Items.AddRange(new object[] { "Muž", "Žena" });

            this.label6.AutoSize = true; this.label6.Location = new System.Drawing.Point(30, 230);
            this.label6.Text = "Vzdělání:";
            this.comboEducation.Location = new System.Drawing.Point(150, 227); this.comboEducation.Size = new System.Drawing.Size(200, 24);
            this.comboEducation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEducation.Items.AddRange(new object[] { "ZŠ", "SŠ", "VŠ" });

            this.btnSave.Location = new System.Drawing.Point(150, 280);
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.Text = "ULOŽIT";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Form settings
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comboEducation); this.Controls.Add(this.label6);
            this.Controls.Add(this.comboGender); this.Controls.Add(this.label5);
            this.Controls.Add(this.dateBirth); this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail); this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastName); this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName); this.Controls.Add(this.label1);
            this.Text = "Registrace čtenáře";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6;
        private System.Windows.Forms.TextBox txtFirstName, txtLastName, txtEmail;
        private System.Windows.Forms.DateTimePicker dateBirth;
        private System.Windows.Forms.ComboBox comboGender, comboEducation;
        private System.Windows.Forms.Button btnSave;
    }
}