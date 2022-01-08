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
using System.Windows.Forms;

namespace DayLightMachineController.View.MainWindowPages
{
    /// <summary>
    /// ControlPage.xaml etkileşim mantığı
    /// </summary>
    public partial class ControlPage : Page
    {
        int oldBallAngle;
        List<Image> graySlices;
        bool engineButtonState;
        bool levelingButtonState;
        bool hammerButtonState;
        bool lightButtonState;
        bool calibrateButtonState;
        public ControlPage()
        {
            oldBallAngle = -1;
            engineButtonState = false;
            levelingButtonState = false;
            hammerButtonState = false;
            lightButtonState = false;
            calibrateButtonState = false;

            InitializeComponent();
            CreateThrottleGaugeGraySlices();

            Task.Run(() => BatteryLevelDemo());
            Task.Run(() => FuelLevelDemo());
            Task.Run(() => OilLevelDemo());
            Task.Run(() => TempLevelDemo());
            Task.Run(() => HydroTempLevelDemo());
            Task.Run(() => HydroLevelDemo());
            Task.Run(() => WiFiLevelDemo());
            Task.Run(() => CellLevelDemo());
            Task.Run(() => UartLevelDemo());
            Task.Run(() => CanBusLevelDemo());
            Task.Run(() => StorageLevelDemo());
            Task.Run(() => DatabaseLevelDemo());
        }

        private void CreateThrottleGaugeGraySlices()
        {
            graySlices = new List<Image>();
            for (int i = 0; i < 90; i++)
            {
                Image graySlice = new Image();
                graySlice.Margin = new Thickness(0, -240 - (0.01 * i), 0, 0);
                graySlice.Height = Double.NaN;
                graySlice.Width = 21;
                graySlice.VerticalAlignment = VerticalAlignment.Center;
                graySlice.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                graySlice.RenderTransformOrigin = new Point(0.5, 1.0);
                graySlice.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/throttleGrayslice.png"));
                graySlice.RenderTransform = new RotateTransform(i * -4);

                graySlices.Add(graySlice);
            }
            imageItems.ItemsSource = graySlices;
        }

        private async void DatabaseLevelDemo()
        {
            await Task.Delay(1200);

            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(DatabaseLevel, DatabaseLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(DatabaseLevel, DatabaseLogo, i);
                    await Task.Delay(1);
                }
                
                await Task.Delay(250);
            }
        }

