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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MollierChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ContextMenuStrip_Chart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ProcessesAndPoints = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Selection = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_Edit = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Remove = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MollierChart)).BeginInit();
            this.ContextMenuStrip_Chart.SuspendLayout();
            this.SuspendLayout();
            // 
            // MollierChart
            // 
            chartArea1.Name = "ChartArea1";
            this.MollierChart.ChartAreas.Add(chartArea1);
            this.MollierChart.ContextMenuStrip = this.ContextMenuStrip_Chart;
            this.MollierChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.MollierChart.Legends.Add(legend1);
            this.MollierChart.Location = new System.Drawing.Point(0, 0);
            this.MollierChart.Name = "MollierChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.MollierChart.Series.Add(series1);
            this.MollierChart.Size = new System.Drawing.Size(816, 588);
            this.MollierChart.TabIndex = 0;
            this.MollierChart.Text = "Mollier Chart";
            this.MollierChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MollierChart_MouseClick);
            this.MollierChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MollierChart_MouseDown);
            this.MollierChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MollierChart_MouseMove);
            this.MollierChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MollierChart_MouseUp);
            // 
            // ContextMenuStrip_Chart
            // 
            this.ContextMenuStrip_Chart.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuStrip_Chart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Zoom,
            this.ToolStripSeparator_Edit,
            this.ToolStripMenuItem_Edit,
            this.ToolStripMenuItem_Remove});
            this.ContextMenuStrip_Chart.Name = "ContextMenuStrip_Chart";
            this.ContextMenuStrip_Chart.Size = new System.Drawing.Size(211, 110);
            this.ContextMenuStrip_Chart.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Chart_Opening);
            // 
            // ToolStripMenuItem_Zoom
            // 
            this.ToolStripMenuItem_Zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ProcessesAndPoints,
            this.ToolStripMenuItem_Selection,
            this.ToolStripMenuItem_Reset});
            this.ToolStripMenuItem_Zoom.Name = "ToolStripMenuItem_Zoom";
            this.ToolStripMenuItem_Zoom.Size = new System.Drawing.Size(210, 24);
            this.ToolStripMenuItem_Zoom.Text = "Zoom";
            // 
            // ToolStripMenuItem_ProcessesAndPoints
            // 
            this.ToolStripMenuItem_ProcessesAndPoints.Name = "ToolStripMenuItem_ProcessesAndPoints";
            this.ToolStripMenuItem_ProcessesAndPoints.Size = new System.Drawing.Size(227, 26);
            this.ToolStripMenuItem_ProcessesAndPoints.Text = "Processes and Points";
            this.ToolStripMenuItem_ProcessesAndPoints.Click += new System.EventHandler(this.ToolStripMenuItem_ProcessesAndPoints_Click);
            // 
            // ToolStripMenuItem_Selection
            // 
            this.ToolStripMenuItem_Selection.Name = "ToolStripMenuItem_Selection";
            this.ToolStripMenuItem_Selection.Size = new System.Drawing.Size(227, 26);
            this.ToolStripMenuItem_Selection.Text = "Selection";
            this.ToolStripMenuItem_Selection.Click += new System.EventHandler(this.ToolStripMenuItem_Selection_Click);
            // 
            // ToolStripMenuItem_Reset
            // 
            this.ToolStripMenuItem_Reset.Name = "ToolStripMenuItem_Reset";
            this.ToolStripMenuItem_Reset.Size = new System.Drawing.Size(227, 26);
            this.ToolStripMenuItem_Reset.Text = "Zoom reset";
            this.ToolStripMenuItem_Reset.Click += new System.EventHandler(this.ToolStripMenuItem_Reset_Click);
            // 
            // ToolStripSeparator_Edit
            // 
            this.ToolStripSeparator_Edit.Name = "ToolStripSeparator_Edit";
            this.ToolStripSeparator_Edit.Size = new System.Drawing.Size(207, 6);
            // 
            // ToolStripMenuItem_Edit
            // 
            this.ToolStripMenuItem_Edit.Name = "ToolStripMenuItem_Edit";
            this.ToolStripMenuItem_Edit.Size = new System.Drawing.Size(210, 24);
            this.ToolStripMenuItem_Edit.Text = "Edit";
            this.ToolStripMenuItem_Edit.Click += new System.EventHandler(this.ToolStripMenuItem_Edit_Click);
            // 
            // ToolStripMenuItem_Remove
            // 
            this.ToolStripMenuItem_Remove.Name = "ToolStripMenuItem_Remove";
            this.ToolStripMenuItem_Remove.Size = new System.Drawing.Size(210, 24);
            this.ToolStripMenuItem_Remove.Text = "Remove";
            this.ToolStripMenuItem_Remove.Click += new System.EventHandler(this.ToolStripMenuItem_Remove_Click);
            // 
            // MollierControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MollierChart);
            this.Name = "MollierControl";
            this.Size = new System.Drawing.Size(816, 588);
            ((System.ComponentModel.ISupportInitialize)(this.MollierChart)).EndInit();
            this.ContextMenuStrip_Chart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MollierChart;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Chart;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Zoom;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ProcessesAndPoints;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Selection;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Reset;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_Edit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Remove;
    }
}
