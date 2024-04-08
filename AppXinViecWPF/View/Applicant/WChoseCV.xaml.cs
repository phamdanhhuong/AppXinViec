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
    /// Interaction logic for WChoseCV.xaml
    /// </summary>
    public partial class WChoseCV : Window
    {
        public WChoseCV(int idpost)
        {
            InitializeComponent();
            IdPost = idpost;
            PostDTO post = PostDAO.Instance.GetPostById(idpost);
            txtNameJob.Text=post.NameJob;
            int[] ids = CVDAO.Instance.GetAllIdCvById(AccountDAO.UserID);
            foreach (int id in ids)
            {
                RadioButton a = new RadioButton();
                a.VerticalAlignment = VerticalAlignment.Center;
                a.Content = new UCrbtnCV(id);
                a.Checked += RadioButton_Checked;
                icCV.Items.Add(a);
            }
        }

        int IdCV=-1;
        int IdPost;

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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            UCrbtnCV ucrbtnCV = radioButton.Content as UCrbtnCV;
            IdCV = ucrbtnCV.IdCV;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (IdCV != -1)
            {
                CVDAO.Instance.ApplyCV(IdCV, IdPost);
                MessageBox.Show("Apply thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cv ứng tuyển");
            }
        }
    }
}
