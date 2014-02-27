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
        public FeedItemWindow()
        {
            InitializeComponent();
        }

        private void urlButton_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser browser = new WebBrowser();
        }
    }
}
