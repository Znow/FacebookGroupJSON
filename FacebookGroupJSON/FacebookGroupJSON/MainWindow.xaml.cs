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
                    ComboBox.Items.Add(new FeedItem(item.Name, item.ID));
                }
            }
            #endregion
        }

        /// <summary>
        /// Handles the click event of the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
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

            foreach (var item in ro.Property)
            {
                ListView.Items.Add(item);
                // TODO Fyld de relevante data ind i listview(gridview)   
            }
        }
    }
}
