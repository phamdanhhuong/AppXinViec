using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppXinViecWPF.DTO
{
    internal class EmployerDTO : INotifyPropertyChanged
    {
        string name;
        string gender;
        string phone;
        string position;
        string nameCompany;
        string addressCompany;
        string website;
        string taxCode;
        string phoneCompany;
        string emailCompany;
        string humanScale;
        string certificatePath;
        string logoPath;
        string intro;

        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); } }
        public string Gender { get => gender; set { gender = value; OnPropertyChanged("Gender"); } }
        public string Phone { get => phone; set { phone = value; OnPropertyChanged("Phone"); } }
        public string Position { get => position; set { position = value; OnPropertyChanged("Position"); } }
        public string NameCompany { get => nameCompany; set => nameCompany = value; }
        public string AddressCompany { get => addressCompany; set => addressCompany = value; }
        public string Website { get => website; set => website = value; }
        public string TaxCode { get => taxCode; set => taxCode = value; }
        public string PhoneCompany { get => phoneCompany; set => phoneCompany = value; }
        public string EmailCompany { get => emailCompany; set => emailCompany = value; }
        public string HumanScale { get => humanScale; set => humanScale = value; }
        public string CertificatePath { get => certificatePath; set => certificatePath = value; }
        public string LogoPath { get => logoPath; set => logoPath = value; }
        public string Intro { get => intro; set { intro = value; OnPropertyChanged("Intro"); } }

        public EmployerDTO(string name, string gender, string phone, string position, string nameCompany, string addressCompany, string website, string taxCode, string phoneCompany, string emailCompany, string humanScale,string certificatePath, string logoPath)
        {
            Name = name;
            Gender = gender;
            Phone = phone;
            Position = position;
            NameCompany = nameCompany;
            AddressCompany = addressCompany;
            Website = website;
            TaxCode = taxCode;
            PhoneCompany = phoneCompany;
            EmailCompany = emailCompany;
            HumanScale = humanScale;
            CertificatePath = certificatePath;
            LogoPath = logoPath;
            Intro = "Không có";
        }
        public EmployerDTO(DataTable data)
        {
            Name = data.Rows[0]["Ten"].ToString();
            Gender = data.Rows[0]["GioiTinh"].ToString(); 
            Phone = data.Rows[0]["SDT"].ToString(); ;
            Position = data.Rows[0]["ChucVu"].ToString(); ;
            NameCompany = data.Rows[0]["TenCongTy"].ToString(); ;
            AddressCompany = data.Rows[0]["DiaChiCongTy"].ToString(); ;
            Website = data.Rows[0]["Website"].ToString(); ;
            TaxCode = data.Rows[0]["MSThue"].ToString(); ;
            PhoneCompany = data.Rows[0]["SDTCongTY"].ToString(); ;
            EmailCompany = data.Rows[0]["EmailCongTY"].ToString(); ;
            HumanScale = data.Rows[0]["QuyMo"].ToString(); 
            CertificatePath = data.Rows[0]["ChungChi"].ToString();
            LogoPath = data.Rows[0]["Logo"].ToString();
            Intro = data.Rows[0]["GioiThieu"].ToString();
        }
        public bool NotNull()
        {
            var properties = typeof(EmployerDTO).GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(this);
                string name_ = NameProp(property.Name);

                if (value == null || value.ToString() == "")
                {
                    MessageBox.Show($"{name_} trống");
                    return false;
                }
            }
            return true;
        }
        private string NameProp(string nameprop)
        {
            string NameProp = "";
            switch (nameprop)
            {
                case "Name":
                    NameProp = "Tên";
                    break;
                case "Gender":
                    NameProp = "Giới tính";
                    break;
                case "Phone":
                    NameProp = "Số điện thoại";
                    break;
                case "Position":
                    NameProp = "Chức vụ";
                    break;
                case "NameCompany":
                    NameProp = "Tên công ty";
                    break;
                case "AddressCompany":
                    NameProp = "Địa chỉ công ty";
                    break;
                case "Website":
                    NameProp = "Trang web công ty";
                    break;
                case "TaxCode":
                    NameProp = "Mã số thuế";
                    break;
                case "PhoneCompany":
                    NameProp = "Số điện thoại công ty";
                    break;
                case "EmailCompany":
                    NameProp = "Email công ty";
                    break;
                case "HumanScale":
                    NameProp = "Quy mô công ty";
                    break;
                case "CertificatePath":
                    NameProp = "Giấy phép kinh doanh";
                    break;
                case "LogoPath":
                    NameProp = "Logo công ty";
                    break;
            }
            return NameProp;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
