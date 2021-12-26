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

        private void RightTrackTouchBall_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(this);
            RightTrackTouchBall.Margin = new Thickness(0, -50, 0, 0);
            Console.WriteLine("Mouse captured.");

            if (e.LeftButton == MouseButtonState.Pressed)
            {

            }
        }
    }
}
