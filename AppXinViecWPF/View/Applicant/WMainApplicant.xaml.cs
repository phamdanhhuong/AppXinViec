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
            pnlJobSearch.Visibility = Visibility.Collapsed;
            gridSearchJob.Height = new GridLength(0);
            gridMyCV.Height = new GridLength(0);
            gridCompany.Height = new GridLength(0);
            UCSearchJobs uCSearchJobs = new UCSearchJobs();
            //ccMain.Content = uCSearchJobs;
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

        private void btnSearchJobs_Click(object sender, RoutedEventArgs e)
        {
            if (pnlJobSearch.Visibility == Visibility.Visible)
            {
                pnlJobSearch.Visibility = Visibility.Collapsed;
                gridSearchJob.Height = new GridLength(0);
            }
            else
            {
                pnlJobSearch.Visibility = Visibility.Visible;
                gridSearchJob.Height = new GridLength(150);
            }
        }

        private void btnMyCV_Click(object sender, RoutedEventArgs e)
        {
            if (pnlMyCV.Visibility == Visibility.Visible)
            {
                pnlMyCV.Visibility = Visibility.Collapsed;
                gridMyCV.Height = new GridLength(0);
            }
            else
            {
                pnlMyCV.Visibility = Visibility.Visible;
                gridMyCV.Height = new GridLength(150);
            }
        }

        private void btnCompany_Click(object sender, RoutedEventArgs e)
        {
            if (pnlCompany.Visibility == Visibility.Visible)
            {
                pnlCompany.Visibility = Visibility.Collapsed;
                gridCompany.Height = new GridLength(0);
            }
            else
            {
                pnlCompany.Visibility = Visibility.Visible;
                gridCompany.Height = new GridLength(100);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSeachJobs_Click(object sender, RoutedEventArgs e)
        {
            UCSearchJobs uCSearchJobs = new UCSearchJobs();
            ccMain.Content = uCSearchJobs;
        }

        private void btnSavedJobs_Click(object sender, RoutedEventArgs e)
        {
            UCSavedJobs uCSavedJobs = new UCSavedJobs();
            ccMain.Content = uCSavedJobs;
        }

        private void btnAppliedJobs_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnManegeCVs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUploadCVs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSampleCVs_Click(object sender, RoutedEventArgs e)
        {
            UCCreateCV uCCreateCV = new UCCreateCV();
            ccMain.Content = uCCreateCV;
        }

        private void btnListCompany_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTopCompany_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
