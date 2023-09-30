using DesignModels.Service;
using DevExpress.XtraBars;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.CompilerServices;
using DevExpress.XtraSplashScreen;

namespace DesignModels
{
    public partial class frmMainss : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMainss()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        void OpenForm(Type typeForm)
        {
            foreach (Form frm in MdiChildren)
            {
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
            }

            this.IsMdiContainer = true;
            Form frma = (Form)Program.ServiceProvider.GetRequiredService(typeForm);
            frma.MdiParent = this;
            frma.Show();

        }
        private void barModels_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //splashScreenManager1.ShowWaitForm();
                OpenForm(typeof(Models));
                //splashScreenManager1.CloseWaitForm();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void barDetailsModels_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            OpenForm(typeof(frmDetailsModels));
            splashScreenManager1.CloseWaitForm();
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }



        private void ribbon_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            OpenForm(typeof(frmNhapKho));
            splashScreenManager1.CloseWaitForm();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            OpenForm(typeof(frmXuatKho));
            splashScreenManager1.CloseWaitForm();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            OpenForm(typeof(frmTraCuu));
            splashScreenManager1.CloseWaitForm();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            OpenForm(typeof(frmKhu));
            splashScreenManager1.CloseWaitForm();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            OpenForm(typeof(frmHang));
            splashScreenManager1.CloseWaitForm();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            OpenForm(typeof(frmKe));
            splashScreenManager1.CloseWaitForm();
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            OpenForm(typeof(frmBieuDo));
            splashScreenManager1.CloseWaitForm();
        }
    }
}