using System.Threading.Tasks;

namespace MyAwesomeApp.Services
{
    public class LoginService : ILoginService
    {
        public async Task<bool> LoginAsync(string username, string password)
        {
            await Task.Delay(2000);
            return username == password;
        }
    }
}
