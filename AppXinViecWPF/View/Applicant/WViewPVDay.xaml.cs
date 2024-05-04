using AppXinViecWPF.DAO;
using AppXinViecWPF.DTO;
using AppXinViecWPF.View.Custom;
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
using System.Windows.Shapes;

namespace AppXinViecWPF.View.Applicant
{
    /// <summary>
    /// Interaction logic for WViewPVDay.xaml
    /// </summary>
    public partial class WViewPVDay : Window
    {
        public WViewPVDay(int id)
        {
            InitializeComponent();
            PVDay pVDay = PVDayDAO.Instance.GetById(id);
            if (pVDay != null)
            {
                txtDate.Text = pVDay.Date.ToString("d");
                txtTime.Text = pVDay.Time;
                txtAddress.Text = pVDay.Address;
            }
            this.MouseLeftButtonDown += UC_MouseLeftButtonDown;
        }
        private void UC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
