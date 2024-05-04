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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppXinViecWPF.View.Applicant
{
    /// <summary>
    /// Interaction logic for UCDayInterviewPreview.xaml
    /// </summary>
    public partial class UCDayInterviewPreview : System.Windows.Controls.UserControl
    {
        public UCDayInterviewPreview(int id)
        {
            InitializeComponent();
            PVDay = PVDayDAO.Instance.GetById(id);
            if (PVDay != null)
            {
                txtDate.Text = PVDay.Date.ToString("d");
                txtTime.Text = PVDay.Time;
                txtAddress.Text = PVDay.Address;
            }
            this.MouseLeftButtonDown += UC_MouseLeftButtonDown;
        }
        PVDay PVDay;
        private void UC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(ucBorder.BorderThickness == new Thickness(0))
            {
                ucBorder.BorderThickness = new Thickness(2);
                UCChoseInterviewDay.ChosedDate = PVDay.Id;
                UnPickElse();
            }
            else
            {
                ucBorder.BorderThickness = new Thickness(0);
            }
        }
        private void UnPickElse()
        {
            var itemControl = FindParentItemControl(this);
            foreach (UCDayInterviewPreview item in itemControl.Items)
            {
                if(item != this)
                {
                    item.ucBorder.BorderThickness = new Thickness(0);
                }
            }
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
        
    }
}
