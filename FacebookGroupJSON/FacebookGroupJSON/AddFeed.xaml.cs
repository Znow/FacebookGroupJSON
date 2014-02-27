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
using Newtonsoft.Json;
using System.IO;

namespace FacebookGroupJSON
{
    /// <summary>
    /// Interaction logic for AddFeed.xaml
    /// </summary>
    public partial class AddFeed : Window
    {
        string fileData;

        string searchNoWhiteSpaces;

        public AddFeed()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtSearchString.Text))
            {
                searchNoWhiteSpaces = txtSearchString.Text.Replace(" ", "%");
                FeedItem fItem = new FeedItem(txtSearchString.Text, searchNoWhiteSpaces);
                string json = JsonConvert.SerializeObject(fItem);

                if (File.Exists(CONSTANTS.FEEDITEMPATH + "FeedItem.json"))
                {
                    fileData = File.ReadAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json");
                    if (fileData.EndsWith("]"))
                    {
                        fileData = fileData.Remove(fileData.Length - 1);
                        fileData = fileData + ",";
                        File.WriteAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", fileData);
                    }
                    File.AppendAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", json + ",");
                }
                else
                {
                    File.AppendAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", "[");
                    File.AppendAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", json + ",");
                }
                DialogResult = true;
                this.Close();
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            fileData = File.ReadAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json");

            if(fileData.EndsWith(","))
            {
                fileData = fileData.Remove(fileData.Length - 1);
                fileData = fileData + "]";
                File.WriteAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", fileData);
            }
        }
    }
}
