using DayLightMachineController.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DayLightMachineController
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {
        private void Main(object sender, StartupEventArgs e)
        {
            SplashWindow splashWindow = new SplashWindow();
            splashWindow.Show();

            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
        }
    }
}
