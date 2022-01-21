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

namespace DayLightMachineController.View.MainWindowPages
{
    /// <summary>
    /// SettingsPage.xaml etkileşim mantığı
    /// </summary>
    public partial class SettingsPage : Page
    {
        bool leftTrackButtonPressed;
        bool rightTrackButtonPressed;
        bool elevator1ButtonPressed;
        bool elevator2ButtonPressed;
        bool levelSensorButtonPressed;
        public SettingsPage()
        {
            InitializeComponent();

            leftTrackButtonPressed = false;
            rightTrackButtonPressed = false;
            elevator1ButtonPressed = false;
            elevator2ButtonPressed = false;
            levelSensorButtonPressed = false;

            ClickLeftTrackButton();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SetValueForLeftTopSlider(RandomNumber(0, 100));
        }

        private void TopGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnclickAllTopButtons();

            Grid clickedButton = (Grid)sender;
            if (clickedButton.Name == "LeftTrackButtonGrid")
            {
                ClickLeftTrackButton();
            }
            else if (clickedButton.Name == "RightTrackButtonGrid")
            {
                ClickRightTrackButton();
            }
            else if (clickedButton.Name == "Elevator1ButtonGrid")
            {
                ClickElevator1Button();
            }
            else if (clickedButton.Name == "Elevator2ButtonGrid")
            {
                ClickElevator2Button();
            }
            else if (clickedButton.Name == "LevelSensorButtonGrid")
            {
                ClickLevelSensorButton();
            }
            else
            {
                Console.WriteLine("Hatali Buton Secimi.");
            }
        }

        private void ClickLeftTrackButton()
        {
            LeftTrackButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            LeftTrackButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            leftTrackButtonPressed = true;
        }

        private void ClickRightTrackButton()
        {
            RightTrackButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            RightTrackButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            rightTrackButtonPressed = true;
        }

        private void ClickElevator1Button()
        {
            Elevator1ButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            Elevator1ButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            elevator1ButtonPressed = true;
        }

        private void ClickElevator2Button()
        {
            Elevator2ButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            Elevator2ButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            elevator2ButtonPressed = true;
        }

        private void ClickLevelSensorButton()
        {
            LevelSensorButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            LevelSensorButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            levelSensorButtonPressed = true;
        }

        private void UnclickAllTopButtons()
        {
            LevelSensorButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButton.png"));
            LevelSensorButtonLabel.Foreground = new SolidColorBrush(Colors.White);
            levelSensorButtonPressed = false;

            Elevator2ButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButton.png"));
            Elevator2ButtonLabel.Foreground = new SolidColorBrush(Colors.White);
            elevator2ButtonPressed = false;

            Elevator1ButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButton.png"));
            Elevator1ButtonLabel.Foreground = new SolidColorBrush(Colors.White);
            elevator1ButtonPressed = false;

            RightTrackButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButton.png"));
            RightTrackButtonLabel.Foreground = new SolidColorBrush(Colors.White);
            rightTrackButtonPressed = false;

            LeftTrackButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButton.png"));
            LeftTrackButtonLabel.Foreground = new SolidColorBrush(Colors.White);
            leftTrackButtonPressed = false;
        }

        private void LeftTopParameterTouchBallMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            Point position = e.GetPosition(this);

            double newMarginForBall = (position.X - 300) * 2;

            if (newMarginForBall < -460)
            {
                newMarginForBall = -460;
            }
            else if (newMarginForBall > 460)
            {
                newMarginForBall = 460;
            }

            LeftTopParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newPosiitonForForeground = position.X - 45;

            if (newPosiitonForForeground < 0)
            {
                newPosiitonForForeground = 0;
            }
            else if (newPosiitonForForeground > 520)
            {
                newPosiitonForForeground = 520;
            }

            LeftTopSliderForeground.Width = newPosiitonForForeground;
        }

        private void SetValueForLeftTopSlider(int percentage)
        {
            if (percentage > 100 || percentage < 0)
            {
                Console.WriteLine("  ## SetValueForLeftTopSlider percentage is out of bounds.");
                return;
            }

            double newMarginForBall = (percentage * 9.2) - 460;

            if (newMarginForBall < -460)
            {
                newMarginForBall = -460;
            }
            else if (newMarginForBall > 460)
            {
                newMarginForBall = 460;
            }

            LeftTopParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newWidthForForeground = percentage * 5.2;

            if (newWidthForForeground < 0)
            {
                newWidthForForeground = 0;
            }
            else if (newWidthForForeground > 520)
            {
                newWidthForForeground = 520;
            }

            LeftTopSliderForeground.Width = newWidthForForeground;
        }

        private double GetValueFromLeftTopSlider()
        {
            return (LeftTopSliderForeground.Width / 5.2);
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random(); 
            return random.Next(min, max);
        }

        private void LeftTopSliderTouchGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine(GetValueFromLeftTopSlider());
        }

        private void LeftTopSliderTouchGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            Console.WriteLine(GetValueFromLeftTopSlider());
        }
    }
}
