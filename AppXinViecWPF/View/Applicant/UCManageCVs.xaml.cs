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
    /// Interaction logic for UCManageCVs.xaml
    /// </summary>
    public partial class UCManageCVs : UserControl
    {
        public UCManageCVs()
        {
            InitializeComponent();
            int[] ids = CVDAO.Instance.GetAllIdCvById(AccountDAO.UserID);
            foreach (int id in ids)
            {
                icMain.Items.Add(new UCIconCV(id));
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
