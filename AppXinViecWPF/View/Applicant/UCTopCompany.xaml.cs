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
    /// Interaction logic for UCTopCompany.xaml
    /// </summary>
    public partial class UCTopCompany : UserControl
    {
        public UCTopCompany()
        {
            InitializeComponent();
            List<int> listFAV = EmployerDAO.Instance.GetAllIdSortByFav();
            foreach (int item in listFAV)
            {
                UCInfoCompany uc = new UCInfoCompany(item);
                menuCompany.Items.Add(uc);
            }
            List<int> list = EmployerDAO.Instance.GetAllId();
            //lấy phần tử có trong list nhưng khong có trong listFAV
            List<int> listNotFAV = list.Except(listFAV).ToList();
            foreach (int item in listNotFAV)
            {
                UCInfoCompany uc = new UCInfoCompany(item);
                menuCompany.Items.Add(uc);
            }
        }
    }
}
