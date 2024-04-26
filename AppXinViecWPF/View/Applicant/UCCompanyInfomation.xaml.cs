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
    /// Interaction logic for UCCompanyInfomation.xaml
    /// </summary>
    public partial class UCCompanyInfomation : Window
    {
        public UCCompanyInfomation(int id)
        {
            InitializeComponent();
            Id=id;
            Emp = EmployerDAO.Instance.GetInfoById(id);
            DataContext = Emp;
            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, Emp.LogoPath);
            imgLogoCompany.Source = new BitmapImage(new Uri(imagePath));
            ListPost = PostDAO.Instance.GetAllIdPostById(id);
            icMain.Items.Clear();
            foreach (int idpost in ListPost)
            {
                icMain.Items.Add(new UCJob(idpost));
            }
        }

        int[] listPost;
        int id;
        EmployerDTO emp;

        public int[] ListPost { get => listPost; set => listPost = value; }
        public int Id { get => id; set => id = value; }
        internal EmployerDTO Emp { get => emp; set => emp = value; }

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

    }
}
