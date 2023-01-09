using Dapper;
using Roulette.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.API.Repositories
{
    public abstract class DapperRepository : IDapperRepository
    {
        private string _connectionString;

        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, DynamicParameters parameters = null)// where T : class
        {
            return await QueryAsync<T>(query, CommandType.StoredProcedure, parameters);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, CommandType commandType, DynamicParameters parameters = null)// where T : class
        {
            using (var db = new SqlConnection(_connectionString))
            {
                if (parameters != null)
                {
                    var result = await db.QueryAsync<T>(query, param: parameters, commandType: commandType);
                    return result;
                }
                else
                {
                    var result = await db.QueryAsync<T>(query, commandType: commandType);
                    return result;
                }
            }
        }

        public async Task ExecuteAsync(string query, DynamicParameters parameters = null)
        {
            await ExecuteAsync(query, CommandType.StoredProcedure, parameters);
        }

        public async Task ExecuteAsync(string query, CommandType commandType, DynamicParameters parameters = null)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                if (parameters != null)
                {
                    await db.ExecuteAsync(query, param: parameters, commandType: commandType);
                }
                else
                {
                    await db.ExecuteAsync(query, commandType: commandType);
                }
            }
        }

        public async Task<(int ReturnValue, DynamicParameters Parameters)> ExecuteOutParamAsync(string query, DynamicParameters parameters)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var result = await db.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return (result, parameters);
            }

        }
    }
}
