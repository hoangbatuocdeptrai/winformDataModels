using Model;
using Models.Services;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Models
{
    public partial class Form1 : Form
    {
        private readonly IModelsService _modelsServices;

        public Form1(IModelsService modelsServices)
        {
            InitializeComponent();

        }

        private NpgsqlConnection conn;

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            var abc = _modelsServices.GetAllModels();
            dataGridView1.DataSource = abc;


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                MessageBox.Show("Vui long bo nhap id. vi id tu dong tang");
                return;
            }
            var modelsname = txtmodelname.Text;
            var getModelsNameUnique = await _modelsServices.CheckName(modelsname);
            if (getModelsNameUnique == true)
            {
                MessageBox.Show("Khong duoc nhap trung ten models");
                return;
            }

            var quantity = txtQuantity.Text;
            var created_at = dateTimePickerCreated_at.Value = DateTime.Now;
            var updated_at = dateTimePickerUpdated_at.Value = DateTime.Now;
            if (string.IsNullOrEmpty(modelsname))
            {
                MessageBox.Show("Please input your model name");
                txtmodelname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("Please input your model quantity");
                txtQuantity.Focus();
                return;
            }

            var model = new Modelss();
            model.modelsname = modelsname;
            model.quantity = int.Parse(quantity);
            model.created_at = created_at;
            model.updated_at = updated_at;

            await _modelsServices.CreateModelss(model);
            //PostgresHelper.Insert(model);

            //txtmodelname.Text = "";
            //txtQuantity.Text = "";


            btnGetData_Click_1(null, null);


        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtId.Text);
            var get = await _modelsServices.GetModelss(id);
            if (get == null)
            {
                MessageBox.Show("Vui long chon lai Id");
                return;
            }
            var created_at = get.created_at;
            //var getCreated_at = PostgresHelper.GetAll<Modelss>().FirstOrDefault(x => x.created_at == created_at);

            var modelsname = txtmodelname.Text;
            var getModelsNameUnique = await _modelsServices.CheckName(modelsname);
            if (getModelsNameUnique == true)
            {
                MessageBox.Show("Khong duoc nhap trung ten models");
                return;
            }
            var quantity = txtQuantity.Text;
            var updated_at = dateTimePickerUpdated_at.Value = DateTime.Now;

            var updateModels = new Modelss();

            updateModels.modelsname = modelsname;
            updateModels.quantity = int.Parse(quantity);
            updateModels.updated_at = updated_at;
            updateModels.created_at = created_at;
            updateModels.id = id;

            PostgresHelper.Update(updateModels);

            btnGetData_Click_1(null, null);
        }

        private async void btnGetById_Click(object sender, EventArgs e)
        {
            var text_id = txtId.Text;
            if (string.IsNullOrEmpty(text_id))
            {
                MessageBox.Show("Please input your model name");
                txtmodelname.Focus();
                return;
            }
            var id = Convert.ToInt32(text_id);
            var getAll = await _modelsServices.GetModelss(id);
            //var models = PostgresHelper.GetById<Modelss>(id);
            if (getAll == null)
            {
                MessageBox.Show("Id : " + id + " khong ton tai. vui long chon lai.!");
                return;
            }

            txtmodelname.Text = getAll.modelsname;
            txtQuantity.Text = getAll.quantity.ToString();
            //dateTimePicker1.Value = models.updated_at;

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtId.Text);
            var getAll = await _modelsServices.GetModelss(id);
            if (getAll == null)
            {
                MessageBox.Show("Id : " + id + " khong ton tai. vui long chon lai.!");
                return;
            }
            await _modelsServices.DeleteModelss(id);
            MessageBox.Show("Xoa ok");

            btnGetData_Click_1(null, null);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtmodelname.Text = "";
            txtQuantity.Text = "";
        }

        //private void btnGetData_Click_1(object sender, EventArgs e)
        //{

        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            btnGetData_Click_1(null, null);
        }

        private async void btnGetData_Click_1(object sender, EventArgs e)
        {
            var abc = await _modelsServices.GetAllModels();
            dataGridView1.DataSource = abc;
        }

        private void dateTimePickerCreated_at_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerUpdated_at_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}