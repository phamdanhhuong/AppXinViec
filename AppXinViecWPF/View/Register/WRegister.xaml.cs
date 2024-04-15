using AppXinViecWPF.DAO;
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
using AppXinViecWPF.DTO;

namespace AppXinViecWPF.View.Register
{
    /// <summary>
    /// Interaction logic for WRegister.xaml
    /// </summary>
    public partial class WRegister : Window
    {
        public WRegister()
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

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account(txtUser.Text,txtPass.Password,txtEmail.Text,0);
            if ((txtPass.Password == txtPassAgain.Password) && account.NotNull())
            {
                ApplicantDTO applicant = new ApplicantDTO(txtName.Text, cboGender.Text, txtPhone.Text, dpBirth.SelectedDate.Value);
                if (applicant.NotNull())
                {
                    AccountDAO.Instance.CreateAccount(account);
                    ApplicantDAO.Instance.Add(applicant);
                    MessageBox.Show("Đăng ký thành công");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("không để trống username và nhập đúng mật khẩu nhập lại");
            }
        }

        private void btnEmployerRegister_Click(object sender, RoutedEventArgs e)
        {
            WEmployerRegister wEmployerRegister = new WEmployerRegister();
            this.Hide();
            wEmployerRegister.ShowDialog();
            this.Show();
        }
    }
}
