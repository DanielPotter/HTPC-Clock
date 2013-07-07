using HTPC_Clock.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace HTPC_Clock
{
    public static class ScreenHandler
    {
        public static Screen GetPrimaryScreen()
        {
            return GetScreen(Settings.Default.PrimaryScreenId);
        }

        public static Screen GetSecondaryScreen()
        {
            return GetScreen(Settings.Default.SecondaryScreenId);
        }

        public static Screen GetCurrentScreen(Window window)
        {
            var parentArea = new System.Drawing.Rectangle((int)window.Left, (int)window.Top, (int)window.Width, (int)window.Height);
            return Screen.FromRectangle(parentArea);
        }

        private static Screen GetScreen(int requestedScreen)
        {
            var screens = Screen.AllScreens;
            if (screens.Length > requestedScreen)
            {
                return screens[requestedScreen];
            }
            return null;
        }
    }
}
