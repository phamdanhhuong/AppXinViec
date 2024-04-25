using AppXinViecWPF.DAO;
using AppXinViecWPF.DTO;
using AppXinViecWPF.View.Applicant;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for UCMiniPost.xaml
    /// </summary>
    public partial class UCMiniPost : UserControl
    {
        int idPost;
        PostDTO post;
        public UCMiniPost(int idPost)
        {
            InitializeComponent();
            IdPost = idPost;
            Post = PostDAO.Instance.GetPostById(IdPost);
            DataContext = post;
            txtExpireDate.Text = post.ExpireDate.ToString();
            if(post.Status == 0) 
            {
                txtStatus.Text = "Không tuyển dụng";
                btnPause_Icon.Icon = IconChar.Play;
                btnPause_Text.Text = "Tiếp tục tuyển dụng";
            }
        }

        public int IdPost { get => idPost; set => idPost = value; }
        internal PostDTO Post { get => post; set => post = value; }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            WJobInfo jobInfo = new WJobInfo(IdPost);
            jobInfo.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa bài viết","Cảnh báo",MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                PostDAO.Instance.DeletePostById(IdPost);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WCreateNewPost post = new WCreateNewPost(IdPost);
            post.ShowDialog();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if(post.Status == 1)
            {
                PostDAO.Instance.UpdateStatusPost(IdPost, 0);
                Post.Status = 0;
                txtStatus.Text = "Không tuyển dụng";
                btnPause_Icon.Icon = IconChar.Play;
                btnPause_Text.Text = "Tiếp tục tuyển dụng";
            }
            else
            {
                PostDAO.Instance.UpdateStatusPost(IdPost, 1);
                Post.Status = 1;
                txtStatus.Text = "Đang tuyển dụng";
                btnPause_Icon.Icon = IconChar.Pause;
                btnPause_Text.Text = "Ngưng tuyển dụng";
            }
        }
    }
}
