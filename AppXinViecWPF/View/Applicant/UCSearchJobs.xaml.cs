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

namespace AppXinViecWPF.View.Applicant
{
    /// <summary>
    /// Interaction logic for UCSearchJobs.xaml
    /// </summary>
    public partial class UCSearchJobs : UserControl
    {
        int[] listPost;

        public int[] ListPost { get => listPost; set => listPost = value; }

        public UCSearchJobs()
        {
            InitializeComponent();
            ListPost = PostDAO.Instance.GetAllIdNotPause();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            menuJobs.Items.Clear();
            foreach (int id in ListPost)
            {
                menuJobs.Items.Add(new UCJob(id));
            }
            txtNumberSearch.Text = ListPost.Length.ToString();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string khuVuc = cboSearchLocation.Text;
            string luong = cboSalarySearch.Text;
            string kinhNghiem = cboExperienceSearch.Text;
            string tenCongViec = txtNameJob.Text;
            if (string.IsNullOrWhiteSpace(tenCongViec) && string.IsNullOrEmpty(khuVuc) && string.IsNullOrEmpty(luong) && string.IsNullOrEmpty(kinhNghiem))
            {
                ListPost = PostDAO.Instance.GetAllIdNotPause();
                UserControl_Loaded(sender, e);
            }
            else 
            {
                ListPost = PostDAO.Instance.SearchPost(tenCongViec,khuVuc, kinhNghiem, luong);
                UserControl_Loaded(sender, e);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ListPost = PostDAO.Instance.GetAllIdNotPause();
            UserControl_Loaded(sender, e);
        }
    }
}
