using DesignModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesignModels.Services
{
    public interface IHangService
    {
        Task<bool> CreateHang(Hang hang);
        Task<List<Hang>> GetAllHang();
        Task<bool> CheckNameSave(string name);

    }
}
