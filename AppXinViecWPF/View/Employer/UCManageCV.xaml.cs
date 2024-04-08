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
            foreach (ApplyCV cv in list)
            {
                icMain.Items.Add(new UCMiniCV(cv.IdPost,cv.IdCV,cv.SubmitDay));
            }
        }
    }
}
