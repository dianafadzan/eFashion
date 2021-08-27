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
using System.Windows.Shapes;

namespace GuiPrvaVerzija
{
    /// <summary>
    /// Interaction logic for DodajAzurirajRadnikaProzor.xaml
    /// </summary>
    public partial class DodajAzurirajRadnikaProzor : Window
    {
        bool novi = false;
        public DodajAzurirajRadnikaProzor()
        {
            novi = true;
            InitializeComponent();
            tbNaslov.Text = "Dodaj novog radnika";
        }

        List<administrator> lista = new List<administrator>();
        private async void inicijalizacija()
        {
            lista = await Utilities.GetAdministratoriAsync("http://localhost:9000/administratori");
        }
        public DodajAzurirajRadnikaProzor(radnik r)
        {
            novi = false;
            InitializeComponent();
            tbNaslov.Text = "Ažuriraj podatke o radniku";
            inicijalizacija();
            
            tbJmb.Text=r.jmb;
            tbIme.Text = r.ime;
            tbPrezime.Text = r.prezime;
            tbUsername.Text = r.username;
            tbPlata.Text=r.plata.ToString();
            if(r.aktivan)
                cbAktivan.IsChecked = true;
            bool pronadjen = false;
            foreach (var l in lista)
                if (l.radnik.jmb.Equals(r.jmb))
                    pronadjen = true;
            if(pronadjen)
                cbAdmin.IsChecked=true;

        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            string jmb, ime, prezime, username, plata, lozinka;
            bool isAdmin, isAktiv;
            jmb = tbJmb.Text;
            ime = tbIme.Text;
            prezime = tbPrezime.Text;
            username = tbUsername.Text;
            plata = tbPlata.Text;
            lozinka = tbPassword.Password;
            isAdmin = (bool)cbAdmin.IsChecked;
            isAktiv = (bool)cbAktivan.IsChecked;
            if (jmb.Length == 0 || ime.Length == 0 || prezime.Length == 0 || username.Length == 0 || plata.Length == 0)
            {
                MessageBox.Show("Popunite sva polja");
            }
            else
            {
                decimal plataD = Decimal.Parse(plata);
                if (novi)
                {
                    if (lozinka.Length == 0)
                        MessageBox.Show("Popunite sva polja");
                    radnik r = new radnik
                    {
                        jmb = jmb,
                        ime = ime,
                        prezime = prezime,
                        username = username,
                        plata = plataD,
                        aktivan = isAktiv,
                        lozinka = MainWindow.GetSHA256(lozinka)
                    };

                }
                else
                {

                }
            }
        }

        private void btnOdbaci_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }
    }
}
