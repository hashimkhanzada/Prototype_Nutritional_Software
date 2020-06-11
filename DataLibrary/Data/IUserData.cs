using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IUserData //methods are called from this interface instead of the UserData class - dependency injection
    {
        Task CreateUserDetails(UserModel user);
        Task<List<UserModel>> GetUser();
        Task GetUserByUserId(string Id);
    }
}