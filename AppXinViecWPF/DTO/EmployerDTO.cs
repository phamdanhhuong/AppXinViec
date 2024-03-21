using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DTO
{
    internal class EmployerDTO
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

        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Position { get => position; set => position = value; }
        public string NameCompany { get => nameCompany; set => nameCompany = value; }
        public string AddressCompany { get => addressCompany; set => addressCompany = value; }
        public string Website { get => website; set => website = value; }
        public string TaxCode { get => taxCode; set => taxCode = value; }
        public string PhoneCompany { get => phoneCompany; set => phoneCompany = value; }
        public string EmailCompany { get => emailCompany; set => emailCompany = value; }
        public string HumanScale { get => humanScale; set => humanScale = value; }

        public EmployerDTO(string name, string gender, string phone, string position, string nameCompany, string addressCompany, string website, string taxCode, string phoneCompany, string emailCompany, string humanScale)
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
            HumanScale = data.Rows[0]["QuyMo"].ToString(); ;
        }

    }
}
