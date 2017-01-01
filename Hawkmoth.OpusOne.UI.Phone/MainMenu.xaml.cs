using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Hawkmoth.OpusOne.UI.Phone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();

            MenuControl.ItemsSource = MainPage.Current.MenuItems;
        }


        private void MenuControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menuListBox = sender as ListBox;

            var menuItem = menuListBox.SelectedItem as MenuItem;

            if (menuItem != null)
            {
                var mainFrame = MainPage.Current.FindName("MainFrame") as Frame;
                mainFrame.Navigate(menuItem.ClassType);
            }

            // Clear the selection before we navigate away
            menuListBox.SelectedItem = null;
        }
    }
}
