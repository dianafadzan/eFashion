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
        radnik rad;
        bool admin;
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
            foreach (var a in lista)
                if (a.radnik.jmb.Equals(rad.jmb))
                {
                    cbAdmin.IsChecked = true;
                    admin = true;
                }
        }
        public DodajAzurirajRadnikaProzor(radnik r)
        {
            novi = false;
            InitializeComponent();
            tbNaslov.Text = "Ažuriraj podatke o radniku";
            rad = r;
            inicijalizacija();
            
            
            tbJmb.Text=r.jmb;
            tbIme.Text = r.ime;
            tbPrezime.Text = r.prezime;
            tbUsername.Text = r.username;
            tbPlata.Text=r.plata.ToString();
            if(r.aktivan!=0)
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
                decimal plataD;
                if (decimal.TryParse(plata, out plataD))
                {
                    if (novi)
                    {
                        if (lozinka.Length == 0)
                            MessageBox.Show("Popunite sva polja");
                        else
                        {
                            int akt = 0;
                            if (isAktiv)
                                akt = 1;
                            radnik r = new radnik
                            {
                                jmb = jmb,
                                ime = ime,
                                prezime = prezime,
                                username = username,
                                plata = plataD,
                                aktivan = akt,
                                lozinka = Utilities.GetSHA256(lozinka)
                            };
                            var t = Task.Run(() => Utilities.CreateRadnikAsync(r));
                            if (isAdmin)
                            {
                                administrator a = new administrator
                                {
                                    radnik_jmb = r.jmb,
                                    radnik = r
                                };
                                var t2 = Task.Run(() => Utilities.CreateAdministratorAsync(a));
                                MessageBox.Show("Uspjesno ste dodali novog administratora u sistem.");
                            }
                            else
                                MessageBox.Show("Uspjesno ste dodali novog radnika u sistem.");
                            this.Hide();

                        }
                        
                    }
                    else
                    {
                        int akt = 0;
                        if (isAktiv)
                            akt = 1;
                        rad.jmb = jmb;
                        rad.ime = ime;
                        rad.prezime = prezime;
                        rad.username = username;
                        rad.plata = plataD;
                        rad.aktivan = akt;
                        if (lozinka.Length != 0)
                            rad.lozinka = Utilities.GetSHA256(lozinka);
                        var t = Task.Run(() => Utilities.UpdateRadnikAsync(rad));
                        if (!admin && isAdmin)
                        {
                            //ne prolazi kako treba
                            administrator a = new administrator
                            {
                                radnik_jmb = rad.jmb,
                                radnik = rad
                            };
                            var t2 = Task.Run(() => Utilities.CreateAdministratorAsync(a));
                        }
                        if(admin && !isAdmin)
                        {
                            //treba uraditi delete admina
                        }
                        MessageBox.Show("Uspjesno ste promjenili podatke o radniku ");
                        this.Hide();
                    }
                    
                }
            }
        }

        private void btnOdbaci_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }
    }
}
