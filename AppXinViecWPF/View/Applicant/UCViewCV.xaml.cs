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
    /// Interaction logic for UCViewCV.xaml
    /// </summary>
    public partial class UCViewCV : UserControl
    {
        public UCViewCV(int id)
        {
            InitializeComponent();
            Cv = CVDAO.Instance.GetCvById(id);
            DataContext = Cv;
            txtBirth.Text = Cv.NgaySinh.Date.ToString("d");
        }

        CV cv;

        internal CV Cv { get => cv; set => cv = value; }
    }
}
