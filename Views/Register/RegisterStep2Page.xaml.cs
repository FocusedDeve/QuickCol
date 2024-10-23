using Microsoft.Maui.Controls;
using QuickCol.ViewModels;

namespace QuickCol.Views.Register
{
    public partial class RegisterStep2Page : ContentPage
    {
        public RegisterStep2Page()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }
    }
}
