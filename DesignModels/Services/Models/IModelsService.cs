using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesignModels.Services
{
    public interface IModelsService
    {
        Task<bool> CreateModelss(Modelss models);
        Task<Modelss> GetModelss(int id);
        Task<List<Modelss>> GetAllModels();
        Task<Modelss> UpdateModelss(Modelss models);
        Task<bool> DeleteModelss(int id);
        Task<Modelss> GetModelssByName(string modelName);
        Task<bool> CheckName(string name, int id);
        Task<bool> CheckNameSave(string name);


    }
}
