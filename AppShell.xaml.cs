using Microsoft.Maui.Controls;
using QuickCol.Views;
using QuickCol.Views.Register;

namespace QuickCol
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Définition des routes pour la navigation
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterStep1Page), typeof(RegisterStep1Page));
            Routing.RegisterRoute(nameof(RegisterStep2Page), typeof(RegisterStep2Page));
            Routing.RegisterRoute(nameof(RegisterStep3Page), typeof(RegisterStep3Page));
        }

    }
}
