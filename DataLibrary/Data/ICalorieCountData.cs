using DataLibrary.Models;
using System;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface ICalorieCountData
    {
        Task CreateCalorieCount(CalorieCountModel calorieCount);
        Task<CalorieCountModel> GetCalorieCountByIdAndDate(string UserId, DateTime Date);

        Task<CalorieCountModel> GetRecentCalorieGoal(string UserId);
    }
}