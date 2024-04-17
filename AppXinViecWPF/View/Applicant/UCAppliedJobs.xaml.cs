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
    /// Interaction logic for UCAppliedJobs.xaml
    /// </summary>
    public partial class UCAppliedJobs : UserControl
    {
        public UCAppliedJobs()
        {
            InitializeComponent();
            applyCV = CVDAO.Instance.GetApplyCVByIdApplycant(AccountDAO.UserID);
            foreach (ApplyCV cv in applyCV)
            {
                icMain.Items.Add(new UCIconAppliedJobs(cv.IdCV,cv.IdPost,cv.SubmitDay,cv.Comfirm));
            }
        }
        List<ApplyCV> applyCV;

        private void btnComfirm_Click(object sender, RoutedEventArgs e)
        {
            icMain.Items.Clear();
            foreach (ApplyCV cv in applyCV)
            {
                if (cv.Comfirm == 1)
                {
                    icMain.Items.Add(new UCIconAppliedJobs(cv.IdCV, cv.IdPost, cv.SubmitDay, cv.Comfirm));
                }
            }
        }

        private void btnUnComfirm_Click(object sender, RoutedEventArgs e)
        {
            icMain.Items.Clear();
            foreach (ApplyCV cv in applyCV)
            {
                if (cv.Comfirm == 0)
                {
                    icMain.Items.Add(new UCIconAppliedJobs(cv.IdCV, cv.IdPost, cv.SubmitDay, cv.Comfirm));
                }
            }
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            icMain.Items.Clear();
            foreach (ApplyCV cv in applyCV)
            {
                icMain.Items.Add(new UCIconAppliedJobs(cv.IdCV, cv.IdPost, cv.SubmitDay, cv.Comfirm));
            }
        }
    }
}
