using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface INzFoodFilesData
    {
        Task<List<NzFoodFilesModel>> GetNzFoodByFoodId(string FoodId);
    }
}