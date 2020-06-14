using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class NzFoodFilesData : INzFoodFilesData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public NzFoodFilesData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<NzFoodFilesModel>> GetNzFoodByFoodId(string FoodId)
        {
            return _dataAccess.LoadData<NzFoodFilesModel, dynamic>("dbo.spNzFood_GetFood_ByFoodId",
                new
                {
                    FoodId
                },
                _connectionString.SqlConnectionName);
        }
    }
}
