using DesignModels.Entity;
using DesignModels.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModels.Services.FileImage
{
    public class FileImageService:IFileImageService
    {
        private readonly IDbservice _dbservice;
        public FileImageService(IDbservice dbservice) 
        {
            _dbservice = dbservice; 
        }

        public async Task<bool> CheckName(string barcode)
        
        {
            var sql = "SELECT COUNT(1) FROM public.detailmodels WHERE barcode = @barcode";
            return await _dbservice.CheckExists(sql, new { barcode });
        }

        public async Task<bool> CreateDetailModels(DetailModels detailModels)
        {
            var sql = await _dbservice.CreateData("INSERT INTO public.detailmodels(modelid, barcode, pathimage, created_at, status) VALUES(@modelid, @barcode, @pathimage, @created_at, @status)", detailModels);
            return true;
        }

        public async Task<bool> DeleteDetailModels(int id)
        {
            var sql = await _dbservice.DeleteData("DELETE FROM public.detailmodels WHERE id = @id", new { id });
            return true;
        }

        public async Task<List<DetailModels>> GetAllDetailModels()
        {
            var result = await _dbservice.GettAll<DetailModels>("SELECT * FROM public.detailmodels", new { });
            return result;
        }

        public async Task<DetailModels> GetDetailModels(int id)
        {
            var sql = "SELECT * FROM public.detailmodels WHERE id = @id";
            return await _dbservice.GetAsync<DetailModels>(sql, new { id });
        }

        public Task<DetailModels> GetDetailModelsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<DetailModels> GetImageByBarcode(string barcode)
        {
            var sql = "SELECT * FROM public.detailmodels WHERE barcode  = @barcode";
            return await _dbservice.GetAsync<DetailModels>(sql, new { barcode });
        }

        public async Task<DetailModels> UpdateDetailModels(DetailModels detailModels)
        {
            var abc = await _dbservice.EditData("UPDATE public.detailmodels SET modelid = @modelid, barcode = @barcode, pathimage = @pathimage, created_at = @created_at, status = @status WHERE id = @id", detailModels);
            return detailModels;
        }
    }
}
