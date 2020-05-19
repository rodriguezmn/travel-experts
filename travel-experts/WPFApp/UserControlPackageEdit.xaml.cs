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
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            PackageName = "";
            PackageDesc = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var package = await GetPackage("https://localhost:44327/api/PackagesAPI/2");
            PackageName = package.PkgName;
            PackageDesc = package.PkgDesc;

        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string PackageName { get { return _packageName; } set { _packageName = value; OnPropertyChanged(); } }
        private string _packageName;
        public string PackageDesc { get { return _packageDesc; } set { _packageDesc = value; OnPropertyChanged(); } }
        private string _packageDesc;

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
    }
}
