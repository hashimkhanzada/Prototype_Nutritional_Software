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
    public class UserData : IUserData
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

        public async Task<UserModel> GetUserByUserId(string Id)
        {
            var recs = await _dataAccess.LoadData<UserModel, dynamic>("dbo.spUser_GetByUserId", //select user based on who's logged in
                new
                {
                    Id
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }

        public async Task CreateUserDetails(UserModel user)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Id", user.Id);
            p.Add("UserName", user.UserName);
            p.Add("Email", user.Email);
            p.Add("FirstName", user.FirstName);
            p.Add("LastName", user.LastName);
            p.Add("Height", user.Height);
            p.Add("Weight", user.Weight);
            p.Add("Age", user.Age);
            p.Add("Gender", user.Gender);
            p.Add("ActivityLevel", user.ActivityLevel);
            p.Add("MedicalConditions", user.MedicalConditions);


            await _dataAccess.SaveData("dbo.spUser_Insert", //insert statement
                                       p,
                                       _connectionString.SqlConnectionName);
        }
    }
}
