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
    /// Interaction logic for AfterLoginUserWindow.xaml
    /// </summary>
    public partial class AfterLoginUserWindow : Window
    {
        int X = 0;
        int Y = 0;
        private Kupac kupac;
        private List<Artikal> artikli = new List<Artikal>();
        private List<string> kategorije = new List<string>();
        public AfterLoginUserWindow()
        {
           
            InitializeComponent();
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            dodajArtikleUListu();
            dodajKategorijeUListy();
            dodajKategorije(kategorije);
            setArticals(artikli);


        }
        public AfterLoginUserWindow(Kupac kupac)
        {
            this.kupac = kupac;
            InitializeComponent();
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            dodajArtikleUListu();
            dodajKategorijeUListy();
            dodajKategorije(kategorije);
            setArticals(artikli);


        }

        private void refreshGrid()
        {
            X = 0;
            Y = 0;
            gridSlike.Children.Clear();
        }

        private void dodajKategorijeUListy()
        {
            kategorije.Add("MAJICE");
            kategorije.Add("HALJINE");
            kategorije.Add("SORCEVI");
            kategorije.Add("HLACE");
            kategorije.Add("JAKNE");
            kategorije.Add("KOSULJE");

        }

        private void dodajArtikleUListu()
        {
            int i = 0;
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/0/f/c/1/0fc1ac76eaf2c04fee3cfbc2d427cc48e4a3d284_cms7024_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/0/f/c/1/0fc1ac76eaf2c04fee3cfbc2d427cc48e4a3d284_cms7024_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/0/f/c/1/0fc1ac76eaf2c04fee3cfbc2d427cc48e4a3d284_cms7024_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/0/f/c/1/0fc1ac76eaf2c04fee3cfbc2d427cc48e4a3d284_cms7024_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Majice"));

        }

        private Button btnKat(string naziv)
        {
            Button btn = new Button();
            btn.Name = "btn_" + naziv;
            TextBlock tb = new TextBlock();
            tb.Text = naziv;
            tb.Style = FindResource("TextBlockCijenaStyle2") as Style;
            btn.Style = FindResource("ButtonCategoryStyle2") as Style;
            btn.Content = tb;
            btn.Click += new RoutedEventHandler(onbtnCategory);
            return btn;
        }
        private Button setArtikalButton(Artikal a)
        {
            Button btn = new Button();
            btn.Name = "btn_" + a.getSifra();
            Image img = new Image();
            var fullPath = a.getPutanja();
            Console.WriteLine("putanja:" + fullPath);
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Vertical;
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullPath, UriKind.Absolute);
                bitmap.EndInit();

                img.Source = bitmap;
                img.Style = FindResource("ImageStyle2") as Style;

                stack.Children.Add(img);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            TextBlock tb1 = new TextBlock();
            tb1.Text = a.getJedCijena() + "KM";
            tb1.Style = FindResource("TextBlockCijenaStyle2") as Style;


            stack.Children.Add(tb1);

            btn.Style = FindResource("ButtonArticalStyle2") as Style;

            btn.Content = stack;
            btn.Click += new RoutedEventHandler(onbtnArtikal);
            return btn;




        }

        private void setCategoryArticals(string kategorija)
        {
            refreshGrid();
            List<Artikal> artikli = new List<Artikal>(); //lista artikala iz kategorije kategorija
            int i = 0;
            artikli.Add(new Artikal(i++, "xl", 83.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Suknje"));
            artikli.Add(new Artikal(i++, "m", 773.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Suknje"));

            for (int j = 0; j < artikli.Count / 7 + 1; j++)
            {
                gridSlike.RowDefinitions.Add(new RowDefinition());
                //gridSlike.RowDefinitions[j].Height = new GridLength(00);
            }
            foreach (Artikal a in artikli)
            {
                Button artBtn = setArtikalButton(a);
                if (Y == 7)
                {
                    Y = 0;
                    X++;
                }
                Grid.SetColumn(artBtn, Y);
                Grid.SetRow(artBtn, X);
                gridSlike.Children.Add(artBtn);
                Y++;
            }
        }
        private void onbtnArtikal(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var sifraArt = (btn.Name.Split('_'))[1];
            foreach(Artikal a in artikli)
            {
                if (a.getSifra() == int.Parse(sifraArt))
                {
                    ArtikalWindow artikalWindow = new ArtikalWindow(a);
                    artikalWindow.Show();
                    this.Hide();
                    return;
                }
            }
            
        }

        private void onbtnCategory(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var katName = (btn.Name.Split('_'))[1];
            setCategoryArticals(katName);

        }

        private void dodajKategorije(List<string> kategorije)
        {
            foreach(string s in kategorije)
            {
                Button kat = btnKat(s);
                stackCat.Children.Add(kat);
            }
        }

        private void setArticals(List<Artikal> artikli)
        {
            refreshGrid();
            
            
            for (int j = 0; j < artikli.Count / 7 + 1; j++)
            {
                gridSlike.RowDefinitions.Add(new RowDefinition());
                //gridSlike.RowDefinitions[j].Height = new GridLength(00);
            }
            foreach (Artikal a in artikli)
            {
                Button artBtn = setArtikalButton(a);
                if (Y == 7)
                {
                    Y = 0;
                    X++;
                }
                Grid.SetColumn(artBtn, Y);
                Grid.SetRow(artBtn, X);
                gridSlike.Children.Add(artBtn);
                Y++;
            }
        }


        private void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            if (cbUser.IsDropDownOpen == true)
            {
                cbUser.IsDropDownOpen = false;
            }else
            cbUser.IsDropDownOpen = true;
           /* Kupac k = new Kupac("k1", "", "", "", "", "", "");
            UserInfoWindow user = new UserInfoWindow(k);
            user.Show();
            this.Hide();*/
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPretraga_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            tbPretraga.Visibility = Visibility.Visible;
            FocusManager.SetFocusedElement(this, tbPretraga);

        }

        private void TbPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Console.WriteLine("upisano :" + tbPretraga.Text);
                string pretraga = tbPretraga.Text;
                //izlistati sve artikle iz pretrage
                List<Artikal> artikals = new List<Artikal>();
                artikals.Add(new Artikal(1, "s", 23.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Majice"));
                setArticals(artikals);
                tbPretraga.Text = "";
                tbPretraga.Visibility = Visibility.Hidden;
                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(tbPretraga), null);
                // Kill keyboard focus
                Keyboard.ClearFocus();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            AfterLoginUserWindow afterLoginUserWindow = new AfterLoginUserWindow();
            afterLoginUserWindow.Show();
            this.Hide();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void CbProfil_Selected(object sender, RoutedEventArgs e)
        {
            Kupac k = new Kupac("k1", "", "", "", "", "", "");
            this.Visibility = Visibility.Hidden;
            UserInfoWindow user = new UserInfoWindow(k,this);
            
            user.Show();
            
            
        }

        private void CbOdjava_Selected(object sender, RoutedEventArgs e)
        {
            FirstWindow first = new FirstWindow();
            first.Show();
            this.Hide();
        }

        private void BtnKorpa_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            Stavka s = new Stavka(new Artikal(i++, "xl", 83.65, "https://cdn-img.prettylittlething.com/1/e/7/d/1e7d822faee2458dd406525241878ef74b0c39f3_cmr2989_1.jpg?imwidth=400", "Suknje"), 5);
            Stavka s1 = new Stavka(new Artikal(i++, "xl", 83.65, "https://cdn-img.prettylittlething.com/b/c/a/3/bca3d37490e5f431644eeb1531d3c711d70fd644_cmc0348_1.jpg?imwidth=1024", "Suknje"), 5);
            List<Stavka> stavke = new List<Stavka>();
            stavke.Add(s);
            stavke.Add(s1);
            Narudzba narudzba = new Narudzba(stavke, 1);
            KorpaWindow korpaWindow = new KorpaWindow(narudzba);
            korpaWindow.Show();
            this.Hide();
        }
    }
}
