namespace IS.Knihovna.UI.WinForms
{
    partial class StatistikyForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelOvládání = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnObnovit = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelOvládání.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOvládání
            // 
            this.panelOvládání.Controls.Add(this.label1);
            this.panelOvládání.Controls.Add(this.btnObnovit);
            this.panelOvládání.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOvládání.Location = new System.Drawing.Point(0, 0);
            this.panelOvládání.Name = "panelOvládání";
            this.panelOvládání.Size = new System.Drawing.Size(800, 62);
            this.panelOvládání.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "📊 Statistiky a přehledy";
            // 
            // btnObnovit
            // 
            this.btnObnovit.Location = new System.Drawing.Point(12, 33);
            this.btnObnovit.Name = "btnObnovit";
            this.btnObnovit.Size = new System.Drawing.Size(75, 23);
            this.btnObnovit.TabIndex = 12;
            this.btnObnovit.Text = "Obnovit";
            this.btnObnovit.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 62);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(800, 388);
            this.chart1.TabIndex = 16;
            this.chart1.Text = "chart1";
            // 
            // StatistikyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panelOvládání);
            this.Name = "StatistikyForm";
            this.Text = "StatistikyForm";
            this.panelOvládání.ResumeLayout(false);
            this.panelOvládání.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOvládání;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnObnovit;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}