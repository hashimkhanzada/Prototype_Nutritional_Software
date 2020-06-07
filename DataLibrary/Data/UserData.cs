using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return _dataAccess.LoadData<UserModel, dynamic>("dbo.spUser_All", //select * from user table- stored procedure
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }

        public async Task<UserModel> GetUserByUserId(string UserId) 
        {
            var recs = await _dataAccess.LoadData<UserModel, dynamic>("dbo.spUser_GetByUserId", //select user based on who's logged in
                new
                {
                    Id = UserId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }

        public async Task CreateUserDetails(UserModel user)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("UserId", user.UserName);
            p.Add("UserId", user.Email);
            p.Add("UserId", user.Height);
            p.Add("UserId", user.Weight);
            p.Add("UserId", user.Age);
            p.Add("UserId", user.FirstName);
            p.Add("UserId", user.LastName);


            await _dataAccess.SaveData("spUser_Insert", //insert statement
                                       p,
                                       _connectionString.SqlConnectionName);
        }
    }
}
