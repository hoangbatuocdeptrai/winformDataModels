namespace DesignModels
{
    partial class frmDetailsModels
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
            components = new System.ComponentModel.Container();
            listBox1 = new ListBox();
            label2 = new Label();
            btnSearch = new Button();
            txtBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            timer1 = new System.Windows.Forms.Timer(components);
            cboModel = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 16;
            listBox1.Location = new Point(40, 13);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(171, 644);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(239, 6);
            label2.Name = "label2";
            label2.Size = new Size(61, 16);
            label2.TabIndex = 9;
            label2.Text = "Tìm Kiếm";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(426, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(78, 27);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Go";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtBox1
            // 
            txtBox1.Location = new Point(239, 24);
            txtBox1.Name = "txtBox1";
            txtBox1.Size = new Size(171, 23);
            txtBox1.TabIndex = 7;
            txtBox1.KeyDown += txtBox1_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(239, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(799, 596);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // cboModel
            // 
            cboModel.FormattingEnabled = true;
            cboModel.Location = new Point(537, 25);
            cboModel.Name = "cboModel";
            cboModel.Size = new Size(151, 24);
            cboModel.TabIndex = 12;
            cboModel.SelectedIndexChanged += cboModel_SelectedIndexChanged;
            // 
            // frmDetailsModels
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 669);
            Controls.Add(cboModel);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(btnSearch);
            Controls.Add(txtBox1);
            Controls.Add(listBox1);
            Name = "frmDetailsModels";
            Text = "Chi tiết Models";
            Load += frmDetailsModels_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private Label label2;
        private Button btnSearch;
        private TextBox txtBox1;
        private PictureBox pictureBox1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Timer timer1;
        private ComboBox cboModel;
    }
}