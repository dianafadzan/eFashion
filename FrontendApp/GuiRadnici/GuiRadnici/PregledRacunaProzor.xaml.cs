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
    /// Interaction logic for PregledRacunaProzor.xaml
    /// </summary>
    public partial class PregledRacunaProzor : Window
    {
        List<stavka> nizStavki = new List<stavka>();
        racun rac;

        private async void inicijalizacija()
        {
            nizStavki = await Utilities.GetStavkeAsync("http://localhost:9000/stavke/" + rac.idracuna);
            RacunTable.ItemsSource = nizStavki;
            RacunTable.Items.Refresh();
        }
        public PregledRacunaProzor(racun r)
        {
            rac = r;
            InitializeComponent();
            inicijalizacija();
            tbSifra.Text = r.idracuna + "";
            tbIme.Text = r.radnik.ime + " " + r.radnik.prezime;
            tbDatum.Text = r.datum.ToString("dd MM yyyy");
            tbUkupno.Text = r.ukupno.ToString() + " KM";


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
        }
    }
}
