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

namespace GuiRadnici
{
    /// <summary>
    /// Interaction logic for RadnikPocetniProzor.xaml
    /// </summary>
    public partial class RadnikPocetniProzor : Window
    {
        List<stavka> nizStavki = new List<stavka>();

        radnik radnikPravi;

        List<racun> listaRacuna = new List<racun>();
        List<kategorija> listaKategorija = new List<kategorija>();
        List<radnik> listaRadnika = new List<radnik>();
        List<administrator> listaAdministratora = new List<administrator>();
        List<artikal> listaArtikala = new List<artikal>();
        List<artikal> artikliURacunu;

        racun racunTest;

        private async void inicijalizacija()
        {
            listaRacuna = await Utilities.GetRacuniAsync("http://localhost:9000/racuni");
            listaKategorija = await Utilities.GetKategorijeAsync("http://localhost:9000/kategorije");
            listaRadnika = await Utilities.GetRadniciAsync("http://localhost:9000/radnici");
            listaAdministratora = await Utilities.GetAdministratoriAsync("http://localhost:9000/administratori");
            listaArtikala = await Utilities.GetArtikliAsync("http://localhost:9000/artikli");

        }

        public RadnikPocetniProzor(radnik r)
        {
            InitializeComponent();
            inicijalizacija();
            radnikPravi = r;
            HideAllCanvas();


        }

        private void HideAllCanvas()
        {
            IzdavanjeRacunaCanvas.Visibility = Visibility.Hidden;
            PregledRacunaCanvas.Visibility = Visibility.Hidden;
            PregledSkladistaCanvas.Visibility = Visibility.Hidden;
            ReklamacijaRacunaCanvas.Visibility = Visibility.Hidden;

        }

        private void btnIzdajRacun_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            IzdavanjeRacunaCanvas.Visibility = Visibility.Visible;
            artikliURacunu = new List<artikal>();
            ArtikliTabela.ItemsSource = listaArtikala;
            ArtikliTabela.Items.Refresh();
            RacunTabela.ItemsSource = artikliURacunu;
            RacunTabela.Items.Refresh();
        }

