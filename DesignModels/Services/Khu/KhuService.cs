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
    public class KhuService : IKhuService
    {
        private readonly IDbservice _dbservice;

        public KhuService(IDbservice dbservice)
        {
            _dbservice = dbservice;
        }

        public async Task<bool> CheckName(string name, int id)
        {
            var sql = "SELECT COUNT(1) FROM public.khu WHERE tenkhu = @name and id != @id";
            return await _dbservice.CheckExists(sql, new { name, id });
        }

        public async Task<bool> CheckNameSave(string name)
        {
            var sql = "SELECT COUNT(1) FROM public.khu WHERE tenkhu = @name";
            return await _dbservice.CheckExists(sql, new { name});
        }

        public async Task<bool> CreateKhu(Khu khu)
        {
            var sql = await _dbservice.CreateData("INSERT INTO public.khu(tenkhu) VALUES(@tenkhu)", khu);
            return true;
        }


        public async Task<List<Khu>> GetAllKhu()
        {
            var result = await _dbservice.GettAll<Khu>("SELECT * FROM public.khu", new { });
            return result;
        }

    }
}
