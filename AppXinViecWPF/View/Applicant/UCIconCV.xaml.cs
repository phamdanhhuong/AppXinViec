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
    /// Interaction logic for UCIconCV.xaml
    /// </summary>
    public partial class UCIconCV : UserControl
    {
        public UCIconCV(int id)
        {
            InitializeComponent();
            GetCv = CVDAO.Instance.GetCvById(id);
            DataContext = GetCv;
            txtCreatDay.Text += GetCv.NgayTao.ToString();
            txtEditDay.Text += GetCv.NgaySua.ToString();
        }

        CV getCv;
        internal CV GetCv { get => getCv; set => getCv = value; }

        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CVDAO.Instance.DeleteCvById(GetCv.Id);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WMainApplicant.uCCCV = new UCCreateCV(GetCv.Id);
            WMainApplicant.uCManageCVs.TriggerButtonClick();
        }
    }
}
