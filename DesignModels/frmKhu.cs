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
    public partial class frmKhu : DevExpress.XtraEditors.XtraForm
    {
        private readonly IKhuService _khuService;
        public frmKhu(IKhuService khuService)
        {
            InitializeComponent();
            _khuService = khuService;

        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(2000);
            var abc = await _khuService.GetAllKhu();

            gridControl1.DataSource = abc;

            //gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            //gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

            splashScreenManager1.CloseWaitForm();

        }
        private async void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                var tenkhu = txtTenKhu.Text;//độ dày
                var getTenKhuUnique = await _khuService.CheckNameSave(tenkhu);
                if (getTenKhuUnique == true)
                {
                    MessageBox.Show("Tên Model đã tồn tại!");
                    return;
                }
                if (string.IsNullOrEmpty(tenkhu))
                {
                    MessageBox.Show("Vui lòng nhập tên khu!");
                    txtTenKhu.Focus();
                    return;
                }
                var khu = new Khu();
                khu.tenkhu = tenkhu;

                splashScreenManager1.ShowWaitForm();
                //Thread.Sleep(2000);

                bool saveOk = await _khuService.CreateKhu(khu);
                splashScreenManager1.CloseWaitForm();
                if (saveOk == true)
                {
                    txtTenKhu.Text = "";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");

                throw;
            }
            btnGetData_Click(null, null);
        }

        
        private async void frmKhu_Load_1(object sender, EventArgs e)
        {
            var abc = await _khuService.GetAllKhu();
            gridControl1.DataSource = abc;
        }
    }
}