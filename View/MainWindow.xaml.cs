using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
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
using DayLightMachineController.View.MainWindowPages;

namespace DayLightMachineController.View
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool HamburgerToggle;
        private Page MainWindowHomePage;
        private Page MainWindowControlPage;
        private Page MainWindowConnectionPage;
        private Page MainWindowFavoritesPage;
        private Page MainWindowDetailsPage;
        private Page MainWindowUpdatePage;
        private Page MainWindowSettingsPage;
        public MainWindow(List<Page> PageList)
        {
            HamburgerToggle = false;
            MainWindowHomePage = PageList[0];
            MainWindowControlPage = PageList[1];
            MainWindowConnectionPage = PageList[2];
            MainWindowFavoritesPage = PageList[3];
            MainWindowDetailsPage = PageList[4];
            MainWindowUpdatePage = PageList[5];
            MainWindowSettingsPage = PageList[6];
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UnclickAllButtons();
            HomeButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/homeButtonClicked.png"));
            MainFrame.Navigate(MainWindowHomePage);
        }

        private void HamburgerOpen()
        {
            for (int i = 90; i <= 290; i++)
            {
                LeftMenu.Dispatcher.Invoke(new Action(() => LeftMenu.Width = i));
            }
        }

        private void HamburgerClose()
        {
            for (int i = 290; i >= 90; i--)
            {
                LeftMenu.Dispatcher.Invoke(new Action(() => LeftMenu.Width = i));
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            UnclickAllButtons();
            HomeButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/homeButtonClicked.png"));
            MainFrame.Navigate(MainWindowHomePage);
        }

        private void RoundButton_Click(object sender, RoutedEventArgs e)
        {
            UnclickAllButtons();
            RoundButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/roundButtonClicked.png"));
            MainFrame.Navigate(MainWindowControlPage);
        }

        private void ConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            UnclickAllButtons();
            ConnectionButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/connectionButtonClicked.png"));
            MainFrame.Navigate(MainWindowConnectionPage);
        }

        private void StarButton_Click(object sender, RoutedEventArgs e)
        {
            UnclickAllButtons();
            StarButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/starButtonClicked.png"));
            MainFrame.Navigate(MainWindowFavoritesPage);
        }

        private void DocumentButton_Click(object sender, RoutedEventArgs e)
        {
            UnclickAllButtons();
            DocumentButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/documentButtonClicked.png"));
            MainFrame.Navigate(MainWindowDetailsPage);
        }

        private void ArrowButton_Click(object sender, RoutedEventArgs e)
        {
            UnclickAllButtons();
            ArrowButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/arrowButtonClicked.png"));
            MainFrame.Navigate(MainWindowUpdatePage);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            UnclickAllButtons();
            SettingsButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/settingsButtonClicked.png"));
            MainFrame.Navigate(MainWindowSettingsPage);
        }

        private void UnclickAllButtons()
        {
            HomeButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/homeButton.png"));
            RoundButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/roundButton.png"));
            ConnectionButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/connectionButton.png"));
            StarButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/starButton.png"));
            DocumentButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/documentButton.png"));
            ArrowButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/arrowButton.png"));
            SettingsButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/settingsButton.png"));
        }

        private void HamburgerButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (HamburgerToggle == false)
            {
                HamburgerToggle = true;
                MainFrameOverlayGrid.Visibility = Visibility.Visible;
                Task.Run(() => HamburgerOpen());
            }
            else if (HamburgerToggle == true)
            {
                HamburgerToggle = false;
                MainFrameOverlayGrid.Visibility = Visibility.Collapsed;
                Task.Run(() => HamburgerClose());
            }
        }

        private void HomeButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnclickAllButtons();
            HomeButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/homeButtonClicked.png"));
            MainFrame.Navigate(MainWindowHomePage);
        }

        private void RoundButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnclickAllButtons();
            RoundButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/roundButtonClicked.png"));
            MainFrame.Navigate(MainWindowControlPage);
        }

        private void ConnectionButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnclickAllButtons();
            ConnectionButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/connectionButtonClicked.png"));
            MainFrame.Navigate(MainWindowConnectionPage);
        }

        private void StarButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnclickAllButtons();
            StarButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/starButtonClicked.png"));
            MainFrame.Navigate(MainWindowFavoritesPage);
        }

        private void DocumentButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnclickAllButtons();
            DocumentButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/documentButtonClicked.png"));
            MainFrame.Navigate(MainWindowDetailsPage);
        }

        private void ArrowButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnclickAllButtons();
            ArrowButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/arrowButtonClicked.png"));
            MainFrame.Navigate(MainWindowUpdatePage);
        }

        private void SettingsButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UnclickAllButtons();
            SettingsButtonIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/settingsButtonClicked.png"));
            MainFrame.Navigate(MainWindowSettingsPage);
        }
    }
}
