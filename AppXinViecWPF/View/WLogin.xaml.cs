using AppXinViecWPF.DAO;
using AppXinViecWPF.View.Applicant;
using AppXinViecWPF.View.Employer;
using AppXinViecWPF.View.Register;
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

namespace AppXinViecWPF.View
{
    /// <summary>
    /// Interaction logic for WLogin.xaml
    /// </summary>
    public partial class WLogin : Window
    {
        public WLogin()
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
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (AccountDAO.Instance.Login(txtUser.Text, txtPass.Password))
            {
                if(AccountDAO.Instance.IsEmployer(txtUser.Text, txtPass.Password))
                {
                    WMainEmployer win = new WMainEmployer();
                    this.Hide();
                    win.ShowDialog();
                    this.Show();
                }
                else
                {
                    WMainApplicant win = new WMainApplicant();
                    this.Hide();
                    win.ShowDialog();
                    this.Show();
                }
                
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            WRegister wRegister = new WRegister();
            wRegister.ShowDialog();
        }
    }
}
