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
    /// Interaction logic for UCCreateCV.xaml
    /// </summary>
    public partial class UCCreateCV : System.Windows.Controls.UserControl
    {
        public UCCreateCV()
        {
            InitializeComponent();
        }
        string imgAvt;

        public string ImgAvt { get => imgAvt; set => imgAvt = value; }

        private void btnUploadAvt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files|*.bmp;*.png;*.jpg";
            open.FilterIndex = 1;
            if (open.ShowDialog() == DialogResult.OK)
            {
                imgAvatar.Source = new BitmapImage(new Uri(open.FileName));
                ImgAvt = open.FileName;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CV cV = new CV(AccountDAO.UserID, txtNameCV.TxtText,txtFullName.TxtText,txtApplyPosition.TxtText,ImgAvt,
                txtPhone.TxtText,txtGender.TxtText,txtEmail.TxtText, DateTime.Parse(txtBirth.TxtText)
                , txtLink.TxtText,txtAddress.TxtText,txtMajor.TxtText,txtNameSchool.TxtText,txtSchoolDay.TxtText,txtSchoolAchive.TxtText,
                txtNameLastJob.TxtText,txtNameLastCompany.TxtText,txtWorkDay.TxtText,txtDescriptionExp.TxtText,txtProjectName.TxtText,txtProjectPosition.TxtText,
                txtProjectDay.TxtText,txtProjectDescription.TxtText,txtTarget.TxtText,txtSkill.TxtText,txtCertificate.TxtText,txtFav.TxtText,txtExtra.TxtText);
            CVDAO.Instance.CreateCV(cV);
            UserControl_Loaded(sender, e);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
