using System;
using System.Collections.Generic;
using System.Data;
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

        string putanjaZaSlike = @"C:\Users\Acer ES1\Desktop\FAKULTET\4 godina\InformacioniSistemi\Projekat\eFashion\BackendApp\NOVO\slikeOdjece";
        string nazivSlike = "";

        List<racun> listaRacuna = new List<racun>();
        List<kategorija> listaKategorija = new List<kategorija>();
        List<radnik> listaRadnika = new List<radnik>();
        List<administrator> listaAdministratora = new List<administrator>();
        List<artikal> listaArtikala = new List<artikal>();

        List<radnik> radniciUTabeli = new List<radnik>();

        artikal aZaIzmjenu;

        private async void inicijalizacija()
        {
            listaRacuna = await Utilities.GetRacuniAsync("http://localhost:9000/racuni");
            listaKategorija = await Utilities.GetKategorijeAsync("http://localhost:9000/kategorije");
            listaRadnika = await Utilities.GetRadniciAsync("http://localhost:9000/radnici");
            listaAdministratora = await Utilities.GetAdministratoriAsync("http://localhost:9000/administratori");
            listaArtikala = await Utilities.GetArtikliAsync("http://localhost:9000/artikli");

        }
        public AdminastrorPocetniProzor(administrator admin)
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
                await Task.Delay(1000);
                VecPokrenuto = true;
            }
            UnosRobeCanvas.Visibility = Visibility.Visible;
            cbxKategorija.Items.Clear();
            foreach (kategorija k in listaKategorija)
                cbxKategorija.Items.Add(k.naziv);
            ponistiDodajNovi();

        }

        private async void btnIzmjeniBazu_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            btnIzmjeniBazu.Style = (Style)FindResource("RoundedButtonStyle");
            if (!VecPokrenuto)
            {
                MovePocetniCanvas();
                await Task.Delay(1000);
                VecPokrenuto = true;
            }
            IzmjenaBazeArtikalaCanvas.Visibility = Visibility.Visible;
            cbxKategorija2.Items.Clear();
            foreach (kategorija k in listaKategorija)
                cbxKategorija2.Items.Add(k.naziv);
            ponistiIzmjenu();
        }

        private async void btnPregledRacuna_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            btnPregledRacuna.Style = (Style)FindResource("RoundedButtonStyle");
            if (!VecPokrenuto)
            {
                MovePocetniCanvas();
                await Task.Delay(1000);
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
                await Task.Delay(1000);
                VecPokrenuto = true;
            }
            PregledProdajeCanvas.Visibility = Visibility.Visible;


            dpDatumPoc.DisplayDate = DateTime.Today;
            dpDatumKraj.DisplayDate = DateTime.Today;
            //nije dobro popunjena tabela, artikli treba da se poredaju po broju prodanih artikala
            //========================================
            //=========================================
            ProdajaTabela3.ItemsSource = listaArtikala;
            ProdajaTabela3.Items.Refresh();

            cbKategorija3.Items.Clear();
            foreach (var kat in listaKategorija)
            {
                cbKategorija3.Items.Add(kat.naziv);
            }
        }

        private async void btnPregledZarade_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            btnPregledZarade.Style = (Style)FindResource("RoundedButtonStyle");
            if (!VecPokrenuto)
            {
                MovePocetniCanvas();
                await Task.Delay(1000);
                VecPokrenuto = true;
            }
            PregledZaradeCanvas.Visibility = Visibility.Visible;
            dpDatumPoc5.SelectedDate = DateTime.Today;
            dpDatumKraj5.SelectedDate = DateTime.Today;
            zaradaPoc();
        }

        private async void btnIzmjenaZaposlenih_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            btnIzmjenaZaposlenih.Style = (Style)FindResource("RoundedButtonStyle");
            if (!VecPokrenuto)
            {
                MovePocetniCanvas();
                await Task.Delay(1000);
                VecPokrenuto = true;
            }
            ZaposleniCanvas.Visibility = Visibility.Visible;
            radniciUTabeli = new List<radnik>();
            foreach(radnik r in listaRadnika)
            {
                if (r.aktivan!=0)
                    radniciUTabeli.Add(r);
            }
            ZaposleniTable.ItemsSource = radniciUTabeli;
            ZaposleniTable.Items.Refresh();
            cbAktivni.SelectedIndex = 0;
            cbZaposleni.SelectedIndex = 0;
        }

        private void MovePocetniCanvas()
        {
            TranslateTransform trans1 = new TranslateTransform();
            btnDodajRobu.RenderTransform = trans1;
            DoubleAnimation btn1X_anim = new DoubleAnimation(0, -90, TimeSpan.FromSeconds(1));
            DoubleAnimation btn1Y_anim = new DoubleAnimation(0, -190, TimeSpan.FromSeconds(1));
            trans1.BeginAnimation(TranslateTransform.XProperty, btn1X_anim);
            trans1.BeginAnimation(TranslateTransform.YProperty, btn1Y_anim);

            TranslateTransform trans2 = new TranslateTransform();
            btnIzmjeniBazu.RenderTransform = trans2;
            DoubleAnimation btn2X_anim = new DoubleAnimation(0, -510, TimeSpan.FromSeconds(1));
            DoubleAnimation btn2Y_anim = new DoubleAnimation(0, -105, TimeSpan.FromSeconds(1));
            trans2.BeginAnimation(TranslateTransform.XProperty, btn2X_anim);
            trans2.BeginAnimation(TranslateTransform.YProperty, btn2Y_anim);

            TranslateTransform trans3 = new TranslateTransform();
            btnPregledArt.RenderTransform = trans3;
            DoubleAnimation btn3X_anim = new DoubleAnimation(0, -90, TimeSpan.FromSeconds(1));
            DoubleAnimation btn3Y_anim = new DoubleAnimation(0, -120, TimeSpan.FromSeconds(1));
            trans3.BeginAnimation(TranslateTransform.XProperty, btn3X_anim);
            trans3.BeginAnimation(TranslateTransform.YProperty, btn3Y_anim);

            TranslateTransform trans4 = new TranslateTransform();
            btnPregledRacuna.RenderTransform = trans4;
            DoubleAnimation btn4X_anim = new DoubleAnimation(0, -510, TimeSpan.FromSeconds(1));
            DoubleAnimation btn4Y_anim = new DoubleAnimation(0, -35, TimeSpan.FromSeconds(1));
            trans4.BeginAnimation(TranslateTransform.XProperty, btn4X_anim);
            trans4.BeginAnimation(TranslateTransform.YProperty, btn4Y_anim);

            TranslateTransform trans5 = new TranslateTransform();
            btnPregledZarade.RenderTransform = trans5;
            DoubleAnimation btn5X_anim = new DoubleAnimation(0, -90, TimeSpan.FromSeconds(1));
            DoubleAnimation btn5Y_anim = new DoubleAnimation(0, -50, TimeSpan.FromSeconds(1));
            trans5.BeginAnimation(TranslateTransform.XProperty, btn5X_anim);
            trans5.BeginAnimation(TranslateTransform.YProperty, btn5Y_anim);

            TranslateTransform trans6 = new TranslateTransform();
            btnIzmjenaZaposlenih.RenderTransform = trans6;
            DoubleAnimation btn6X_anim = new DoubleAnimation(0, -510, TimeSpan.FromSeconds(1));
            DoubleAnimation btn6Y_anim = new DoubleAnimation(0, 35, TimeSpan.FromSeconds(1));
            trans6.BeginAnimation(TranslateTransform.XProperty, btn6X_anim);
            trans6.BeginAnimation(TranslateTransform.YProperty, btn6Y_anim);

            tbDobrodosli.Visibility = Visibility.Hidden;
            tbNazivApp.Visibility = Visibility.Visible;
        }


        public void ponistiDodajNovi()
        {
            nazivSlike = "";
            var uriSource = new Uri(@"C:\Users\Acer ES1\Desktop\FAKULTET\4 godina\InformacioniSistemi\Projekat\eFashion\FrontendApp\GuiPrvaVerzija\GuiPrvaVerzija\add.png", UriKind.Absolute);
            Slika.Source = new BitmapImage(uriSource);
            tbNaziv.Text = "";
            tbKolicina.Text = "";
            tbCijena.Text = "";
            tbVelicina.Text = "";
            cbxKategorija.SelectedIndex = -1;
        }

        public void ponistiIzmjenu()
        {
            nazivSlike = "";
            var uriSource = new Uri(@"C:\Users\Acer ES1\Desktop\FAKULTET\4 godina\InformacioniSistemi\Projekat\eFashion\FrontendApp\GuiPrvaVerzija\GuiPrvaVerzija\add.png", UriKind.Absolute);
            Slika2.Source = new BitmapImage(uriSource);
            tbNaziv2.Text = "";
            tbKolicina2.Text = "";
            tbCijena2.Text = "";
            tbVelicina2.Text = "";
            cbxKategorija2.SelectedIndex = -1;
            tbSifra2.Text = "";
        }

        public void zaradaPoc()
        {
            if (VecPokrenuto)
            {
                DateTime datumPoc = (DateTime)dpDatumPoc5.SelectedDate;
                DateTime datumKraj = (DateTime)dpDatumKraj5.SelectedDate;
                decimal zarada = 0;
                foreach (var r in listaRacuna)
                    if (DateTime.Compare(r.datum, datumPoc) >= 0 && DateTime.Compare(r.datum, datumKraj) <= 0)
                    {
                        zarada += r.ukupno;
                    }
                tbZarada.Text = zarada + " KM";
            }
        }

        //Canvas Dodaj novi artikal

        private void btnSacuvajNoviArtikal_Click(object sender, RoutedEventArgs e)
        {
            string naziv, velicina, kolicina, cijena;
            int indeksKategorije;
            bool ispravno = true;
            naziv = tbNaziv.Text;
            velicina = tbVelicina.Text;
            kolicina = tbKolicina.Text;
            cijena = tbCijena.Text;
            indeksKategorije = cbxKategorija.SelectedIndex;           
            if (naziv.Length==0 || velicina.Length==0 || kolicina.Length==0 || cijena.Length==0 || nazivSlike.Length==0 || indeksKategorije < 0)
            {
                MessageBox.Show("Unesite sve podatke o artiklu!");
            }
            else
            {
                int kolicinaInt=0;
                decimal cijenaDec=0;
                ispravno=int.TryParse(kolicina, out kolicinaInt);
                if (ispravno)
                    ispravno = decimal.TryParse(cijena, out cijenaDec);
                if (ispravno)
                {
                    artikal art = new artikal
                    {
                        naziv = naziv,
                        velicina = velicina,
                        kolicina = kolicinaInt,
                        cijena = cijenaDec,
                        kategorija = listaKategorija.Where(kategorija => kategorija.idkategorije == (indeksKategorije+1)).FirstOrDefault(),
                        slika = putanjaZaSlike + "\\" + nazivSlike
                    };
                    var t = Task.Run(() => Utilities.CreateArtikalAsync(art));
                    ponistiDodajNovi();
                    MessageBox.Show("Uspješno ste unijeli artikal u sistem");
                }
                else
                {
                    MessageBox.Show("Unos artikla u sistem nije uspio");
                }

            }

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
                openFileDialog.InitialDirectory = putanjaZaSlike;
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                Nullable<bool> result = openFileDialog.ShowDialog();

                if (result == true)
                {
                    filePath = openFileDialog.SafeFileName;
                    nazivSlike = filePath.ToString();
                    var uriSource = new Uri(putanjaZaSlike +"\\"+ filePath, UriKind.Absolute);
                    Slika.Source = new BitmapImage(uriSource);
                }
            }
        }



        //Izmjena baze artikala Canvas
        private void btnSifra2_Click(object sender, RoutedEventArgs e)
        {
            int sifra = int.Parse(tbSifra2.Text);

            //Pretraga po sifri i da se postavi vrijednost na mjesto koje treba da budu
            artikal a = listaArtikala.Where(artikal => artikal.sifra==sifra).FirstOrDefault();
            if (a == null)
            {
                MessageBox.Show("Ne postoji artikal sa tom sifrom!");
            }
            else
            {
                tbNaziv2.IsEnabled = true;
                tbNaziv2.Text = a.naziv;
                tbCijena2.IsEnabled = true;
                tbCijena2.Text = a.cijena.ToString();
                tbKolicina2.IsEnabled = true;
                tbKolicina2.Text = a.kolicina.ToString();
                tbVelicina2.IsEnabled = true;
                tbVelicina2.Text = a.velicina;
                cbxKategorija2.IsEnabled = true;
                int index = a.kategorija.idkategorije - 1;
                cbxKategorija2.SelectedIndex = index;
                btnSlika2.IsEnabled = true;
                var uriSource = new Uri(a.slika, UriKind.Absolute);
                Slika2.Source = new BitmapImage(uriSource);
                nazivSlike = a.slika;
                aZaIzmjenu = a;
            }



        }

        private void btnSlika2_Click(object sender, RoutedEventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var fileContent = string.Empty;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                openFileDialog.InitialDirectory = putanjaZaSlike;
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                Nullable<bool> result = openFileDialog.ShowDialog();

                if (result == true)
                {
                    filePath = openFileDialog.SafeFileName;
                    nazivSlike = filePath.ToString();
                    var uriSource = new Uri(putanjaZaSlike + "\\" + filePath, UriKind.Absolute);
                    Slika2.Source = new BitmapImage(uriSource);
                    nazivSlike = putanjaZaSlike + "\\" + nazivSlike;
                }
            }
        }

        private void btnSacuvajNoviArtikal2_Click(object sender, RoutedEventArgs e)
        {
            string naziv, velicina, kolicina, cijena;
            int indeksKategorije;
            bool ispravno = true;
            naziv = tbNaziv2.Text;
            velicina = tbVelicina2.Text;
            kolicina = tbKolicina2.Text;
            cijena = tbCijena2.Text;
            indeksKategorije = cbxKategorija2.SelectedIndex;
            if (naziv.Length == 0 || velicina.Length == 0 || kolicina.Length == 0 || cijena.Length == 0 || nazivSlike.Length == 0 || indeksKategorije < 0)
            {
                MessageBox.Show("Unesite sve podatke o artiklu!");
            }
            else
            {
                int kolicinaInt = 0;
                decimal cijenaDec = 0;
                ispravno = int.TryParse(kolicina, out kolicinaInt);
                if (ispravno)
                    ispravno = decimal.TryParse(cijena, out cijenaDec);
                if (ispravno)
                {

                    aZaIzmjenu.naziv = naziv;
                    aZaIzmjenu.velicina = velicina;
                    aZaIzmjenu.kolicina = kolicinaInt;
                    aZaIzmjenu.cijena = cijenaDec;
                    aZaIzmjenu.kategorija = listaKategorija.Where(kategorija => kategorija.idkategorije == (indeksKategorije + 1)).FirstOrDefault();
                    aZaIzmjenu.slika = nazivSlike;
                    
                    var t = Task.Run(() => Utilities.UpdateArtikalAsync(aZaIzmjenu));
                    ponistiIzmjenu();
                    MessageBox.Show("Uspješno ste izmjenili artikal u sistem");
                }
                else
                {
                    MessageBox.Show("Izmjena artikla u sistem nije uspjela");
                }

            }
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

        

        private void tbSifra4_KeyUp(object sender, KeyEventArgs e)
        {
            
            var filtrirani = listaRacuna.Where(racun => racun.idracuna == int.Parse(tbSifra4.Text));
            RacuniTabela4.ItemsSource = filtrirani;
            RacuniTabela4.Items.Refresh();
        }

        private void btnPogledajRacun4_Click(object sender, RoutedEventArgs e)
        {
            racun r = (racun)RacuniTabela4.SelectedItem;
            new PregledRacunaProzor(r).ShowDialog();
        }



        private void dpDatum4_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime datum4 = (DateTime)dpDatum4.SelectedDate;
            var filtrirani = listaRacuna.Where(racun => DateTime.Compare(racun.datum,datum4)==0);
            RacuniTabela4.ItemsSource = filtrirani;
            RacuniTabela4.Items.Refresh();
        }

        //Zarada

        private void dpDatum5_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VecPokrenuto)
            {
                DateTime datumPoc = (DateTime)dpDatumPoc5.SelectedDate;
                DateTime datumKraj = (DateTime)dpDatumKraj5.SelectedDate;
                decimal zarada = 0;
                foreach(var r in listaRacuna)
                    if(DateTime.Compare(r.datum,datumPoc)>=0 && DateTime.Compare(r.datum, datumKraj) <= 0)
                    {
                        zarada += r.ukupno;
                    }
                //naci zaradu izmedju ova dva datuma i staviti na ovaj tbZarada.Text=
                tbZarada.Text = zarada+" KM";
            }
        }

        //Canvas Zaposleni

        private void tbZaposleni_KeyUp(object sender, KeyEventArgs e)
        {
            
            var filtrirani = radniciUTabeli.Where(radnik => radnik.ime.ToLower().StartsWith(tbZaposleni.Text.ToLower()) || radnik.prezime.ToLower().StartsWith(tbZaposleni.Text.ToLower()) || radnik.username.ToLower().StartsWith(tbZaposleni.Text.ToLower()));
            ZaposleniTable.ItemsSource = filtrirani;
            ZaposleniTable.Items.Refresh();

        }

        private void cbSviItem_Selected(object sender, RoutedEventArgs e)
        {
            radniciUTabeli = new List<radnik>();
            int selectIndex = cbAktivni.SelectedIndex;
            foreach (radnik r in listaRadnika)
            {
                if (selectIndex == 0)
                {
                    if (r.aktivan!=0)
                        radniciUTabeli.Add(r);                   
                }
                else
                {
                    if (r.aktivan==0)
                        radniciUTabeli.Add(r);
                }
            }
            ZaposleniTable.ItemsSource = radniciUTabeli;
            ZaposleniTable.Items.Refresh();

        }
        private void cbRadniciItem_Selected(object sender, RoutedEventArgs e)
        {
            radniciUTabeli = new List<radnik>();         
            int selectIndex = cbAktivni.SelectedIndex;
            bool pronadjen = false;
            foreach (radnik r in listaRadnika)
            {
                pronadjen = false;
                foreach(administrator a in listaAdministratora)
                {
                    if (a.radnik.jmb.Equals(r.jmb))
                        pronadjen = true;
                }
                if (!pronadjen)
                {
                    if (selectIndex == 0)
                    {
                        if (r.aktivan!=0)
                            radniciUTabeli.Add(r);
                    }
                    else
                    {
                        if (r.aktivan==0)
                            radniciUTabeli.Add(r);
                    }
                }
            }
            ZaposleniTable.ItemsSource = radniciUTabeli;
            ZaposleniTable.Items.Refresh();

        }
        private void cbAdministratoriItem_Selected(object sender, RoutedEventArgs e)
        {
            radniciUTabeli = new List<radnik>();
            int selectIndex = cbAktivni.SelectedIndex;
            foreach (administrator r in listaAdministratora)
            {
                
                {
                    if (selectIndex == 0)
                    {
                        if (r.radnik.aktivan!=0)
                            radniciUTabeli.Add(r.radnik);
                    }
                    else
                    {
                        if (r.radnik.aktivan==0)
                            radniciUTabeli.Add(r.radnik);
                    }
                }
            }
            ZaposleniTable.ItemsSource = radniciUTabeli;
            ZaposleniTable.Items.Refresh();
        }
        private void cbTrenutnoItem_Selected(object sender, RoutedEventArgs e)
        {
            int selectIndex = cbZaposleni.SelectedIndex;
            radniciUTabeli = new List<radnik>();
            if (selectIndex == 0)
            {
                foreach (radnik r in listaRadnika)
                    if (r.aktivan!=0)
                        radniciUTabeli.Add(r);
            }else if (selectIndex == 1)
            {
                bool pronadjen = false;
                foreach(radnik r in listaRadnika)
                {
                    if (r.aktivan!=0)
                    {
                        pronadjen = false;
                        foreach (var a in listaAdministratora)
                            if (a.radnik.jmb.Equals(r.jmb))
                                pronadjen = true;
                        if (!pronadjen)
                            radniciUTabeli.Add(r);
                    }
                }
            }
            else
            {
                foreach (var a in listaAdministratora)
                    if (a.radnik.aktivan!=0)
                        radniciUTabeli.Add(a.radnik);
            }
            ZaposleniTable.ItemsSource = radniciUTabeli;
            ZaposleniTable.Items.Refresh();
        }
        private void cbBivsiItem_Selected(object sender, RoutedEventArgs e)
        {
            int selectIndex = cbZaposleni.SelectedIndex;
            radniciUTabeli = new List<radnik>();
            if (selectIndex == 0)
            {
                foreach (radnik r in listaRadnika)
                    if (r.aktivan==0)
                        radniciUTabeli.Add(r);
            }
            else if (selectIndex == 1)
            {
                bool pronadjen = false;
                foreach (radnik r in listaRadnika)
                {
                    if (r.aktivan==0)
                    {
                        pronadjen = false;
                        foreach (var a in listaAdministratora)
                            if (a.radnik.jmb.Equals(r.jmb))
                                pronadjen = true;
                        if (!pronadjen)
                            radniciUTabeli.Add(r);
                    }
                }
            }
            else
            {
                foreach (var a in listaAdministratora)
                    if (a.radnik.aktivan==0)
                        radniciUTabeli.Add(a.radnik);
            }
            ZaposleniTable.ItemsSource = radniciUTabeli;
            ZaposleniTable.Items.Refresh();
        }


        private void btnDodajRadnika_Click(object sender, RoutedEventArgs e)
        {
            new DodajAzurirajRadnikaProzor().ShowDialog();
        }
        private void btnAzurirajRadnika_Click(object sender, RoutedEventArgs e)
        {
            radnik r = (radnik)ZaposleniTable.SelectedItem;
            new DodajAzurirajRadnikaProzor(r).ShowDialog();
        }




    }
}
