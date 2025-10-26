using MauiApp2.Services;
using Windows.System.Display;

namespace MauiApp2.Platforms.Windows.Services
{
    public class ScreenLockService : IScreenLockService
    {
        private DisplayRequest? _displayRequest;

        public void KeepScreenOn(bool enable)
        {
            if (enable)
            {
  if (_displayRequest == null)
          {
   _displayRequest = new DisplayRequest();
         _displayRequest.RequestActive();
          }
     }
  else
  {
    if (_displayRequest != null)
                {
 _displayRequest.RequestRelease();
     _displayRequest = null;
        }
  }
        }
    }
}
