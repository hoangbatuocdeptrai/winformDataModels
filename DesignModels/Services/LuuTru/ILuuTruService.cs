using DesignModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesignModels.Services
{
    public interface ILuuTruService
    {
        Task<bool> CreateLuuTru(LuuTru luuTru);
        Task<List<LuuTru>> GetAllLuuTru();
        Task<List<LuuTru>> SearchAllLuuTru(string name);
      
    }
}
