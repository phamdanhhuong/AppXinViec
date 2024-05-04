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
using System.Windows.Shapes;

namespace AppXinViecWPF.View.Applicant
{
    /// <summary>
    /// Interaction logic for UCChoseInterviewDay.xaml
    /// </summary>
    public partial class UCChoseInterviewDay : Window
    {
        public UCChoseInterviewDay(int idpost, int idcv)
        {
            InitializeComponent();
            pVDays = PVDayDAO.Instance.GetAllByIdPostAndIdCV(idpost, idcv);
            foreach (PVDay item in pVDays)
            {
                UCDayInterviewPreview uCDayInterviewPreview = new UCDayInterviewPreview(item.Id);
                listday.Items.Add(uCDayInterviewPreview);
            }
            ChosedDate = -1;
        }
        List<PVDay> pVDays;
        public static int ChosedDate = -1;
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if(ChosedDate != -1)
            {
                DialogResult = true;
                PVDayDAO.Instance.UpdatePick(ChosedDate,1);
                MessageBox.Show("Chọn ngày phỏng vấn thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn ngày phỏng vấn");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
