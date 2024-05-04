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

namespace AppXinViecWPF.View.Employer
{
    /// <summary>
    /// Interaction logic for UCSetDayInterview.xaml
    /// </summary>
    public partial class UCSetDayInterview : Window
    {
        public UCSetDayInterview(int idpost, int idcv)
        {
            InitializeComponent();
            IdPost = idpost;
            IdCV = idcv;
        }
        int IdPost;
        int IdCV;
        //List<UCSetDayInterviewPreview> listUC = new List<UCSetDayInterviewPreview>();
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UCSetDayInterviewPreview uc = new UCSetDayInterviewPreview(IdPost, IdCV, dpPVDay.SelectedDate.Value, txtTime.TxtText, txtAddress.TxtText);
                listDay.Items.Add(uc);
            }
            catch (Exception)
            {
                MessageBox.Show("Chưa nhập ngày");
            }
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            foreach (UCSetDayInterviewPreview uc in listDay.Items)
            {
                uc.AddPVDay();
            }
            DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
