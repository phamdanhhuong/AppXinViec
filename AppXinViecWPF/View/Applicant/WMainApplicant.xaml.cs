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

namespace AppXinViecWPF.View.Applicant
{
    /// <summary>
    /// Interaction logic for WMainApplicant.xaml
    /// </summary>
    public partial class WMainApplicant : Window
    {
        public WMainApplicant()
        {
            InitializeComponent();
            UCSearchJobs uCSearchJobs = new UCSearchJobs();
            ccMain.Content = uCSearchJobs;
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTimViecLam_Click(object sender, RoutedEventArgs e)
        {
            UCSearchJobs uCSearchJobs = new UCSearchJobs();
            ccMain.Content = uCSearchJobs;
        }

        private void btnUploadCV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateCV_Click(object sender, RoutedEventArgs e)
        {
            UCCreateCV uCCreateCV = new UCCreateCV();
            ccMain.Content=uCCreateCV;
        }

        private void btnUserInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
