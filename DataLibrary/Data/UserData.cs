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
    public class UserData : IUserData //interface extracted from the class (interface is called instead of the class - dependency injection
    {
        private readonly IDataAccess _dataAccess; //initialize fields
        private readonly ConnectionStringData _connectionString;

        //IDataAccess = access to sql (interface extracted from the sqldb class)
        //ConnectionStringData = class where the connection string name is specified
        public UserData(IDataAccess dataAccess, ConnectionStringData connectionString) 
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<UserModel>> GetUser() //gets a list of all users. This method isn't used yet
        {
            return _dataAccess.LoadData<UserModel, dynamic>("dbo.spUser_All", //select * from user table
                                                            new { }, //this is where the parameters would go
                                                            _connectionString.SqlConnectionName); //gets the connection string based on the name, from appsettings.json
        }

        public async Task GetUserByUserId(string Id) //this method hasn't been used
        {
            //LoadData<T, U> and SaveData<T> are from IDataAccess (sqldb)
            var recs = await _dataAccess.LoadData<UserModel, dynamic>("dbo.spUser_GetByUserId", //select user based on who's logged in
                new
                {
                    Id //this will be the userId of the user logged in
                },
                _connectionString.SqlConnectionName);
        }

        public async Task CreateUserDetails(UserModel user) // creates new user/inserts data into user table
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Id", user.Id); //parameters are retrieved from the user model (which is where the data will be inserted from the view (register page)
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


            await _dataAccess.SaveData("dbo.spUser_Insert", //stored procedure to insert data
                                       p,
                                       _connectionString.SqlConnectionName);
        }

        
    }
}
