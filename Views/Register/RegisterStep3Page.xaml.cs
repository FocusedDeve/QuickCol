using Microsoft.Maui.Controls;
using QuickCol.ViewModels;

namespace QuickCol.Views.Register
{
    public partial class RegisterStep3Page : ContentPage
    {
        public RegisterStep3Page()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }
    }
}
