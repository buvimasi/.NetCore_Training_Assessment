using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Training.Domain.Data;
using Training.Domain.Entities;
using Training.WebAPI.Helpers;
using Training.WebAPI.IServices;
using Training.WebAPI.Models;

namespace Training.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly AppSettings _appSettings;
        public UserService(EmployeeDbContext dbContext,IOptions<AppSettings> appSettings)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        #region Helper 
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is my first Security key and hope this is enough to create jwt token");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
        public List<User> GetUser()
        {
            var user = _dbContext.Users.ToList();
            return user;
        }
        public User GetById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u=>u.Id == id);
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
