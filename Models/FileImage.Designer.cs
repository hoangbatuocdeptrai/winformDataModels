namespace Models
{
    partial class FileImage
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
            listBox1 = new ListBox();
            btnError = new Button();
            pictureBox1 = new PictureBox();
            txtBox1 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(26, 143);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(203, 384);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // btnError
            // 
            btnError.Location = new Point(108, 102);
            btnError.Name = "btnError";
            btnError.Size = new Size(121, 35);
            btnError.TabIndex = 2;
            btnError.Text = "Add Database";
            btnError.UseVisualStyleBackColor = true;
            btnError.Click += btnError_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(391, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(533, 384);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // txtBox1
            // 
            txtBox1.Location = new Point(393, 56);
            txtBox1.Name = "txtBox1";
            txtBox1.Size = new Size(171, 27);
            txtBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(580, 56);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "TIm kiem";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(393, 33);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 6;
            label1.Text = "TIm kiem";
            // 
            // FileImage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1393, 683);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(txtBox1);
            Controls.Add(pictureBox1);
            Controls.Add(btnError);
            Controls.Add(listBox1);
            Name = "FileImage";
            Text = "FileImage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button btnError;
        private PictureBox pictureBox1;
        private TextBox txtBox1;
        private Button button1;
        private Label label1;
    }
}