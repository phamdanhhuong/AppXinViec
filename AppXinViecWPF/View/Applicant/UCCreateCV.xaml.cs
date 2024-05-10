﻿using AppXinViecWPF.DAO;
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
using Button = System.Windows.Controls.Button;

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
            btnData.Visibility = Visibility.Collapsed;
        }
        public UCCreateCV(int id)
        {
            InitializeComponent();
            Id = id;
            IsCreate = false;
            GetCV = CVDAO.Instance.GetCvById(Id);
            loadData();
            btnClear.Click += btnClear_Click_2;
        }
        string imgAvt;
        int id;
        CV getCV;
        bool IsCreate=true;

        public string ImgAvt { get => imgAvt; set => imgAvt = value; }
        public int Id { get => id; set => id = value; }
        internal CV GetCV { get => getCV; set => getCV = value; }

        private void btnUploadAvt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files|*.bmp;*.png;*.jpg";
            open.FilterIndex = 1;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedImagePath = open.FileName;
                string targetDirectory = "Image";
                string targetPath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(selectedImagePath));
                string projectDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string destinationPath = System.IO.Path.Combine(projectDirectory, targetPath);
                System.IO.File.Copy(selectedImagePath, destinationPath, true);
                ImgAvt = targetPath;
                imgAvatar.Source = new BitmapImage(new Uri(open.FileName));
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsCreate)
            {
                AddCv();
            }
            else
            {
                EditCv();
            }
        }

        private void AddCv()
        {
            try
            {
                DateTime.Parse(txtBirth.TxtText);
                CV cV = new CV(AccountDAO.UserID, txtNameCV.TxtText, txtFullName.TxtText, txtApplyPosition.TxtText, ImgAvt,
                txtPhone.TxtText, txtGender.TxtText, txtEmail.TxtText, DateTime.Parse(txtBirth.TxtText)
                , txtLink.TxtText, txtAddress.TxtText, txtMajor.TxtText, txtNameSchool.TxtText, txtSchoolDay.TxtText, txtSchoolAchive.TxtText,
                txtNameLastJob.TxtText, txtNameLastCompany.TxtText, txtWorkDay.TxtText, txtDescriptionExp.TxtText, txtProjectName.TxtText, txtProjectPosition.TxtText,
                txtProjectDay.TxtText, txtProjectDescription.TxtText, txtTarget.TxtText, txtSkill.TxtText, txtCertificate.TxtText, txtFav.TxtText, txtExtra.TxtText);
                if (cV.NotNull())
                {
                    CVDAO.Instance.CreateCV(cV);
                    TriggerButtonClick();
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Ngày sinh không hợp lệ");
            }
        }

        private void EditCv()
        {
            try
            {
                DateTime.Parse(txtBirth.TxtText);
                CV cV = new CV(AccountDAO.UserID, txtNameCV.TxtText, txtFullName.TxtText, txtApplyPosition.TxtText, ImgAvt,
                txtPhone.TxtText, txtGender.TxtText, txtEmail.TxtText, DateTime.Parse(txtBirth.TxtText)
                , txtLink.TxtText, txtAddress.TxtText, txtMajor.TxtText, txtNameSchool.TxtText, txtSchoolDay.TxtText, txtSchoolAchive.TxtText,
                txtNameLastJob.TxtText, txtNameLastCompany.TxtText, txtWorkDay.TxtText, txtDescriptionExp.TxtText, txtProjectName.TxtText, txtProjectPosition.TxtText,
                txtProjectDay.TxtText, txtProjectDescription.TxtText, txtTarget.TxtText, txtSkill.TxtText, txtCertificate.TxtText, txtFav.TxtText, txtExtra.TxtText);
                cV.Id = Id;
                if (cV.NotNull())
                {
                    CVDAO.Instance.EditCV(cV);
                    TriggerButtonClick();
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Ngày sinh không hợp lệ");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void loadData()
        {
            this.txtNameCV.TxtText = GetCV.TenCV;
            this.txtFullName.TxtText = GetCV.HoVaTen;
            this.txtApplyPosition.TxtText = GetCV.ViTriUngTuyen;
            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, GetCV.Avatar);
            this.imgAvatar.Source = new BitmapImage(new Uri(imagePath));
            this.imgAvt = GetCV.Avatar;
            this.txtPhone.TxtText = GetCV.SDT;
            this.txtGender.TxtText = GetCV.GioiTinh;
            txtEmail.TxtText = GetCV.Email;
            txtBirth.TxtText = GetCV.NgaySinh.Date.ToString();
            txtLink.TxtText = GetCV.TrangCaNhan;
            txtAddress.TxtText = GetCV.DiaChi;
            txtMajor.TxtText = GetCV.NganhHoc;
            txtNameSchool.TxtText = GetCV.TenTruong;
            txtSchoolDay.TxtText = GetCV.ThoiGianHoc;
            txtSchoolAchive.TxtText = GetCV.ThanhTich;
            txtNameLastJob.TxtText = GetCV.CongViecCu;
            txtNameLastCompany.TxtText = GetCV.CongTyCu;
            txtWorkDay.TxtText = GetCV.ThoiGianLamViec;
            txtDescriptionExp.TxtText = GetCV.MoTaKinhNghiem;
            txtProjectName.TxtText = GetCV.TenDuAn;
            txtProjectPosition.TxtText = GetCV.ViTriTrongDuAn;
            txtProjectDay.TxtText = GetCV.ThoiGianLamDuAn;
            txtProjectDescription.TxtText = GetCV.MoTaHoatDong;
            txtTarget.TxtText = GetCV.MucTieu;
            txtSkill.TxtText = GetCV.KyNang;
            txtCertificate.TxtText = GetCV.ChungChi;
            txtFav.TxtText = GetCV.SoThich;
            txtExtra.TxtText = GetCV.ThongTinThem;
        }
        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            txtNameCV.TxtText = GetCV.TenCV;
            txtFullName.TxtText = GetCV.HoVaTen;
            txtApplyPosition.TxtText = GetCV.ViTriUngTuyen;
            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, GetCV.Avatar);
            imgAvatar.Source = new BitmapImage(new Uri(imagePath));
            imgAvt = GetCV.Avatar;
            txtPhone.TxtText = GetCV.SDT;
            txtGender.TxtText = GetCV.GioiTinh;
            txtEmail.TxtText = GetCV.Email;
            txtBirth.TxtText = GetCV.NgaySinh.Date.ToString();
            txtLink.TxtText = GetCV.TrangCaNhan;
            txtAddress.TxtText = GetCV.DiaChi;
            txtMajor.TxtText = GetCV.NganhHoc;
            txtNameSchool.TxtText = GetCV.TenTruong;
            txtSchoolDay.TxtText = GetCV.ThoiGianHoc;
            txtSchoolAchive.TxtText = GetCV.ThanhTich;
            txtNameLastJob.TxtText = GetCV.CongViecCu;
            txtNameLastCompany.TxtText = GetCV.CongTyCu;
            txtWorkDay.TxtText = GetCV.ThoiGianLamViec;
            txtDescriptionExp.TxtText = GetCV.MoTaKinhNghiem;
            txtProjectName.TxtText = GetCV.TenDuAn;
            txtProjectPosition.TxtText = GetCV.ViTriTrongDuAn;
            txtProjectDay.TxtText = GetCV.ThoiGianLamDuAn;
            txtProjectDescription.TxtText = GetCV.MoTaHoatDong;
            txtTarget.TxtText = GetCV.MucTieu;
            txtSkill.TxtText = GetCV.KyNang;
            txtCertificate.TxtText = GetCV.ChungChi;
            txtFav.TxtText = GetCV.SoThich;
            txtExtra.TxtText = GetCV.ThongTinThem;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click_2(object sender, RoutedEventArgs e)
        {
            WMainApplicant.uCCCV = new UCCreateCV(Id);
            WMainApplicant.uCManageCVs.TriggerButtonClick();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

        }
        public void TriggerButtonClick()
        {
            btnLoad.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }
}
