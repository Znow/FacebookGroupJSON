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
        #region Fields

        string fileData;
        string searchNoWhiteSpaces;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public AddFeed()
        {
            InitializeComponent();
        }

        #region Event Handlers

        /// <summary>
        /// Handles the click event of btnAdd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Checks if textbox is empty.
            if(!string.IsNullOrWhiteSpace(txtSearchString.Text))
            {
                //Replaces all whitespaces with '%', for us to use in queryURL.
                searchNoWhiteSpaces = txtSearchString.Text.Replace(" ", "%");
                //Creates a new FeedItem.
                FeedItem fItem = new FeedItem(txtSearchString.Text, searchNoWhiteSpaces);
                //Serializes the FeedItem.
                string json = JsonConvert.SerializeObject(fItem);

                //Checks if our file already exists.
                if (File.Exists(CONSTANTS.FEEDITEMPATH + "FeedItem.json"))
                {
                    //File.AppendAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", json + ",");
                    fileData = File.ReadAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json");
                    //Here we check if our document ends with ']'
                    if (fileData.EndsWith("]"))
                    {
                        //If it ends with ']', then remove it, and replace it with ','
                        fileData = fileData.Remove(fileData.Length - 1);
                        fileData = fileData + ",";
                        //Write to our file again.
                        File.WriteAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", fileData);
                    }
                    File.AppendAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", json + ",");
                }
                else
                {
                    //If our file doesn't exists already, then we'll have to start our file with a ']', to have a valid JSON
                    File.AppendAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", "[");
                    File.AppendAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", json + ",");
                }
                //Sets the dialogresult to true
                DialogResult = true;
                //Closes the windows.
                this.Close();
            }
            
        }

        /// <summary>
        /// Handles the Window Closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Reads our JSON file
            fileData = File.ReadAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json");

            //Checks if the file ends with ','
            if(fileData.EndsWith(","))
            {
                //And if it does, then it removes it, and adds ']' instead.
                //This ensures us, than we have a valid JSON everytime we add a new entry.
                fileData = fileData.Remove(fileData.Length - 1);
                fileData = fileData + "]";
                File.WriteAllText(CONSTANTS.FEEDITEMPATH + "FeedItem.json", fileData);
            }
        }

        #endregion
    }
}
