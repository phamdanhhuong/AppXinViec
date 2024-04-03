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
    /// Interaction logic for UCManagePost.xaml
    /// </summary>
    public partial class UCManagePost : UserControl
    {
        public UCManagePost()
        {
            InitializeComponent();
        }
        int[] idPosts;

        public int[] IdPosts { get => idPosts; set => idPosts = value; }

        private void btnNewPost_Click(object sender, RoutedEventArgs e)
        {
            WCreateNewPost wCreateNewPost = new WCreateNewPost();
            wCreateNewPost.ShowDialog();
            UserControl_Loaded(sender, e);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            icMain.Items.Clear();
            IdPosts = PostDAO.Instance.GetAllIdPostById(AccountDAO.UserID);
            foreach (int IdPost in IdPosts)
            {
                UCMiniPost p = new UCMiniPost(IdPost);
                p.btnDelete.Click += UserControl_Loaded;
                icMain.Items.Add(p);
            }
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            icMain.Items.Clear();
            foreach (int IdPost in IdPosts)
            {
                icMain.Items.Add(new UCMiniPost(IdPost));
            }
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            List<int> search = new List<int>();
            foreach (int IdPost in IdPosts)
            {
                PostDTO Post = PostDAO.Instance.GetPostById(IdPost);
                if (Post.Status == 1)
                {
                    search.Add(IdPost);
                }
            }
            icMain.Items.Clear();
            foreach (int IdPost in search)
            {
                icMain.Items.Add(new UCMiniPost(IdPost));
            }
        }

        private void btnExpire_Click(object sender, RoutedEventArgs e)
        {
            List<int> search = new List<int>();
            foreach (int IdPost in IdPosts)
            {
                PostDTO Post = PostDAO.Instance.GetPostById(IdPost);
                if (Post.ExpireDate < DateTime.Now)
                {
                    search.Add(IdPost);
                }
            }
            icMain.Items.Clear();
            foreach (int IdPost in search)
            {
                icMain.Items.Add(new UCMiniPost(IdPost));
            }
        }

        private void btnNotDisplay_Click(object sender, RoutedEventArgs e)
        {
            List<int> search = new List<int>();
            foreach (int IdPost in IdPosts)
            {
                PostDTO Post = PostDAO.Instance.GetPostById(IdPost);
                if (Post.Status != 1)
                {
                    search.Add(IdPost);
                }
            }
            icMain.Items.Clear();
            foreach (int IdPost in search)
            {
                icMain.Items.Add(new UCMiniPost(IdPost));
            }
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            IdPosts = PostDAO.Instance.SearchPostByName(txtSearch.Text);
            icMain.Items.Clear();
            foreach (int IdPost in IdPosts)
            {
                icMain.Items.Add(new UCMiniPost(IdPost));
            }
        }
    }
}
