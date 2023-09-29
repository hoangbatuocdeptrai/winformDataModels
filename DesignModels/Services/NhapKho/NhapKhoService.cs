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
    public class NhapKhoService : INhapKhoService
    {
        private readonly IDbservice _dbservice;

        public NhapKhoService(IDbservice dbservice)
        {
            _dbservice = dbservice;
        }

        public async Task<bool> CreateNhapkho(NhapKho nhapKho)
        {
            var sql = await _dbservice.CreateData("INSERT INTO public.nhapkho(masanpham, tensanpham, soluong, khuid, hangid, keid, nguoinhap,nhasanxuat, ngaynhapkho, thoihansudung) VALUES(@masanpham, @tensanpham, @soluong, @khuid, @hangid, @keid, @nguoinhap,@nhasanxuat, @ngaynhapkho, @thoihansudung)", nhapKho);
            return true;
        }

        public async Task<List<NhapKho>> GetAllNhapKho()
        {
            //var result = await _dbservice.GettAll<NhapKho>("SELECT * FROM public.nhapkho", new { });
            var result = await _dbservice.GettAll<NhapKho>("SELECT nk.*, k.tenkhu, h.tenhang, ke.tenke FROM public.nhapkho as nk join public.khu as k on nk.khuid = k.id join public.hang as h on nk.hangid = h.id join public.ke as ke on nk.keid = ke.id", new { });
            return result;
        }

        //public Task<NhapKho> GetNhapKho(int id)
        //{

        //}
    }
}
