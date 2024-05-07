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
    /// Interaction logic for UCIconPostedCV.xaml
    /// </summary>
    public partial class UCIconPostedCV : UserControl
    {
        public UCIconPostedCV(int idpostcv)
        {
            InitializeComponent();
            Idpostcv = idpostcv;
        }
        PostCV PostCV;
        int Idpostcv;
        private ItemsControl FindParentItemControl(FrameworkElement element)
        {
            var parent = VisualTreeHelper.GetParent(element);
            while (parent != null && !(parent is ItemsControl))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as ItemsControl;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WUpdatePostCV wUpdate = new WUpdatePostCV(PostCV.Id);
            wUpdate.ShowDialog();
            UserControl_Loaded(sender, e);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            WViewPostCV wView = new WViewPostCV(PostCV.Id);
            wView.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa bài đăng này không?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                PostCVDAO.Instance.deletePostCVById(PostCV.Id);
                ItemsControl itemsControl = FindParentItemControl(this);
                itemsControl.Items.Remove(this);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PostCV = PostCVDAO.Instance.getPostCVById(Idpostcv);
            DataContext = PostCV;
            txtCreatDay.Text = PostCV.PublicDate.ToString("d");
        }
    }
}
