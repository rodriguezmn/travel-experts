using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
    }
}
