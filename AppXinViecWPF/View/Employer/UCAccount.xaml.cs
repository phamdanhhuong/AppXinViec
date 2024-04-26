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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppXinViecWPF.View.Employer
{
    /// <summary>
    /// Interaction logic for UCAccount.xaml
    /// </summary>
    public partial class UCAccount : System.Windows.Controls.UserControl
    {
        public UCAccount()
        {
            InitializeComponent();
            EmployerDTO employer = EmployerDAO.Instance.GetInfoById(AccountDAO.UserID);
            Employer = employer;
            DataContext = Employer;
            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, employer.LogoPath);
            imgAvatar.Source = new BitmapImage(new Uri(imagePath));
        }
        EmployerDTO Employer;
        private void btnChangeAvatar_Click(object sender, RoutedEventArgs e)
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
                Employer.LogoPath = targetPath;
                imgAvatar.Source = new BitmapImage(new Uri(open.FileName));
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            EmployerDAO.Instance.UpdateInfo(Employer);
            System.Windows.MessageBox.Show("Cập nhật thành công");
        }
    }
}
