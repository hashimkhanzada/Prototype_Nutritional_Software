using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    class UserData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public UserData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<UserModel>> GetUser()
        {
            return _dataAccess.LoadData<UserModel, dynamic>("", //stored procedure
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }
    }
}
