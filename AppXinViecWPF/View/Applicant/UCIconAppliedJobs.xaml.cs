using AppXinViecWPF.DAO;
using AppXinViecWPF.DTO;
using AppXinViecWPF.View.Employer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppXinViecWPF.View.Applicant
{
    /// <summary>
    /// Interaction logic for UCIconAppliedJobs.xaml
    /// </summary>
    public partial class UCIconAppliedJobs : UserControl
    {
        public UCIconAppliedJobs(int idCV,int idPost,DateTime submitDay,int comfirm)
        {
            InitializeComponent();
            Post = PostDAO.Instance.GetPostById(idPost);
            Cv = CVDAO.Instance.GetCvById(idCV);
            Emp = EmployerDAO.Instance.GetInfoById(Post.IdEmployer);
            txtNameJob.Text = Post.NameJob;
            txtSalary.Text = Post.Salary;
            txtNameCV.Text = Cv.TenCV;
            txtNameEmp.Text = Emp.NameCompany;
            txtSubmitDay.Text = submitDay.ToString("d");
            if (comfirm == 1)
            {
                txtStatus.Text = "Hồ sơ đã được duyệt";
                txtStatus.Background = new SolidColorBrush(Colors.LightGreen);
            }
            if (Emp.LogoPath != "")
            {
                imgLogoCompany.Source = new BitmapImage(new Uri(Emp.LogoPath));
            }
        }
        PostDTO Post;
        CV Cv;
        EmployerDTO Emp;
        private void btnViewCV_Click(object sender, RoutedEventArgs e)
        {
            WViewCV viewCV = new WViewCV(Cv.Id);
            viewCV.Show();
        }

        private void btnChat_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
