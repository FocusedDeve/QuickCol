using Microsoft.Maui.Controls;
using QuickCol.ViewModels;

namespace QuickCol.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
