using AppXinViecWPF.DAO;
using AppXinViecWPF.DTO;
using AppXinViecWPF.View.Applicant;
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

namespace AppXinViecWPF.View.Employer
{
    /// <summary>
    /// Interaction logic for UCMiniCV.xaml
    /// </summary>
    public partial class UCMiniCV : UserControl
    {
        public UCMiniCV(int idPost,int idCV,DateTime date)
        {
            InitializeComponent();
            IdCV = idCV;
            IdPost = idPost;
            txtDateSubmit.Text = date.ToString("d");
            CV cv = CVDAO.Instance.GetCvById(idCV);
            PostDTO post = PostDAO.Instance.GetPostById(idPost);
            txtName.Text = cv.HoVaTen;
            txtNameJob.Text = post.NameJob;
            txtIdPost.Text = idPost.ToString();
            if (CVDAO.Instance.IsComfirm(IdCV, IdPost))
            {
                Icon_comfirm.Foreground = new SolidColorBrush(Colors.Green);
                txtStatus.Text = "Đã duyệt";
                txtStatus.Background = new SolidColorBrush(Colors.LightGreen);
            }
            if (CVDAO.Instance.IsFavCV(IdCV))
            {
                Icon_Fav.Icon = FontAwesome.Sharp.IconChar.HeartCircleCheck;
            }
        }
        int IdCV;
        int IdPost;
        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            WViewCV wViewCV = new WViewCV(IdCV);
            wViewCV.Show();
        }

        private void btnComfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!CVDAO.Instance.IsComfirm(IdCV, IdPost))
            {
                UCSetDayInterview uCSetDayInterview = new UCSetDayInterview(IdPost,IdCV);
                if(uCSetDayInterview.ShowDialog() == true)
                {
                    MessageBox.Show("Đã thêm lịch phỏng vấn");
                    CVDAO.Instance.Comfirm(IdCV, IdPost);
                    Icon_comfirm.Foreground = new SolidColorBrush(Colors.Green);
                    txtStatus.Text = "Đã duyệt";
                    txtStatus.Background = new SolidColorBrush(Colors.LightGreen);
                }
                else
                {
                    MessageBox.Show("Chưa thêm lịch phỏng vấn");
                }
            }
            else
            {
                if(MessageBox.Show("Bạn có muốn xóa lịch phỏng vấn","Cảnh báo",MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    PVDayDAO.Instance.DeletePVDayByIdPostAndIdCV(IdPost,IdCV);
                    CVDAO.Instance.UnComfirm(IdCV, IdPost);
                    ApplicantDAO.Instance.UnConfirmApplyJob(IdCV, IdPost);
                    Icon_comfirm.Foreground = new SolidColorBrush(Colors.Black);
                    txtStatus.Text = "Chưa duyệt";
                    txtStatus.Background = new SolidColorBrush(Colors.LightGray);
                }
            }
        }

        private void btnFav_Click(object sender, RoutedEventArgs e)
        {
            if (!CVDAO.Instance.IsFavCV(IdCV))
            {
                CVDAO.Instance.AddFavCV(IdCV);
                Icon_Fav.Icon = FontAwesome.Sharp.IconChar.HeartCircleCheck;
            }
            else
            {
                CVDAO.Instance.DeleteFavCV(IdCV);
                Icon_Fav.Icon = FontAwesome.Sharp.IconChar.Heart;
            }
        }
    }
}
