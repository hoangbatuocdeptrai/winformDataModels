using DesignModels.Entity;
using DesignModels.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignModels.Services
{
    public class XuatKhoService : IXuatKhoService
    {
        private readonly IDbservice _dbservice;

        public XuatKhoService(IDbservice dbservice)
        {
            _dbservice = dbservice;
        }

        public async Task<bool> CreateXuatKho(XuatKho xuatKho)
        {
            var sql = await _dbservice.CreateData("INSERT INTO public.xuatkho(masanpham, tensanpham, soluong, khuid, hangid, keid, nguoilay, ngaylay) VALUES(@masanpham, @tensanpham, @soluong, @khuid, @hangid, @keid, @nguoilay, @ngaylay)", xuatKho);
            return true;
        }

        public async Task<List<XuatKho>> GetAllXuatKho()
        {
            var result = await _dbservice.GettAll<XuatKho>("SELECT nk.*, k.tenkhu, h.tenhang, ke.tenke FROM public.xuatkho as nk join public.khu as k on nk.khuid = k.id join public.hang as h on nk.hangid = h.id join public.ke as ke on nk.keid = ke.id", new { });
            return result;
        }

        //public Task<NhapKho> GetNhapKho(int id)
        //{

        //}
    }
}
