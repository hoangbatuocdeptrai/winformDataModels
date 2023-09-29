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
    public class LuuTruService : ILuuTruService
    {
        private readonly IDbservice _dbservice;

        public LuuTruService(IDbservice dbservice)
        {
            _dbservice = dbservice;
        }

        public async Task<bool> CreateLuuTru(LuuTru luuTru)
        {
            var sql = await _dbservice.CreateData("INSERT INTO public.luutru(masanpham, tensanpham, soluong, nguoixuli, nhaporxuat) VALUES(@masanpham, @tensanpham, @soluong, @nguoixuli, @nhaporxuat)", luuTru);
            return true;
        }

        public async Task<List<LuuTru>> GetAllLuuTru()
        {
            var result = await _dbservice.GettAll<LuuTru>("SELECT * FROM public.luutru", new { });
            return result;
        }

        public async Task<List<LuuTru>> SearchAllLuuTru(string masanpham)
        {
            var result = await _dbservice.GettAll<LuuTru>("SELECT * FROM public.luutru WHERE masanpham like '%@masanpham%'", new { masanpham });
            return result;
        }
    }
}
