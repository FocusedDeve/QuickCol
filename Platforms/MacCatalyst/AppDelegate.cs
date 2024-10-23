using Foundation;
using QuickCol;

namespace QuickCol
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MyMauiApp.MauiProgram.CreateMauiApp();
    }
}
