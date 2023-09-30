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
    public partial class frmTraCuu : DevExpress.XtraEditors.XtraForm
    {
        private ILuuTruService _luuTruService;
        private INhapKhoService _nhapKhoService;
        private IXuatKhoService _xuatKhoService;
        public frmTraCuu(ILuuTruService luuTruService, INhapKhoService nhapKhoService, IXuatKhoService xuatKhoService)
        {
            InitializeComponent();
            _luuTruService = luuTruService;
            _nhapKhoService = nhapKhoService;
            _xuatKhoService = xuatKhoService;
        }

        List<LuuTru> lst = new List<LuuTru>();
        private async void frmTraCuu_Load(object sender, EventArgs e)
        {
            var nhapkho = await _nhapKhoService.GetAllNhapKho();
            foreach (var lstnhap in nhapkho)
            {
                var nhap = new LuuTru();
                nhap.masanpham = lstnhap.masanpham;
                nhap.tensanpham = lstnhap.tensanpham;
                nhap.soluong = lstnhap.soluong;
                nhap.nguoixuli = lstnhap.nguoinhap;
                nhap.ngayxuli = lstnhap.ngaynhapkho;
                nhap.nhaporxuat = "Nhập Kho";
                lst.Add(nhap);
            }

            var xuatkho = await _xuatKhoService.GetAllXuatKho();
            foreach (var lstnhap in xuatkho)
            {
                var xuat = new LuuTru();
                xuat.masanpham = lstnhap.masanpham;
                xuat.tensanpham = lstnhap.tensanpham;
                xuat.soluong = lstnhap.soluong;
                xuat.nguoixuli = lstnhap.nguoilay;
                xuat.ngayxuli = lstnhap.ngaylay;
                xuat.nhaporxuat = "Xuất kho";
                lst.Add(xuat);
            }
            gridControl1.DataSource = lst.OrderByDescending(x => x.ngayxuli);

            //var abc = await _luuTruService.GetAllLuuTru();
            //gridControl1.DataSource = abc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var timkiem = txtSearch.Text;
            var abc = lst.Where(x => x.masanpham == timkiem).ToList();
            gridControl1.DataSource = abc;


        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}