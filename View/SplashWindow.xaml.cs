using System;
using DeviceId;
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
using System.Windows.Shapes;
using DayLightMachineController.Utility;
using System.Threading;

namespace DayLightMachineController.View
{
    /// <summary>
    /// SplashWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class SplashWindow : Window
    {
        public string deviceId;

        private LicenseHandler licenseHandler;
        private MainWindow mainWindow;
        public SplashWindow()
        {
            InitializeComponent();
            licenseHandler = new LicenseHandler();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            deviceId = GetDeviceId();
            Task.Run(() => CheckLicenseAsync());
            
        }

        public async Task CheckLicenseAsync()
        {
            await Task.Delay(2000);
            if (licenseHandler.CheckExistingLicense(deviceId) == true)
            {
                Dispatcher.Invoke(new Action(() => licenseStatusLabel.Content = "Machine ID: " + deviceId.ToString() + " Licensed"));
                await Task.Delay(3000);
                Dispatcher.Invoke(new Action(() => mainWindow = new MainWindow()));
                Dispatcher.Invoke(new Action(() => mainWindow.Show()));
            }
            else
            {
                Dispatcher.Invoke(new Action(() => licenseStatusLabel.Content = "License Check Failed"));
                await Task.Delay(3000);
                LicenseWindow licenseWindow = new LicenseWindow(GetDeviceId());
                licenseWindow.Show();
            }
            Dispatcher.Invoke(new Action(() => Close()));
        }

        public string GetDeviceId()
        {
            string deviceId = "";
            string[] deviceIdSubStrings = new string[3];
            deviceIdSubStrings[0] = StringHelper.RemoveNonNumbers(new DeviceIdBuilder().AddMachineName().ToString());
            deviceIdSubStrings[0] = deviceIdSubStrings[0].Remove(2, deviceIdSubStrings[0].Length - 2);
            deviceIdSubStrings[1] = StringHelper.RemoveNonNumbers(new DeviceIdBuilder().AddMacAddress().ToString());
            deviceIdSubStrings[1] = deviceIdSubStrings[1].Remove(4, deviceIdSubStrings[1].Length - 4);
            deviceIdSubStrings[2] = StringHelper.RemoveNonNumbers(new DeviceIdBuilder().AddUserName().ToString());
            deviceIdSubStrings[2] = deviceIdSubStrings[2].Remove(2, deviceIdSubStrings[2].Length - 2);
            for (int i = 0; i < deviceIdSubStrings.Length; i++)
            {
                deviceId += deviceIdSubStrings[i];
            }
            return deviceId;
        }
    }
}
