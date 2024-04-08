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
    /// Interaction logic for UCrbtnCV.xaml
    /// </summary>
    public partial class UCrbtnCV : UserControl
    {
        public UCrbtnCV(int id)
        {
            InitializeComponent();
            CV cv = CVDAO.Instance.GetCvById(id);
            IdCV = cv.Id;
            txtName.Text = cv.TenCV;
        }
        public int IdCV;
    }
}
