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

namespace AppXinViecWPF.View.Employer
{
    /// <summary>
    /// Interaction logic for WMainEmployer.xaml
    /// </summary>
    public partial class WMainEmployer : Window
    {
        public WMainEmployer()
        {
            InitializeComponent();
            UCNews uCNews = new UCNews();
            ccMain.Content = uCNews;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            UCNews uCNews = new UCNews();
            ccMain.Content = uCNews;
        }

        private void btnUserInfo_Click(object sender, RoutedEventArgs e)
        {
            UCAccount uCAccount = new UCAccount();  
            ccMain.Content = uCAccount;
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            UCManagePost uCManagePost   = new UCManagePost();
            ccMain.Content = uCManagePost;
        }

        private void btnCV_Click(object sender, RoutedEventArgs e)
        {
            UCManageCV uCManageCV = new UCManageCV();
            ccMain.Content= uCManageCV;
        }

        private void btnFavCV_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
