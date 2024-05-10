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

namespace AppXinViecWPF.View.Applicant
{
    /// <summary>
    /// Interaction logic for UCManagePostCV.xaml
    /// </summary>
    public partial class UCManagePostCV : UserControl
    {
        public UCManagePostCV()
        {
            InitializeComponent();
        }
        List<PostCV> postCVs;
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            WCreatePost wCreatePost = new WCreatePost();
            wCreatePost.ShowDialog();
            UserControl_Loaded(sender, e);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listPost.Items.Clear();
            postCVs = PostCVDAO.Instance.getAllPostCVByUserId();
            foreach (PostCV postCV in postCVs)
            {
                UCIconPostedCV ucIconPostedCV = new UCIconPostedCV(postCV.Id);
                listPost.Items.Add(ucIconPostedCV);
            }
        }
    }
}
