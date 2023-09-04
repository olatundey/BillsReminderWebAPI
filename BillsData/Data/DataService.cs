using System;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace BillssData.Data
{
	public class DataService : IDataService
	{
        private readonly IConfiguration _config;

        public DataService(IConfiguration config)
        {
            _config = config;
        }

        // this method will return a list of type T
        public async Task<IEnumerable<T>> GetData<T, P>(string query, P parameters,
            string connectionId = "DefaultConnection")
        {
            using IDbConnection connection =
                new MySqlConnection(_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(query, parameters);
        }

        public async Task SaveData<P>
            (string query, P parameters, string connectionId = "DefaultConnection")
        {
            using IDbConnection connection =
                 new MySqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(query, parameters);

        }
    }
}

