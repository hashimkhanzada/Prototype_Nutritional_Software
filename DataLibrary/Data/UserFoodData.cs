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

        public async Task InsertFood(UserFoodModel userFood)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("FoodId", userFood.FoodId);
            p.Add("UserId", userFood.UserId);
            p.Add("Date", userFood.Date);
            p.Add("Quantity", userFood.Quantity);

            await _dataAccess.SaveData("dbo.spUserFood_InsertFoodId",
                                       p,
                                       _connectionString.SqlConnectionName);
        }

        public async Task InsertCustomFood(UserFoodModel userFood)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("CustomFoodId", userFood.CustomFoodId);
            p.Add("UserId", userFood.UserId);
            p.Add("Date", userFood.Date);
            p.Add("Quantity", userFood.Quantity);

            await _dataAccess.SaveData("dbo.spUserFood_InsertCustomFood",
                                       p,
                                       _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteUserFood(int UserFoodId)
        {
            return _dataAccess.SaveData("dbo.spUserFood_DeleteFood",
                                        new
                                        {
                                            UserFoodId
                                        },
                                        _connectionString.SqlConnectionName);
        }


    }
}
