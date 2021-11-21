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

namespace DayLightMachineController.View
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool HamburgerToggle;

        public MainWindow()
        {
            HamburgerToggle = false;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            if (HamburgerToggle == false)
            {
                HamburgerToggle = true;
                Task.Run(() => HamburgerOpen());
            }
            else if (HamburgerToggle == true)
            {
                HamburgerToggle = false;
                Task.Run(() => HamburgerClose());
            }
        }

        private void HamburgerOpen()
        {
            for (int i = 100; i <= 500; i++)
            {
                LeftMenu.Dispatcher.Invoke(new Action(() => LeftMenu.Width = i));
                long j = 0;
            }
        }

        private void HamburgerClose()
        {
            for (int i = 500; i >= 100; i--)
            {
                LeftMenu.Dispatcher.Invoke(new Action(() => LeftMenu.Width = i));
                long j = 0;
            }
        }
    }
}
