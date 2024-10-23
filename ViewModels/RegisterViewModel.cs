using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace QuickCol.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string password;
        private string confirmPassword;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
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

        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public ICommand NextCommand { get; }
        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            NextCommand = new Command(OnNextClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnNextClicked()
        {
            // Passer à la page suivante
            await Shell.Current.GoToAsync("RegisterStep2Page");
        }

        private async void OnRegisterClicked()
        {
            // Logique d'inscription
            if (Password == ConfirmPassword)
            {
                // Enregistrer l'utilisateur et naviguer vers la page principale
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                // Gérer les erreurs
            }
        }
    }
}
