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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTituly = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTituly)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTituly
            // 
            this.dgvTituly.AllowUserToAddRows = false;
            this.dgvTituly.AllowUserToDeleteRows = false;
            this.dgvTituly.AllowUserToResizeRows = false;
            this.dgvTituly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTituly.BackgroundColor = System.Drawing.Color.White;
            this.dgvTituly.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTituly.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTituly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTituly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTituly.Location = new System.Drawing.Point(0, 0);
            this.dgvTituly.MultiSelect = false;
            this.dgvTituly.Name = "dgvTituly";
            this.dgvTituly.ReadOnly = true;
            this.dgvTituly.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTituly.Size = new System.Drawing.Size(800, 450);
            this.dgvTituly.TabIndex = 0;
            // 
            // TitulForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTituly);
            this.Name = "TitulForm";
            this.Text = "TitulForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTituly)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTituly;
    }
}