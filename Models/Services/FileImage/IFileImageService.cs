using Model;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public interface IFileImageService
    {
        Task<bool> CreateDetailModels(DetailModels detailModels);
        Task<DetailModels> GetDetailModels(int id);
        Task<List<DetailModels>> GetAllDetailModels();
        Task<DetailModels> UpdateDetailModels(DetailModels detailModels);
        Task<bool> DeleteDetailModels(int id);
        Task<DetailModels> GetDetailModelsByName(string name);
        Task<bool> CheckName(string name);
        Task<DetailModels> GetImageByBarcode(string barode);
    }
}
