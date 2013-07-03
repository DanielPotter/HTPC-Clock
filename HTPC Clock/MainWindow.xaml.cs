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
        }

        private double initialWindowWidth;
        private double initialScale = 1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.textGrid.RenderTransform = new ScaleTransform();
            this.initialWindowWidth = this.ActualWidth;
            this.WindowState = System.Windows.WindowState.Maximized;
        }

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
    }
}
