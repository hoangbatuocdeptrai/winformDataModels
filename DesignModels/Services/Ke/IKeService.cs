using DesignModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesignModels.Services
{
    public interface IKeService
    {
        Task<bool> CreateKe(Ke ke);
        Task<List<Ke>> GetAllKe();
        Task<bool> CheckNameSave(string name);

    }
}
