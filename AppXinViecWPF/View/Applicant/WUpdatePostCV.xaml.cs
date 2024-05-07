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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppXinViecWPF.View.Applicant
{
    /// <summary>
    /// Interaction logic for WUpdatePostCV.xaml
    /// </summary>
    public partial class WUpdatePostCV : Window
    {
        public WUpdatePostCV(int idpostcv)
        {
            InitializeComponent();
            PostCV = PostCVDAO.Instance.getPostCVById(idpostcv);
            txtTitle.Text = PostCV.Title;
            rtxtContent.Document.Blocks.Add(new Paragraph(new Run(PostCV.Content)));
            int[] ids = CVDAO.Instance.GetAllIdCvById(AccountDAO.UserID);
            foreach (int id in ids)
            {
                RadioButton a = new RadioButton();
                a.VerticalAlignment = VerticalAlignment.Center;
                a.Content = new UCrbtnCV(id);
                a.Checked += RadioButton_Checked;
                listCV.Items.Add(a);
            }
        }
        int IdCV = -1;
        PostCV PostCV;
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            UCrbtnCV ucrbtnCV = radioButton.Content as UCrbtnCV;
            IdCV = ucrbtnCV.IdCV;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IdCV == -1)
            {
                MessageBox.Show("Chưa chọn CV");
                return;
            }
            else
            {
                string title = txtTitle.Text;
                TextRange content = new TextRange(rtxtContent.Document.ContentStart, rtxtContent.Document.ContentEnd);
                PostCV.Title = title;
                PostCV.Content = content.Text;
                PostCV.IdCV = IdCV;
                if(PostCV.NotNull())
                {
                    PostCVDAO.Instance.updatePostCV(PostCV);
                    MessageBox.Show("Sửa bài thành công");
                    this.Close();
                }
            }
        }
    }
}
