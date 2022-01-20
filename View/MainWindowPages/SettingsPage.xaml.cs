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

            LeftTrackButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
            LeftTrackButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
            leftTrackButtonPressed = true;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnclickAllTopButtons();

            Grid clickedButton = (Grid)sender;
            if (clickedButton.Name == "LeftTrackButtonGrid")
            {
                LeftTrackButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
                LeftTrackButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
                leftTrackButtonPressed = true;
            }
            else if (clickedButton.Name == "RightTrackButtonGrid")
            {
                RightTrackButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
                RightTrackButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
                rightTrackButtonPressed = true;
            }
            else if (clickedButton.Name == "Elevator1ButtonGrid")
            {
                Elevator1ButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
                Elevator1ButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
                elevator1ButtonPressed = true;
            }
            else if (clickedButton.Name == "Elevator2ButtonGrid")
            {
                Elevator2ButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
                Elevator2ButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
                elevator2ButtonPressed = true;
            }
            else if (clickedButton.Name == "LevelSensorButtonGrid")
            {
                LevelSensorButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rectangularButtonClicked.png"));
                LevelSensorButtonLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
                levelSensorButtonPressed = true;
            }
            else
            {
                Console.WriteLine("Hatali Buton Secimi.");
            }
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
    }
}
