using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.Auth;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IUserRepository : IDataRepository<User>
    {
        User GetAuthUser(LoginModel user);
        Task<ActionResult<User>> FindByEmail(string email);
        Task<ActionResult<User>> GetById(int id, bool withAdresses = false);
        Task<ActionResult<User>> GetAllUserData(int id);
    }
}
