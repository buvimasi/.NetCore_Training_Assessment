using Training.Domain.Entities;

namespace Training.WebAPI.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Username = user.UserName;
            Token = token;
        }
    }
}
