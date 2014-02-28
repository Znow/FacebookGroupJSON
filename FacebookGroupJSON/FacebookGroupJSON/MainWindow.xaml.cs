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
using System.Collections.Specialized;
using System.Windows.Threading;
using HtmlAgilityPack;

namespace FacebookGroupJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        bool loadNewSearchString;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //Load the combobox, from our JSON file.
            LoadComboBox();
            if (ComboBox.Items.Count > 0)
            {
                ComboBox.SelectedIndex = 0;
            }

            //LoadFeed();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles the click event of the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newW = new AddFeed();
            newW.ShowDialog();
            if (newW.DialogResult.HasValue && newW.DialogResult.Value)
            {
                loadNewSearchString = true;
                LoadComboBox();
                ComboBox.SelectedIndex = ComboBox.Items.Count - 1;
            }
        }

        /// <summary>
        /// Handles the mouse double click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Get the item from the datacontext as a Result item, so we can access its values
            var item = ((FrameworkElement)e.OriginalSource).DataContext as Result;

            if (item == null)
            {
                return;
            }

            // Find the feed item window
            var feedItemWindow = new FeedItemWindow();

            // Set the published date in the window
            var publishedDateLabel = (Label)feedItemWindow.FindName("itemPublishedDate");
            if (publishedDateLabel != null)
            {
                publishedDateLabel.Content = item.publishedDate;
            }

            // Set the publisher name in the window
            var publisherLabel = (Label)feedItemWindow.FindName("itemPublisherLabel");
            if (publisherLabel != null)
            {
                publisherLabel.Content = item.publisher;
            }

            // Set the title in the window
            var titleLabel = (Label)feedItemWindow.FindName("itemTitle");
            if (titleLabel != null)
            {
                titleLabel.Content = Tools.StripTags(item.title.Replace("&#39;", "'"));
            }

            // Set the content in the window
            var contentTextBlock = (TextBlock)feedItemWindow.FindName("itemContent");
            if (contentTextBlock != null)
            {
                contentTextBlock.Text = Tools.StripTags(item.content.Replace("&#39;", "'"));
            }

            // Set the news url in the window
            var urlButton = (Button)feedItemWindow.FindName("urlButton");
            if (urlButton != null)
            {
                urlButton.CommandParameter = item.unescapedUrl;
            }

            // Set the related stories
            var relatedStoriesList = (ListView)feedItemWindow.FindName("relatedStories");
            if (relatedStoriesList != null)
            {
                relatedStoriesList.ItemsSource = item.relatedStories;
            }

            // Show the window
            feedItemWindow.Show();
        }

        /// <summary>
        /// Handles the Selection Changed event of ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadFeed(ComboBox.SelectedValue.ToString());
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the feed
        /// </summary>
        private void LoadFeed(string search)
        {
            //string url = "https://ajax.googleapis.com/ajax/services/search/news?v=1.0&q=barack%20obama";

            Rootobject ro = FeedParser.ParseJsonFromURL(CONSTANTS.BASEQUERYURL + search);

            if (ro == null)
            {
                return;
            }

            ListView.ItemsSource = ro.responseData.results;
        }

        /// <summary>
        /// Loads the items in the ComboBox
        /// </summary>
        private void LoadComboBox()
        {
            //Check if our filepath doesn't exist.
            if (!Directory.Exists(CONSTANTS.FEEDITEMPATH))
            {
                //Create our directory, if the directory isn't present.
                Directory.CreateDirectory(CONSTANTS.FEEDITEMPATH);
            }
            //Checks if our JSON file is present.
            if (File.Exists(CONSTANTS.FEEDITEMPATH + "FeedItem.json"))
            {
                //Deserializes our JSON, into fItem which is a list of FeedItem
                var fItem = JsonConvert.DeserializeObject<List<FeedItem>>(File.ReadAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json"));

                if (fItem == null)
                {
                    return;
                }

                //This bool is set to true, in our "Add new Feed" button.
                //This is set, because we don't want to load all the entries from our JSON file, just the last one.
                if (loadNewSearchString)
                {
                    var item = fItem[fItem.Count - 1];
                    ComboBox.Items.Add(new FeedItem(item.Search, item.SearchNoWhiteSpaces).ToString());
                }
                //If the bool is false, then it will add all the entries from our JSON file, this happends first time the program starts.
                else
                {
                    foreach (var item in fItem)
                    {
                        ComboBox.Items.Add(new FeedItem(item.Search, item.SearchNoWhiteSpaces).ToString());
                    }
                }
            }

            loadNewSearchString = false;
        }

        #endregion

    }
}
