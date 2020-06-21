using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface ICustomFoodData
    {
        Task CreateCustomFood(CustomFoodModel customFood);

        Task<List<CustomFoodModel>> GetAllCustomFood();

        Task<List<CustomFoodModel>> GetCustomFoodByFoodId(int CustomFoodId);
    }
}