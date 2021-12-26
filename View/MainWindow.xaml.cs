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
        public MainWindow()
        {
            HamburgerToggle = false;
            MainWindowHomePage = new HomePage();
            MainWindowControlPage = new ControlPage();
            MainWindowConnectionPage = new ConnectionPage();
            MainWindowFavoritesPage = new FavoritesPage();
            MainWindowDetailsPage = new DetailsPage();
            MainWindowUpdatePage = new UpdatePage();
            MainWindowSettingsPage = new SettingsPage();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(MainWindowHomePage);
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
    }
}
