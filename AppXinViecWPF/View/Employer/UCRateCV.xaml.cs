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
        public UCRateCV(int idCV)
        {
            InitializeComponent();
            IdCV= idCV;
            CV =CVDAO.Instance.GetCvById(idCV);
            txtName.Text = CV.HoVaTen;
            txtNameCV.Text = CV.TenCV;
            if(CVDAO.Instance.IsFavCV(idCV))
            {
                btnLike_Icon.Icon = FontAwesome.Sharp.IconChar.HeartCircleCheck;
            }
        }
        CV CV;
        int IdCV;
        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            if (!CVDAO.Instance.IsFavCV(IdCV))
            {
                CVDAO.Instance.AddFavCV(IdCV);
                btnLike_Icon.Icon = FontAwesome.Sharp.IconChar.HeartCircleCheck;
            }
            else
            {
                CVDAO.Instance.DeleteFavCV(IdCV);
                btnLike_Icon.Icon = FontAwesome.Sharp.IconChar.Heart;
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            WViewCV wViewCV = new WViewCV(IdCV);
            wViewCV.Show();
        }
    }
}
