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

namespace AppXinViecWPF.View.Applicant
{
    /// <summary>
    /// Interaction logic for WJobInfo.xaml
    /// </summary>
    public partial class WJobInfo : Window
    {
        int idPost;
        PostDTO post;
        EmployerDTO emp;
        public int IdPost { get => idPost; set => idPost = value; }
        internal PostDTO Post { get => post; set => post = value; }
        internal EmployerDTO Emp { get => emp; set => emp = value; }

        public WJobInfo(int idPost)
        {
            InitializeComponent();
            IdPost = idPost;
            post = PostDAO.Instance.GetPostById(idPost);
            DataContext = post;
            Emp = EmployerDAO.Instance.GetInfoById(post.IdEmployer);
            txtExpireDate.Text = post.ExpireDate.ToString();
            txtHumanScale.Text = Emp.HumanScale;
            txtNameFirm.Text = Emp.NameCompany;
            if (AccountDAO.Instance.IsEmployerById(AccountDAO.UserID))
            {
                btnApply.Visibility = Visibility.Collapsed;
                btnSavePost.Visibility = Visibility.Collapsed;
            }
            int[] list = ApplicantDAO.Instance.GetAllFavIdJob();
            if(list.Contains(idPost))
            {
                btnApply.Click -= btnApply_Click;
                btnApply.Click += btnApply_2_Click;
            }
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

        private void btnCompanyDetail_Click(object sender, RoutedEventArgs e)
        {
            UCCompanyInfomation uCCompanyInfomation = new UCCompanyInfomation(post.IdEmployer);
            uCCompanyInfomation.ShowDialog();
        }

        private void txtNameJob_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            WChoseCV wChoseCV = new WChoseCV(IdPost); 
            wChoseCV.Show();
        }
        private void btnApply_2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn đã apply công việc này rồi");
        }
    }
}