        private async void StorageLevelDemo()
        {
            await Task.Delay(1100);

            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(StorageLevel, StorageLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(StorageLevel, StorageLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }

        private async void CanBusLevelDemo()
        {
            await Task.Delay(1000);

            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(CanBusLevel, CanLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(CanBusLevel, CanLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }

        private async void UartLevelDemo()
        {
            await Task.Delay(900);

            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(UartLevel, UartLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(UartLevel, UartLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }

        private async void CellLevelDemo()
        {
            await Task.Delay(800);

            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(CellLevel, CellLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(CellLevel, CellLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }

        private async void WiFiLevelDemo()
        {
            await Task.Delay(700);

            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(WiFiLevel, WiFiLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(WiFiLevel, WiFiLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }


        private async void HydroLevelDemo()
        {
            await Task.Delay(600);

            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(HydroLevel, HydraulicLevelLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(HydroLevel, HydraulicLevelLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }

        private async void HydroTempLevelDemo()
        {
            await Task.Delay(500);
            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(HydroTempLevel, HydraulicTempLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(HydroTempLevel, HydraulicTempLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }

        private async void TempLevelDemo()
        {
            await Task.Delay(400);
            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(TempLevel, TemperatureLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(TempLevel, TemperatureLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }

        private async void OilLevelDemo()
        {
            await Task.Delay(300);
            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(OilLevel, OilLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(OilLevel, OilLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }

        private async void FuelLevelDemo()
        {
            await Task.Delay(200);
            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(FuelLevel, FuelLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(FuelLevel, FuelLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }

        private async void BatteryLevelDemo()
        {
            await Task.Delay(100);
            while (true)
            {
                for (int i = 0; i <= 90; i++)
                {
                    SetGraph(BatteryLevel, BatteryLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);

                for (int i = 90; i >= 0; i--)
                {
                    SetGraph(BatteryLevel, BatteryLogo, i);
                    await Task.Delay(1);
                }
                await Task.Delay(250);
            }
        }

        private void SetGraph(Image graph, Image logo, int value)
        {
            graph.Dispatcher.Invoke(new Action(() => graph.Height = value * 2 ));

            if (value <= 25)
            {
                graph.Dispatcher.Invoke(new Action(() => graph.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/graphicLogoWarning.png"))));
                logo.Dispatcher.Invoke(new Action(() => logo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + logo.Name + "Warning.png"))));
            }
            else
            {
                graph.Dispatcher.Invoke(new Action(() => graph.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/graphicLogo.png"))));
                logo.Dispatcher.Invoke(new Action(() => logo.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/" + logo.Name + ".png"))));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ThrottleGaugeControl(int angle)
        {
            for (int i = 0; i < 90; i++)
            {
                graySlices[i].Dispatcher.Invoke(new Action(() => graySlices[i].Visibility = Visibility.Hidden));
                imageItems.Dispatcher.Invoke(new Action(() => imageItems.ItemsSource = graySlices));
            }

            for (int i = 0; i < 90 - (angle / 4); i++)
            {
                graySlices[i].Dispatcher.Invoke(new Action(() => graySlices[i].Visibility = Visibility.Visible));
                imageItems.Dispatcher.Invoke(new Action(() => imageItems.ItemsSource = graySlices));
            }
        }

        private void ThrottleTouchBallMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            Image senderImage = (Image)sender;

            Point position = e.GetPosition(this);
            double leftMarginForBall = (position.X - 590) * 2;
            double topMarginForBall = (position.Y - 300) * 2;

            if (senderImage.Name == "HollowCircle")
            {
                double preResult = Math.Sqrt(Math.Pow(topMarginForBall, 2) + Math.Pow(leftMarginForBall, 2));

                if (preResult < 350 || preResult > 550)
                {
                    return;
                }
            }

            while (true)
            {
                double result = Math.Sqrt(Math.Pow(topMarginForBall, 2) + Math.Pow(leftMarginForBall, 2));
                if (result > 450 + 1)
                {
                    if (topMarginForBall > 0)
                    {
                        topMarginForBall--;
                    }
                    else
                    {
                        topMarginForBall++;
                    }
                    if (leftMarginForBall > 0)
                    {
                        leftMarginForBall--;
                    }
                    else
                    {
                        leftMarginForBall++;
                    }
                }
                else if (result < 450 - 1)
                {
                    if (topMarginForBall > 0)
                    {
                        topMarginForBall++;
                    }
                    else
                    {
                        topMarginForBall--;
                    }
                    if (leftMarginForBall > 0)
                    {
                        leftMarginForBall++;
                    }
                    else
                    {
                        leftMarginForBall--;
                    }
                }
                else
                {
                    break;
                }
            }

            int ballAngle = ThrottleTouchAngleDetection(leftMarginForBall, topMarginForBall);

            if (oldBallAngle > 340 && ballAngle < 20)
            {
                return;
            }
            else if (oldBallAngle < 20 && ballAngle > 340)
            {
                return;
            }
            oldBallAngle = ballAngle;

            ThrottleTouchBall.Margin = new Thickness(leftMarginForBall, topMarginForBall, 0, 0);
            ThrottleGaugeControl(ballAngle);
            UpdateRpmLabel(ballAngle);
        }

        private int ThrottleTouchAngleDetection(double leftMarginForBall, double topMarginForBall)
        {
            double angle = Math.Atan(Math.Abs(leftMarginForBall) / Math.Abs(topMarginForBall)) * 180 / Math.PI;

            if (leftMarginForBall >= 0 && topMarginForBall > 0)
            {
                angle = 180 - angle;
            }
            else if (leftMarginForBall < 0 && topMarginForBall > 0)
            {
                angle = 180 + angle;
            }
            else if (leftMarginForBall < 0 && topMarginForBall <= 0)
            {
                angle = 360 - angle;
            }

            return (int)angle;
        }

        private void UpdateRpmLabel(double angle)
        {
            int RmpContent = (int)(angle * 10);
            RpmLabel.Content = RmpContent.ToString();
        }

        private void ThrottleTouchBallBallReset(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ThrottleTouchBall.Margin = new Thickness(0, -450, 0, 0);
        }

        private void RightTrackTouchBallMove(object sender, TouchEventArgs e)
        {
            TouchPoint position = e.GetTouchPoint(this);
            double newMarginForBall = (position.Position.Y - 605) * 2;

            if (newMarginForBall < -240)
            {
                newMarginForBall = -240;
            }
            else if (newMarginForBall > 240)
            {
                newMarginForBall = 240;
            }
            RightTrackTouchBall.Margin = new Thickness(0, newMarginForBall, 0, 0);
        }

        private void RightTrackTouchBallReset(object sender, TouchEventArgs e)
        {
            RightTrackTouchBall.Margin = new Thickness(0, 0, 0, 0);
        }

        private void LeftTrackTouchBallReset(object sender, TouchEventArgs e)
        {
            LeftTrackTouchBall.Margin = new Thickness(0, 0, 0, 0);
        }

        private void LeftTrackTouchBallMove(object sender, TouchEventArgs e)
        {
            TouchPoint position = e.GetTouchPoint(this);

            double newMarginForBall = (position.Position.Y - 605) * 2;

            if (newMarginForBall < -240)
            {
                newMarginForBall = -240;
            }
            else if (newMarginForBall > 240)
            {
                newMarginForBall = 240;
            }
            LeftTrackTouchBall.Margin = new Thickness(0, newMarginForBall, 0, 0);
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid clickedButton = (Grid)sender;
            if (clickedButton.Name == "EngineButton")
            {
                if (engineButtonState == false)
                {
                    EngineButtonBg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/generalButtonOn.png"));
                    EngineLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
                    engineButtonState = true;
                }
                else
                {
                    EngineButtonBg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/generalButtonOff.png"));
                    EngineLabel.Foreground = new SolidColorBrush(Colors.White);
                    engineButtonState = false;
                }
            }
            else if (clickedButton.Name == "LevelingButton")
            {
                if (levelingButtonState == false)
                {
                    LevelingButtonBg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/generalButtonOn.png"));
                    LevelingLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
                    levelingButtonState = true;
                }
                else
                {
                    LevelingButtonBg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/generalButtonOff.png"));
                    LevelingLabel.Foreground = new SolidColorBrush(Colors.White);
                    levelingButtonState = false;
                }
            }
            else if (clickedButton.Name == "HammerButton")
            {
                if (hammerButtonState == false)
                {
                    HammerButtonBg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/generalButtonOn.png"));
                    HammerLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
                    hammerButtonState = true;
                }
                else
                {
                    HammerButtonBg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/generalButtonOff.png"));
                    HammerLabel.Foreground = new SolidColorBrush(Colors.White);
                    hammerButtonState = false;
                }
            }
            else if (clickedButton.Name == "LightButton")
            {
                if (lightButtonState == false)
                {
                    LightButtonBg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/generalButtonOn.png"));
                    LightLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
                    lightButtonState = true;
                }
                else
                {
                    LightButtonBg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/generalButtonOff.png"));
                    LightLabel.Foreground = new SolidColorBrush(Colors.White);
                    lightButtonState = false;
                }
            }
            else if (clickedButton.Name == "CalibrateButton")
            {
                if (calibrateButtonState == false)
                {
                    CalibrateButtonBg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/generalButtonOn.png"));
                    CalibrateLabel.Foreground = new SolidColorBrush(Color.FromRgb(8, 15, 31));
                    calibrateButtonState = true;
                }
                else
                {
                    CalibrateButtonBg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/generalButtonOff.png"));
                    CalibrateLabel.Foreground = new SolidColorBrush(Colors.White);
                    calibrateButtonState = false;
                }
            }
        }
    }
}
