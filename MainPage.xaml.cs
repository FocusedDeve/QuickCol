using QuickCol.ViewModels;
using Microsoft.Maui.Controls;

namespace QuickCol
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;

            // Abonnement à l'événement de changement d'élément du carrousel
            CarouselView.CurrentItemChanged += OnCarouselItemChanged;
        }

        // Fonction pour vérifier si c'est le dernier élément
        private void OnCarouselItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            var viewModel = (MainPageViewModel)BindingContext;
            var isLastItem = viewModel.CarousselItems.IndexOf(e.CurrentItem as CarousselItem) == viewModel.CarousselItems.Count - 1;

            // Afficher ou masquer le bouton "COMMENCER" selon si c'est le dernier élément
            CommencerButton.IsVisible = isLastItem;
        }

        // Gestion du clic sur le bouton "COMMENCER"
        private async void OnCommencerButtonClicked(object sender, EventArgs e)
        {
            // Redirection vers la page de login
            await Shell.Current.GoToAsync("LoginPage");
        }
    }
}
