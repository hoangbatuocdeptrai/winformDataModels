using DesignModels.Entity;
using DesignModels.Services;
using DevExpress.XtraEditors;
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
    public partial class frmHang : DevExpress.XtraEditors.XtraForm
    {
        private readonly IHangService _hangService;
        public frmHang(IHangService hangService)
        {
            InitializeComponent();
            _hangService = hangService;
        }
        private async void btnGetData_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(2000);
            var abc = await _hangService.GetAllHang();

            gridControl1.DataSource = abc;

            //gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            //gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

            splashScreenManager1.CloseWaitForm();

        }
        private async void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                var tenhang = txtTenHang.Text;//độ dày
                var getTenKhuUnique = await _hangService.CheckNameSave(tenhang);
                if (getTenKhuUnique == true)
                {
                    MessageBox.Show("Tên hàng đã tồn tại!");
                    return;
                }
                if (string.IsNullOrEmpty(tenhang))
                {
                    MessageBox.Show("Vui lòng nhập tên hàng!");
                    txtTenHang.Focus();
                    return;
                }
                var hang = new Hang();
                hang.tenhang = tenhang;

                splashScreenManager1.ShowWaitForm();

                bool saveOk = await _hangService.CreateHang(hang);
                splashScreenManager1.CloseWaitForm();
                if (saveOk == true)
                {
                    txtTenHang.Text = "";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");

                throw;
            }
            btnGetData_Click(null, null);
        }

        private async void frmHang_Load(object sender, EventArgs e)
        {
            var abc = await _hangService.GetAllHang();
            gridControl1.DataSource = abc;
        }
    }
}