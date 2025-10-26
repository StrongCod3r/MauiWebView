using Android.Views;
using MauiApp2.Services;

namespace MauiApp2.Platforms.Android.Services
{
    public class ScreenLockService : IScreenLockService
    {
        public void KeepScreenOn(bool enable)
        {
            var activity = Platform.CurrentActivity;
  if (activity?.Window != null)
    {
             activity.RunOnUiThread(() =>
    {
          if (enable)
 {
      activity.Window.AddFlags(WindowManagerFlags.KeepScreenOn);
      }
        else
  {
     activity.Window.ClearFlags(WindowManagerFlags.KeepScreenOn);
      }
            });
        }
        }
    }
}
