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
using System.Windows.Shapes;

namespace AppXinViecWPF.View.Applicant
{
    /// <summary>
    /// Interaction logic for UCChoseInterviewDay.xaml
    /// </summary>
    public partial class UCChoseInterviewDay : Window
    {
        public UCChoseInterviewDay()
        {
            InitializeComponent();
            /*
            int[] days = CVDAO.Instance.GetAllDay(AccountDAO.UserID);
            foreach (int day in days)
            {
                RadioButton a = new RadioButton();
                a.VerticalAlignment = VerticalAlignment.Center;
                a.Content = new UCDayInterviewPreview(id);
                a.Checked += RadioButton_Checked;
                listDay.Items.Add(a);
            }*/
        }
    }
}
