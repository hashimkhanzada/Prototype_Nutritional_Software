using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class CustomFoodData : ICustomFoodData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public CustomFoodData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<CustomFoodModel>> GetAllCustomFood()
        {
            return _dataAccess.LoadData<CustomFoodModel, dynamic>(
                "spCustomFood_GetAll",
                new { },
                _connectionString.SqlConnectionName);
        }

        public async Task CreateCustomFood(CustomFoodModel customFood)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("ShortName", customFood.ShortName);
            p.Add("ServingSize", customFood.ServingSize);
            p.Add("Energy", customFood.Energy);
            p.Add("Carbohydrates", customFood.Carbohydrates);
            p.Add("Protein", customFood.Protein);
            p.Add("Fat", customFood.Fat);
            p.Add("Sugar", customFood.Sugar);
            p.Add("Sodium", customFood.Sodium);
            p.Add("SaturatedFat", customFood.SaturatedFat);
            p.Add("Fibre", customFood.Fibre);

            await _dataAccess.SaveData("dbo.spCustomFood_Insert",
                                       p,
                                       _connectionString.SqlConnectionName);

        }

        public Task<List<CustomFoodModel>> GetCustomFoodByFoodId(int CustomFoodId)
        {
            return _dataAccess.LoadData<CustomFoodModel, dynamic>("dbo.spCustomFood_GetFood_ByFoodId",
                new
                {
                    CustomFoodId
                },
                _connectionString.SqlConnectionName);
        }
    }
}
