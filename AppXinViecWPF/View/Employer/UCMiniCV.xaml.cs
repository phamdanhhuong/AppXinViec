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
        }
        int IdCV;
        int IdPost;
    }
}
