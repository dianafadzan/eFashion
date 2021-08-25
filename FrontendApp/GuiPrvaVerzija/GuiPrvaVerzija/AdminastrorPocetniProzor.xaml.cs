using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace GuiPrvaVerzija
{
    /// <summary>
    /// Interaction logic for AdminastrorPocetniProzor.xaml
    /// </summary>
    public partial class AdminastrorPocetniProzor : Window
    {
        private Boolean VecPokrenuto = false;


        //lista racuna
        List<racun> listaRacuna = null;
        List<kategorija> listaKategorija = null;

        private async void inicijalizacija()
        {
            listaRacuna = await Utilities.GetRacuniAsync("http://localhost:9000/racuni");
            listaKategorija = await Utilities.GetKategorijeAsync("http://localhost:9000/kategorije");
        }
        public AdminastrorPocetniProzor()
        {
            InitializeComponent();
            PocetniCanvas.Visibility = Visibility.Visible;
            HideAllCanvas();
            inicijalizacija();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLoggou_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Hide();
        }

        private void HideAllCanvas()
        {
            IzmjenaBazeArtikalaCanvas.Visibility = Visibility.Hidden;
            PregledProdajeCanvas.Visibility = Visibility.Hidden;
            PregledRacunaCanvas.Visibility = Visibility.Hidden;
            PregledZaradeCanvas.Visibility = Visibility.Hidden;
            UnosRobeCanvas.Visibility = Visibility.Hidden;
            ZaposleniCanvas.Visibility = Visibility.Hidden;
            btnDodajRobu.Style = (Style)FindResource("RoundedButtonSacuvajStyle");
            btnIzmjenaZaposlenih.Style = (Style)FindResource("RoundedButtonSacuvajStyle");
            btnIzmjeniBazu.Style = (Style)FindResource("RoundedButtonSacuvajStyle");
            btnPregledArt.Style = (Style)FindResource("RoundedButtonSacuvajStyle");
            btnPregledRacuna.Style = (Style)FindResource("RoundedButtonSacuvajStyle");
            btnPregledZarade.Style = (Style)FindResource("RoundedButtonSacuvajStyle");
        }

        private async void btnDodajRobu_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            btnDodajRobu.Style = (Style)FindResource("RoundedButtonStyle");
            if (!VecPokrenuto)
            {
                MovePocetniCanvas();
                await Task.Delay(2000);
                VecPokrenuto = true;
            }            
            UnosRobeCanvas.Visibility = Visibility.Visible;

        }

        private async void btnIzmjeniBazu_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            btnIzmjeniBazu.Style = (Style)FindResource("RoundedButtonStyle");
            if (!VecPokrenuto)
            {
                MovePocetniCanvas();
                await Task.Delay(2000);
                VecPokrenuto = true;
            }
            IzmjenaBazeArtikalaCanvas.Visibility = Visibility.Visible;
        }

        private async void btnPregledRacuna_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            btnPregledRacuna.Style = (Style)FindResource("RoundedButtonStyle");
            if (!VecPokrenuto)
            {
                MovePocetniCanvas();
                await Task.Delay(2000);
                VecPokrenuto = true;
            }
            PregledRacunaCanvas.Visibility = Visibility.Visible;
            RacuniTabela4.ItemsSource = listaRacuna;
            RacuniTabela4.Items.Refresh();
        }

        private async void btnPregledArt_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            btnPregledArt.Style = (Style)FindResource("RoundedButtonStyle");
            if (!VecPokrenuto)
            {
                MovePocetniCanvas();
                await Task.Delay(2000);
                VecPokrenuto = true;
            }
            PregledProdajeCanvas.Visibility = Visibility.Visible;
            
            
            dpDatumPoc.DisplayDate = DateTime.Today;
            dpDatumKraj.DisplayDate = DateTime.Today;
            //popuniTabelu();
            
            //treba povuci kategorije iz baze i staviti ih ovdje
            foreach(var kat in listaKategorija)
            {
                cbKategorija3.Items.Add(kat.Naziv);
            }
        }

        private async void btnPregledZarade_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            btnPregledZarade.Style = (Style)FindResource("RoundedButtonStyle");
            if (!VecPokrenuto)
            {
                MovePocetniCanvas();
                await Task.Delay(2000);
                VecPokrenuto = true;
            }
            PregledZaradeCanvas.Visibility = Visibility.Visible;
        }

        private async void btnIzmjenaZaposlenih_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            btnIzmjenaZaposlenih.Style = (Style)FindResource("RoundedButtonStyle");
            if (!VecPokrenuto)
            {
                MovePocetniCanvas();
                await Task.Delay(2000);
                VecPokrenuto = true;
            }
            ZaposleniCanvas.Visibility = Visibility.Visible;
        }

        private void MovePocetniCanvas()
        {
            TranslateTransform trans1 = new TranslateTransform();
            btnDodajRobu.RenderTransform = trans1;
            DoubleAnimation btn1X_anim = new DoubleAnimation(0, -90, TimeSpan.FromSeconds(2));
            DoubleAnimation btn1Y_anim = new DoubleAnimation(0, -190, TimeSpan.FromSeconds(2));
            trans1.BeginAnimation(TranslateTransform.XProperty, btn1X_anim);
            trans1.BeginAnimation(TranslateTransform.YProperty, btn1Y_anim);

            TranslateTransform trans2 = new TranslateTransform();
            btnIzmjeniBazu.RenderTransform = trans2;
            DoubleAnimation btn2X_anim = new DoubleAnimation(0, -510, TimeSpan.FromSeconds(2));
            DoubleAnimation btn2Y_anim = new DoubleAnimation(0, -105, TimeSpan.FromSeconds(2));
            trans2.BeginAnimation(TranslateTransform.XProperty, btn2X_anim);
            trans2.BeginAnimation(TranslateTransform.YProperty, btn2Y_anim);

            TranslateTransform trans3 = new TranslateTransform();
            btnPregledArt.RenderTransform = trans3;
            DoubleAnimation btn3X_anim = new DoubleAnimation(0, -90, TimeSpan.FromSeconds(2));
            DoubleAnimation btn3Y_anim = new DoubleAnimation(0, -120, TimeSpan.FromSeconds(2));
            trans3.BeginAnimation(TranslateTransform.XProperty, btn3X_anim);
            trans3.BeginAnimation(TranslateTransform.YProperty, btn3Y_anim);

            TranslateTransform trans4 = new TranslateTransform();
            btnPregledRacuna.RenderTransform = trans4;
            DoubleAnimation btn4X_anim = new DoubleAnimation(0, -510, TimeSpan.FromSeconds(2));
            DoubleAnimation btn4Y_anim = new DoubleAnimation(0, -35, TimeSpan.FromSeconds(2));
            trans4.BeginAnimation(TranslateTransform.XProperty, btn4X_anim);
            trans4.BeginAnimation(TranslateTransform.YProperty, btn4Y_anim);

            TranslateTransform trans5 = new TranslateTransform();
            btnPregledZarade.RenderTransform = trans5;
            DoubleAnimation btn5X_anim = new DoubleAnimation(0, -90, TimeSpan.FromSeconds(2));
            DoubleAnimation btn5Y_anim = new DoubleAnimation(0, -50, TimeSpan.FromSeconds(2));
            trans5.BeginAnimation(TranslateTransform.XProperty, btn5X_anim);
            trans5.BeginAnimation(TranslateTransform.YProperty, btn5Y_anim);

            TranslateTransform trans6 = new TranslateTransform();
            btnIzmjenaZaposlenih.RenderTransform = trans6;
            DoubleAnimation btn6X_anim = new DoubleAnimation(0, -510, TimeSpan.FromSeconds(2));
            DoubleAnimation btn6Y_anim = new DoubleAnimation(0, 35, TimeSpan.FromSeconds(2));
            trans6.BeginAnimation(TranslateTransform.XProperty, btn6X_anim);
            trans6.BeginAnimation(TranslateTransform.YProperty, btn6Y_anim);

            tbDobrodosli.Visibility = Visibility.Hidden;
            tbNazivApp.Visibility = Visibility.Visible;
        }

        
        
        //Canvas Dodaj novi artikal

        private void btnSacuvajNoviArtikal_Click(object sender, RoutedEventArgs e)
        {

        }

        //dodavanje slike
        private void btnSlika_Click(object sender, RoutedEventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var fileContent = string.Empty;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                openFileDialog.InitialDirectory = projectDirectory+"\\GuiPrvaVerzija\\odjeca";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                Nullable<bool> result = openFileDialog.ShowDialog();

                if (result == true)
                {
                    filePath = openFileDialog.SafeFileName;
                    var uriSource = new Uri(@"/GuiPrvaVerzija;component/odjeca/"+ filePath, UriKind.Relative);
                    Slika.Source = new BitmapImage(uriSource);
                }
            }            
        }



        //Izmjena baze artikala Canvas
        private void btnSifra2_Click(object sender, RoutedEventArgs e)
        {
            string sifra = tbSifra2.Text;
            //Pretraga po sifri i da se postavi vrijednost na mjesto koje treba da budu

            tbNaziv2.IsEnabled = true;
            tbCijena2.IsEnabled = true;
            tbKolicina2.IsEnabled = true;
            tbVelicina2.IsEnabled = true;
            cbxKategorija2.IsEnabled = true;
            btnSlika2.IsEnabled = true;



        }

        private void btnSlika2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSacuvajNoviArtikal2_Click(object sender, RoutedEventArgs e)
        {

        }


        //Pregled prodaje Canvas

        private void popuniTabelu()
        {
            if (VecPokrenuto)
            {
                String kategorija = cbKategorija3.Text;
                DateTime datumPoc = (DateTime)dpDatumPoc.SelectedDate;
                DateTime datumKraj = (DateTime)dpDatumKraj.SelectedDate;

                //sada treba povuci iz baze sve proizvode koji su se prodali u periodu od datumPoc
                // do datumKraj i koji su kategorije kategorija. Ako je kategorija!=Sve onda je neka
                //specificna kategorija, a ako je kategorija ==Sve onda su to sve kategorije

            }
        }

        private void cbKategorija3_Selected(object sender, RoutedEventArgs e)
        {
            popuniTabelu();
        }

        private void dpDatumKraj_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            popuniTabelu();
        }

        private void dpDatumPoc_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            popuniTabelu();
        }




        //Pregld racuna Canvas
        private void ComboBoxItem_Selected_Datum(object sender, RoutedEventArgs e)
        {
            tbUputstvo.Text = "Izaberite datum računa";
            dpDatum4.Visibility = Visibility.Visible;
            tbSifra4.Visibility = Visibility.Hidden;
                

        }

        private void ComboBoxItem_Selected_Sifra(object sender, RoutedEventArgs e)
        {
            tbUputstvo.Text = "Unesite šifru računa";
            dpDatum4.Visibility = Visibility.Hidden;
            tbSifra4.Visibility = Visibility.Visible;
        }

        private void btnSifra4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbSifra4_KeyUp(object sender, KeyEventArgs e)
        {
            /*
                ovu liniju koda mozes staviti i negdje vani tako da se ne pristupa bazi svaki put kada pritisnes dugme
                ali to je kod koji ce ti omoguciti da se filtriraju racuni po sifri svaki put kada budes otkucala slovo sifre
                sviRacuni= (from c in db.racuns select c).ToList();

                var filtrirani = sviRacuni.Where(racun => racun.sifra.ToLower().StartsWith(tbSifra4.Text.ToLower()));
                RacuniTabela4.ItemsSource = filtrirani;
             */
            
            var filtrirani = listaRacuna.Where(racun => racun.idracuna==int.Parse(tbSifra4.Text));
            RacuniTabela4.ItemsSource = filtrirani;
            RacuniTabela4.Items.Refresh();
        }

        private void btnPogledajRacun4_Click(object sender, RoutedEventArgs e)
        {
            new PregledRacunaProzor().ShowDialog();
        }

      

        private void dpDatum4_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Zarada

        private void dpDatum5_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VecPokrenuto)
            {
                DateTime datumPoc = (DateTime)dpDatumPoc5.SelectedDate;
                DateTime datumKraj = (DateTime)dpDatumKraj5.SelectedDate;
                //naci zaradu izmedju ova dva datuma i staviti na ovaj tbZarada.Text=
                tbZarada.Text = "";
            }
        }

        //Canvas Zaposleni

        private void tbZaposleni_KeyUp(object sender, KeyEventArgs e)
        {
            /*
             sviZaposleniFiltrirani da budu zaposleni koji su u ovim combo boxovima izabrani

            var filtrirani = sviZaposleniFiltrirani.Where(zaposlen => zaposlen.ime.ToLower().StartsWith(tbZaposleni.Text.ToLower()) || zaposlen.prezime.ToLower().StartsWith(tbZaposleni.Text.ToLower()) || zaposlen.username.ToLower().StartsWith(tbZaposleni.Text.ToLower()) );
            ZaposleniTable.ItemsSource = filtrirani;*/
        }

        private void cbSviItem_Selected(object sender, RoutedEventArgs e)
        {

        }
        private void cbRadniciItem_Selected(object sender, RoutedEventArgs e)
        {

        }
        private void cbAdministratoriItem_Selected(object sender, RoutedEventArgs e)
        {

        }
        private void cbTrenutnoItem_Selected(object sender, RoutedEventArgs e)
        {

        }
        private void cbBivsiItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        
        private void btnDodajRadnika_Click(object sender, RoutedEventArgs e)
        {
            new DodajAzurirajRadnikaProzor().ShowDialog();
        }
        private void btnAzurirajRadnika_Click(object sender, RoutedEventArgs e)
        {
            string Radnik = "";
            new DodajAzurirajRadnikaProzor(Radnik).ShowDialog();
        }




    }
}
