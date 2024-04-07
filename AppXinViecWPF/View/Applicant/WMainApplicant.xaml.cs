using AppXinViecWPF.View.Employer;
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
            gridSearchJob.Height = new GridLength(0);
            gridMyCV.Height = new GridLength(0);
            gridCompany.Height = new GridLength(0);
            UCSearchJobs uCSearchJobs = new UCSearchJobs();
            //ccMain.Content = uCSearchJobs;
        }
        public static UCCreateCV uCCCV;
        public static UCManageCVs uCManageCVs;
        public static UCViewCV uCViewCV;
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
            UCAppliedJobs uCAppliedJobs = new UCAppliedJobs();
            ccMain.Content= uCAppliedJobs;
        }

        private void btnManegeCVs_Click(object sender, RoutedEventArgs e)
        {
            uCManageCVs = new UCManageCVs();
            uCManageCVs.btnCreate.Click += btnSampleCVs_Click;
            uCManageCVs.btnEdit.Click += Edit;
            uCManageCVs.btnView.Click += View;
            ccMain.Content= uCManageCVs;
        }

        public void Edit(object sender, RoutedEventArgs e)
        {
            uCCCV.btnSave.Click += btnManegeCVs_Click;
            ccMain.Content = uCCCV;
        }

        public void View(object sender, RoutedEventArgs e)
        {
            ccMain.Content = uCViewCV;
        }

        private void btnUploadCVs_Click(object sender, RoutedEventArgs e)
        {
            UCUploadCVs uCUploadCVs = new UCUploadCVs();
            ccMain.Content = uCUploadCVs;
        }

        private void btnSampleCVs_Click(object sender, RoutedEventArgs e)
        {
            UCCreateCV uCCreateCV = new UCCreateCV();
            uCCreateCV.btnSave.Click += btnManegeCVs_Click;
            uCCreateCV.btnClear.Click += btnSampleCVs_Click;
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
