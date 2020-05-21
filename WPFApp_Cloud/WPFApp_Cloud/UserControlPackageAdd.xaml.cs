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
    /// Interaction logic for UserControlAddPackage.xaml
    /// </summary>
    public partial class UserControlPackageAdd : UserControl
    {
        public UserControlPackageAdd()
        {
            InitializeComponent();
        }
        private void costTextbox_TextChanged(object sender, EventArgs e)
        {
            // This textbox should only include numbers

            // Return if nothing is entered
            if (costTextbox.Text == "")
            {
                return;
            }

            // Check if text entered is number, and format as number if able to Parse
            if (double.TryParse(costTextbox.Text, out double number))
            {
                // number is entered
                costTextbox.Text = string.Format("{0:#.00}", number);
                costTextbox.CaretIndex = costTextbox.Text.Length - 3;
            }
            else
            {
                // letter is entered
                costTextbox.Text = "Only Numbers Allowed";
                costTextbox.Focus();
                costTextbox.SelectAll();
            }
            
        }
        private void commissionTextbox_TextChanged(object sender, EventArgs e)
        {
            // This textbox should only include numbers

            // Return if nothing is entered
            if (commissionTextbox.Text == "")
            {
                return;
            }

            // Check if text entered is number, and format as number if able to Parse
            if (double.TryParse(commissionTextbox.Text, out double number))
            {
                // number is entered
                commissionTextbox.Text = string.Format("{0:#.00}", number);
                commissionTextbox.CaretIndex = commissionTextbox.Text.Length - 3;
            }
            else
            {
                // letter is entered
                commissionTextbox.Text = "Only Numbers Allowed";
                commissionTextbox.Focus();
                commissionTextbox.SelectAll();
            }

        }
        public async void addSubmit_ClickAsync(object sender, EventArgs e)
        {
            // clera Status Text every time add button is clicked
            statusTextBlock.Text = "";

            // Image Text is optional, but is required for database, so place dummy text
            if (image.Text == "")
            {
                image.Text = "None Provided";
            }

            string packageName = nameTextbox.Text;
            DateTime? packageStart = startDate.SelectedDate;
            DateTime? packageEnd = endDate.SelectedDate;
            string packageDesc = desc.Text;
            string packagePrice = costTextbox.Text;
            string packageImage = image.Text;
            string packageCommission = commissionTextbox.Text;

            // If any required fields are empty, show error and return
            if (nameTextbox.Text=="" || startDate.SelectedDate == null|| endDate.SelectedDate==null || desc.Text=="" || costTextbox.Text=="" || commissionTextbox.Text=="")
            {
                statusTextBlock.Foreground = Brushes.DarkOrange;
                statusTextBlock.Text = "Missing Fields!!";
                submitButton.Background = Brushes.DarkOrange;
                return;
            }

            // Start Date cannot be after End Date
            if (startDate.SelectedDate > endDate.SelectedDate)
            {
                statusTextBlock.Foreground = Brushes.DarkOrange;
                statusTextBlock.Text = "Start Date cannot be later than End Date!!";
                submitButton.Background = Brushes.DarkOrange;
                return;
            }

            // Cost cannot be less than Commission
            if (decimal.Parse(costTextbox.Text) < decimal.Parse(commissionTextbox.Text))
            {
                statusTextBlock.Foreground = Brushes.DarkOrange;
                statusTextBlock.Text = "Base Price cannot be less than Commmission!!";
                submitButton.Background = Brushes.DarkOrange;
                return;
            }

            // Create new Packages object from input fields for API call
            var package = new Packages
            {
                PkgName = nameTextbox.Text,
                PkgStartDate = startDate.SelectedDate,
                PkgEndDate = endDate.SelectedDate,
                PkgDesc = desc.Text,
                PkgBasePrice = (decimal)double.Parse(costTextbox.Text),
                PkgImage = image.Text,
                PkgAgencyCommission = (decimal?)double.Parse(commissionTextbox.Text),
            };

            // Make POST API call and return status code
            var task = await PostPackageAsync("https://travelexperts.azurewebsites.net/api/PackagesAPI", package);
            var items = task;
            if (items == HttpStatusCode.Created)
            {
                // Status code shows object created
                statusTextBlock.Foreground = Brushes.Green;
                statusTextBlock.Text = "Package Created!";
                submitButton.Background = Brushes.Green;
                nameTextbox.Text = "";
                startDate.Text = "";
                endDate.Text = "";
                desc.Text = "";
                image.Text = "";
                costTextbox.Text = "";
                commissionTextbox.Text = "";
            }
            else
            {
                // Status code shows anything other than object created
                statusTextBlock.Foreground = Brushes.Red;
                statusTextBlock.Text = "Unable to Add Package!";
                submitButton.Background = Brushes.Red;
            }

        }
        private async Task<HttpStatusCode> PostPackageAsync(string path, Packages package)
        {
            // Logic needed for Post API Call
            HttpClient client = new System.Net.Http.HttpClient();

            // convert Packages object passed in to JSON for API call
            var content = JsonConvert.SerializeObject(package);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Make async call and collect status code response
            HttpResponseMessage response = await client.PostAsync(path,httpContent);
            return response.StatusCode;
        }

    }
}
