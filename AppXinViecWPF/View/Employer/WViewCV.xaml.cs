using AppXinViecWPF.DAO;
using AppXinViecWPF.DTO;
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
    /// Interaction logic for WViewCV.xaml
    /// </summary>
    public partial class WViewCV : Window
    {
        public WViewCV(int id)
        {
            InitializeComponent();
            Cv = CVDAO.Instance.GetCvById(id);
            DataContext = Cv;
            txtBirth.Text = Cv.NgaySinh.Date.ToString("d");
            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, Cv.Avatar);
            imgAvatar.Source = new BitmapImage(new Uri(imagePath));
        }

        CV cv;
        internal CV Cv { get => cv; set => cv = value; }
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
    }
}
