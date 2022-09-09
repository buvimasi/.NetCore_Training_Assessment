using Training.Domain.Entities;
using Training.WebAPI.Models;

namespace Training.WebAPI.IServices
{
    public interface IUserService
    {
        List<User> GetUser();

        string UpdateUser(UserModel user);
    }
}
