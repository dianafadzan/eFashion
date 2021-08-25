using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace GuiPrvaVerzija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this, tbUsername);
            
        }

        static async Task Main(string []args)
        {
            var novi = new MainWindow();
            await Utilities.RunAsync();
        }
        
       




        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


        public static string GetSHA256(string password)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "").ToLower();
            }
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            String username = tbUsername.Text;
            String password = GetSHA256(pbSifra.Password);
            var administratori = await Utilities.GetAdministratoriAsync("http://localhost:9000/administratori");
            bool pronadjen = false;
            administrator praviAdmin = null;
            foreach(var admin in administratori)
            {
                if(admin.radnik.username.Equals(username) && admin.radnik.lozinka.Equals(password))
                {
                    pronadjen = true;
                    praviAdmin = admin;
                }
            }
            if (pronadjen)
            {
                new AdminastrorPocetniProzor(praviAdmin).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ne postoji administrator sa tim kredencijalima");
                tbUsername.Text = "";
                pbSifra.Password = "";
            }
            
        }
    }
}
