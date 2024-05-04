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
            IdPost = idPost;
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
                btnConfirm.Visibility = Visibility.Visible;
                if (ApplicantDAO.Instance.IsComfirmApplyJob(idCV, idPost))
                {
                    btnConfirm_text.Text = "Hủy PV";
                    btnConfirm_bg.Background = new SolidColorBrush(Colors.Red);
                    btnViewPVDay.Visibility = Visibility.Visible;
                }
            }
            if (Emp.LogoPath != "")
            {
                string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, Emp.LogoPath);
                imgLogoCompany.Source = new BitmapImage(new Uri(imagePath));
            }
        }
        PostDTO Post;
        int IdPost;
        CV Cv;
        EmployerDTO Emp;
        private void btnViewCV_Click(object sender, RoutedEventArgs e)
        {
            WViewCV viewCV = new WViewCV(Cv.Id);
            viewCV.ShowDialog();
        }

        private void btnChat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(ApplicantDAO.Instance.IsComfirmApplyJob(Cv.Id,IdPost))
            {
                ApplicantDAO.Instance.UnConfirmApplyJob(Cv.Id, IdPost);
                btnConfirm_text.Text = "Xác nhận PV";
                btnConfirm_bg.Background = new SolidColorBrush(Colors.Green);
                PVDayDAO.Instance.UpdatePick(PVDayDAO.Instance.GetPickedByIdPostAndIdCV(IdPost, Cv.Id).Id, 0);
                btnViewPVDay.Visibility = Visibility.Collapsed;
            }
            else
            {
                UCChoseInterviewDay uCChoseInterviewDay = new UCChoseInterviewDay(IdPost, Cv.Id);
                if (uCChoseInterviewDay.ShowDialog() == true)
                {
                    ApplicantDAO.Instance.ConfirmApplyJob(Cv.Id, IdPost);
                    btnConfirm_text.Text = "Hủy PV";
                    btnConfirm_bg.Background = new SolidColorBrush(Colors.Red);
                    btnViewPVDay.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnViewPVDay_Click(object sender, RoutedEventArgs e)
        {
            WViewPVDay pVDay = new WViewPVDay(PVDayDAO.Instance.GetPickedByIdPostAndIdCV(IdPost, Cv.Id).Id);
            pVDay.Show();
        }
    }
}
