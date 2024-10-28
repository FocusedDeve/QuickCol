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
        private bool isBusy;

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

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand NextCommand { get; }
        public ICommand RegisterCommand { get; }

        public ICommand ClientCommand { get; }
        public ICommand AgentCommand { get; }
        public ICommand NextCommand2 { get; }

        public RegisterViewModel()
        {
            NextCommand = new Command(OnNextClicked);
            RegisterCommand = new Command(OnRegisterClicked);

            ClientCommand = new Command(OnClientClicked);
            AgentCommand = new Command(OnAgentClicked);

            NextCommand2 = new Command(OnCommand2Clicked);
        }

        private async void OnCommand2Clicked(object obj)
        {
            if (IsBusy)
                return;

            IsBusy = true; // Active l'indicateur de chargement

            // Simule une action longue (par exemple une navigation ou appel à une API)
            await Task.Delay(1000);

            IsBusy = false; // Désactive l'indicateur de chargement

            // Naviguer vers la page suivante
            await Shell.Current.GoToAsync("RegisterStep3Page");
        }

        private async void OnAgentClicked()
        {
            if (IsBusy)
                return;

            IsBusy = true; // Active l'indicateur de chargement

            // Simule une action longue (par exemple une navigation ou appel à une API)
            await Task.Delay(1000);

            IsBusy = false; // Désactive l'indicateur de chargement

            // Naviguer vers la page suivante
            await Shell.Current.GoToAsync("AgentRegisterPage");
        }

        private async void OnClientClicked()
        {
            if (IsBusy)
                return;

            IsBusy = true; // Active l'indicateur de chargement

            // Simule une action longue (par exemple une navigation ou appel à une API)
            await Task.Delay(1000);

            IsBusy = false; // Désactive l'indicateur de chargement

            // Naviguer vers la page suivante
            await Shell.Current.GoToAsync("RegisterStep1Page");
        }

        private async void OnNextClicked()
        {
            if (IsBusy)
                return;

            IsBusy = true; // Active l'indicateur de chargement

            // Simule une action longue (par exemple une navigation ou appel à une API)
            await Task.Delay(1000);

            IsBusy = false; // Désactive l'indicateur de chargement

            // Naviguer vers la page suivante
            await Shell.Current.GoToAsync("RegisterStep2Page");
        }

        private async void OnRegisterClicked()
        {
            if (IsBusy)
                return;

            // Vérifier la correspondance des mots de passe
            if (Password == ConfirmPassword)
            {
                IsBusy = true;

                // Simuler l'enregistrement de l'utilisateur (API ou base de données)
                await Task.Delay(1000);

                IsBusy = false;

                // Naviguer vers la page principale
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                // Afficher un message d'erreur (vous pouvez utiliser un dialogue ou un label d'erreur lié au ViewModel)
                await Application.Current.MainPage.DisplayAlert("Erreur", "Les mots de passe ne correspondent pas.", "OK");
            }
        }
    }
}
