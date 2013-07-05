using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HTPC_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            fetchTimeClock.Interval = TimeSpan.FromMilliseconds(1000);
            fetchTimeClock.Tick += fetchTimeClock_Tick;
        }

        private void fetchTimeClock_Tick(object sender, EventArgs e)
        {
            SetClock(DateTime.Now);
        }

        private double initialWindowWidth;
        private double initialScale = 1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.textGrid.RenderTransform = new ScaleTransform();
            this.initialWindowWidth = this.ActualWidth;
            this.WindowState = System.Windows.WindowState.Maximized;
            fetchTimeClock.Start();
        }

        DispatcherTimer fetchTimeClock = new DispatcherTimer();

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.PreviousSize.Width != 0)
            {
                double newScale = e.NewSize.Width * this.initialScale / this.initialWindowWidth;
                textGrid.RenderTransform = new ScaleTransform(newScale, newScale);
            }
        }

        private void clockLabel_Loaded(object sender, RoutedEventArgs e)
        {
            //this.initialFontSize = this.clockLabel.FontSize;
        }

        private void SetClock(DateTime timeToDisplay)
        {
            int hour = timeToDisplay.TimeOfDay.Hours;
            if (hour > 12)
                hour -= 12;
            string ampm = "pm";
            if (timeToDisplay.TimeOfDay.TotalHours - 12 < 0)
                ampm = "am";
            timeMajorLabel.Content = hour.ToString() + ":" + timeToDisplay.TimeOfDay.Minutes.ToString("00");
            timeMinorLabel.Content = ":" + timeToDisplay.TimeOfDay.Seconds.ToString("00") + " " + ampm;
            dateLabel.Content = timeToDisplay.DayOfWeek.ToString() + ", " + timeToDisplay.ToString("m");
            switch (timeToDisplay.Day.ToString().Last())
            {
                case '1':
                    dateLabel.Content += "st";
                    break;
                case '2':
                    dateLabel.Content += "nd";
                    break;
                case '3':
                    dateLabel.Content += "rd";
                    break;
                default:
                    dateLabel.Content += "th";
                    break;
            }
        }
    }
}
