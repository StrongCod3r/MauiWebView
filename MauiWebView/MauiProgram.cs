using Microsoft.Extensions.Logging;
using MauiApp2.Services;

namespace MauiApp2
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Register ScreenLockService per platform
#if ANDROID
       builder.Services.AddSingleton<IScreenLockService, Platforms.Android.Services.ScreenLockService>();
#elif IOS
   builder.Services.AddSingleton<IScreenLockService, Platforms.iOS.Services.ScreenLockService>();
#elif WINDOWS
          builder.Services.AddSingleton<IScreenLockService, Platforms.Windows.Services.ScreenLockService>();
#elif MACCATALYST
            builder.Services.AddSingleton<IScreenLockService, Platforms.MacCatalyst.Services.ScreenLockService>();
#endif

builder.Services.AddTransient<MainPage>();

            return builder.Build();
        }
    }
}
