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
using System.Windows.Shapes;

namespace FacebookGroupJSON
{
    /// <summary>
    /// Interaction logic for FeedItemWindow.xaml
    /// </summary>
    public partial class FeedItemWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FeedItemWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of urlButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void urlButton_Click(object sender, RoutedEventArgs e)
        {
            // Sets the sender as a button, so we can get command params
            var button = (Button) sender;

            // initialize the window: webbrowser
            var webBrowserWindow = new WebBrowserWindow();

            // finds the webbrowser in the webbrowserwindow
            var webBrowser = (WebBrowser) webBrowserWindow.FindName("webBrowser");

            if (webBrowser != null)
            {
                // Navigates to the URL from the buttons command param
                webBrowser.Navigate(button.CommandParameter.ToString());    
            }

            // Show the webbrowser window
            webBrowserWindow.Show();
        }

        private void relatedStories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
