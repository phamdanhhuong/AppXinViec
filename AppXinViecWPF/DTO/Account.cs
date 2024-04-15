using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppXinViecWPF.DTO
{
    internal class Account
    {
        int id;
        string userName;
        string password;
        string email;
        int role;

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public int Role { get => role; set => role = value; }

        public Account( string userName, string password, string email, int role)
        {
            Id = 0;
            UserName = userName;
            Password = password;
            Email = email;
            Role = role;
        }
        public bool NotNull()
        {
            var properties = typeof(Account).GetProperties();

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
                case "UserName":
                    NameProp = "Tên người dùng";
                    break;
                case "Password":
                    NameProp = "Mật khẩu";
                    break;
                case "Email":
                    NameProp = "Email";
                    break;
            }
            return NameProp;
        }
    }
}
