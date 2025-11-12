namespace IS.Knihovna.UI.WinForms
{
    partial class RezervaceForm
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
            this.btnObnovit = new System.Windows.Forms.Button();
            this.btnVyhledat = new System.Windows.Forms.Button();
            this.btnSmazat = new System.Windows.Forms.Button();
            this.btnUpravit = new System.Windows.Forms.Button();
            this.btnPridat = new System.Windows.Forms.Button();
            this.dgvTituly = new System.Windows.Forms.DataGridView();
            this.panelOvládání = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTituly)).BeginInit();
            this.panelOvládání.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "🕒 Rezervace titulů";
            // 
            // btnObnovit
            // 
            this.btnObnovit.Location = new System.Drawing.Point(340, 32);
            this.btnObnovit.Name = "btnObnovit";
            this.btnObnovit.Size = new System.Drawing.Size(75, 23);
            this.btnObnovit.TabIndex = 12;
            this.btnObnovit.Text = "Obnovit";
            this.btnObnovit.UseVisualStyleBackColor = true;
            this.btnObnovit.Click += new System.EventHandler(this.btnObnovit_Click);
            // 
            // btnVyhledat
            // 
            this.btnVyhledat.Location = new System.Drawing.Point(258, 32);
            this.btnVyhledat.Name = "btnVyhledat";
            this.btnVyhledat.Size = new System.Drawing.Size(75, 23);
            this.btnVyhledat.TabIndex = 11;
            this.btnVyhledat.Text = "Vyhledat";
            this.btnVyhledat.UseVisualStyleBackColor = true;
            this.btnVyhledat.Click += new System.EventHandler(this.btnVyhledat_Click);
            // 
            // btnSmazat
            // 
            this.btnSmazat.Location = new System.Drawing.Point(176, 33);
            this.btnSmazat.Name = "btnSmazat";
            this.btnSmazat.Size = new System.Drawing.Size(75, 23);
            this.btnSmazat.TabIndex = 10;
            this.btnSmazat.Text = "Smazat";
            this.btnSmazat.UseVisualStyleBackColor = true;
            this.btnSmazat.Click += new System.EventHandler(this.btnSmazat_Click);
            // 
            // btnUpravit
            // 
            this.btnUpravit.Location = new System.Drawing.Point(94, 33);
            this.btnUpravit.Name = "btnUpravit";
            this.btnUpravit.Size = new System.Drawing.Size(75, 23);
            this.btnUpravit.TabIndex = 9;
            this.btnUpravit.Text = "Upravit";
            this.btnUpravit.UseVisualStyleBackColor = true;
            this.btnUpravit.Click += new System.EventHandler(this.btnUpravit_Click);
            // 
            // btnPridat
            // 
            this.btnPridat.Location = new System.Drawing.Point(12, 33);
            this.btnPridat.Name = "btnPridat";
            this.btnPridat.Size = new System.Drawing.Size(75, 23);
            this.btnPridat.TabIndex = 8;
            this.btnPridat.Text = "Přidat";
            this.btnPridat.UseVisualStyleBackColor = true;
            this.btnPridat.Click += new System.EventHandler(this.btnPridat_Click);
            // 
            // dgvTituly
            // 
            this.dgvTituly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTituly.BackgroundColor = System.Drawing.Color.White;
            this.dgvTituly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTituly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTituly.Location = new System.Drawing.Point(0, 62);
            this.dgvTituly.Name = "dgvTituly";
            this.dgvTituly.ReadOnly = true;
            this.dgvTituly.RowHeadersVisible = false;
            this.dgvTituly.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTituly.Size = new System.Drawing.Size(462, 267);
            this.dgvTituly.TabIndex = 21;
            // 
            // panelOvládání
            // 
            this.panelOvládání.Controls.Add(this.label1);
            this.panelOvládání.Controls.Add(this.btnObnovit);
            this.panelOvládání.Controls.Add(this.btnVyhledat);
            this.panelOvládání.Controls.Add(this.btnSmazat);
            this.panelOvládání.Controls.Add(this.btnUpravit);
            this.panelOvládání.Controls.Add(this.btnPridat);
            this.panelOvládání.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOvládání.Location = new System.Drawing.Point(0, 0);
            this.panelOvládání.Name = "panelOvládání";
            this.panelOvládání.Size = new System.Drawing.Size(462, 62);
            this.panelOvládání.TabIndex = 20;
            // 
            // RezervaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 329);
            this.Controls.Add(this.dgvTituly);
            this.Controls.Add(this.panelOvládání);
            this.Name = "RezervaceForm";
            this.Text = "RezervaceForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTituly)).EndInit();
            this.panelOvládání.ResumeLayout(false);
            this.panelOvládání.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnObnovit;
        private System.Windows.Forms.Button btnVyhledat;
        private System.Windows.Forms.Button btnSmazat;
        private System.Windows.Forms.Button btnUpravit;
        private System.Windows.Forms.Button btnPridat;
        private System.Windows.Forms.DataGridView dgvTituly;
        private System.Windows.Forms.Panel panelOvládání;
    }
}