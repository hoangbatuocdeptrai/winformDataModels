using DesignModels.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignModels.Services
{
    public class ModelsService : IModelsService
    {
        private readonly IDbservice _dbservice;

        public ModelsService(IDbservice dbservice)
        {
            _dbservice = dbservice;
        }

        public async Task<bool> CheckName(string name, int id)
        {
            var sql = "SELECT COUNT(1) FROM public.models WHERE modelsname = @name and id != @id";
            return await _dbservice.CheckExists(sql, new { name, id });
        }

        public async Task<bool> CheckNameSave(string name)
        {
            var sql = "SELECT COUNT(1) FROM public.models WHERE modelsname = @name";
            return await _dbservice.CheckExists(sql, new { name});
        }

        public async Task<bool> CreateModelss(Modelss models)
        {
            var sql = await _dbservice.CreateData("INSERT INTO public.models(modelsname, quantity, created_at, updated_at, trayThicknessmm, traycount) VALUES(@modelsname, @quantity, @created_at, @updated_at, @trayThicknessmm, @traycount)", models);
            return true;
        }

        public async Task<bool> DeleteModelss(int id)
        {
            var sql = await _dbservice.DeleteData("DELETE FROM public.models WHERE id = @id", new { id });
            return true ;
        }

        public async Task<List<Modelss>> GetAllModels()
        {
            var result = await _dbservice.GettAll<Modelss>("SELECT * FROM public.models", new { });
            return result;
        }

        public async Task<Modelss> GetModelss(int id)
        {
            var sql = "SELECT * FROM public.models WHERE id = @id";
            return await _dbservice.GetAsync<Modelss>(sql, new { id });
        }

        public async Task<Modelss> GetModelssByName(string modelName)
        {
            var sql = "SELECT * FROM public.models WHERE modelsname = @modelName";
            return await _dbservice.GetAsync<Modelss>(sql, new { modelName });
        }

        public async Task<Modelss> UpdateModelss(Modelss models)
        {
            var abc = await _dbservice.EditData("UPDATE public.models SET modelsname = @modelsname, quantity = @quantity, created_at = @created_at, updated_at = @updated_at WHERE id = @id", models);
            return models;

        }
    }
}
