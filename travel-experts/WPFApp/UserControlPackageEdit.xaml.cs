using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Runtime.CompilerServices;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for UserControlPackageEdit.xaml
    /// </summary>
    public partial class UserControlPackageEdit : INotifyPropertyChanged
    {
        public UserControlPackageEdit()
        {
            DataContext = this;
            InitializeComponent();
        }
        //private void Reset_Click(object sender, RoutedEventArgs e)
        //{
        //    PackageName = "";
        //    PackageStart = null;
        //    PackageEnd = null;
        //    PackageDesc = "";
        //    PackagePrice = 0;
        //    PackagePrice = 0;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var package = await GetPackage("https://localhost:44327/api/PackagesAPI/2");
            //PackageName = package.PkgName;
            //PackageDesc = package.PkgDesc;
            //PackageStart = package.PkgStartDate;
            //PackageEnd = package.PkgEndDate;
            //PackagePrice = package.PkgBasePrice;
            //PackageImage = package.PkgImage;
            //PackageCommission = package.PkgAgencyCommission;

            var packages = await GetPackages("https://localhost:44327/api/PackagesAPI");
            packagesComboBox.ItemsSource = packages;

        }
        public async void ComboBox_Changed(object sender, EventArgs e)
        {
            int packageID = packagesComboBox.SelectedIndex;
            packageID = packageID + 1;
            var package = await GetPackage("https://localhost:44327/api/PackagesAPI/" + packageID.ToString());
            PackageName = package.PkgName;
            PackageDesc = package.PkgDesc;
            PackageStart = package.PkgStartDate;
            PackageEnd = package.PkgEndDate;
            PackagePrice = package.PkgBasePrice;
            PackageImage = package.PkgImage;
            PackageCommission = package.PkgAgencyCommission;
        }
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
        public async void addSubmit_ClickAsync(object sender, EventArgs e) { }
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
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string PackageName { get { return _packageName; } set { _packageName = value; OnPropertyChanged(); } }
        private string _packageName;
        public string PackageDesc { get { return _packageDesc; } set { _packageDesc = value; OnPropertyChanged(); } }
        private string _packageDesc;
        public DateTime? PackageStart { get { return _packageStart; } set { _packageStart = value; OnPropertyChanged(); } }
        private DateTime? _packageStart;
        public DateTime? PackageEnd { get { return _packageEnd; } set { _packageEnd = value; OnPropertyChanged(); } }
        private DateTime? _packageEnd;
        public decimal PackagePrice { get { return _packagePrice; } set { _packagePrice = value; OnPropertyChanged(); } }
        private decimal _packagePrice;
        public string PackageImage { get { return _packageImage; } set { _packageImage = value; OnPropertyChanged(); } }
        private string _packageImage;
        public decimal? PackageCommission { get { return _packageCommission; } set { _packageCommission = value; OnPropertyChanged(); } }
        private decimal? _packageCommission;

        private async Task<Packages> GetPackage(string path)
        {
            HttpClient client = new System.Net.Http.HttpClient();
            Packages pkgs = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                pkgs = JsonConvert.DeserializeObject<Packages>(await response.Content.ReadAsStringAsync());
            }
            return pkgs;
        }
        private async Task<List<Packages>> GetPackages(string path)
        {
            HttpClient client = new System.Net.Http.HttpClient();
            List<Packages> pkgs = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                pkgs = JsonConvert.DeserializeObject<List<Packages>>(await response.Content.ReadAsStringAsync());
            }
            return pkgs;
        }
    }
}
