using Microsoft.Extensions.DependencyInjection;
using Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Models
{
    public partial class MainForm : Form
    {
        private readonly IModelsService _modelsService;

        public MainForm()
        {
            InitializeComponent();
            //_modelsService = modelsService;
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1(_modelsService);
            // form1.ShowDialog();
            //this.Close();
            //this.Hide();
            using (var form2 = Program.ServiceProvider.GetRequiredService<Form1>())
                form2.ShowDialog();
        }

        private void fileImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form3 = Program.ServiceProvider.GetRequiredService<FileImage>())
                form3.ShowDialog();
        }
    }
}
