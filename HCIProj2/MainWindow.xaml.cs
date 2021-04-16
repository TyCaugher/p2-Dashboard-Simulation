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

namespace HCIProj2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Reset the blinker opacity on launch

            // Blink timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += TimerTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }


        private void Fuel_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private bool isBlinking = false;
        private bool left = false;
        private bool right = false;
        private bool em = false;

        private void TimerTick(object sender, EventArgs e)
        {
            if (isBlinking)
            {
                if(left)
                {
                    left_blinker.Opacity = 1.0;
                    Console.WriteLine("Left blink");
                }
                else if (right)
                {
                    right_blinker.Opacity = 1.0;
                    Console.WriteLine("Right blink");
                }
                else if (em)
                {
                    right_blinker.Opacity = 1.0;
                    left_blinker.Opacity = 1.0;
                    Console.WriteLine("Emergency Blink");
                }
            }
            else
            {
                 right_blinker.Opacity = 0.0;
                 left_blinker.Opacity = 0.0;
            }
            isBlinking = !isBlinking;
            // Console.WriteLine("tick");
        }

        private void LeftBlinker(object sender, RoutedEventArgs e)
        {
            if (!left)
            {
                isBlinking = true;
                left = true;
                Console.WriteLine("Left Blinker on");
                bl_left.Background = Brushes.LightGreen;
            }
            else
            {
                isBlinking = false;
                left = false;
                Console.WriteLine("Left Blinker off");
                bl_left.Background = Brushes.WhiteSmoke;
            }
        }

        private void RightBlinker(object sender, RoutedEventArgs e)
        {
            if (!right)
            {
                isBlinking = true;
                right = true;
                Console.WriteLine("Left Blinker on");
                bl_right.Background = Brushes.LightGreen;
            }
            else
            {
                isBlinking = false;
                right = false;
                Console.WriteLine("Left Blinker off");
                bl_right.Background = Brushes.White;
            }
        }

        private void BlinkEmergency(object sender, RoutedEventArgs e)
        {
            if (!em)
            {
                isBlinking = true;
                em = true;
                Console.WriteLine("Emergency on");
                emergency.Background = Brushes.LightGreen;
            }
            else
            {
                isBlinking = false;
                em = false;
                Console.WriteLine("Emergency off");
                emergency.Background = Brushes.White;
            }
        }
    }
}
