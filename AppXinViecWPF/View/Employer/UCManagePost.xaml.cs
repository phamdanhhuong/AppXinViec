using AppXinViecWPF.DAO;
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

        private void btnNewPost_Click(object sender, RoutedEventArgs e)
        {
            WCreateNewPost wCreateNewPost = new WCreateNewPost();
            wCreateNewPost.ShowDialog();
            UserControl_Loaded(sender, e);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            icMain.Items.Clear();
            int[] IdPosts = PostDAO.Instance.GetAllIdPostById(AccountDAO.UserID);
            foreach (int IdPost in IdPosts)
            {
                icMain.Items.Add(new UCMiniPost(IdPost));
            }
        }
    }
}
