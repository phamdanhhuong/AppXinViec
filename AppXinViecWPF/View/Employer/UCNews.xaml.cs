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
    /// Interaction logic for UCNews.xaml
    /// </summary>
    public partial class UCNews : UserControl
    {
        public UCNews()
        {
            InitializeComponent();
            List<ApplyCV> list = CVDAO.Instance.GetApplyCVByIdEmp(AccountDAO.UserID);
            int count = 0;
            foreach (ApplyCV cv in list)
            {
                if (cv.Comfirm == 1)
                {
                    count++;
                }
            }
            txtConfirmCV.Text = count.ToString();
            txtNewCV.Text = (list.Count - count).ToString();
            int[] IdPosts = PostDAO.Instance.GetAllIdPostById(AccountDAO.UserID);
            txtPost.Text = IdPosts.Length.ToString();
            EmployerDTO emp = EmployerDAO.Instance.GetInfoById(AccountDAO.UserID);
            txtName.Text = emp.Name;
        }
    }
}
