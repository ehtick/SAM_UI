﻿namespace SAM.Core.Mollier.UI.Controls
{
    partial class MollierControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MollierChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.MollierChart)).BeginInit();
            this.SuspendLayout();
            // 
            // MollierChart
            // 
            chartArea2.Name = "ChartArea1";
            this.MollierChart.ChartAreas.Add(chartArea2);
            this.MollierChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.MollierChart.Legends.Add(legend2);
            this.MollierChart.Location = new System.Drawing.Point(0, 0);
            this.MollierChart.Name = "MollierChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.MollierChart.Series.Add(series2);
            this.MollierChart.Size = new System.Drawing.Size(816, 588);
            this.MollierChart.TabIndex = 0;
            this.MollierChart.Text = "chart1";
            // 
            // MollierControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MollierChart);
            this.Name = "MollierControl";
            this.Size = new System.Drawing.Size(816, 588);
            this.Load += new System.EventHandler(this.MollierControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MollierChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MollierChart;
    }
}