using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class CalorieCountData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public CalorieCountData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<int> CreateCalorieCount(CalorieCountModel calorieCount)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("CountId", calorieCount.CountId);
            p.Add("UserId", calorieCount.UserId);
            p.Add("CalorieGoal", calorieCount.CalorieGoal);
            p.Add("Date", calorieCount.Date);
            p.Add("CaloriesConsumed", calorieCount.CaloriesConsumed);
            p.Add("RecipeId", calorieCount.RecipeId);
            p.Add("FoodId", calorieCount.FoodId);

            await _dataAccess.SaveData("", //insert statement
                                       p,
                                       _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        //public Task<int> 

    }
}
