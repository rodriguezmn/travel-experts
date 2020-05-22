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
    /// Interaction logic for UserControlSupplierEdit.xaml
    /// </summary>
    public partial class UserControlSupplierEdit : UserControl
    {
        public UserControlSupplierEdit()
        {
            InitializeComponent();
        }
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // When window loads. Get Suppliers Objects list from API and Bind to ComboBox
            var suppliers = await GetSuppliers("https://travelexperts.azurewebsites.net/api/SuppliersAPI");
            supplierList = suppliers;
            suppliersComboBox.ItemsSource = suppliers;

        }

        // Class property to store Suppliers List from Get Request
        private List<Suppliers> supplierList { get; set; }
        public async void ComboBox_Changed(object sender, EventArgs e)
        {
            // Try to make API call for selected Suppliers Object and display in Textbox. Else return
            try
            {
                statusTextBlock.Text = "";
                Suppliers selectedSupplier = (Suppliers)suppliersComboBox.SelectedItem;
                int supplierID = supplierList.Find(p => p.SupplierId == selectedSupplier.SupplierId).SupplierId;
                var supplier = await GetSupplier("https://travelexperts.azurewebsites.net/api/SuppliersAPI/" + supplierID.ToString());
                var products = await GetProductsFromSupplier(selectedSupplier);
                myListView.ItemsSource = products;
                nameTextbox.Text = supplier.SupName;
            }
            catch (Exception)
            {
                return;
            }

        }
        public async void deleteSubmit_ClickAsync(object sender, EventArgs e)
        {

            // User Experience Are you Sure dialog
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                try
                {
                    // Try to delete Supplier. ComboBox selection might throw exception

                    // User is sure they want to delete Supplier
                    Suppliers selectedSupplier = (Suppliers)suppliersComboBox.SelectedItem;

                    int supplierID = supplierList.Find(p => p.SupName == selectedSupplier.SupName).SupplierId;

                    // Make Delete API Call and get returned deleted Supplier object
                    var returnSupplier = await DeleteSupplierAsync("https://travelexperts.azurewebsites.net/api/SuppliersAPI", supplierID);
                    if (returnSupplier != null)
                    {
                        // Delete call successful because deleted Suppliers object was returned
                        statusTextBlock.Foreground = Brushes.Green;
                        statusTextBlock.Text = $"Supplier '{returnSupplier.SupName}' Deleted!";
                        nameTextbox.Text = "";
                    }
                    else
                    {
                        // Delete call failed
                        statusTextBlock.Foreground = Brushes.Red;
                        statusTextBlock.Text = "Unable to Delete Supplier!";
                    }
                }
                catch (Exception)
                {
                    // Delete call failed
                    statusTextBlock.Foreground = Brushes.Red;
                    statusTextBlock.Text = "Unable to Delete Supplier!";
                }

            }
            else
            {
                // User changed their mind, simply return
                return;
            }
        }
        public async void editSubmit_ClickAsync(object sender, EventArgs e)
        {
            // get current selected Supplier Object from ComboBox
            Suppliers selectedSupplier = (Suppliers)suppliersComboBox.SelectedItem;

            // If user did not change anything, simply return
            if (selectedSupplier.SupName == nameTextbox.Text)
            {
                return;
            }

            // Clear Status Text
            statusTextBlock.Text = "";

            string supplierName = nameTextbox.Text;

            // Validation: Name cannot be null
            if (nameTextbox.Text == "")
            {
                statusTextBlock.Foreground = Brushes.DarkOrange;
                statusTextBlock.Text = "Missing Fields!!";
                editButton.Background = Brushes.DarkOrange;
                return;
            }

            // Create new Suppliers object from selected Supplier in ComboBox and input Name field
            var supplier = new Suppliers
            {
                SupplierId = selectedSupplier.SupplierId,
                SupName = nameTextbox.Text,
            };

            // Put API request to Update Supplier Object in database. return statuscode
            var task = await PutSupplierAsync("https://travelexperts.azurewebsites.net/api/SuppliersAPI", supplier);
            if (task == HttpStatusCode.NoContent)
            {
                // Object successfully updated
                // Update Product in productList
                int oldSupplierIndex = supplierList.FindIndex(p => p.SupplierId == supplier.SupplierId);
                supplierList[oldSupplierIndex] = supplier;
                suppliersComboBox.SelectedItem = supplier;

                // Set Edited Message and Clear
                statusTextBlock.Foreground = Brushes.Green;
                statusTextBlock.Text = "Supplier Edited!";
                nameTextbox.Text = "";
            }
            else
            {
                // Failed to update
                statusTextBlock.Foreground = Brushes.Red;
                statusTextBlock.Text = "Unable to Edit Supplier!";
            }

        }
        private async Task<Suppliers> GetSupplier(string path)
        {
            // Get Suppliers object from Get Request, path includes SupplierId
            HttpClient client = new System.Net.Http.HttpClient();
            Suppliers supps = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                supps = JsonConvert.DeserializeObject<Suppliers>(await response.Content.ReadAsStringAsync());
            }
            return supps;
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
        private async Task<HttpStatusCode> PutSupplierAsync(string path, Suppliers supplier)
        {
            // Update Suppliers Object in PUT Request
            HttpClient client = new System.Net.Http.HttpClient();
            var content = JsonConvert.SerializeObject(supplier);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(path + "/" + supplier.SupplierId, httpContent);
            return response.StatusCode;
        }
        private async Task<Suppliers> DeleteSupplierAsync(string path, int supplierID)
        {
            // Delete Suppliers Object in Delete Request
            HttpClient client = new System.Net.Http.HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(path + "/" + supplierID);
            var returnSupplier = JsonConvert.DeserializeObject<Suppliers>(await response.Content.ReadAsStringAsync());
            return returnSupplier;
        }
        private async Task<List<Products>> GetProductsFromSupplier(Suppliers supplier)
        {
            HttpClient client = new System.Net.Http.HttpClient();

            // Get Supplier object
            HttpResponseMessage responseSupplier = await client.GetAsync("https://travelexperts.azurewebsites.net/api/SuppliersAPI/" + supplier.SupplierId.ToString());
            var supplierObject = JsonConvert.DeserializeObject<Suppliers>(await responseSupplier.Content.ReadAsStringAsync());

            // Get ProductsSuppliers Objects
            HttpResponseMessage responseProductSuppliersList = await client.GetAsync("https://travelexperts.azurewebsites.net/api/ProductsSuppliersAPI");
            List<ProductsSuppliers> productsSuppliersListFull = JsonConvert.DeserializeObject<List<ProductsSuppliers>>(await responseProductSuppliersList.Content.ReadAsStringAsync());

            // Filter List by Supplier object from previous call
            var productsSuppliersList = productsSuppliersListFull.FindAll(ps => ps.SupplierId == supplierObject.SupplierId);
            List<int> productIdList = new List<int>();
            foreach (var product in productsSuppliersList)
            {
                productIdList.Add(product.ProductId);
            }

            // get list of products
            HttpResponseMessage responseProductsList = await client.GetAsync("https://travelexperts.azurewebsites.net/api/ProductsAPI");
            List<Products> productsListFull = JsonConvert.DeserializeObject<List<Products>>(await responseProductsList.Content.ReadAsStringAsync());
            var productsList = productsListFull.FindAll(p => productIdList.Contains(p.ProductId));

            return productsList;
        }
    }
}
