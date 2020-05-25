using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Db
{
    public class SqlDb
    {
        private readonly IConfiguration _config;

        public SqlDb(IConfiguration config)
        {
            _config = config;
        }

        //Still working on this code, it's to set up the crud actions, it'll be done using stored procedures

        //public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        //{
        //    string connectionString = _config.GetConnectionString(connectionStringName);
        
            
        //}
    }
}
