using Microsoft.Maui.Controls;
using QuickCol.ViewModels;
using System;
using System.Threading.Tasks;


namespace QuickCol.Views.Register
{
    public partial class RegisterStep1Page : ContentPage
    {
        private bool _isAnimating;

        public RegisterStep1Page()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();

        }

        // Lancer l'animation continue lors de l'apparition de la page
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _isAnimating = true;  // Activer le drapeau d'animation
           // StartContinuousAnimation(ClientButton);
        }

        // Arr�ter l'animation lorsque la page est ferm�e
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _isAnimating = false;  // D�sactiver l'animation
        }

        // M�thode d'animation continue avec zoom, bordure bleue et ombre
        private async void StartContinuousAnimation(Frame frame)
        {
            while (_isAnimating)
            {
                // Zoomer et changer la couleur de la bordure et ajouter de l'ombre
                await frame.ScaleTo(1.1, 200);  // Agrandissement
                frame.BorderColor = Colors.Blue;  // Changement de bordure
                frame.HasShadow = true;  // Ajouter l'ombre

                // Revenir � la taille normale et restaurer les propri�t�s
                await frame.ScaleTo(1, 200);  // Retour � la taille normale
                frame.BorderColor = Colors.White;  // Restaurer la bordure blanche
                frame.HasShadow = false;  // Retirer l'ombre
            }
        }
    }
    }
