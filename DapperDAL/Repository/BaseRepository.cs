using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL.Repository
{
    public abstract class BaseRepository
    {
        protected string _ConnectionString = "";
        public SqlConnection _SqlConnection => new SqlConnection(_ConnectionString);

        public T ExecuteScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = _SqlConnection)
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = _SqlConnection)
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(
                    await sqlCon.ExecuteScalarAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure
                    )
                    , typeof(T));
            }
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = _SqlConnection)
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task ExecuteAsync(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = _SqlConnection)
            {
                sqlCon.Open();
              await  sqlCon.ExecuteAsync(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> QueryList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = _SqlConnection)
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> QueryListAsync<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = _SqlConnection)
            {
                sqlCon.Open();
                return await sqlCon.QueryAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public T QueryFirstOrDefault<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = _SqlConnection)
            {
                sqlCon.Open();
                return sqlCon.QueryFirstOrDefault<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = _SqlConnection)
            {
                sqlCon.Open();
                return await sqlCon.QueryFirstOrDefaultAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

    }
}
