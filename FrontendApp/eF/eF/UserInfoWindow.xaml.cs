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
    /// Interaction logic for UserInfoWindow.xaml
    /// </summary>
    public partial class UserInfoWindow : Window
    {
        private Kupac kupac;
        private AfterLoginUserWindow window;
        public UserInfoWindow()
        {
            InitializeComponent();
        }
        public UserInfoWindow(Kupac k)
        {
            this.kupac = k;
            InitializeComponent();
            tbUsername.Text = k.getUsername();
            
        }
        public UserInfoWindow(Kupac k,AfterLoginUserWindow window)
        {
            this.window = window;
            this.kupac = k;
            InitializeComponent();
            tbUsername.Text = k.getUsername();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            AfterLoginUserWindow after = new AfterLoginUserWindow();
            after.Show();
            this.Hide();
           // window.Visibility = Visibility.Visible;
           
        }

       
    }
}
