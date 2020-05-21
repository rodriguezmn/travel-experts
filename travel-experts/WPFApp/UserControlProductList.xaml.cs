using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
using TravelExperts.Team1.WebApp.Models;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for UserControlProductList.xaml
    /// </summary>
    public partial class UserControlProductList : UserControl
    {
        public UserControlProductList()
        {
            InitializeComponent();
        }
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get List of Products from Get API Call and Bind with ListView for display
            var products = await GetProducts("https://localhost:44327/api/ProductsAPI");
            ListViewProducts.ItemsSource = products;

        }
        private async Task<List<Products>> GetProducts(string path)
        {
            // Get List of Products Objects from Get Request, path does not include ProductsID
            HttpClient client = new System.Net.Http.HttpClient();
            List<Products> pdts = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                pdts = JsonConvert.DeserializeObject<List<Products>>(await response.Content.ReadAsStringAsync());
            }
            return pdts;
        }
    }
}
