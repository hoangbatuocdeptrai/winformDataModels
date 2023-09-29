using DesignModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesignModels.Services
{
    public interface IKhuService
    {
        Task<bool> CreateKhu(Khu khu);
        Task<List<Khu>> GetAllKhu();
        Task<bool> CheckNameSave(string name);

    }
}
