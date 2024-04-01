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
    /// Interaction logic for WCreateNewPost.xaml
    /// </summary>
    public partial class WCreateNewPost : Window
    {
        public WCreateNewPost()
        {
            InitializeComponent();
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

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            TextRange desciption = new TextRange(rtxtDescription.Document.ContentStart, rtxtDescription.Document.ContentEnd);
            TextRange require = new TextRange(rtxtRequire.Document.ContentStart, rtxtRequire.Document.ContentEnd);
            TextRange interest = new TextRange(rtxtInterest.Document.ContentStart, rtxtInterest.Document.ContentEnd);
            TextRange skill = new TextRange(rtxtSkill.Document.ContentStart, rtxtSkill.Document.ContentEnd);
            PostDTO post = new PostDTO(txtNameJob.Text,desciption.Text,require.Text,interest.Text,txtAddress.Text,cboSalary.Text,cboLocation.Text,cboExp.Text,cboPosition.Text,txtQuantity.Text,cboWorkMode.Text,cboGender.Text,txtCareer.Text,skill.Text,dpExpireDate.SelectedDate.Value);
            PostDAO.Instance.CreatePost(post);
            MessageBox.Show("Đăng bài thành công");
            this.Close();
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameJob.Text))
            {
                tbPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                tbPlaceHolder.Visibility = Visibility.Hidden;
            }
        }
    }
}
