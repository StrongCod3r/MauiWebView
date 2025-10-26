using MauiApp2.Services;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        private readonly IScreenLockService _screenLockService;

        public MainPage(IScreenLockService screenLockService)
        {
            InitializeComponent();
            _screenLockService = screenLockService;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Activate wake lock to keep screen on
            _screenLockService.KeepScreenOn(true);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Release wake lock when leaving the page
            _screenLockService.KeepScreenOn(false);
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            // Implement Add functionality
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            // Implement Save functionality
        }
    }
}
