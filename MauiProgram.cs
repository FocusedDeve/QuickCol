using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using QuickCol;
using QuickCol.ViewModels;
using QuickCol.Views;
using QuickCol.Views.Register;

namespace MyMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();


            // Ajout des ViewModels au service d'injection de dépendances
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<RegisterViewModel>();

            // Ajout des pages aux services
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterStep1Page>();
            builder.Services.AddTransient<RegisterStep2Page>();
            builder.Services.AddTransient<RegisterStep3Page>();

            return builder.Build();
        }
    }
}
