using MauiApp2.Services;
using MauiPageFullScreen;
using Microsoft.Maui.Storage;

namespace MauiApp2
{

    public partial class MainPage : ContentPage
    {
        private IScreenLockService _screenLockService;
        private const string webUrl = "WebUrl";

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Resolve the service here when the page appears
            _screenLockService ??= IPlatformApplication.Current?.Services?.GetService<IScreenLockService>();

            // Activate wake lock to keep screen on
            _screenLockService?.KeepScreenOn(true);

#if !WINDOWS
            Controls.FullScreen();
#endif

            // Espera un pequeño retraso para asegurarte que la UI se haya renderizado
            //await Task.Delay(100);

            await LoadWebPage(silent: true);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Release wake lock when leaving the page
            _screenLockService?.KeepScreenOn(false);
        }

        private void FloatingButton_Clicked(object sender, EventArgs e)
        {
            _ = LoadWebPage();
        }

        private async Task LoadWebPage(bool silent = false)
        {
            string result = "";

            if (silent)
            {
                result = Preferences.Get(webUrl, "");
            }
            else
            {
                result = Preferences.Get(webUrl, "http://");
                result = await DisplayPromptAsync("Setup", "What's your web?", "Ok", "Cancel", keyboard: Keyboard.Text, initialValue: result);
            }
            

            if (!string.IsNullOrEmpty(result) && result != "http://")
            {
                Preferences.Set(webUrl, result);
                WebViewBrowser.Source = result;
            }
        }
    }
}
