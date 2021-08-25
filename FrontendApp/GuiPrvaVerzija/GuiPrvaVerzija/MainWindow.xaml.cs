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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;


namespace GuiPrvaVerzija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this, tbUsername);
            
        }

        static async Task Main(string []args)
        {
            var novi = new MainWindow();
            await Utilities.RunAsync();
        }
        
       




        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            new AdminastrorPocetniProzor().Show();
            var k = await Utilities.GetRacunAsync("http://localhost:9000/racuni/1");           
            k.ukupno = 30.00M;
            Console.WriteLine(k.ukupno);
            var t = await Utilities.UpdateRacunAsync(k);
            Console.WriteLine(t);
            this.Hide();
        }
    }
}
