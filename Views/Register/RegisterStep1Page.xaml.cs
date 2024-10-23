using Microsoft.Maui.Controls;
using QuickCol.ViewModels;

namespace QuickCol.Views.Register
{
    public partial class RegisterStep1Page : ContentPage
    {
        public RegisterStep1Page()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }
    }
}
