using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using QRCoder;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;

namespace QuickCol.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string nom;
        [ObservableProperty]
        private string prenoms;
        [ObservableProperty]
        private string adresse;
        [ObservableProperty]
        private string telephone;
        [ObservableProperty]
        private string codeClient;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string confirmPassword;
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private ImageSource _qrCodeImageSource;

       /* public string Nom
        {
            get => nom;
            set
            {
                nom = value;
                OnPropertyChanged();
            }
        }

        public string Prenoms
        {
            get => prenoms;
            set
            {
                prenoms = value;
                OnPropertyChanged();
            }
        }

        public string Telephone
        {
            get => telephone;
            set
            {
                telephone = value;
                OnPropertyChanged();
            }
        }

        public string CodeClient
        {
            get => codeClient;
            set
            {
                codeClient = value;
                OnPropertyChanged();
            }
        }

        public string Adresse
        {
            get => adresse;
            set
            {
                adresse = value;
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


        public ImageSource QrCodeImageSource
        {
            get => _qrCodeImageSource;
            set
            {
                _qrCodeImageSource = value;
                OnPropertyChanged(nameof(QrCodeImageSource));
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
        }*/

        public ICommand NextCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand QrCodeCommand { get; }
        public ICommand ClientCommand { get; }
        public ICommand AgentCommand { get; }
        public ICommand NextCommand2 { get; }

        public RegisterViewModel()
        {
            NextCommand = new Command(() => OnNextClicked());
            RegisterCommand = new Command(() => OnRegisterClicked());
            ClientCommand = new Command(() => OnClientClicked());
            AgentCommand = new Command(() => OnAgentClicked());
            NextCommand2 = new Command(() => OnCommand2Clicked());
            QrCodeCommand = new Command(() => OnCodeQrCommand());

            Nom = "TestNom";
            Prenoms = "TestPrenoms";
            Telephone = "0000000000";
            Adresse = "TestAdresse";
            CodeClient = "123456";
            Password = "testpassword";
            ConfirmPassword = "testpassword";

        }

        private void OnCodeQrCommand()
        {

            // Forcer la mise à jour des propriétés
            OnPropertyChanged(nameof(Nom));
            OnPropertyChanged(nameof(Prenoms));
            OnPropertyChanged(nameof(Telephone));
            OnPropertyChanged(nameof(Adresse));
            OnPropertyChanged(nameof(CodeClient));
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(ConfirmPassword));


            if (string.IsNullOrWhiteSpace(Nom) || string.IsNullOrWhiteSpace(Prenoms) ||
                string.IsNullOrWhiteSpace(Telephone) || string.IsNullOrWhiteSpace(Adresse) ||
                string.IsNullOrWhiteSpace(CodeClient) || string.IsNullOrWhiteSpace(Password))
            {
                Application.Current.MainPage.DisplayAlert("Erreur", "Veuillez remplir tous les champs avant de générer le QR code.", "OK");
                return;
            }

            string dataToEncode = $"{Nom};{Prenoms};{Telephone};{Adresse};{CodeClient}";

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(dataToEncode, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeImage = qrCode.GetGraphic(20);
                QrCodeImageSource = ImageSource.FromStream(() => new MemoryStream(qrCodeImage));
                OnPropertyChanged(nameof (QrCodeImageSource));
            }
        }


        private async Task ExecuteCommandAsync(Func<Task> command)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await command();
            IsBusy = false;
        }

        private Task OnNextClicked() => ExecuteCommandAsync(async () => await Shell.Current.GoToAsync("RegisterStep2Page"));

        private Task OnRegisterClicked() => ExecuteCommandAsync(async () =>
        {
            if (Password != ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Les mots de passe ne correspondent pas.", "OK");
                return;
            }

            await Task.Delay(1000); // Simuler l'enregistrement

            await Shell.Current.GoToAsync("//MainPage");
        });

        private Task OnClientClicked() => ExecuteCommandAsync(async () => await Shell.Current.GoToAsync("RegisterStep1Page"));
        private Task OnAgentClicked() => ExecuteCommandAsync(async () => await Shell.Current.GoToAsync("AgentRegisterPage"));
        private Task OnCommand2Clicked() => ExecuteCommandAsync(async () => await Shell.Current.GoToAsync("RegisterStep3Page"));

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
