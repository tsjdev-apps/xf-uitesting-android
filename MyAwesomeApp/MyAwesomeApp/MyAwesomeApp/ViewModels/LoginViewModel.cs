using MyAwesomeApp.Services;
using MyAwesomeApp.Views;
using Xamarin.Forms;

namespace MyAwesomeApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;


        private string _username;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); LoginCommand.ChangeCanExecute(); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); LoginCommand.ChangeCanExecute(); }
        }


        private Command _loginCommand;
        public Command LoginCommand => _loginCommand ?? (_loginCommand = new Command(Login, CanLogin));


        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }


        private async void Login()
        {
            IsLoading = true;

            var loginResult = await _loginService.LoginAsync(Username, Password);

            if (loginResult)
                Application.Current?.MainPage?.Navigation?.PushAsync(new MainPage());

            IsLoading = false;
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }
    }
}
