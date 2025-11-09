namespace IS.Knihovna.UI.WinForms
{
    partial class TitulForm
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
            this.btnPridat = new System.Windows.Forms.Button();
            this.btnUpravit = new System.Windows.Forms.Button();
            this.btnSmazat = new System.Windows.Forms.Button();
            this.btnVyhledat = new System.Windows.Forms.Button();
            this.btnObnovit = new System.Windows.Forms.Button();
            this.panelOvládání = new System.Windows.Forms.Panel();
            this.dgvTituly = new System.Windows.Forms.DataGridView();
            this.panelOvládání.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTituly)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPridat
            // 
            this.btnPridat.Location = new System.Drawing.Point(12, 12);
            this.btnPridat.Name = "btnPridat";
            this.btnPridat.Size = new System.Drawing.Size(75, 23);
            this.btnPridat.TabIndex = 8;
            this.btnPridat.Text = "Přidat";
            this.btnPridat.UseVisualStyleBackColor = true;
            this.btnPridat.Click += new System.EventHandler(this.btnPridat_Click);
            // 
            // btnUpravit
            // 
            this.btnUpravit.Location = new System.Drawing.Point(94, 12);
            this.btnUpravit.Name = "btnUpravit";
            this.btnUpravit.Size = new System.Drawing.Size(75, 23);
            this.btnUpravit.TabIndex = 9;
            this.btnUpravit.Text = "Upravit";
            this.btnUpravit.UseVisualStyleBackColor = true;
            this.btnUpravit.Click += new System.EventHandler(this.btnUpravit_Click);
            // 
            // btnSmazat
            // 
            this.btnSmazat.Location = new System.Drawing.Point(176, 12);
            this.btnSmazat.Name = "btnSmazat";
            this.btnSmazat.Size = new System.Drawing.Size(75, 23);
            this.btnSmazat.TabIndex = 10;
            this.btnSmazat.Text = "Smazat";
            this.btnSmazat.UseVisualStyleBackColor = true;
            this.btnSmazat.Click += new System.EventHandler(this.btnSmazat_Click);
            // 
            // btnVyhledat
            // 
            this.btnVyhledat.Location = new System.Drawing.Point(258, 11);
            this.btnVyhledat.Name = "btnVyhledat";
            this.btnVyhledat.Size = new System.Drawing.Size(75, 23);
            this.btnVyhledat.TabIndex = 11;
            this.btnVyhledat.Text = "Vyhledat";
            this.btnVyhledat.UseVisualStyleBackColor = true;
            this.btnVyhledat.Click += new System.EventHandler(this.btnVyhledat_Click);
            // 
            // btnObnovit
            // 
            this.btnObnovit.Location = new System.Drawing.Point(340, 11);
            this.btnObnovit.Name = "btnObnovit";
            this.btnObnovit.Size = new System.Drawing.Size(75, 23);
            this.btnObnovit.TabIndex = 12;
            this.btnObnovit.Text = "Obnovit";
            this.btnObnovit.UseVisualStyleBackColor = true;
            this.btnObnovit.Click += new System.EventHandler(this.btnObnovit_Click);
            // 
            // panelOvládání
            // 
            this.panelOvládání.Controls.Add(this.btnObnovit);
            this.panelOvládání.Controls.Add(this.btnVyhledat);
            this.panelOvládání.Controls.Add(this.btnSmazat);
            this.panelOvládání.Controls.Add(this.btnUpravit);
            this.panelOvládání.Controls.Add(this.btnPridat);
            this.panelOvládání.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOvládání.Location = new System.Drawing.Point(0, 0);
            this.panelOvládání.Name = "panelOvládání";
            this.panelOvládání.Size = new System.Drawing.Size(439, 46);
            this.panelOvládání.TabIndex = 14;
            // 
            // dgvTituly
            // 
            this.dgvTituly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTituly.BackgroundColor = System.Drawing.Color.White;
            this.dgvTituly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTituly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTituly.Location = new System.Drawing.Point(0, 46);
            this.dgvTituly.Name = "dgvTituly";
            this.dgvTituly.ReadOnly = true;
            this.dgvTituly.RowHeadersVisible = false;
            this.dgvTituly.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTituly.Size = new System.Drawing.Size(439, 336);
            this.dgvTituly.TabIndex = 15;
            // 
            // TitulForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 382);
            this.Controls.Add(this.dgvTituly);
            this.Controls.Add(this.panelOvládání);
            this.Name = "TitulForm";
            this.Text = "TitulForm";
            this.panelOvládání.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTituly)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPridat;
        private System.Windows.Forms.Button btnUpravit;
        private System.Windows.Forms.Button btnSmazat;
        private System.Windows.Forms.Button btnVyhledat;
        private System.Windows.Forms.Button btnObnovit;
        private System.Windows.Forms.Panel panelOvládání;
        private System.Windows.Forms.DataGridView dgvTituly;
    }
}