namespace Models
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnGetData = new Button();
            label1 = new Label();
            label2 = new Label();
            txtmodelname = new TextBox();
            txtQuantity = new TextBox();
            button1 = new Button();
            label3 = new Label();
            txtId = new TextBox();
            btnUpdate = new Button();
            btnGetById = new Button();
            dateTimePickerUpdated_at = new DateTimePicker();
            dateTimePickerCreated_at = new DateTimePicker();
            btnDelete = new Button();
            button3 = new Button();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 245);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1058, 352);
            dataGridView1.TabIndex = 0;
            // 
            // btnGetData
            // 
            btnGetData.Location = new Point(42, 187);
            btnGetData.Name = "btnGetData";
            btnGetData.Size = new Size(94, 29);
            btnGetData.TabIndex = 1;
            btnGetData.Text = "Get data";
            btnGetData.UseVisualStyleBackColor = true;
            btnGetData.Click += btnGetData_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 89);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 2;
            label1.Text = "Models Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 142);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 2;
            label2.Text = "Quantity :";
            // 
            // txtmodelname
            // 
            txtmodelname.Location = new Point(154, 82);
            txtmodelname.Name = "txtmodelname";
            txtmodelname.Size = new Size(313, 27);
            txtmodelname.TabIndex = 3;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(154, 135);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(313, 27);
            txtQuantity.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(260, 187);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 38);
            label3.Name = "label3";
            label3.Size = new Size(33, 20);
            label3.TabIndex = 2;
            label3.Text = "Id : ";
            // 
            // txtId
            // 
            txtId.Location = new Point(154, 31);
            txtId.Name = "txtId";
            txtId.Size = new Size(313, 27);
            txtId.TabIndex = 3;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(154, 187);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnGetById
            // 
            btnGetById.Location = new Point(524, 29);
            btnGetById.Name = "btnGetById";
            btnGetById.Size = new Size(94, 29);
            btnGetById.TabIndex = 4;
            btnGetById.Text = "GetById";
            btnGetById.UseVisualStyleBackColor = true;
            btnGetById.Click += btnGetById_Click;
            // 
            // dateTimePickerUpdated_at
            // 
            dateTimePickerUpdated_at.Location = new Point(821, 38);
            dateTimePickerUpdated_at.Name = "dateTimePickerUpdated_at";
            dateTimePickerUpdated_at.Size = new Size(250, 27);
            dateTimePickerUpdated_at.TabIndex = 5;
            dateTimePickerUpdated_at.Visible = false;
            dateTimePickerUpdated_at.ValueChanged += dateTimePickerUpdated_at_ValueChanged;
            // 
            // dateTimePickerCreated_at
            // 
            dateTimePickerCreated_at.Location = new Point(821, 86);
            dateTimePickerCreated_at.Name = "dateTimePickerCreated_at";
            dateTimePickerCreated_at.Size = new Size(250, 27);
            dateTimePickerCreated_at.TabIndex = 6;
            dateTimePickerCreated_at.Visible = false;
            dateTimePickerCreated_at.ValueChanged += dateTimePickerCreated_at_ValueChanged;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(373, 187);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // button3
            // 
            button3.Location = new Point(645, 31);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 8;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(822, 145);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 9;
            dateTimePicker1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 609);
            Controls.Add(dateTimePicker1);
            Controls.Add(button3);
            Controls.Add(btnDelete);
            Controls.Add(dateTimePickerCreated_at);
            Controls.Add(dateTimePickerUpdated_at);
            Controls.Add(btnGetById);
            Controls.Add(btnUpdate);
            Controls.Add(button1);
            Controls.Add(txtQuantity);
            Controls.Add(txtId);
            Controls.Add(txtmodelname);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnGetData);
            Controls.Add(dataGridView1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "C# Postgres SQL";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnGetData;
        private Label label1;
        private Label label2;
        private TextBox txtmodelname;
        private TextBox txtQuantity;
        private Button button1;
        private Label label3;
        private TextBox txtId;
        private Button button2;
        private Button btnUpdate;
        private Button btnGetById;
        private DateTimePicker dateTimePickerUpdated_at;
        private DateTimePicker dateTimePickerCreated_at;
        private Button btnDelete;
        private Button button3;
        private DateTimePicker dateTimePicker1;
    }
}