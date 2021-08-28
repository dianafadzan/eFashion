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

namespace GuiRadnici
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

        static async Task Main(string[] args)
        {
            var novi = new MainWindow();
            await Utilities.RunAsync();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            String username = tbUsername.Text;
            String password = Utilities.GetSHA256(pbSifra.Password);
            var radnici = await Utilities.GetRadniciAsync("http://localhost:9000/radnici");
            bool pronadjen = false;
            radnik praviRadnik = null;
            foreach (var rad in radnici)
            {
                if (rad.username.Equals(username) && rad.lozinka.Equals(password))
                {
                    pronadjen = true;
                    praviRadnik = rad;
                }
            }
            if (pronadjen)
            {
                this.Hide();
                new RadnikPocetniProzor(praviRadnik).Show();
                
            }
            else
            {
                MessageBox.Show("Ne postoji radnik sa tim kredencijalima");
                tbUsername.Text = "";
                pbSifra.Password = "";
            }


        }
    }
}
