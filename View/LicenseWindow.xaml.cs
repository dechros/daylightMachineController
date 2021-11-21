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
        private LicenseHandler licenseHandler = new LicenseHandler();
        private string machineId;
        private const int licenseSize = 19;
        public LicenseWindow(string machineId)
        {
            InitializeComponent();
            this.machineId = machineId;
        }

        private void licenseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int textLenght = licenseTextBox.Text.Length;
            if (textLenght == licenseSize)
            {
                checkButton.IsEnabled = true;
            }
            else
            {
                checkButton.IsEnabled = false;
                if (textLenght % 4 == 0 && textLenght != 19)
                {
                    licenseTextBox.Text += "-";
                }
                else
                {

                }
            }
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
            if (e.Key == Key.Enter && checkButton.IsEnabled == true)
            {
                checkButton_Click(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            machineIdTextBox.Text = machineId;
            bool encryptionTest = licenseHandler.DecodeLicense(licenseTextBox.Text, machineId);
            if (encryptionTest == true)
            {
                messageLabel.Content = "License Checked Successfuly";
            }
            else if (encryptionTest == false)
            {
                messageLabel.Content = "Error Checking License";
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
