using Dapper;
using DesignModels.Service;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModels.Service
{
    public class DbService : IDbservice
    {
        private readonly NpgsqlConnection _db;

        public DbService()
        {
            _db = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=hoang2002;Database=Models");
            _db.Open();
        }


        public async Task<int> EditData(string commamd, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(commamd, parms);

            return result;
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;

        }

        public async Task<List<T>> GettAll<T>(string command, object parms)
        {
            List<T> result = new List<T>();

            result = (await _db.QueryAsync<T>(command, parms)).ToList();

            return result;

        }

        public async Task<int> CreateData(string commamd, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(commamd, parms);

            return result;
        }

        public async Task<int> DeleteData(string commamd, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(commamd, parms);

            return result;
        }

        public async Task<T> GetOneProperty<T>(string commamd, object parms)
        {
            T result;
            result = (await _db.QueryFirstOrDefaultAsync<T>(commamd, parms).ConfigureAwait(false));
            return result;
        }


        public async Task<bool> CheckExists(string command, object parms)
        {
            return await _db.ExecuteScalarAsync<bool>(command, parms);
        }


    }
}
