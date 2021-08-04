using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for KorpaWindow.xaml
    /// </summary>
    public partial class KorpaWindow : Window
    {
        int X = 0;
        int Y = 0;
        private Narudzba narudzba;
        double ukupno = 0;
        public KorpaWindow()
        {
            InitializeComponent();
            setGrid2();
            DataContext = new ComboBoxViewModel();
        }
        public KorpaWindow(Narudzba narudzba)
        {
            this.narudzba = narudzba;
            InitializeComponent();
            DataContext = new ComboBoxViewModel();
            setGrid2();
        }

        private void refreshGrid()
        {
            gridStavke.Children.Clear();
            ukupno = 0;
        }

        private void setGrid2()
        {
            refreshGrid();

            X = 0;
            Y = 0;
            for (int i = 0; i < narudzba.getStavke().Count; i++)
            {
                gridStavke.RowDefinitions.Add(new RowDefinition());
            }
            foreach(Stavka s in narudzba.getStavke())
            {
                Y = 0;
                var path = s.getArtikal().getPutanja();
                Image img = new Image();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path, UriKind.Absolute);
                bitmap.EndInit();

                img.Source = bitmap;
                img.Style = FindResource("ImageStavkaStyle") as Style;

                StackPanel stack2 = new StackPanel();
                stack2.Orientation = Orientation.Vertical;
                stack2.Width = 150;

                TextBlock textBlock = new TextBlock();
                 Console.WriteLine("naziv:" + s.getArtikal().getNaziv());
                 textBlock.Text = s.getArtikal().getNaziv();
                 textBlock.Style = FindResource("TextBlockStavkaStyle") as Style;
                 stack2.Children.Add(textBlock);

                 TextBlock textBlock1 = new TextBlock();
                 textBlock1.Text = s.getArtikal().getSifra().ToString();
                 textBlock1.Style = FindResource("TextBlockStavkaStyle") as Style;
                 stack2.Children.Add(textBlock1);


                 TextBlock textBlock2 = new TextBlock();
                 textBlock2.Text = s.getArtikal().getVelicina();
                 textBlock2.Style = FindResource("TextBlockStavkaStyle") as Style;
                 stack2.Children.Add(textBlock2);
                 
                
                ComboBox comboBox = new ComboBox();
                comboBox.Style = FindResource("ComboBoxStavkaStyle") as Style;
                Binding binding = new Binding();
                binding.Source = ComboBoxViewModel.kolicina;
                comboBox.SetBinding(ComboBox.ItemsSourceProperty, binding);
                comboBox.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);
                comboBox.SelectedItem = s.getKol();
                comboBox.Name = "cb_" + s.getArtikal().getSifra()+"_" + s.getArtikal().getVelicina();
                Console.WriteLine("imee:" + comboBox.Name);


                TextBlock textBlock4 = new TextBlock();
                var cijena1 = s.getArtikal().getJedCijena();
                textBlock4.Text = cijena1.ToString();
                textBlock4.Style = FindResource("TextBlockCijenaStyle3") as Style;

                TextBlock textBlock3 = new TextBlock();
                var cijena = s.getArtikal().getJedCijena() * s.getKol();
                ukupno += cijena;
                textBlock3.Text = cijena.ToString();
                textBlock3.Style = FindResource("TextBlockCijenaStyle3") as Style;

                Button btn = new Button();
                 Image img2 = new Image();
                BitmapImage bitmap2 = new BitmapImage();
                bitmap2.BeginInit();
                bitmap2.UriSource = new Uri("pack://application:,,,/images/1398919_close_cross_incorrect_invalid_x_icon.png");

                bitmap2.EndInit();

                img2.Source = bitmap2;
                img2.Width=32;
                img2.Height = 32;

                btn.Content = img2;
                btn.Style = FindResource("ButtonXStyle") as Style;
                btn.Click+=new RoutedEventHandler(ClickOnX);
                btn.Name = "btn_" + narudzba.getiD() + "_" + s.getArtikal().getSifra() + "_" + s.getArtikal().getVelicina();

                


                Grid.SetColumn(img, Y++);
                Grid.SetRow(img, X);
                gridStavke.Children.Add(img);

                Grid.SetColumn(stack2, Y++);
                Grid.SetRow(stack2, X);
                gridStavke.Children.Add(stack2);

                Grid.SetColumn(comboBox, Y++);
                Grid.SetRow(comboBox, X);
                gridStavke.Children.Add(comboBox);

                Grid.SetColumn(textBlock4, Y++);
                Grid.SetRow(textBlock4, X);
                gridStavke.Children.Add(textBlock4);


                Grid.SetColumn(textBlock3, Y++);
                Grid.SetRow(textBlock3, X);
                gridStavke.Children.Add(textBlock3);

                Grid.SetColumn(btn, Y++);
                Grid.SetRow(btn, X);
                gridStavke.Children.Add(btn);
                X++;




            }
            tbUkupno.Text = ukupno + "KM";
        }


        private void setGrid()
        {
            X = 0;
            Y = 0;

            for(int i = 0; i < narudzba.getStavke().Count; i++)
            {
                gridStavke.RowDefinitions.Add(new RowDefinition());
            }

            foreach(Stavka s in narudzba.getStavke())
            {              
              
               
                StackPanel stack = new StackPanel();
                stack.Name = "btn_" + s.getArtikal().getSifra() + "_" + s.getArtikal().getVelicina();
                stack.Orientation = Orientation.Horizontal;
                stack.Width = 790;
                stack.Height = 106;
                var path = s.getArtikal().getPutanja();
                Image img = new Image();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path, UriKind.Absolute);
                bitmap.EndInit();

                img.Source = bitmap;
                img.Style = FindResource("ImageStavkaStyle") as Style;

                stack.Children.Add(img);

                StackPanel stack2 = new StackPanel();
                stack2.Orientation = Orientation.Vertical;
                TextBlock textBlock = new TextBlock();
                textBlock.Text = s.getArtikal().getNaziv();
                textBlock.Style = FindResource("TextBlockStavkaStyle") as Style;
                stack2.Children.Add(textBlock);

                TextBlock textBlock1 = new TextBlock();
                textBlock.Text = s.getArtikal().getSifra().ToString();
                textBlock.Style = FindResource("TextBlockStavkaStyle") as Style;
                stack2.Children.Add(textBlock1);
                TextBlock textBlock2 = new TextBlock();
                textBlock.Text = s.getArtikal().getVelicina();
                textBlock.Style = FindResource("TextBlockStavkaStyle") as Style;
                stack2.Children.Add(textBlock2);

                stack.Children.Add(stack2);
                

                ComboBox comboBox = new ComboBox();
                comboBox.Style = FindResource("ComboBoxStavkaStyle") as Style;
                Binding binding = new Binding();
                binding.Source = ComboBoxViewModel.kolicina;
                comboBox.SetBinding(ComboBox.ItemsSourceProperty, binding);
                comboBox.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);
                

                stack.Children.Add(comboBox);

                TextBlock textBlock3 = new TextBlock();
                var cijena = s.getArtikal().getJedCijena() * s.getKol();
                textBlock.Text = cijena.ToString();
                textBlock.Style = FindResource("TextBlockCijenaStyle3") as Style;
                stack.Children.Add(textBlock3);

               
                Grid.SetColumn(stack, Y);
                Grid.SetRow(stack, X);
                gridStavke.Children.Add(stack);
                X++;
                Y++;


            }

        }

        private void ClickOnStavka(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClickOnX(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var name = (btn.Name).Split('_');
            var idNarudzbe = name[1];
            var sifraArt = name[2];
            var velArt = name[3];
            Console.WriteLine("id narudzbe:" + idNarudzbe);
            Console.WriteLine("sifra art:"+sifraArt);
            Console.WriteLine("vel art:"+velArt);
            //ukloniti taj artikal iz te narudzbe
            for(int i=0;i<narudzba.getStavke().Count;i++)
            {
                Stavka s = narudzba.getStavke().ElementAt(i);
                if(s.getArtikal().getSifra() == int.Parse(sifraArt) && s.getArtikal().getVelicina().Equals(velArt))
                {
                    narudzba.getStavke().Remove(s);
                }
            }
            setGrid2();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            AfterLoginUserWindow after = new AfterLoginUserWindow();
            after.Show();
            this.Hide();
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            var name = (comboBox.Name).Split('_');
            Console.WriteLine("ime:" + name[0]);
            if (name.Length > 1)
            {
                var sifraArt = name[1];
                var vel = name[2];

                var item = comboBox.SelectedItem;
                Console.WriteLine(item);
                for (int i = 0; i < narudzba.getStavke().Count; i++)
                {
                    Stavka s = narudzba.getStavke().ElementAt(i);
                    if (s.getArtikal().getSifra() == int.Parse(sifraArt) && s.getArtikal().getVelicina().Equals(vel))
                    {
                        s.setKol(int.Parse(item.ToString()));
                        setGrid2();
                    }
                }
            }
            
        }

        private void BtnZavrsiKupovinu_Click(object sender, RoutedEventArgs e)
        {
            narudzba.setUkupno(ukupno);
            KupacInfoWindow kupacInfoWindow = new KupacInfoWindow(narudzba);
            kupacInfoWindow.Show();
            this.Hide();


        }
    }
}
