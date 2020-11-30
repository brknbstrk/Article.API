using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Infrastructure.Auth
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        public UserService(IConfiguration config)
        {
            _config = config;
        }
        private List<User> _users = new List<User>();
        public async Task<User> Authenticate(string username, string password)
        {
            var auth = _config.GetSection("Auth");
            _users.Add(new User()
            {
                Username = auth.GetValue<string>("username"),
                Password = auth.GetValue<string>("password")
            });
            var user = await Task.Run(() => _users.FirstOrDefault(x => x.Username == username && x.Password == password));
            if (user == null)
                return null;

            return user;
        }
    }
}
