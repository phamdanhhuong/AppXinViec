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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppXinViecWPF.View.Register
{
    /// <summary>
    /// Interaction logic for WEmployerRegister.xaml
    /// </summary>
    public partial class WEmployerRegister : Window
    {
        public WEmployerRegister()
        {
            InitializeComponent();
        }
        string logo;
        string certificate;

        public string Logo { get => logo; set => logo = value; }
        public string Certificate { get => certificate; set => certificate = value; }

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

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnImgCertificate_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files|*.bmp;*.png;*.jpg";
            open.FilterIndex = 1;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgCertificate.Source = new BitmapImage(new Uri(open.FileName));
                Certificate = open.FileName;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(txtPass.Password==txtPassAgain.Password)
            {
                AccountDAO.Instance.CreateAccount(txtUser.Text, txtPass.Password, 1);
                EmployerDTO employer = new EmployerDTO(txtName.Text,cboGender.Text,txtPhone.Text,txtPosition.Text,txtNameCompany.Text,txtAddress.Text,txtWebsite.Text,txtIdTax.Text,txtHotline.Text,txtEmailCompany.Text,cboScale.Text,certificate,logo);
                EmployerDAO.Instance.Add(employer);
                System.Windows.MessageBox.Show("Đăng ký thành công");
                this.Close();
            }
        }

        private void btnLogo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files|*.bmp;*.png;*.jpg";
            open.FilterIndex = 1;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgLogo.Source = new BitmapImage(new Uri(open.FileName));
                Logo = open.FileName;
            }
        }
    }
}
