using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFApp_Cloud
{
    /// <summary>
    /// Interaction logic for UserControlSupplierAdd.xaml
    /// </summary>
    public partial class UserControlSupplierAdd : UserControl
    {
        public UserControlSupplierAdd()
        {
            InitializeComponent();
        }
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //// On page load, make API call to get List of Packages from database
            //var packages = await GetPackages("https://travelexperts.azurewebsites.net/api/PackagesAPI");
            //foreach (var package in packages)
            //{
            //    // Convert image name in PkgImage column to string path to find corresponding image
            //    var images = new List<string> { "asia", "caribbean", "europe", "polynesia", "goldengate" };

            //    // if package image tag is in the images list, replace that name with the path to the image
            //    if (images.Contains($"{package.PkgImage}"))
            //    {
            //        package.PkgImage = $"/Images/{package.PkgImage}.jpg";
            //    }
            //    else
            //    {
            //        // else replace with default earth image
            //        package.PkgImage = $"/Images/default.jpg";
            //    }
            //    DateTime EndDate = (DateTime)package.PkgEndDate;
            //    String EndDateString = EndDate.ToShortDateString();
            //    package.PkgEndDate = Convert.ToDateTime(EndDateString);

            //}

            //// Bind ListView to the Packages List from API call for display
            //ListViewPackages.ItemsSource = packages;

        }
        public async void addSubmit_ClickAsync(object sender, EventArgs e)
        {
            // Clear Status text when submit button is clicked
            statusTextBlock.Text = "";

            string supplierName = nameTextbox.Text;

            // Validation: Name is required
            if (nameTextbox.Text == "")
            {
                statusTextBlock.Foreground = Brushes.DarkOrange;
                statusTextBlock.Text = "Missing Fields!!";
                submitButton.Background = Brushes.DarkOrange;
                return;
            }

            // Create new Supplier object from input field to post into database
            var supplier = new Suppliers
            {
                SupName = nameTextbox.Text
            };


            // Make Post API call to database to insert Supplier
            var task = await PostProductAsync("https://travelexperts.azurewebsites.net/api/SuppliersAPI", supplier);
            var items = task;
            if (items == HttpStatusCode.Created)
            {
                // Successful insert of Supplier object into database
                statusTextBlock.Foreground = Brushes.Green;
                statusTextBlock.Text = "Supplier Created!";
                submitButton.Background = Brushes.Green;
                nameTextbox.Text = "";
            }
            else
            {
                // Post Request failed
                statusTextBlock.Foreground = Brushes.Red;
                statusTextBlock.Text = "Unable to Add Supplier!";
                submitButton.Background = Brushes.Red;
            }

        }
        private async Task<HttpStatusCode> PostProductAsync(string path, Suppliers supplier)
        {
            // Post API call to insert passed in Suppliers object into database. Return status code for verification
            HttpClient client = new System.Net.Http.HttpClient();
            var content = JsonConvert.SerializeObject(supplier);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(path, httpContent);
            return response.StatusCode;
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
        //public List<Products> ProductListAPII { get; set; }
    }
}
