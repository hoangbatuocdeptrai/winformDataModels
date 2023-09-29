using DesignModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesignModels.Services
{
    public interface IXuatKhoService
    {
        Task<bool> CreateXuatKho(XuatKho xuatKho);
        //Task<NhapKho> GetNhapKho(int id);
        Task<List<XuatKho>> GetAllXuatKho();
    }
}
