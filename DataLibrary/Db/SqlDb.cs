using Dapper; //Added nuget package, used to simplify data access. Run a stored procedure and get a model
using Microsoft.Data.SqlClient;//Added nuget package. Dapper uses it to connect to sql server 
using Microsoft.Extensions.Configuration; //Added nuget package. connect to appsettings.json (where the connection string is)
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Db
{
    public class SqlDb : IDataAccess //interface extracted from this class
    {
        private readonly IConfiguration _config;

        //constructor - method that is used to initialize this class. It's called whenever an object of this class is created
        public SqlDb(IConfiguration config) //Dependency injection - Iconfiguration comes from the front end (appsettings.json)
        {
            _config = config;
        }

        //Used to load data - returns data in a list
        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName) //
        {
            string connectionString = _config.GetConnectionString(connectionStringName); //gets connection string from IConfiguration (appsettings.json)

            using (IDbConnection connection = new SqlConnection(connectionString)) //creates connection to sql server, inside a using statement
            {
                var rows = await connection.QueryAsync<T>(storedProcedure, //dapper - executes stored procedures, with any parameters needed
                                                          parameters, //<T> will be the model
                                                          commandType: CommandType.StoredProcedure); //this method will only take in stored procedures, for raw sql, the command type needs to be removed. Most queries will be resused, so stored procedures are more efficient

                return rows.ToList(); //will return Ienumerable of <T> (list of <model>)
            } //closes connection here
        }

        //Used to save data
        public async Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionStringName) //<T> here is the parameters, not the model
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.ExecuteAsync(storedProcedure,
                                                     parameters,
                                                     commandType: CommandType.StoredProcedure);
            }
        }
    }
}
