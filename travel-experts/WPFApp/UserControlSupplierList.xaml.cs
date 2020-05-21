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
    /// Interaction logic for UserControlSupplierList.xaml
    /// </summary>
    public partial class UserControlSupplierList : UserControl
    {
        public UserControlSupplierList()
        {
            InitializeComponent();
        }
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // When page loads, make Async Get request getting List of Suppliers objects and bind to ListView for display
            var suppliers = await GetSuppliers("https://localhost:44327/api/SuppliersAPI");
            ListViewSuppliers.ItemsSource = suppliers;

        }
        private async Task<List<Suppliers>> GetSuppliers(string path)
        {
            // Get List of Suppliers Objects from Get Request
            HttpClient client = new System.Net.Http.HttpClient();
            List<Suppliers> supps = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                supps = JsonConvert.DeserializeObject<List<Suppliers>>(await response.Content.ReadAsStringAsync());
            }
            return supps;
        }
    }
}
