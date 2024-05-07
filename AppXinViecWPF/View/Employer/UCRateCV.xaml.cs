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
    /// Interaction logic for UCRateCV.xaml
    /// </summary>
    public partial class UCRateCV : UserControl
    {
        public UCRateCV(int idpostcv)
        {
            InitializeComponent();
            PostCV = PostCVDAO.Instance.getPostCVById(idpostcv);
            Cv = CVDAO.Instance.GetCvById(PostCV.IdCV);
            txtNamePostCV.Text = PostCV.Title;
            txtName.Text = Cv.HoVaTen;
        }
        PostCV PostCV;
        CV Cv;
        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            WViewPostCV wViewPostCV = new WViewPostCV(PostCV.Id);
            wViewPostCV.ShowDialog();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
