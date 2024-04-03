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
        }

        CV getCv;
        internal CV GetCv { get => getCv; set => getCv = value; }
    }
}
