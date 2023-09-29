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
    public class KeService : IKeService
    {
        private readonly IDbservice _dbservice;

        public KeService(IDbservice dbservice)
        {
            _dbservice = dbservice;
        }

        public async Task<bool> CheckName(string name, int id)
        {
            var sql = "SELECT COUNT(1) FROM public.ke WHERE tenke = @name and id != @id";
            return await _dbservice.CheckExists(sql, new { name, id });
        }

        public async Task<bool> CheckNameSave(string name)
        {
            var sql = "SELECT COUNT(1) FROM public.ke WHERE tenke = @name";
            return await _dbservice.CheckExists(sql, new { name});
        }

        public async Task<bool> CreateKe(Ke ke)
        {
            var sql = await _dbservice.CreateData("INSERT INTO public.ke(tenke) VALUES(@tenke)", ke);
            return true;
        }


        public async Task<List<Ke>> GetAllKe()
        {
            var result = await _dbservice.GettAll<Ke>("SELECT * FROM public.ke", new { });
            return result;
        }

    }
}
