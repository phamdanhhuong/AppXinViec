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
    /// Interaction logic for UCManageCV.xaml
    /// </summary>
    public partial class UCManageCV : UserControl
    {
        public UCManageCV()
        {
            InitializeComponent();
            List<ApplyCV> list = CVDAO.Instance.GetApplyCVByIdEmp(AccountDAO.UserID);
            List<int> listPost = new List<int>();
            foreach(ApplyCV cv in list) 
            {
                if (!listPost.Contains(cv.IdPost))
                {
                    listPost.Add(cv.IdPost);
                }
            }
            foreach (int i in listPost)
            {
                PostDTO p = PostDAO.Instance.GetPostById(i);
                TextBlock textBlock = new TextBlock();
                textBlock.Text = $"Hồ sơ nộp cho công việc {p.NameJob}";
                textBlock.FontWeight = FontWeights.Bold;
                textBlock.FontSize = 16;
                icMain.Items.Add(textBlock);
                foreach (ApplyCV cv in list)
                {
                    if(cv.IdPost == i)
                    {
                        icMain.Items.Add(new UCMiniCV(cv.IdPost, cv.IdCV, cv.SubmitDay));
                    }
                }
            }
        }

        private void txtStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(txtStatus.Text == "Đã duyệt")
            //{
            //    foreach (var item in icMain.Items)
            //    {
            //        if (item.GetType() == typeof(UCMiniCV))
            //        {
            //            var item_ = item as UCMiniCV;
            //            if(item_.txtStatus.Text == "Chưa duyệt")
            //            {
            //                item_.Visibility = Visibility.Collapsed;
            //            }
            //            else
            //            {
            //                item_.Visibility = Visibility.Visible;
            //            }
            //        }
            //    }
            //}
            //else if(txtStatus.Text == "Chưa duyệt")
            //{
            //    foreach (var item in icMain.Items)
            //    {
            //        if (item.GetType() == typeof(UCMiniCV))
            //        {
            //            var item_ = item as UCMiniCV;
            //            if (item_.txtStatus.Text == "Đã duyệt")
            //            {
            //                item_.Visibility = Visibility.Collapsed;
            //            }
            //            else
            //            {
            //                item_.Visibility = Visibility.Visible;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    UserControl_Loaded(sender, e);
            //}
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
