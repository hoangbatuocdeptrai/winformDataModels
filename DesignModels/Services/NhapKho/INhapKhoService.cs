using DesignModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesignModels.Services
{
    public interface INhapKhoService
    {
        Task<bool> CreateNhapkho(NhapKho nhapKho);
        //Task<NhapKho> GetNhapKho(int id);
        Task<List<NhapKho>> GetAllNhapKho();
    


    }
}
