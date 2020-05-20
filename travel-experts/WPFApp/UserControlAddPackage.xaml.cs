using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
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
    /// Interaction logic for UserControlAddPackage.xaml
    /// </summary>
    public partial class UserControlAddPackage : UserControl
    {
        public UserControlAddPackage()
        {
            InitializeComponent();
        }
        //private string _pkgName { get; set; }
        //private DateTime _pkgStartDate { get; set; }
        //private DateTime _pkgEndDate { get; set; }
        //private string _pkgDesc { get; set; }
        //private decimal _pkgBasePrice { get; set; }
        //private string _pkgImage { get; set; }
        //private decimal? _pkgAgencyCommission { get; set; }



        //public string PkgName { get; set; }
        //public DateTime PkgStartDate { get; set; }
        //public DateTime PkgEndDate { get; set; }
        //public string PkgDesc { get; set; }
        //public decimal PkgBasePrice { get; set; }
        //public string PkgImage { get; set; }
        //public decimal PkgAgencyCommission { get; set; }

        private void costTextbox_TextChanged(object sender, EventArgs e)
        {
            if (costTextbox.Text == "")
            {
                return;
            }
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
            if (commissionTextbox.Text == "")
            {
                return;
            }
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
            statusTextBlock.Text = "";

            string packageName = nameTextbox.Text;
            DateTime? packageStart = startDate.SelectedDate;
            DateTime? packageEnd = endDate.SelectedDate;
            string packageDesc = desc.Text;
            string packagePrice = costTextbox.Text;
            string packageImage = image.Text;
            string packageCommission = commissionTextbox.Text;

            if (nameTextbox.Text=="" || startDate.SelectedDate == null|| endDate.SelectedDate==null || desc.Text=="" || costTextbox.Text=="" || image.Text=="" || commissionTextbox.Text=="")
            {
                statusTextBlock.Foreground = Brushes.DarkOrange;
                statusTextBlock.Text = "Missing Fields!!";
                submitButton.Background = Brushes.DarkOrange;
                statusTextBlock.Focus();
                return;
            }

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

            //MessageBox.Show($"Name {package.PkgName} \n start {package.PkgStartDate} \n End {package.PkgEndDate} \n Desc {package.PkgDesc} \n Price {package.PkgBasePrice} \n Commission {package.PkgAgencyCommission} \n");

            var task = await PostPackageAsync("https://localhost:44327/api/PackagesAPI", package);
            var items = task;
            if (items == HttpStatusCode.Created)
            {
                statusTextBlock.Foreground = Brushes.Green;
                statusTextBlock.Text = "Package Created!";
                submitButton.Background = Brushes.Green;
                nameTextbox.Text = "";
                startDate.Text = "";
                endDate.Text = "";
                desc.Text = "";
                costTextbox.Text = "";
                commissionTextbox.Text = "";
            }
            else
            {
                statusTextBlock.Foreground = Brushes.Red;
                statusTextBlock.Text = "Unable to Add Package!";
                submitButton.Background = Brushes.Red;
            }

        }
        private async Task<HttpStatusCode> PostPackageAsync(string path, Packages package)
        {
            HttpClient client = new System.Net.Http.HttpClient();
            var content = JsonConvert.SerializeObject(package);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(path,httpContent);
            return response.StatusCode;
        }

    }
}
