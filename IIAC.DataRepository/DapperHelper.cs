using Dapper;
using IIAC.DataRepository.Interfaces;
using IIAC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IIAC.DataRepository
{
    public class DapperHelper : IDapperHelper
    {
        private string _connectionString;
        private ConnectionString _options;
        public DapperHelper(IOptions<ConnectionString> options)
        {
            this._options = options.Value;
            _connectionString = _options.DefaultConnectionString;
        }
        public T AddOrUpdateAsync<T>(string procedureName, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {

                    return connection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                catch (SqlException ex)
                {

                    throw ex;
                }

            }
        }

        public bool Delete(string procedureName, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var result = connection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    return Convert.ToBoolean(result);
                }
                catch (SqlException ex)
                {

                    throw ex;
                }

            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string procedureName, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {

                    return await connection.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        public T GetAsync<T>(string procedureName, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {

                    return connection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        public int Upsert(string procedureName, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {

                    return connection.Query<int>(procedureName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
    }
}
