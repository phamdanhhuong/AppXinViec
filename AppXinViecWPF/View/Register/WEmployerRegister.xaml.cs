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
                string selectedImagePath = open.FileName;
                string targetDirectory = "Image";
                string targetPath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(selectedImagePath));
                string projectDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string destinationPath = System.IO.Path.Combine(projectDirectory, targetPath);
                System.IO.File.Copy(selectedImagePath, destinationPath, true);
                Certificate = targetPath;
                imgCertificate.Source = new BitmapImage(new Uri(open.FileName));
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account(txtUser.Text, txtPass.Password, txtEmail.Text,1);
            if ((txtPass.Password == txtPassAgain.Password) && account.NotNull())
            {
                AccountDAO.Instance.CreateAccount(account);
                EmployerDTO employer = new EmployerDTO(txtName.Text, cboGender.Text, txtPhone.Text, txtPosition.Text, txtNameCompany.Text, txtAddress.Text, txtWebsite.Text, txtIdTax.Text, txtHotline.Text, txtEmailCompany.Text, cboScale.Text, certificate, logo);
                if (employer.NotNull())
                {
                    EmployerDAO.Instance.Add(employer);
                    System.Windows.MessageBox.Show("Đăng ký thành công");
                    this.Close();
                }
            }
        }

        private void btnLogo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files|*.bmp;*.png;*.jpg";
            open.FilterIndex = 1;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedImagePath = open.FileName;
                string targetDirectory = "Image";
                string targetPath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(selectedImagePath));
                string projectDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string destinationPath = System.IO.Path.Combine(projectDirectory, targetPath);
                System.IO.File.Copy(selectedImagePath, destinationPath, true);
                Logo = targetPath;
                imgLogo.Source = new BitmapImage(new Uri(open.FileName));
            }
        }
    }
}
