using AppXinViecWPF.DAO;
using AppXinViecWPF.DTO;
using AppXinViecWPF.View.Applicant;
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
            txtExpireDate.Text = post.ExpireDate.ToString();
            txtIdPost.Text = post.IdPost.ToString();
            txtNameJob.Text = post.NameJob.ToString();
            if(post.Status == 0) 
            {
                txtStatus.Text = "Không hiển thị";
            }
        }

        public int IdPost { get => idPost; set => idPost = value; }
        internal PostDTO Post { get => post; set => post = value; }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            WJobInfo jobInfo = new WJobInfo(IdPost);
            jobInfo.ShowDialog();
        }
    }
}
