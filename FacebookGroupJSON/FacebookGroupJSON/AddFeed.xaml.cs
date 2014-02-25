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

        public AddFeed()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtName.Text) || !string.IsNullOrWhiteSpace(txtID.Text))
            {
                FeedItem fItem = new FeedItem(txtName.Text, txtID.Text);
                string json = JsonConvert.SerializeObject(fItem);

                //File.AppendAllText(@"C:\FeedItem.txt", json + "\n");
                //System.IO.File.WriteAllText(@"C:\FeedItem.txt", json);
                //File.AppendAllText(CONSTANTS.FEEDITEMPATH, json + Environment.NewLine);
                //this.Close();

                if(File.Exists(CONSTANTS.FEEDITEMPATH))
                {
                    fileData = File.ReadAllText(CONSTANTS.FEEDITEMPATH);
                    if (fileData.EndsWith("]"))
                    {
                        fileData = fileData.Remove(fileData.Length - 1);
                        fileData = fileData + ",";
                        File.WriteAllText(CONSTANTS.FEEDITEMPATH, fileData);
                    }
                    File.AppendAllText(CONSTANTS.FEEDITEMPATH, json + ",");
                }
                else
                {
                    File.AppendAllText(CONSTANTS.FEEDITEMPATH, "[");
                    File.AppendAllText(CONSTANTS.FEEDITEMPATH, json + ",");
                }
                this.Close();
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            fileData = File.ReadAllText(CONSTANTS.FEEDITEMPATH);

            if(fileData.EndsWith(","))
            {
                fileData = fileData.Remove(fileData.Length - 1);
                fileData = fileData + "]";
                File.WriteAllText(CONSTANTS.FEEDITEMPATH, fileData);
            }
        }
    }
}
