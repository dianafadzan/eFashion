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
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {

        int X = 0;
        int Y = 0;

        public FirstWindow()
        {
            InitializeComponent();
            
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            Console.WriteLine("width:" + this.Width);
            Console.WriteLine("height:" + this.Height);
            List<string> kateogrije = new List<string>();

            kateogrije.Add("SHIRTS");
            kateogrije.Add("JEANS");
            kateogrije.Add("DRESSES");
            kateogrije.Add("SKIRTS");
            setCategories(kateogrije);
            setArticals();
          
        }

        private void refreshGrid()
        {
            gridSlike.Children.Clear();
            X = 0;
            Y = 0;


            
        }

        private Button setCatButton(string naziv)
        {
            Button btn = new Button();
            btn.Name = "btn_" + naziv;
            TextBlock tb = new TextBlock();
            tb.Text = naziv;
            tb.Style = FindResource("TextBlockCijenaStyle") as Style;
            btn.Style = FindResource("ButtonCategoryStyle") as Style;
            btn.Content = tb;
            btn.Click += new RoutedEventHandler(onbtnCategory);
            return btn;

            
        }

        private void onbtnCategory(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string name = btn.Name;
            string kategorija = (name.Split('_'))[1];
            Console.WriteLine("kategorija:" + kategorija);
            setCategoryArticals(kategorija);


        }

        private void setCategories(List<string> kategorije)
        {
            foreach(string k in kategorije)
            {
                Button btn = setCatButton(k);
                stackCat.Children.Add(btn);
            }

        }

        private Button setArtikalButton(Artikal a)
        {
            Button btn = new Button();
            btn.Name = "btn_" + a.getSifra();
            Image img = new Image();
            var fullPath =a.getPutanja();
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
                img.Style = FindResource("ImageStyle") as Style;
               
                stack.Children.Add(img);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            TextBlock tb1 = new TextBlock();
            tb1.Text =  a.getJedCijena()+"KM";
            tb1.Style = FindResource("TextBlockCijenaStyle") as Style;
          

            stack.Children.Add(tb1);

            btn.Style = FindResource("ButtonArticalStyle") as Style;

            btn.Content = stack;
            btn.Click += new RoutedEventHandler(onbtnItem);
            return btn;



           
        }

        private void onbtnItem(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void setCategoryArticals(string kategorija)
        {
            refreshGrid();
            List<Artikal> artikli = new List<Artikal>(); //lista artikala iz kategorije kategorija
            int i = 0;
            artikli.Add(new Artikal(i++, "xl", 83.65, "https://images-na.ssl-images-amazon.com/images/I/61k2GLjtgzL._AC_UY741_.jpg", "Suknje"));
            artikli.Add(new Artikal(i++, "m", 773.65, "https://images-na.ssl-images-amazon.com/images/I/61k2GLjtgzL._AC_UY741_.jpg", "Suknje"));

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

        private void setArticals()
        {
            refreshGrid();
            List<Artikal> artikli = new List<Artikal>();
            int i = 0;
            artikli.Add(new Artikal(i++,"s",23.65, "https://images-na.ssl-images-amazon.com/images/I/41zXnBshtIL.jpg","Majice"));
            artikli.Add(new Artikal(i++, "xl", 83.65, "https://images-na.ssl-images-amazon.com/images/I/61k2GLjtgzL._AC_UY741_.jpg", "Suknje"));
            artikli.Add(new Artikal(i++, "m", 773.65, "https://assetscdn1.paytm.com/images/catalog/product/A/AP/APPSTARS-AND-YOSTAR733385C6C48CA7/1593260979713_0..jpg?imwidth=320&impolicy=hq", "Suknje"));
            artikli.Add(new Artikal(i++, "l", 456.65, "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1585862572-boyis3005315d41_q1_2-0._QL90_UX336_.jpg?crop=1.00xw:0.847xh;0,0.102xh&resize=480:*", "Hlace"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://images-na.ssl-images-amazon.com/images/I/61MZHjcuKaL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "xl", 83.65, "https://m.media-amazon.com/images/I/71PJppEp2hL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "m", 773.65, "https://assets.myntassets.com/fl_progressive/h_960,q_80,w_720/v1/assets/images/9444937/2019/8/14/aec7d9db-5e28-4a7a-adaf-8e290d337aca1565785223227-Mast--Harbour-Women-Jeans-5391565785221493-1.jpg", "HALJINE"));
            artikli.Add(new Artikal(i++, "m", 125.65, "https://images-na.ssl-images-amazon.com/images/I/61ifPh2yf-L.jpg", "Hlace"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://images-na.ssl-images-amazon.com/images/I/41zXnBshtIL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "xl", 83.65, "https://images-na.ssl-images-amazon.com/images/I/61k2GLjtgzL._AC_UY741_.jpg", "Suknje"));
            artikli.Add(new Artikal(i++, "m", 773.65, "https://assetscdn1.paytm.com/images/catalog/product/A/AP/APPSTARS-AND-YOSTAR733385C6C48CA7/1593260979713_0..jpg?imwidth=320&impolicy=hq", "Suknje"));
            artikli.Add(new Artikal(i++, "l", 456.65, "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1585862572-boyis3005315d41_q1_2-0._QL90_UX336_.jpg?crop=1.00xw:0.847xh;0,0.102xh&resize=480:*", "Hlace"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://images-na.ssl-images-amazon.com/images/I/61MZHjcuKaL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "xl", 83.65, "https://m.media-amazon.com/images/I/71PJppEp2hL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "m", 773.65, "https://assets.myntassets.com/fl_progressive/h_960,q_80,w_720/v1/assets/images/9444937/2019/8/14/aec7d9db-5e28-4a7a-adaf-8e290d337aca1565785223227-Mast--Harbour-Women-Jeans-5391565785221493-1.jpg", "HALJINE"));
            artikli.Add(new Artikal(i++, "m", 125.65, "https://images-na.ssl-images-amazon.com/images/I/61ifPh2yf-L.jpg", "Hlace"));

            artikli.Add(new Artikal(i++, "s", 23.65, "https://images-na.ssl-images-amazon.com/images/I/41zXnBshtIL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "xl", 83.65, "https://images-na.ssl-images-amazon.com/images/I/61k2GLjtgzL._AC_UY741_.jpg", "Suknje"));
            artikli.Add(new Artikal(i++, "m", 773.65, "https://assetscdn1.paytm.com/images/catalog/product/A/AP/APPSTARS-AND-YOSTAR733385C6C48CA7/1593260979713_0..jpg?imwidth=320&impolicy=hq", "Suknje"));
            artikli.Add(new Artikal(i++, "l", 456.65, "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1585862572-boyis3005315d41_q1_2-0._QL90_UX336_.jpg?crop=1.00xw:0.847xh;0,0.102xh&resize=480:*", "Hlace"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://images-na.ssl-images-amazon.com/images/I/61MZHjcuKaL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "xl", 83.65, "https://m.media-amazon.com/images/I/71PJppEp2hL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "m", 773.65, "https://assets.myntassets.com/fl_progressive/h_960,q_80,w_720/v1/assets/images/9444937/2019/8/14/aec7d9db-5e28-4a7a-adaf-8e290d337aca1565785223227-Mast--Harbour-Women-Jeans-5391565785221493-1.jpg", "HALJINE"));
            artikli.Add(new Artikal(i++, "m", 125.65, "https://images-na.ssl-images-amazon.com/images/I/61ifPh2yf-L.jpg", "Hlace"));

            artikli.Add(new Artikal(i++, "s", 23.65, "https://images-na.ssl-images-amazon.com/images/I/41zXnBshtIL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "xl", 83.65, "https://images-na.ssl-images-amazon.com/images/I/61k2GLjtgzL._AC_UY741_.jpg", "Suknje"));
            artikli.Add(new Artikal(i++, "m", 773.65, "https://assetscdn1.paytm.com/images/catalog/product/A/AP/APPSTARS-AND-YOSTAR733385C6C48CA7/1593260979713_0..jpg?imwidth=320&impolicy=hq", "Suknje"));
            artikli.Add(new Artikal(i++, "l", 456.65, "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1585862572-boyis3005315d41_q1_2-0._QL90_UX336_.jpg?crop=1.00xw:0.847xh;0,0.102xh&resize=480:*", "Hlace"));
            artikli.Add(new Artikal(i++, "s", 23.65, "https://images-na.ssl-images-amazon.com/images/I/61MZHjcuKaL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "xl", 83.65, "https://m.media-amazon.com/images/I/71PJppEp2hL.jpg", "Majice"));
            artikli.Add(new Artikal(i++, "m", 773.65, "https://assets.myntassets.com/fl_progressive/h_960,q_80,w_720/v1/assets/images/9444937/2019/8/14/aec7d9db-5e28-4a7a-adaf-8e290d337aca1565785223227-Mast--Harbour-Women-Jeans-5391565785221493-1.jpg", "HALJINE"));
            artikli.Add(new Artikal(i++, "m", 125.65, "https://images-na.ssl-images-amazon.com/images/I/61ifPh2yf-L.jpg", "Hlace"));


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

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
