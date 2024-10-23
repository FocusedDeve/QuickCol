using System.Windows.Input;
using Microsoft.Maui.Controls;

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

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
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
    }
}
