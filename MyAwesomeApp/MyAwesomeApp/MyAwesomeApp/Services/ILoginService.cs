using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyAwesomeApp.Services
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}
