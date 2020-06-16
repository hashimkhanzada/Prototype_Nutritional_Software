﻿using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class UserFoodData : IUserFoodData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public UserFoodData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<UserFoodModel>> GetUserFoodByIdAndDate(string UserId, DateTime Date)
        {
            return _dataAccess.LoadData<UserFoodModel, dynamic>("dbo.spUserFood_GetByUserId_ByDate",
                new
                {
                    Id = UserId,
                    Date
                },
                _connectionString.SqlConnectionName);
        }


    }
}