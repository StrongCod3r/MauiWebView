using MauiApp2.Services;
using MauiPageFullScreen;

namespace MauiApp2
{
    
    public partial class MainPage : ContentPage
    {
        private IScreenLockService _screenLockService;
        private string webUrl = "http://";

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        
        // Resolve the service here when the page appears
   _screenLockService ??= IPlatformApplication.Current?.Services?.GetService<IScreenLockService>();
  
       // Activate wake lock to keep screen on
      _screenLockService?.KeepScreenOn(true);

#if !WINDOWS
            Controls.FullScreen();
#endif
     }

     protected override void OnDisappearing()
     {
  base.OnDisappearing();
          // Release wake lock when leaving the page
   _screenLockService?.KeepScreenOn(false);
        }

        private async void FloatingButton_Clicked(object sender, EventArgs e)
        {
     //OptionsPanel.IsVisible = !OptionsPanel.IsVisible;
         string result = await DisplayPromptAsync("Setup", "What's your web?", initialValue: webUrl);

     if (!string.IsNullOrEmpty(result))
        {
         webUrl = result;
         WebViewBrowser.Source = result;
      }
        }
    }
}
