using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using IdentityServer4.Stores.Serialization;

namespace TestAddressa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string ADDRESS = "https://geocode-maps.yandex.ru/1.x/?apikey=1a91931f-aa17-48e4-838e-29d4f26ba796&format=json&geocode=*";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchAddress(object sender, RoutedEventArgs e)
        {
            WebClient web = new WebClient();
            string save = tb.Text;
            string tok = tb.Text.Replace(',', '+');
            string replace = "*";
            int IndexFirst = ADDRESS.IndexOf(replace);
            string address = ADDRESS.Remove(IndexFirst, replace.Length).Insert(IndexFirst, tok);
            string json = web.DownloadString(address);

            TestAddressa.RootObject response = JsonConvert.DeserializeObject<TestAddressa.RootObject>(json);

            int size;
            int.TryParse(response.Response.GeoObjectCollection.metaDataProperty.GeocoderResponseMetaData.found, out size);

            string[] menu = new string[size];

            int i = 0;
            foreach (var item in response.Response.GeoObjectCollection.featureMember)
            {
                menu[i] = item.GeoObject.metaDataProperty.GeocoderMetaData.text;
                i++;
            }

            adress.ItemsSource = menu;

            

            MessageBox.Show("Done");
        }
    }
}
