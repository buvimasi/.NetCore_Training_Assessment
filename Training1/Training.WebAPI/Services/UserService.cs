using Training.Domain.Data;
using Training.Domain.Entities;
using Training.WebAPI.IServices;
using Training.WebAPI.Models;

namespace Training.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly EmployeeDbContext _dbContext;
        public UserService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }   

        public List<User> GetUser()
        {
            var user = _dbContext.Users.ToList();
            return user;
        }

        public string UpdateUser(UserModel user)
        {
            if(user != null)
            {
                _dbContext.Add(new User
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role,
                });
                _dbContext.SaveChanges();
                return "User Updated Successfully";
            }
            else
            {
                return "No Data found";
            }
        }
    }
}
