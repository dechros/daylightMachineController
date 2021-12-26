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
        public ControlPage()
        {
            InitializeComponent();
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
    }
}
