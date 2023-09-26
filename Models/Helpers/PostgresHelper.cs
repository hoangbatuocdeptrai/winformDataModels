using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;
//using Dapper.Contrib.Extensions;
//using DevExpress.XtraEditors;
//using NTA_Stone.Module;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class PostgresHelper
    {
        public static T GetById<T>(int id) where T : class
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(Constants.PostgresConnection);
            var dataSource = dataSourceBuilder.Build();

            using (var connection = dataSource.OpenConnection())
            {
                try
                {
                    return connection.Get<T>(id);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public static List<T> GetAll<T>() where T : class
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(Constants.PostgresConnection);
            var dataSource = dataSourceBuilder.Build();

            using (var connection = dataSource.OpenConnection())
            {
                try
                {
                    return connection.GetAll<T>().ToList();
                }
                catch (Exception)
                {
                    return new List<T>();
                }
            }
        }

        public static long Insert<T>(T entityToInsert) where T : class
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(Constants.PostgresConnection);
            var dataSource = dataSourceBuilder.Build();

            using (var connection = dataSource.OpenConnection())
            {
                //connection.Open();
                long re = 0;
                try
                {
                    re = connection.Insert(entityToInsert);
                }
                catch (Exception ex)
                {
                    re = 0;
                    throw new Exception(ex.Message);
                }
                return re;
            }
        }

        public static bool Update<T>(T entityToUpdate) where T : class
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(Constants.PostgresConnection);
            var dataSource = dataSourceBuilder.Build();
            using (var connection = dataSource.OpenConnection())
            {
                //connection.Open();
                var result = false;
                try
                {
                    result = connection.Update(entityToUpdate);
                }
                catch (Exception ex)
                {
                    result = false;
                    //XtraMessageBox.Show(ex.Message);
                    throw new Exception(ex.Message);
                }
                return result;
            }
        }

        public static bool Delete<T>(T entityToDelete) where T : class
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(Constants.PostgresConnection);
            var dataSource = dataSourceBuilder.Build();
            using (var connection = dataSource.OpenConnection())
            {
                //connection.Open();
                bool success = false;
                try
                {
                    success = connection.Delete(entityToDelete);
                }
                catch (Exception ex)
                {
                    //XtraMessageBox.Show(ex.Message);
                    throw new Exception(ex.Message);
                }
                return success;
            }
        }
        public static DataTable ExecProcedureDataAsDataTable(string ProcedureName, object parametter = null)
        {
            using (var connection = new SqlConnection(Constants.PostgresConnection))
            {
                connection.Open();
                DataTable table = new DataTable();
                try
                {
                    var reader = connection.ExecuteReader(ProcedureName, param: parametter, commandType: CommandType.StoredProcedure);

                    table.Load(reader);
                }
                catch (Exception ex)
                {
                    //HelperMessage.Instance.ShowMessageOKWarning(ex.Message, "Lỗi trả về từ Server: ");
                    throw new Exception(ex.Message);
                }

                return table;
            }
        }



        

    }
}
