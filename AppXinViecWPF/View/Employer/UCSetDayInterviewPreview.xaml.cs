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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AppXinViecWPF.View.Employer
{
    /// <summary>
    /// Interaction logic for UCSetDayInterviewPreview.xaml
    /// </summary>
    public partial class UCSetDayInterviewPreview : UserControl
    {
        public UCSetDayInterviewPreview(int idpost, int idcv, DateTime date, string time, string address)
        {
            InitializeComponent();
            pVDay = new PVDay(idpost, idcv, date, time, address);
            txtDate.Text = date.ToString("d");
            txtTime.Text = time;
            txtAddress.Text = address;
        }
        PVDay pVDay;

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Get the parent ItemsControl
            var itemControl = FindParentItemControl(this);

            // Remove this UC from the ItemsControl
            itemControl.Items.Remove(this);
        }

        private ItemsControl FindParentItemControl(FrameworkElement element)
        {
            var parent = VisualTreeHelper.GetParent(element);
            while (parent != null && !(parent is ItemsControl))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as ItemsControl;
        }
        // Add PVDay
        public void AddPVDay()
        {
            PVDayDAO.Instance.AddPVDay(pVDay);
        }
    }
}
