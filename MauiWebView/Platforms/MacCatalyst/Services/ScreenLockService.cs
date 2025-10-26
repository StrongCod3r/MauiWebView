using MauiApp2.Services;
using UIKit;

namespace MauiApp2.Platforms.MacCatalyst.Services
{
    public class ScreenLockService : IScreenLockService
 {
        public void KeepScreenOn(bool enable)
        {
      UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
      UIApplication.SharedApplication.IdleTimerDisabled = enable;
    });
        }
    }
}
