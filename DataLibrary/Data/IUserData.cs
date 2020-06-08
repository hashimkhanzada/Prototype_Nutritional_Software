using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IUserData
    {
        Task CreateUserDetails(UserModel user);
        Task<List<UserModel>> GetUser();
        Task<UserModel> GetUserByUserId(string Id);
    }
}