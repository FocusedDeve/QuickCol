using System.Windows.Input;
using Microsoft.Maui.Controls;
using QuickCol.Views.Register;

namespace QuickCol.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        private string password;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            GoToRegisterCommand = new Command(OnGoToRegister);
        }

        private async void OnLoginClicked()
        {
            // Logique de connexion
            if (Username == "admin" && Password == "password")
            {
                // Naviguer vers la page principale
                await Shell.Current.GoToAsync("RegisterStep1Page");
            }
            else
            {
                // Afficher un message d'erreur
            }
        }

        private async void OnGoToRegister()
        {
            // Redirection vers la page d'inscription
            await Shell.Current.GoToAsync(nameof(RegisterStep1Page));
        }
    }
}
