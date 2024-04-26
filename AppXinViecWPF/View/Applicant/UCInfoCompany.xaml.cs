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
    /// Interaction logic for UCInfoCompany.xaml
    /// </summary>
    public partial class UCInfoCompany : UserControl
    {
        public UCInfoCompany(int idEmp)
        {
            InitializeComponent();
            Emp = EmployerDAO.Instance.GetInfoById(idEmp);
            IdEmp = idEmp;
            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, Emp.LogoPath);
            imgLogo.Source = new BitmapImage(new Uri(imagePath));
            txtNameJob.Text = Emp.NameCompany;
            txtAddress.Text = Emp.AddressCompany;
            txtDes.Text = Emp.Intro;
            txtQuantity.Text = PostDAO.Instance.CountPostById(IdEmp).ToString();
            if(ApplicantDAO.Instance.IsFavCompany(idEmp))
            {
                btnLike_Icon.Icon = FontAwesome.Sharp.IconChar.HeartCircleCheck;
            }
        }
        EmployerDTO Emp;
        int IdEmp;
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            UCCompanyInfomation uCCompanyInfomation = new UCCompanyInfomation(IdEmp);
            uCCompanyInfomation.ShowDialog();
        }

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicantDAO.Instance.IsFavCompany(IdEmp))
            {
                btnLike_Icon.Icon = FontAwesome.Sharp.IconChar.Heart;
                ApplicantDAO.Instance.DeleteFavCompany(IdEmp);
            }
            else
            {
                btnLike_Icon.Icon = FontAwesome.Sharp.IconChar.HeartCircleCheck;
                ApplicantDAO.Instance.AddFavCompany(IdEmp);
            }
        }
    }
}
