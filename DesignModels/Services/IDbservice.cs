using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModels.Service
{
    public interface IDbservice
    {
        Task<T> GetAsync<T>(string command, object parms);
        Task<List<T>> GettAll<T>(string command, object parms);
        Task<int> EditData(string commamd, object parms);
        Task<int> CreateData(string commamd, object parms);
        Task<int> DeleteData(string commamd, object parms);
        Task<T> GetOneProperty<T>(string commamd, object parms);
        Task<bool> CheckExists(string command, object parms);
    }
}
