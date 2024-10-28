using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using QRCoder;
using System.IO;

namespace QuickCol.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string nom;
        private string prenoms;
        private string adresse;
        private string telephone;
        private string codeClient;
        private string password;
        private string confirmPassword;
        private bool isBusy;
        private ImageSource _qrCodeImageSource;

        public string Nom
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
        }

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

        }

        private void OnCodeQrCommand()
        {
            try
            {
                Console.WriteLine("Début de la génération du QR code...");

                string dataToEncode = $"{Nom};{Prenoms};{Telephone};{Adresse};{CodeClient};{Password};{ConfirmPassword}";
                Console.WriteLine($"Données à encoder : {dataToEncode}");

                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(dataToEncode, QRCodeGenerator.ECCLevel.Q))
                using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeImage = qrCode.GetGraphic(20);
                    Console.WriteLine("QR code généré avec succès.");

                    QrCodeImageSource = ImageSource.FromStream(() => new MemoryStream(qrCodeImage));
                    Console.WriteLine("Image QR code assignée à la source.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la génération du QR code : {ex.Message}");
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
