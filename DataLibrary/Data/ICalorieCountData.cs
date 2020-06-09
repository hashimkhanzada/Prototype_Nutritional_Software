using DataLibrary.Models;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface ICalorieCountData
    {
        Task CreateCalorieCount(CalorieCountModel calorieCount);
    }
}