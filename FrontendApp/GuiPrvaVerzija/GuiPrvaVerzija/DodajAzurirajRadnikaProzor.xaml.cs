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
        public DodajAzurirajRadnikaProzor()
        {
            InitializeComponent();
            tbNaslov.Text = "Dodaj novog radnika";
        }

        //ovdje treba radnik Radnik
        public DodajAzurirajRadnikaProzor(String Radnik)
        {
            InitializeComponent();
            tbNaslov.Text = "Ažuriraj podatke o radniku";

            /*
            tbJmb.Text=Radnik.jmb;
            tbIme.Text = Radnik.ime;
            tbPrezime.Text = Radnik.prezime;
            tbUsername.Text = Radnik.username;
            tbPlata.Text=Radnik.plata.ToString();
            if(radnik.aktivan)
                cbAktivan.IsChecked = true;
            if(radnik.Administrator) // ovo nisam siguran kako da uradim jer nemam bazu, pa to
            malo skontaj
                cbAdmin.IsChecked=true;
            */
            cbAktivan.IsChecked = true;

        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

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
