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
    /// Interaction logic for ArtikalWindow.xaml
    /// </summary>
    public partial class ArtikalWindow : Window
    {
        private Artikal artikal;
        public ArtikalWindow()
        {
            InitializeComponent();
        }
        public ArtikalWindow(Artikal a)
        {
            this.artikal = a;
            InitializeComponent();
            DataContext = new ComboBoxViewModel();
            postaviSliku();
            tbCijena.Text = a.getJedCijena() + "KM";
            tbsifra.Text = a.getSifra()+"";
            

        }

        private void postaviSliku()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(artikal.getPutanja(), UriKind.Absolute);
            bitmap.EndInit();

            img.Source = bitmap;
           

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            AfterLoginUserWindow afterLoginUserWindow = new AfterLoginUserWindow();
            afterLoginUserWindow.Show();
            this.Hide();
        }
    }
}
