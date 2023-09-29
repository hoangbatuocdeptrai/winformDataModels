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
    public partial class frmXuatKho : DevExpress.XtraEditors.XtraForm
    {
        private IKhuService _khuService;
        private IHangService _hangService;
        private IKeService _keService;
        private IXuatKhoService _xuatKhoService;
        private ILuuTruService _luuTruService;
        public frmXuatKho(IKhuService khuService, IHangService hangService, IKeService keService, IXuatKhoService xuatKhoService, ILuuTruService luuTruService)
        {
            InitializeComponent();
            _khuService = khuService;
            _hangService = hangService;
            _keService = keService;
            _xuatKhoService = xuatKhoService;
            _luuTruService = luuTruService;
        }

        private async void btnSaveData_Click(object sender, EventArgs e)
        {
            var masp = txtMaSP.Text;
            var tensp = txtTenSP.Text;
            var soluong = txtSoLuong.Text;
            int khuid = (int)cboKhu.SelectedValue;
            int hangid = (int)cboHang.SelectedValue;
            var keid = (int)cboKe.SelectedValue;
            var nguoilay = txtNguoiLay.Text;
            var ngaylay = txtNgayLay.EditValue;

            var xuatkho = new XuatKho();
            xuatkho.masanpham = masp;
            xuatkho.tensanpham = tensp;
            xuatkho.soluong = int.Parse(soluong);
            xuatkho.khuid = khuid;
            xuatkho.hangid = hangid;
            xuatkho.keid = keid;
            xuatkho.nguoilay = nguoilay;
            xuatkho.ngaylay = (DateTime)ngaylay;

            splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(2000);

            bool saveOk = await _xuatKhoService.CreateXuatKho(xuatkho);
            splashScreenManager1.CloseWaitForm();

            //var luutru = new LuuTru();
            //luutru.masanpham = masp;
            //luutru.tensanpham = tensp;
            //luutru.soluong = int.Parse(soluong);
            //luutru.nguoixuli = nguoilay;
            //luutru.nhaporxuat = "Xuất";


            //bool saveLuuTru = await _luuTruService.CreateLuuTru(luutru);

            btnGetData_Click(null, null);

        }

        private async void frmXuatKho_Load(object sender, EventArgs e)
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


            txtNgayLay.EditValue = DateTime.Now;

            var abc = await _xuatKhoService.GetAllXuatKho();

            gridControl1.DataSource = abc;
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(2000);
            var abc = await _xuatKhoService.GetAllXuatKho();

            gridControl1.DataSource = abc;

            //gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            //gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

            splashScreenManager1.CloseWaitForm();

        }
    }
}