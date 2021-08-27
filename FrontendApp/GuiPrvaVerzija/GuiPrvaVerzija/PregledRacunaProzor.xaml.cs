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
    /// Interaction logic for PregledRacunaProzor.xaml
    /// </summary>
    public partial class PregledRacunaProzor : Window
    {
        public PregledRacunaProzor(racun r)
        {
            InitializeComponent();
            tbSifra.Text = r.idracuna+"";
            tbIme.Text=r.radnik.ime+" "+r.radnik.prezime;
            tbDatum.Text = r.datum.ToString("dd MM yyyy");
            tbUkupno.Text = r.ukupno.ToString()+" KM";

            /*
            RacunTable.ItemsSource = racun.niz;
            RacunTable.Items.Refresh();
            */
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
        }
    }
}
