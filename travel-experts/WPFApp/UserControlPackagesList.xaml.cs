using MaterialDesignColors.Recommended;
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
    /// Interaction logic for UserControlPackagesList.xaml
    /// </summary>
    public partial class UserControlPackagesList : UserControl
    {
        public UserControlPackagesList()
        {
            InitializeComponent();
        }
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var packages = await GetPackages("https://localhost:44327/api/PackagesAPI");
            foreach (var package in packages)
            {
                // Convert image name in PkgImage column to string path to find corresponding image
                package.PkgImage = $"/Images/{package.PkgImage}.jpg";

                DateTime EndDate = (DateTime)package.PkgEndDate;
                String EndDateString = EndDate.ToShortDateString();
                package.PkgEndDate = Convert.ToDateTime(EndDateString);

            }
            ListViewPackages.ItemsSource = packages;
            
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
