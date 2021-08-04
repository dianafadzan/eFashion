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

namespace eF
{
    /// <summary>
    /// Interaction logic for KupacInfoWindow.xaml
    /// </summary>
    public partial class KupacInfoWindow : Window
    {
        private Narudzba narudzba;
        public KupacInfoWindow()
        {
            InitializeComponent();
            DataContext = new ComboBoxViewModel();
        }

        public KupacInfoWindow(Narudzba narudzba)
        {
            this.narudzba = narudzba;
            InitializeComponent();
            DataContext = new ComboBoxViewModel();
            tbUkupno.Text = narudzba.getUkupno().ToString();
        }

        private void CbPb_Selected(object sender, RoutedEventArgs e)
        {
            List<Mjesto> mjesta = new List<Mjesto>();
            mjesta.Add(new Mjesto(78000, "Banja Luka"));
            mjesta.Add(new Mjesto(74000, "Doboj"));

            ComboBox cb = sender as ComboBox;
            var sel = cb.SelectedItem;
            foreach(Mjesto m in mjesta)
            {
                if(m.getPostanskiBroj()== int.Parse(sel.ToString()))
                {
                    tbGrad.Text = m.getNaziv();
                }
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            KorpaWindow korpa = new KorpaWindow(narudzba);
            korpa.Show();
            this.Hide();

        }

        private void CbPb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Mjesto> mjesta = new List<Mjesto>();
            mjesta.Add(new Mjesto(78000, "Banja Luka"));
            mjesta.Add(new Mjesto(74000, "Doboj"));

            ComboBox cb = sender as ComboBox;
            var sel = cb.SelectedItem;
            foreach (Mjesto m in mjesta)
            {
                if (m.getPostanskiBroj() == int.Parse(sel.ToString()))
                {
                    tbGrad.Text = m.getNaziv();
                }
            }

        }
    }
}
