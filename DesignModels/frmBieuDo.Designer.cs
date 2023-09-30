namespace DesignModels
{
    partial class frmBieuDo
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Legend legend1 = new DevExpress.XtraCharts.Legend();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Legend legend2 = new DevExpress.XtraCharts.Legend();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView2 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            chartControl1 = new DevExpress.XtraCharts.ChartControl();
            chartControl2 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)chartControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)legend1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pieSeriesView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)legend2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pieSeriesView2).BeginInit();
            SuspendLayout();
            // 
            // chartControl1
            // 
            chartControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            chartControl1.Diagram = xyDiagram1;
            chartControl1.Legend.LegendID = -1;
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            legend1.LegendID = 0;
            legend1.Name = "Legend 1";
            legend1.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chartControl1.Legends.AddRange(new DevExpress.XtraCharts.Legend[] { legend1 });
            chartControl1.Location = new Point(55, 27);
            chartControl1.Name = "chartControl1";
            series1.Name = "Series 2";
            series1.SeriesID = 1;
            sideBySideBarSeriesView1.Border.Thickness = 2;
            sideBySideBarSeriesView1.ColorEach = true;
            series1.View = sideBySideBarSeriesView1;
            chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1 };
            chartControl1.SeriesTemplate.View = pieSeriesView1;
            chartControl1.Size = new Size(537, 623);
            chartControl1.TabIndex = 0;
            // 
            // chartControl2
            // 
            chartControl2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            chartControl2.Diagram = xyDiagram2;
            chartControl2.Legend.LegendID = -1;
            chartControl2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            legend2.LegendID = 0;
            legend2.Name = "Legend 1";
            legend2.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chartControl2.Legends.AddRange(new DevExpress.XtraCharts.Legend[] { legend2 });
            chartControl2.Location = new Point(762, 27);
            chartControl2.Name = "chartControl2";
            series2.Name = "Series 2";
            series2.SeriesID = 1;
            sideBySideBarSeriesView2.Border.Thickness = 2;
            sideBySideBarSeriesView2.ColorEach = true;
            series2.View = sideBySideBarSeriesView2;
            chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series2 };
            chartControl2.SeriesTemplate.View = pieSeriesView2;
            chartControl2.Size = new Size(486, 623);
            chartControl2.TabIndex = 0;
            // 
            // frmBieuDo
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 662);
            Controls.Add(chartControl2);
            Controls.Add(chartControl1);
            Name = "frmBieuDo";
            Text = "Biểu đồ";
            ((System.ComponentModel.ISupportInitialize)xyDiagram1).EndInit();
            ((System.ComponentModel.ISupportInitialize)legend1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)series1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pieSeriesView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)xyDiagram2).EndInit();
            ((System.ComponentModel.ISupportInitialize)legend2).EndInit();
            ((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)series2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pieSeriesView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraCharts.ChartControl chartControl2;
    }
}