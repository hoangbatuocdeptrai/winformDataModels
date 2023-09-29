using DesignModels.Entity;
using DesignModels.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignModels
{
    public partial class frmKe : DevExpress.XtraEditors.XtraForm
    {
        private readonly IKeService _KeService;
        public frmKe(IKeService keService)
        {
            InitializeComponent();
            _KeService = keService;
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(2000);
            var abc = await _KeService.GetAllKe();

            gridControl1.DataSource = abc;

            //gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            //gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

            splashScreenManager1.CloseWaitForm();

        }

        private async void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                var tenke = txtTenKe.Text;
                var getTenKeUnique = await _KeService.CheckNameSave(tenke);
                if (getTenKeUnique == true)
                {
                    MessageBox.Show("Tên kệ đã tồn tại!");
                    return;
                }
                if (string.IsNullOrEmpty(tenke))
                {
                    MessageBox.Show("Vui lòng nhập tên kệ!");
                    txtTenKe.Focus();
                    return;
                }
                var ke = new Ke();
                ke.tenke = tenke;

                splashScreenManager1.ShowWaitForm();
                //Thread.Sleep(2000);

                bool saveOk = await _KeService.CreateKe(ke);
                splashScreenManager1.CloseWaitForm();
                if (saveOk == true)
                {
                    txtTenKe.Text = "";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");

                throw;
            }
            btnGetData_Click(null, null);
        }

        private async void frmKe_Load(object sender, EventArgs e)
        {
            var abc = await _KeService.GetAllKe();
            gridControl1.DataSource = abc;
        }
    }
}