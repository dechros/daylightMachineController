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
        private bool leftTrackButtonPressed;
        private bool rightTrackButtonPressed;
        private bool elevator1ButtonPressed;
        private bool elevator2ButtonPressed;
        private bool miscButtonPressed;

        private Utility.RandomNumberGenerator randomGenerator;
        public SettingsPage()
        {
            InitializeComponent();

            leftTrackButtonPressed = false;
            rightTrackButtonPressed = false;
            elevator1ButtonPressed = false;
            elevator2ButtonPressed = false;
            miscButtonPressed = false;

            randomGenerator = new Utility.RandomNumberGenerator();

            ClickLeftTrackButton();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void TopGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnclickAllTopButtons();
            SetRandomValuesToSliders();

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
            else if (clickedButton.Name == "MiscButtonGrid")
            {
                ClickMiscButton();
            }
            else
            {
                Console.WriteLine("Hatali Buton Secimi.");
            }
        }

        private void SetSliderLabelsForValves()
        {
            LeftTopSliderLabel.Content = "Minimum Valve Opening";
            LeftMidSliderLabel.Content = "Maximum Valve Opening";
            LeftBottomSliderLabel.Content = "Middle Valve Position";
            RightTopSliderLabel.Content = "Starting Ramp";
            RightMidSliderLabel.Content = "Stopping Ramp"; 
            RightBottomSliderLabel.Content = "Filter Strength";
        }

        private void SetSliderLabelsForMisc()
        {
            LeftTopSliderLabel.Content = "Leveling Sensor Data Interval";
            LeftMidSliderLabel.Content = "Leveling Sensor Filter Strength";
            LeftBottomSliderLabel.Content = "Leveling Sensor Data Size";
            RightTopSliderLabel.Content = "Information Data Interval";
            RightMidSliderLabel.Content = "Engine RPM Filter Strength";
            RightBottomSliderLabel.Content = "Lost Connection Interval";
        }

        private void ClickLeftTrackButton()
        {
            LeftTrackButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            LeftTrackButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            leftTrackButtonPressed = true;
            SetSliderLabelsForValves();
        }

        private void ClickRightTrackButton()
        {
            RightTrackButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            RightTrackButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            rightTrackButtonPressed = true;
            SetSliderLabelsForValves();
        }

        private void ClickElevator1Button()
        {
            Elevator1ButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            Elevator1ButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            elevator1ButtonPressed = true;
            SetSliderLabelsForValves();
        }

        private void ClickElevator2Button()
        {
            Elevator2ButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            Elevator2ButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            elevator2ButtonPressed = true;
            SetSliderLabelsForValves();
        }

        private void ClickMiscButton()
        {
            MiscButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            MiscButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            miscButtonPressed = true;
            SetSliderLabelsForMisc();
        }

        private void UnclickAllTopButtons()
        {
            MiscButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButton.png"));
            MiscButtonLabel.Foreground = new SolidColorBrush(Colors.White);
            miscButtonPressed = false;

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

        private void SetRandomValuesToSliders()
        {
            /* For Demo */
            SetValueForLeftTopSlider(randomGenerator.RandomNumber(0, 100));
            SetValueForLeftMidSlider(randomGenerator.RandomNumber(0, 100));
            SetValueForLeftBottomSlider(randomGenerator.RandomNumber(0, 100));
            SetValueForRightTopSlider(randomGenerator.RandomNumber(0, 100));
            SetValueForRightMidSlider(randomGenerator.RandomNumber(0, 100));
            SetValueForRightBottomSlider(randomGenerator.RandomNumber(0, 100));
        }

        /* Left Top Slider */

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

            LeftTopPercentageLabel.Content = (int)GetValueFromLeftTopSlider() + " / 100";
        }

        private void SetValueForLeftTopSlider(int percentage)
        {
            if (percentage > 100 || percentage < 0)
            {
                Console.WriteLine("  ## SetValueForLeftTopSlider percentage is out of bounds.");
                return;
            }

            LeftTopPercentageLabel.Content = percentage + " / 100";

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

        private void LeftTopSliderTouchGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            /* For Demo */
            Console.WriteLine(GetValueFromLeftTopSlider());
            /* For Demo */
        }

        private void LeftTopSliderTouchGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            /* For Demo */
            Console.WriteLine(GetValueFromLeftTopSlider());
            /* For Demo */
        }

        /* Left Mid Slider */

        private void LeftMidParameterTouchBallMove(object sender, System.Windows.Input.MouseEventArgs e)
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

            LeftMidParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newPosiitonForForeground = position.X - 45;

            if (newPosiitonForForeground < 0)
            {
                newPosiitonForForeground = 0;
            }
            else if (newPosiitonForForeground > 520)
            {
                newPosiitonForForeground = 520;
            }

            LeftMidSliderForeground.Width = newPosiitonForForeground;

            LeftMidPercentageLabel.Content = (int)GetValueFromLeftMidSlider() + " / 100";
        }

        private void SetValueForLeftMidSlider(int percentage)
        {
            if (percentage > 100 || percentage < 0)
            {
                Console.WriteLine("  ## SetValueForLeftMidSlider percentage is out of bounds.");
                return;
            }

            LeftMidPercentageLabel.Content = percentage + " / 100";

            double newMarginForBall = (percentage * 9.2) - 460;

            if (newMarginForBall < -460)
            {
                newMarginForBall = -460;
            }
            else if (newMarginForBall > 460)
            {
                newMarginForBall = 460;
            }

            LeftMidParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newWidthForForeground = percentage * 5.2;

            if (newWidthForForeground < 0)
            {
                newWidthForForeground = 0;
            }
            else if (newWidthForForeground > 520)
            {
                newWidthForForeground = 520;
            }

            LeftMidSliderForeground.Width = newWidthForForeground;
        }

        private double GetValueFromLeftMidSlider()
        {
            return (LeftMidSliderForeground.Width / 5.2);
        }

        private void LeftMidSliderTouchGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            /* For Demo */
            Console.WriteLine(GetValueFromLeftMidSlider());
            /* For Demo */
        }

        private void LeftMidSliderTouchGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            /* For Demo */
            Console.WriteLine(GetValueFromLeftMidSlider());
            /* For Demo */
        }

        /* Left Bottom Slider */

        private void LeftBottomParameterTouchBallMove(object sender, System.Windows.Input.MouseEventArgs e)
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

            LeftBottomParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newPosiitonForForeground = position.X - 45;

            if (newPosiitonForForeground < 0)
            {
                newPosiitonForForeground = 0;
            }
            else if (newPosiitonForForeground > 520)
            {
                newPosiitonForForeground = 520;
            }

            LeftBottomSliderForeground.Width = newPosiitonForForeground;

            LeftBottomPercentageLabel.Content = (int)GetValueFromLeftBottomSlider() + " / 100";
        }

        private void SetValueForLeftBottomSlider(int percentage)
        {
            if (percentage > 100 || percentage < 0)
            {
                Console.WriteLine("  ## SetValueForLeftBottomSlider percentage is out of bounds.");
                return;
            }

            LeftBottomPercentageLabel.Content = percentage + " / 100";

            double newMarginForBall = (percentage * 9.2) - 460;

            if (newMarginForBall < -460)
            {
                newMarginForBall = -460;
            }
            else if (newMarginForBall > 460)
            {
                newMarginForBall = 460;
            }

            LeftBottomParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newWidthForForeground = percentage * 5.2;

            if (newWidthForForeground < 0)
            {
                newWidthForForeground = 0;
            }
            else if (newWidthForForeground > 520)
            {
                newWidthForForeground = 520;
            }

            LeftBottomSliderForeground.Width = newWidthForForeground;
        }

        private double GetValueFromLeftBottomSlider()
        {
            return (LeftBottomSliderForeground.Width / 5.2);
        }

        private void LeftBottomSliderTouchGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            /* For Demo */
            Console.WriteLine(GetValueFromLeftBottomSlider());
            /* For Demo */
        }

        private void LeftBottomSliderTouchGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            /* For Demo */
            Console.WriteLine(GetValueFromLeftBottomSlider());
            /* For Demo */
        }

        /* Right Top Slider */

        private void RightTopParameterTouchBallMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            Point position = e.GetPosition(this);

            double newMarginForBall = (position.X - 885) * 2;

            if (newMarginForBall < -460)
            {
                newMarginForBall = -460;
            }
            else if (newMarginForBall > 460)
            {
                newMarginForBall = 460;
            }

            RightTopParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newPosiitonForForeground = position.X - 645;

            if (newPosiitonForForeground < 0)
            {
                newPosiitonForForeground = 0;
            }
            else if (newPosiitonForForeground > 520)
            {
                newPosiitonForForeground = 520;
            }

            RightTopSliderForeground.Width = newPosiitonForForeground;

            RightTopPercentageLabel.Content = (int)GetValueFromRightTopSlider() + " / 100";
        }

        private void SetValueForRightTopSlider(int percentage)
        {
            if (percentage > 100 || percentage < 0)
            {
                Console.WriteLine("  ## SetValueForRightTopSlider percentage is out of bounds.");
                return;
            }

            RightTopPercentageLabel.Content = percentage + " / 100";

            double newMarginForBall = (percentage * 9.2) - 460;

            if (newMarginForBall < -460)
            {
                newMarginForBall = -460;
            }
            else if (newMarginForBall > 460)
            {
                newMarginForBall = 460;
            }

            RightTopParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newWidthForForeground = percentage * 5.2;

            if (newWidthForForeground < 0)
            {
                newWidthForForeground = 0;
            }
            else if (newWidthForForeground > 520)
            {
                newWidthForForeground = 520;
            }

            RightTopSliderForeground.Width = newWidthForForeground;
        }

        private double GetValueFromRightTopSlider()
        {
            return (RightTopSliderForeground.Width / 5.2);
        }

        private void RightTopSliderTouchGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            /* For Demo */
            Console.WriteLine(GetValueFromRightTopSlider());
            /* For Demo */
        }

        private void RightTopSliderTouchGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            /* For Demo */
            Console.WriteLine(GetValueFromRightTopSlider());
            /* For Demo */
        }

        /* Right Mid Slider */

        private void RightMidParameterTouchBallMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            Point position = e.GetPosition(this);

            double newMarginForBall = (position.X - 885) * 2;

            if (newMarginForBall < -460)
            {
                newMarginForBall = -460;
            }
            else if (newMarginForBall > 460)
            {
                newMarginForBall = 460;
            }

            RightMidParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newPosiitonForForeground = position.X - 645;

            if (newPosiitonForForeground < 0)
            {
                newPosiitonForForeground = 0;
            }
            else if (newPosiitonForForeground > 520)
            {
                newPosiitonForForeground = 520;
            }

            RightMidSliderForeground.Width = newPosiitonForForeground;

            RightMidPercentageLabel.Content = (int)GetValueFromRightMidSlider() + " / 100";
        }

        private void SetValueForRightMidSlider(int percentage)
        {
            if (percentage > 100 || percentage < 0)
            {
                Console.WriteLine("  ## SetValueForRightMidSlider percentage is out of bounds.");
                return;
            }

            RightMidPercentageLabel.Content = percentage + " / 100";

            double newMarginForBall = (percentage * 9.2) - 460;

            if (newMarginForBall < -460)
            {
                newMarginForBall = -460;
            }
            else if (newMarginForBall > 460)
            {
                newMarginForBall = 460;
            }

            RightMidParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newWidthForForeground = percentage * 5.2;

            if (newWidthForForeground < 0)
            {
                newWidthForForeground = 0;
            }
            else if (newWidthForForeground > 520)
            {
                newWidthForForeground = 520;
            }

            RightMidSliderForeground.Width = newWidthForForeground;
        }

        private double GetValueFromRightMidSlider()
        {
            return (RightMidSliderForeground.Width / 5.2);
        }

        private void RightMidSliderTouchGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            /* For Demo */
            Console.WriteLine(GetValueFromRightMidSlider());
            /* For Demo */
        }

        private void RightMidSliderTouchGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            /* For Demo */
            Console.WriteLine(GetValueFromRightMidSlider());
            /* For Demo */
        }

        /* Right Bottom Slider */

        private void RightBottomParameterTouchBallMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            Point position = e.GetPosition(this);

            double newMarginForBall = (position.X - 885) * 2;

            if (newMarginForBall < -460)
            {
                newMarginForBall = -460;
            }
            else if (newMarginForBall > 460)
            {
                newMarginForBall = 460;
            }

            RightBottomParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newPosiitonForForeground = position.X - 645;

            if (newPosiitonForForeground < 0)
            {
                newPosiitonForForeground = 0;
            }
            else if (newPosiitonForForeground > 520)
            {
                newPosiitonForForeground = 520;
            }

            RightBottomSliderForeground.Width = newPosiitonForForeground;

            RightBottomPercentageLabel.Content = (int)GetValueFromRightBottomSlider() + " / 100";
        }

        private void SetValueForRightBottomSlider(int percentage)
        {
            if (percentage > 100 || percentage < 0)
            {
                Console.WriteLine("  ## SetValueForRightBottomSlider percentage is out of bounds.");
                return;
            }

            RightBottomPercentageLabel.Content = percentage + " / 100";

            double newMarginForBall = (percentage * 9.2) - 460;

            if (newMarginForBall < -460)
            {
                newMarginForBall = -460;
            }
            else if (newMarginForBall > 460)
            {
                newMarginForBall = 460;
            }

            RightBottomParameterTouchBall.Margin = new Thickness(newMarginForBall, 0, 0, 0);

            double newWidthForForeground = percentage * 5.2;

            if (newWidthForForeground < 0)
            {
                newWidthForForeground = 0;
            }
            else if (newWidthForForeground > 520)
            {
                newWidthForForeground = 520;
            }

            RightBottomSliderForeground.Width = newWidthForForeground;
        }

        private double GetValueFromRightBottomSlider()
        {
            return (RightBottomSliderForeground.Width / 5.2);
        }

        private void RightBottomSliderTouchGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            /* For Demo */
            Console.WriteLine(GetValueFromRightBottomSlider());
            /* For Demo */
        }

        private void RightBottomSliderTouchGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            /* For Demo */
            Console.WriteLine(GetValueFromRightBottomSlider());
            /* For Demo */
        }

        
    }
}
