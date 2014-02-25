﻿using System;
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

namespace FacebookGroupJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newW = new AddFeed();
            newW.Show();

            FeedParser.ParseJsonFromURL("https://graph.facebook.com/237173582992285/feed?access_token=CAACEdEose0cBAHmDGAZBcbKYrNKLfK1DG1yN97iKmyx8QmZABa5PnX1shxXFuQWBfXGFGW5fccpRkFTqMOoobne87fmZBZB4noHsufOm9xM70kHj2IuTFRAc0ZBZCwcMVWm5ZBsZBf859OCU6ty20mx48Ew6G3c6CE2uZBVGLwSPrmopjKBCXmQXisWg5OZCCqBZCYZD");
        }
    }
}
