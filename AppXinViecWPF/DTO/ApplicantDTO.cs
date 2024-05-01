using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AppXinViecWPF.DTO
{
    internal class ApplicantDTO
    {
        string name;
        string gender;
        string phone;
        DateTime birth;

        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public DateTime Birth { get => birth; set => birth = value; }

        public ApplicantDTO(string name, string gender, string phone, DateTime birth) 
        { 
            Name = name;
            Gender = gender;    
            Phone = phone;
            Birth = birth;
        }
        public ApplicantDTO(DataTable dt)
        {
            Name = dt.Rows[0]["Ten"].ToString();
            Gender = dt.Rows[0]["GioiTinh"].ToString();
            Phone = dt.Rows[0]["SDT"].ToString();
            Birth = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
        }

        public bool NotNull()
        {
            var properties = typeof(ApplicantDTO).GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(this);
                string name_=NameProp(property.Name);
                
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
            }
            return NameProp;
        }
    }
}