        private void btnReklamacija_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            ReklamacijaRacunaCanvas.Visibility = Visibility.Visible;
            artikliURacunu = new List<artikal>();
            RacunTabela2.ItemsSource = artikliURacunu;
            RacunTabela2.Items.Refresh();
            NoviRacunTabela.ItemsSource = artikliURacunu;
            NoviRacunTabela.Items.Refresh();

        }

        private void btnPregledSkladista_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            PregledSkladistaCanvas.Visibility = Visibility.Visible;
            tbUputstvo.Visibility = Visibility.Hidden;
            tbArtikal3.Visibility = Visibility.Hidden;
            cbKategorija3.Visibility = Visibility.Hidden;
            cbKategorija3.Items.Clear();
            cbKategorija3.Items.Add("Svi");
            foreach (kategorija k in listaKategorija)
                cbKategorija3.Items.Add(k.naziv);

        }

        private void btnPregledRacuna_Click(object sender, RoutedEventArgs e)
        {
            HideAllCanvas();
            PregledRacunaCanvas.Visibility = Visibility.Visible;
        }

        private void btnPregledZarade_Click(object sender, RoutedEventArgs e)
        {
            var filtrirani = listaRacuna.Where(racun => DateTime.Compare(racun.datum, DateTime.Today) == 0);
            decimal ukupno = 0;
            foreach (racun r in filtrirani)
                ukupno += r.ukupno;
            MessageBox.Show("Današnja zarada iznosi " + ukupno + " KM!");
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



        //Kreiranje novog racuna

        private void tbArtikal_KeyUp(object sender, KeyEventArgs e)
        {
            var filtrirani = listaArtikala.Where(artikal => artikal.naziv.ToLower().StartsWith(tbArtikal.Text.ToLower()));
            ArtikliTabela.ItemsSource = filtrirani;
            ArtikliTabela.Items.Refresh();

        }

        private void ArtikliTabela_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                int index = ArtikliTabela.SelectedIndex;
                if (index < ArtikliTabela.Items.Count-1)
                    index -= 1;
                ArtikliTabela.SelectedIndex = index;
                artikal art = (artikal)ArtikliTabela.SelectedItem;
                art.kolicina = 1;
                artikliURacunu.Add(art);
                RacunTabela.ItemsSource = artikliURacunu;
                RacunTabela.Items.Refresh();
                decimal ukupno = 0;
                foreach (artikal a in RacunTabela.Items)
                    ukupno += (a.kolicina * a.cijena);
                tbUkupno.Text = ukupno + " KM ";
            }
        }

        private async void  RacunTabela_KeyUp(object sender, KeyEventArgs e)
        {
            decimal ukupno = 0;
            if (e.Key == Key.Enter)
            {
                foreach (artikal a in RacunTabela.Items)
                    ukupno += (a.kolicina * a.cijena);
                tbUkupno.Text = ukupno + " KM";
            }
            List<artikal> lista = await Utilities.GetArtikliAsync("http://localhost:9000/artikli");
            ArtikliTabela.ItemsSource = lista;
            ArtikliTabela.Items.Refresh();
        }

        private void btnObrisiStavku_Click(object sender, RoutedEventArgs e)
        {
            artikal art = (artikal)RacunTabela.SelectedItem;
            artikliURacunu.Remove(art);
            RacunTabela.ItemsSource = artikliURacunu;
            RacunTabela.Items.Refresh();
            decimal ukupno = 0;
            foreach (artikal a in RacunTabela.Items)
                ukupno += (a.kolicina * a.cijena);
            tbUkupno.Text = ukupno + " KM";

        }

        private void btnOdbaciRacun_Click(object sender, RoutedEventArgs e)
        {
            artikliURacunu.Clear();
            RacunTabela.ItemsSource = artikliURacunu;
            RacunTabela.Items.Refresh();
            decimal ukupno = 0;
            foreach (artikal a in RacunTabela.Items)
                ukupno += (a.kolicina * a.cijena);
            tbUkupno.Text = ukupno + " KM";
        }

        private async void btnStampajRacun_Click(object sender, RoutedEventArgs e)
        {
            decimal ukupno = 0;
            bool validno = true;
            List<artikal> listaArtikala1 = await Utilities.GetArtikliAsync("http://localhost:9000/artikli");
            foreach (artikal a in RacunTabela.Items)
            {
                artikal pom = listaArtikala1.Where(artikal => artikal.sifra == a.sifra).FirstOrDefault();
                if (pom.kolicina < a.kolicina)
                    validno = false;
                ukupno += (a.kolicina * a.cijena);
            }
            if (validno)
            {
                racun r = new racun
                {
                    idracuna = 0,
                    datum = DateTime.Now,
                    radnik = radnikPravi,
                    ukupno = ukupno

                };
                var t = Task.Run(() => Utilities.CreateRacunAsync(r));
                int idRacuna = 7;
                r.idracuna = idRacuna;
                racunTest = r;
                var rac1 = await Utilities.GetRacuniAsync("http://localhost:9000/racuni");
                var rac2 = rac1.Last();

                foreach (artikal a in RacunTabela.Items)
                {
                    stavka s = new stavka
                    {
                        cijena = a.cijena,
                        kolicina = a.kolicina,
                        racun = rac2,
                        artikal = a,
                        racunIdracuna = rac2.idracuna,
                        artikalSifra = a.sifra
                    };
                    var t2 = Task.Run(() => Utilities.CreateStavkaAsync(s));
                }
                artikliURacunu.Clear();
                RacunTabela.ItemsSource = artikliURacunu;
                RacunTabela.Items.Refresh();
                ukupno = 0;
                tbUkupno.Text = ukupno + " KM";
                listaArtikala = await Utilities.GetArtikliAsync("http://localhost:9000/artikli");
                ArtikliTabela.ItemsSource = listaArtikala;
                ArtikliTabela.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nije moguće štampati račun jer nema dovoljno artikala u skladištu");
            }
            artikliURacunu.Clear();
            RacunTabela.ItemsSource = artikliURacunu;
            RacunTabela.Items.Refresh();
            ukupno = 0;
            tbUkupno.Text = ukupno + " KM";


        }

        //Reklamacija Racuna 

        private void btnOdbaciRacun2_Click(object sender, RoutedEventArgs e)
        {
            artikliURacunu.Clear();
            RacunTabela2.ItemsSource = artikliURacunu;
            RacunTabela2.Items.Refresh();
            NoviRacunTabela.ItemsSource = artikliURacunu;
            NoviRacunTabela.Items.Refresh();
            tbUkupno2.Text = "0.0 KM";
        }

        private void btnStampajRacun2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RacunTabela2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int index = RacunTabela2.SelectedIndex;
                if (index < RacunTabela2.Items.Count - 1)
                    index -= 1;
                RacunTabela2.SelectedIndex = index;
                stavka s= (stavka)RacunTabela2.SelectedItem;
                artikal a = s.artikal;
                a.kolicina = 0 - a.kolicina;
                artikliURacunu.Add(a);
                NoviRacunTabela.ItemsSource = artikliURacunu;
                NoviRacunTabela.Items.Refresh();
                decimal ukupno = 0;
                foreach (artikal art in NoviRacunTabela.Items)
                    ukupno += (art.kolicina * art.cijena);
                tbUkupno2.Text = ukupno + " KM";
            }
        }

        private async void btnSifra2_Click(object sender, RoutedEventArgs e)
        {
            racunTest = listaRacuna.Where(racun => racun.idracuna == int.Parse(tbSifra2.Text)).FirstOrDefault();
            List<stavka> lista = await Utilities.GetStavkeAsync("http://localhost:9000/stavke/" + racunTest.idracuna);
            RacunTabela2.ItemsSource = lista;
            RacunTabela2.Items.Refresh();
        }

        private async void NoviRacunTabela_KeyUp(object sender, KeyEventArgs e)
        {
            decimal ukupno = 0;
            if (e.Key == Key.Enter)
            {
                foreach (artikal a in NoviRacunTabela.Items)
                    ukupno += (a.kolicina * a.cijena);
                tbUkupno2.Text = ukupno + " KM";
            }
            List<stavka> lista = await Utilities.GetStavkeAsync("http://localhost:9000/stavke/" + racunTest.idracuna);
            RacunTabela2.ItemsSource = lista;
            RacunTabela2.Items.Refresh();
        }

        //Pregled skladista

        private void tbArtikal3_KeyUp(object sender, KeyEventArgs e)
        {
            string sifra = tbArtikal3.Text;
            int sifraInt;
            if (int.TryParse(sifra, out sifraInt))
            {
                var filtrirani = listaArtikala.Where(artikal => artikal.sifra.ToString().StartsWith(sifra));
                ArtikliTabela3.ItemsSource = filtrirani;
                ArtikliTabela3.Items.Refresh();

            }
        }

        private void ComboBoxItem_Selected_Kategorija(object sender, RoutedEventArgs e)
        {
            tbUputstvo.Visibility = Visibility.Visible;
            tbUputstvo.Text = "Izaberite kategoriju";
            cbKategorija3.Visibility = Visibility.Visible;
            tbArtikal3.Visibility = Visibility.Hidden;
            ArtikliTabela3.ItemsSource = listaArtikala;
            ArtikliTabela3.Items.Refresh();
            cbKategorija3.SelectedIndex = 0;

        }

        private void ComboBoxItem_Selected_Sifra(object sender, RoutedEventArgs e)
        {
            tbUputstvo.Visibility = Visibility.Visible;
            tbUputstvo.Text = "Izaberite šifru";
            cbKategorija3.Visibility = Visibility.Hidden;
            tbArtikal3.Visibility = Visibility.Visible;
            ArtikliTabela3.ItemsSource = listaArtikala;
            ArtikliTabela3.Items.Refresh();
            tbArtikal3.Text = "";
        }

        private void cbKategorija3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idKategorije = cbKategorija3.SelectedIndex;
            if (idKategorije != 0)
            {
                var filtrirani = listaArtikala.Where(artikal => artikal.kategorija.idkategorije == idKategorije);
                ArtikliTabela3.ItemsSource = filtrirani;
                ArtikliTabela3.Items.Refresh();
            }

        }


        //pregled racuna
        private async void ComboBoxItem_Selected_Datum2(object sender, RoutedEventArgs e)
        {
            tbUputstvo2.Text = "Izaberite datum računa";
            dpDatum4.Visibility = Visibility.Visible;
            tbSifra4.Visibility = Visibility.Hidden;
            listaRacuna = await Utilities.GetRacuniAsync("http://localhost:9000/racuni");
            RacuniTabela4.ItemsSource = listaRacuna;
            RacuniTabela4.Items.Refresh();
            dpDatum4.SelectedDate = DateTime.Today;


        }

        private async void ComboBoxItem_Selected_Sifra2(object sender, RoutedEventArgs e)
        {
            tbUputstvo2.Text = "Unesite šifru računa";
            dpDatum4.Visibility = Visibility.Hidden;
            tbSifra4.Visibility = Visibility.Visible;
            listaRacuna = await Utilities.GetRacuniAsync("http://localhost:9000/racuni");
            RacuniTabela4.ItemsSource = listaRacuna;
            RacuniTabela4.Items.Refresh();
        }

        private void tbSifra4_KeyUp(object sender, KeyEventArgs e)
        {

            var filtrirani = listaRacuna.Where(racun => racun.idracuna.ToString().ToLower().StartsWith(tbSifra4.Text));
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
            var filtrirani = listaRacuna.Where(racun => DateTime.Compare(racun.datum, datum4) == 0);
            RacuniTabela4.ItemsSource = filtrirani;
            RacuniTabela4.Items.Refresh();
        }

        
    }

}
