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
    public class HangService : IHangService
    {
        private readonly IDbservice _dbservice;

        public HangService(IDbservice dbservice)
        {
            _dbservice = dbservice;
        }

        public async Task<bool> CheckName(string name, int id)
        {
            var sql = "SELECT COUNT(1) FROM public.hang WHERE tenhang = @name and id != @id";
            return await _dbservice.CheckExists(sql, new { name, id });
        }

        public async Task<bool> CheckNameSave(string name)
        {
            var sql = "SELECT COUNT(1) FROM public.hang WHERE tenhang = @name";
            return await _dbservice.CheckExists(sql, new { name});
        }

        public async Task<bool> CreateHang(Hang hang)
        {
            var sql = await _dbservice.CreateData("INSERT INTO public.hang(tenhang) VALUES(@tenhang)", hang);
            return true;
        }


        public async Task<List<Hang>> GetAllHang()
        {
            var result = await _dbservice.GettAll<Hang>("SELECT * FROM public.hang", new { });
            return result;
        }

    }
}
