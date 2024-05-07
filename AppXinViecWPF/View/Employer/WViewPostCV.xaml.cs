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
    /// Interaction logic for WViewPostCV.xaml
    /// </summary>
    public partial class WViewPostCV : Window
    {
        public WViewPostCV(int id)
        {
            InitializeComponent();
            PostCV=PostCVDAO.Instance.getPostCVById(id);
            Cv = CVDAO.Instance.GetCvById(PostCV.IdCV);
            txtName.Text = Cv.HoVaTen;
            txtPublicDate.Text = PostCV.PublicDate.ToString("d");
            txtTitle.Text = PostCV.Title;
            txtContent.Text = PostCV.Content;
            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, Cv.Avatar);
            imgAvatar.Source = new BitmapImage(new Uri(imagePath));
        }
        PostCV PostCV;
        CV Cv;
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnViewCV_Click(object sender, RoutedEventArgs e)
        {
            WViewCV wViewCV = new WViewCV(Cv.Id);
            wViewCV.ShowDialog();
        }
    }
}
