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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

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

            #region Initialize comboBox
            if (File.Exists(CONSTANTS.FEEDITEMPATH))
            {
                var fItem = JsonConvert.DeserializeObject<List<FeedItem>>(File.ReadAllText(CONSTANTS.FEEDITEMPATH));

                if (fItem == null)
                {
                    return;
                }

                foreach (var item in fItem)
                {
                    //comboBox.Items.Add(fItem);
                    ComboBox.Items.Add(new FeedItem(item.Search, item.SearchNoWhiteSpaces).ToString());
                }
            }
            #endregion

            LoadFeed();
        }

        #region Event Handlers

        /// <summary>
        /// Handles the click event of the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        /// <summary>
        /// Handles the mouse double click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Get the item from the datacontext as a Result item, so we can access its values
            Result item = ((FrameworkElement) e.OriginalSource).DataContext as Result;

            if (item == null)
            {
                return;
            }

            var publishedDate = item.publishedDate;

            // Find the feed item window
            var feedItemWindow = new FeedItemWindow();

            // if its null, return
            if (feedItemWindow == null)
            {
                return;
            }

            // Set the title in the window
            var titleLabel = (Label)feedItemWindow.FindName("itemTitle");
            if (titleLabel != null)
            {
                titleLabel.Content = Tools.StripHTML(item.title);    
            }

            // Set the content in the window
            var contentTextBlock = (TextBlock)feedItemWindow.FindName("itemContent");
            if (contentTextBlock != null)
            {
                contentTextBlock.Text = Tools.StripHTML(item.content);
            }
            

            // Show the window
            feedItemWindow.Show();
        }

        #endregion

        /// <summary>
        /// Loads the feed
        /// </summary>
        private void LoadFeed()
        {
            var newW = new AddFeed();
            newW.Show();

            //string url = "https://graph.facebook.com/237173582992285/feed?access_token=CAACEdEose0cBACvXQ9zwIad9Ut5qZCiCRV8ClJxOXrZCtZCIUxytkZCt5SzFyYXQ5XLoZB1krQ0HZAjVwZB183DCg9eY1jNx3hGxC0XgObtrh38BAd0QLTkyOpiueZAUERTVmWuwNmXkekVxXQ5zedKMXLT63mIgDnQFeQCDCDIKWVkKsW8ZAnBwNeqZBazUg6xH4ZD";
            string url = "https://ajax.googleapis.com/ajax/services/search/news?v=1.0&q=barack%20obama";

            Rootobject ro = FeedParser.ParseJsonFromURL(url);

            if (ro == null)
            {
                return;
            }

            ListView.ItemsSource = ro.responseData.results;
        }

        

    }
}
