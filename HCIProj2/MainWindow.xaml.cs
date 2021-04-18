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
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {

            InitializeComponent();

            // Initialization

            left_blinker.Opacity = 0.0;
            right_blinker.Opacity = 0.0;
            CEL_Icon.Opacity = 0.0;
            Bat_Icon.Opacity = 0.0;
            Oil_Icon.Opacity = 0.0;
            Notification.Opacity = 0;

            Door_Notif.Opacity = 0;
            Airbag_Icon.Opacity = 0;

            timer.Tick += TimerTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);

            Mileage.Content = 0;
        }

        private bool isBlinking = false;
        private bool left = false;
        private bool right = false;
        private bool em = false;

        private bool needsService = false;
        private bool cel = false;
        private bool battery = false;
        private bool oil = false;

        private bool seatbelt = false;
        private bool headlights = false;
        private bool airbag = false;
        private bool door = false;

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
                timer.Start();
                isBlinking = true;
                left = true;
                Console.WriteLine("Left Blinker on");
                bl_left.Background = Brushes.LightGreen;
            }
            else
            {
                timer.Stop();
                isBlinking = false;
                left = false;
                left_blinker.Opacity = 0;
                Console.WriteLine("Left Blinker off");
                bl_left.Background = Brushes.WhiteSmoke;
            }
        }

        private void RightBlinker(object sender, RoutedEventArgs e)
        {
 
            if (!right)
            {
                timer.Start();
                isBlinking = true;
                right = true;
                Console.WriteLine("Left Blinker on");
                bl_right.Background = Brushes.LightGreen;
            }
            else
            {
                timer.Stop();
                isBlinking = false;
                right = false;
                right_blinker.Opacity = 0;
                Console.WriteLine("Left Blinker off");
                bl_right.Background = Brushes.White;
            }
        }

        private void BlinkEmergency(object sender, RoutedEventArgs e)
        {

            if (!em)
            {
                timer.Start();
                isBlinking = true;
                em = true;
                Console.WriteLine("Emergency on");
                emergency.Background = Brushes.LightGreen;
            }
            else
            {
                timer.Stop();
                isBlinking = false;
                em = false;
                right_blinker.Opacity = 0;
                left_blinker.Opacity = 0;
                Console.WriteLine("Emergency off");
                emergency.Background = Brushes.White;
            }
        }

        private void FuelChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double mpg = Fuel.Value * 3;
            double fuelVal = Fuel.Value;

            Mileage.Content = mpg;

            if (fuelVal >= 60 && fuelVal <= 120) // If between 90 and 120
            {
                FuelGauge.Stroke = Brushes.Turquoise;
            }
            else if (fuelVal >= 30 && fuelVal < 60)
            {
                FuelGauge.Stroke = Brushes.Orange;
            }
            else
            {
                FuelGauge.Stroke = Brushes.Red;
            }
  
        }

        private void Temp_Change(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double tempVal = Temp.Value;

            if (tempVal >= 60 && tempVal <= 120) // If between 90 and 120
            {
                Temp_Gauge.Stroke = Brushes.Orange;
            }
            else if (tempVal >= 30 && tempVal < 60)
            {
                Temp_Gauge.Stroke = Brushes.Turquoise;
            }
            else
            {
                Temp_Gauge.Stroke = Brushes.LightBlue;
            }

        }

        private bool ServiceCheck()
        {
            if (cel == true || battery == true || oil == true)
            {
                needsService = true;
                return true;
            }
            else
            {
                needsService = false;
                Notification.Opacity = 0;
                return false;
            }
        }

        private void CEL_Click(object sender, RoutedEventArgs e)
        {
            if (!cel)
            {
                cel = true;
                CEL_Icon.Opacity = 1;

                if (!needsService)
                {
                    needsService = true;
                    Notification.Opacity = 1;
                }
            }
            else
            {
                CEL_Icon.Opacity = 0;
                cel = false;
                ServiceCheck();
            }
        }

        private void Oil_Click(object sender, RoutedEventArgs e)
        {
            if (!oil)
            {
                oil = true;
                Oil_Icon.Opacity = 1;

                if (!needsService)
                {
                    needsService = true;
                    Notification.Opacity = 1;
                }
            }
            else
            {
                Oil_Icon.Opacity = 0;
                oil = false;
                ServiceCheck();
            }
        }

        private void Bat_Click(object sender, RoutedEventArgs e)
        {
            if (!battery)
            {
                battery = true;
                Bat_Icon.Opacity = 1;

                if (!needsService)
                {
                    needsService = true;
                    Notification.Opacity = 1;
                }
            }
            else
            {
                Bat_Icon.Opacity = 0;
                battery = false;
                ServiceCheck();
            }
        }

        private void Seatbelt_Click(object sender, RoutedEventArgs e)
        {
            if (!seatbelt)
            {
                Seatbelt_Icon.Opacity = 0;
                seatbelt = true;
            }
            else
            {
                Seatbelt_Icon.Opacity = 1;
                seatbelt = false;
            }
        }

        private void Door_Click(object sender, RoutedEventArgs e)
        {
            if (!door)
            {
                Door_Notif.Opacity = 1;
                door = true;
            }
            else
            {
                Door_Notif.Opacity = 0;
                door = false;
            }
        }

        private void Lights_Click(object sender, RoutedEventArgs e)
        {
            if (!headlights)
            {
                Headlight_Icon.Opacity = 1;
                headlights = true;
            }
            else
            {
                Headlight_Icon.Opacity = 0;
                headlights = false;
            }
        }

        private void Airback_Click(object sender, RoutedEventArgs e)
        {
            if (!airbag)
            {
                Airbag_Icon.Opacity = 1;
                airbag = true;
            }
            else
            {
                Airbag_Icon.Opacity = 0;
                airbag = false;
            }
        }
    }
}
