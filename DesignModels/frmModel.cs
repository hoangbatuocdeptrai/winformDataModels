using DesignModels.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignModels
{
    public partial class Models : DevExpress.XtraEditors.XtraForm
    {
        private readonly IModelsService _modelsService;
        public Models(IModelsService modelsService)
        {
            InitializeComponent();
            _modelsService = modelsService;

        }


        private async void btnUpdateData_Click(object sender, EventArgs e)
        {
            var update = gridView1.GetFocusedRow() as Modelss;
            if (update == null)
            {
                MessageBox.Show("Vui lòng chọn lại!");
                return;
            }
            if (string.IsNullOrEmpty(txtModelName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Model!");
                txtModelName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng!");
                txtQuantity.Focus();
                return;
            }

            var created_at = update.created_at;

            var get = await _modelsService.GetModelss(update.id);
            var modelsname = txtModelName.Text;

            var getModelsNameUnique = await _modelsService.CheckName(modelsname, get.id);
            if (getModelsNameUnique == true)
            {
                MessageBox.Show("Tên Model đã tồn tại. Vui lòng nhập lại!");
                return;
            }
            var quantity = txtQuantity.Text;
            var updated_at = txtUpdatedAt.Value = DateTime.Now;
            var traycount = txtTrayCount.Text;
            var traythicknessmm = txtTrayThicknessMm.Text;
            var updateModels = new Modelss();

            updateModels.modelsname = modelsname;
            updateModels.quantity = int.Parse(quantity);
            updateModels.updated_at = updated_at;
            updateModels.created_at = created_at;
            updateModels.traycount = int.Parse(traycount);
            updateModels.traythicknessmm = float.Parse(traythicknessmm);

            updateModels.id = get.id;
            //loading
            splashScreenManager1.ShowWaitForm();
            await _modelsService.UpdateModelss(updateModels);
            splashScreenManager1.CloseWaitForm();

            btnGetData_Click(null, null);
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(2000);
            var abc = await _modelsService.GetAllModels();

            gridControl1.DataSource = abc;

            //gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            //gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

            splashScreenManager1.CloseWaitForm();

        }

        private async void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {

                var traythicknessmm = txtTrayThicknessMm.Text;//độ dày
                var traycount = txtTrayCount.Text;//số lượng
                var modelsname = txtModelName.Text;
                var getModelsNameUnique = await _modelsService.CheckNameSave(modelsname);
                if (getModelsNameUnique == true)
                {
                    MessageBox.Show("Tên Model đã tồn tại!");
                    return;
                }
                var quantity = txtQuantity.Text;
                var created_at = txtCreatedAt.Value = DateTime.Now;
                var updated_at = txtUpdatedAt.Value = DateTime.Now;
                if (string.IsNullOrEmpty(modelsname))
                {
                    MessageBox.Show("Vui lòng nhập tên model!");
                    txtModelName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(quantity))
                {
                    MessageBox.Show("Vui lòng nhập số lượng!");
                    txtQuantity.Focus();
                    return;
                }

                var model = new Modelss();
                model.modelsname = modelsname;
                model.quantity = int.Parse(quantity);
                model.created_at = created_at;
                model.updated_at = updated_at;
                model.traythicknessmm = float.Parse(traythicknessmm);
                model.traycount = int.Parse(traycount);
                //loading
                splashScreenManager1.ShowWaitForm();
                //Thread.Sleep(2000);

                bool saveOk = await _modelsService.CreateModelss(model);
                splashScreenManager1.CloseWaitForm();
                if (saveOk == true)
                {
                    txtModelName.Text = "";
                    txtQuantity.Text = "";
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
            }

            btnGetData_Click(null, null);

        }

        private async void frmModel_Load(object sender, EventArgs e)
        {
            var abc = await _modelsService.GetAllModels();
            gridControl1.DataSource = abc;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtModelName.Text = null;
            txtQuantity.Text = null;
            txtTrayCount.Text = null;
            txtTrayThicknessMm = null;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var gridview = sender as GridView;
            if (gridview.IsDataRow(e.FocusedRowHandle))
            {
                var view = gridview.GetFocusedRow() as Modelss;
                txtModelName.Text = view.modelsname;
                txtQuantity.Text = view.quantity.ToString();
                txtTrayCount.Text = view.traycount.ToString();
                txtTrayThicknessMm.Text = view.traythicknessmm.ToString();
            }
        }

        private async void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column == colDelete)
            {
                var delete = gridView1.GetFocusedRow() as Modelss;
                var dlg = XtraMessageBox.Show("Bạn có muốn xóa ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == DialogResult.Yes)
                {
                    //loading
                    //Thread.Sleep(3000);
                    await _modelsService.GetModelss(delete.id);
                    splashScreenManager1.ShowWaitForm();
                    gridView1.DeleteSelectedRows();
                    splashScreenManager1.CloseWaitForm();
                }
            }

            if (e.Column == colEdit)
            {
                var update = gridView1.GetFocusedRow() as Modelss;
                if (update == null)
                {
                    MessageBox.Show("Vui lòng chọn lại!");
                    return;
                }

                txtModelName.Text = update.modelsname;
                txtQuantity.Text = update.quantity.ToString();
                txtTrayCount.Text = update.traycount.ToString();
                txtTrayThicknessMm.Text = update.traythicknessmm.ToString();
                //var created_at = update.created_at;
                //var modelsname = txtModelName.Text;
                //var get = await _modelsService.GetModelss(update.id);

                //var getModelsNameUnique = await _modelsService.CheckName(modelsname, get.id);
                //if (getModelsNameUnique == true)
                //{
                //    MessageBox.Show("Tên Model đã tồn tại. Vui lòng nhập lại!");
                //    return;
                //}
                //var quantity = txtQuantity.Text;
                //var updated_at = txtUpdatedAt.Value = DateTime.Now;

                //var updateModels = new Modelss();

                //updateModels.modelsname = modelsname;
                //updateModels.quantity = int.Parse(quantity);
                //updateModels.updated_at = updated_at;
                //updateModels.created_at = created_at;
                //updateModels.id = get.id;
                ////loading
                //splashScreenManager1.ShowWaitForm();
                //Thread.Sleep(2000);
                //splashScreenManager1.CloseWaitForm();
                //await _modelsService.UpdateModelss(updateModels);

                //btnGetData_Click(null, null);



            }
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //var gridview = sender as GridView;
            //if (gridview.IsDataRow(e.FocusedRowHandle))
            //{
            //    var view = gridview.GetFocusedRow() as Modelss;
            //    txtModelName.Text = view.modelsname;
            //    txtQuantity.Text = view.quantity.ToString();

            //}
        } //click Show
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void gridControl1_Click_1(object sender, EventArgs e)
        {




        }
        private void gridControl1_Click_2(object sender, EventArgs e)
        {

        }
    }
}