﻿using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IUserFoodData
    {
        Task<List<UserFoodModel>> GetUserFoodByIdAndDate(string UserId, DateTime Date);

        Task InsertFood(UserFoodModel userFood);

        Task<int> DeleteUserFood(int UserFoodId);

        Task InsertCustomFood(UserFoodModel userFood);
    }
}