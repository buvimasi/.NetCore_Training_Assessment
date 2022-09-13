using Training.Domain.Entities;
using Training.WebAPI.Models;

namespace Training.WebAPI.IServices
{
    public interface IUserService
    {
        List<User> GetUser();

        string UpdateUser(UserModel user);
        User GetById(int id);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
