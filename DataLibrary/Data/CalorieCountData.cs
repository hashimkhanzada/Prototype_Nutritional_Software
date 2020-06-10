﻿using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class CalorieCountData : ICalorieCountData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public CalorieCountData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task CreateCalorieCount(CalorieCountModel calorieCount)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("UserId", calorieCount.UserId);
            p.Add("CalorieGoal", calorieCount.CalorieGoal);
            p.Add("Date", calorieCount.Date);

            await _dataAccess.SaveData("dbo.spCalorieCount_InsertInitialUserData", //insert statement
                                       p,
                                       _connectionString.SqlConnectionName);
        }

        public async Task<CalorieCountModel> GetCalorieCountByIdAndDate(string UserId, DateTime Date)
        {
            var recs = await _dataAccess.LoadData<CalorieCountModel, dynamic>("dbo.spCalorieCount_GetByUserId_ByDate",
                new
                {
                    Id = UserId,
                    Date
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }


    }
}
