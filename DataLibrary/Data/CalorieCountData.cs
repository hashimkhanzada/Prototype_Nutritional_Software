using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
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



    }
}
