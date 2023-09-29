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
    public partial class frmNhapKho : DevExpress.XtraEditors.XtraForm
    {
        private IKhuService _khuService;
        private IHangService _hangService;
        private IKeService _keService;
        private INhapKhoService _nhapKhoService;
        private ILuuTruService _luuTruService;
        public frmNhapKho(IKhuService khuService, IHangService hangService, IKeService keService, INhapKhoService nhapKhoService, ILuuTruService luuTruService)
        {
            InitializeComponent();
            _khuService = khuService;
            _hangService = hangService;
            _keService = keService;
            _nhapKhoService = nhapKhoService;
            _luuTruService = luuTruService;
        }
        private async void frmNhapKho_Load(object sender, EventArgs e)
        {
            var khu = await _khuService.GetAllKhu();
            cboKhu.DisplayMember = "tenkhu";
            var promptItem = new Khu { id = -1, tenkhu = "Chọn khu..." };
            // Thêm đối tượng mời bạn chọn vào đầu danh sách
            khu.Insert(0, promptItem);
            cboKhu.ValueMember = "id";
            //cboKhu.Items.Add("Mời bạn chọn khu");
            //cboKhu.SelectedIndex = 0; // Đặt mục đầu tiên là mục được chọn
            cboKhu.DataSource = khu;

            var hang = await _hangService.GetAllHang();
            cboHang.DisplayMember = "tenhang";
            cboHang.ValueMember = "id";
            var promptItem1 = new Hang { id = -1, tenhang = "Chọn hàng..." };
            // Thêm đối tượng mời bạn chọn vào đầu danh sách
            hang.Insert(0, promptItem1);
            //cboHang.SelectedIndex = 0; // Đặt mục đầu tiên là mục được chọn
            cboHang.DataSource = hang;


            var ke = await _keService.GetAllKe();
            cboKe.DisplayMember = "tenke";
            cboKe.ValueMember = "id";
            var promptItem2 = new Ke { id = -1, tenke = "Chọn kệ..." };
            // Thêm đối tượng mời bạn chọn vào đầu danh sách
            ke.Insert(0, promptItem2);
            //cboHang.SelectedIndex = 0; // Đặt mục đầu tiên là mục được chọn
            cboKe.DataSource = ke;


            txtNgayNhapKho.EditValue = DateTime.Now;

            var abc = await _nhapKhoService.GetAllNhapKho();

            gridControl1.DataSource = abc;
        }

        private async void btnSaveData_Click(object sender, EventArgs e)
        {
            var ma = txtMaSP.Text;
            var tensp = txtTenSP.Text;
            var soluong = txtSoLuong.Text;
            int khuid = (int)cboKhu.SelectedValue;
            int hangid = (int)cboHang.SelectedValue;
            var keid = (int)cboKe.SelectedValue;
            var nguoinhap = txtNguoiNhap.Text;
            var nhasanxuat = txtNhaSanXuat.Text;
            var ngaynhapkho = txtNgayNhapKho.EditValue = DateTime.Now;
            var thoihansudung = txtThoiGianSuDung.EditValue;

            var nhapkho = new NhapKho();
            nhapkho.masanpham = ma;
            nhapkho.tensanpham = tensp;
            nhapkho.soluong = int.Parse(soluong);
            nhapkho.khuid = khuid;
            nhapkho.hangid = hangid;
            nhapkho.keid = keid;
            nhapkho.nguoinhap = nguoinhap;
            nhapkho.nhasanxuat = nhasanxuat;
            nhapkho.ngaynhapkho = (DateTime)ngaynhapkho;
            nhapkho.thoihansudung = (DateTime)thoihansudung;

            splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(2000);

            bool saveOk = await _nhapKhoService.CreateNhapkho(nhapkho);
            splashScreenManager1.CloseWaitForm();
            //if (saveOk == true)
            //{
            //    txtModelName.Text = "";
            //    txtQuantity.Text = "";
            //}
            //var luutru = new LuuTru();
            //luutru.masanpham = ma;
            //luutru.tensanpham = tensp;
            //luutru.soluong = int.Parse(soluong);
            //luutru.nguoixuli = nguoinhap;
            //luutru.nhaporxuat = "Nhập";

            //bool saveLuuTru = await _luuTruService.CreateLuuTru(luutru);



            btnGetData_Click(null, null);
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(2000);
            var abc = await _nhapKhoService.GetAllNhapKho();

            gridControl1.DataSource = abc;

            //gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            //gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

            splashScreenManager1.CloseWaitForm();

        }

        private void cboKhu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}