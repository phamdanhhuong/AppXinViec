using AppXinViecWPF.DAO;
using AppXinViecWPF.DTO;
using FontAwesome.Sharp;
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
    /// Interaction logic for UCJob.xaml
    /// </summary>
    public partial class UCJob : UserControl
    {
        int idPost;
        PostDTO post;
        EmployerDTO emp;
        public UCJob(int idPost)
        {
            InitializeComponent();
            IdPost = idPost;
            int[] ListPostFav=ApplicantDAO.Instance.GetAllFavIdJob();
            if (ListPostFav.Contains(idPost))
            {
                btnLike_Icon.Icon = IconChar.HeartCircleCheck;
            }
        }

        public int IdPost { get => idPost; set => idPost = value; }
        internal PostDTO Post { get => post; set => post = value; }
        internal EmployerDTO Emp { get => emp; set => emp = value; }

        private void btnViewJobs_Click(object sender, RoutedEventArgs e)
        {
            WJobInfo jobInfo = new WJobInfo(idPost);
            jobInfo.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Post = PostDAO.Instance.GetPostById(IdPost);
            Emp = EmployerDAO.Instance.GetInfoById(post.IdEmployer);
            txtNameJob.Text = post.NameJob;
            txtNameCompany.Text = emp.NameCompany;
            txtSalary.Text = post.Salary;
            txtLocation.Text = post.Location;
            if (Emp.LogoPath !="")
            {
                imgLogo.Source = new BitmapImage(new Uri(Emp.LogoPath));
            }
            if (GetExpDays().Days > 0) 
            {
                txtExpire.Text = "Còn " + GetExpDays().Days+ " ngày "+ GetExpDays().Hours+ " giờ " + "để ứng tuyển";
            }
            else
            {
                txtExpire.Text = "Hết hạn";
            }
        }
        private TimeSpan GetExpDays()
        {
            TimeSpan timeSpan = post.ExpireDate.Subtract(DateTime.Now);
            return timeSpan;
        }

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            //var btnLike_Icon = btnLike.Template.FindName("btnLike_Icon", btnLike) as IconImage;
            if (btnLike_Icon.Icon == IconChar.Heart)
            {
                ApplicantDAO.Instance.AddFavJob(IdPost);
                btnLike_Icon.Icon = IconChar.HeartCircleCheck;
            }
            else
            {
                ApplicantDAO.Instance.DeleteFavJob(IdPost);
                btnLike_Icon.Icon = IconChar.Heart;
            }
        }
        public void TriggerButton()
        {
            btnLike.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }
}
