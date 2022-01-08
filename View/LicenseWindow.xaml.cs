using DayLightMachineController.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DayLightMachineController.View
{
    /// <summary>
    /// Interaction logic for LicenseWindow.xaml
    /// </summary>
    public partial class LicenseWindow : Window
    {
        private string machineId;
        private LicenseHandler licenseHandler;
        
        public LicenseWindow(string machineId)
        {
            InitializeComponent();
            this.machineId = machineId;
            machineIdTextBox.Text = machineId;
            licenseHandler = new LicenseHandler();
        }

        private void licenseTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void licenseTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            base.OnPreviewKeyDown(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && CheckButton.IsEnabled == true)
            {
                CheckButton_Click(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {

            machineIdTextBox.Text = machineId;
            bool encryptionTest = licenseHandler.DecodeLicense(licenseTextBox.Text, machineId);
            if (encryptionTest)
            {
                if (licenseHandler.WriteLicense(licenseTextBox.Text))
                {
                    messageLabel.Content = "License Check Succeeded";
                    Task.Run(() => RestartApp());
                }
                else
                {
                    messageLabel.Content = "Can Not Save The License";
                }
            }
            else if (!encryptionTest)
            {
                messageLabel.Content = "Error Checking License";
            }
            
        }

        private async Task RestartApp()
        {
            await Task.Delay(300);
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
