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
        public PregledRacunaProzor()
        {
            InitializeComponent();
            /*racun racun = new Racun(7);
            tbSifra.Text = racun.id;
            tbIme.Text = racun.id;
            tbDatum.Text = racun.id;
            double ukupno = 0.0;
            foreach(var stavka in racun.niz)
            {
                ukupno += (stavka.kolicina * stavka.cijena);
            }
            tbUkupno.Text = ukupno.ToString()+" KM";
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
