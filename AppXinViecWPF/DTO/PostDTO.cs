using AppXinViecWPF.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DTO
{
    internal class PostDTO
    {
        int idPost;
        string nameJob;
        int idEmployer;
        DateTime expireDate;
        int status;
        //Than bai viet
        string jd;
        string requirement;
        string interest;
        string address;
        // thong tin chung
        string salary;
        string location;
        string experience;
        string position;
        string quantity;
        string workMode;
        string gender;
        string career;
        string skill;

        public int IdPost { get => idPost; set => idPost = value; }
        public string Jd { get => jd; set => jd = value; }
        public string Requirement { get => requirement; set => requirement = value; }
        public string Interest { get => interest; set => interest = value; }
        public string Address { get => address; set => address = value; }
        public string Salary { get => salary; set => salary = value; }
        public string Location { get => location; set => location = value; }
        public string Experience { get => experience; set => experience = value; }
        public string Position { get => position; set => position = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string WorkMode { get => workMode; set => workMode = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Career { get => career; set => career = value; }
        public string Skill { get => skill; set => skill = value; }
        public string NameJob { get => nameJob; set => nameJob = value; }
        public DateTime ExpireDate { get => expireDate; set => expireDate = value; }
        public int Status { get => status; set => status = value; }
        public int IdEmployer { get => idEmployer; set => idEmployer = value; }

        public PostDTO(string name, string jd, string requirement, string interest, string address, string salary, string location, string experience, string position, string quantity, string workMode, string gender, string career, string skill, DateTime expireDate, int idPost = 0)
        {
            NameJob = name;
            Jd = jd;
            IdEmployer = AccountDAO.UserID;
            Requirement = requirement;
            Interest = interest;
            Address = address;
            Salary = salary;
            Location = location;
            Experience = experience;
            Position = position;
            Quantity = quantity;
            WorkMode = workMode;
            Gender = gender;
            Career = career;
            Skill = skill;
            ExpireDate = expireDate;
            IdPost = idPost;
        }

        public PostDTO(DataTable data)
        {
            IdPost = int.Parse(data.Rows[0]["Id"].ToString());
            NameJob = data.Rows[0]["TenCongViec"].ToString();
            IdEmployer = int.Parse(data.Rows[0]["IdEmployer"].ToString());
            Jd = data.Rows[0]["MoTa"].ToString();
            Requirement = data.Rows[0]["YeuCau"].ToString();
            Interest = data.Rows[0]["QuyenLoi"].ToString();
            Address = data.Rows[0]["DiaChi"].ToString();
            Salary = data.Rows[0]["Luong"].ToString();
            Location = data.Rows[0]["KhuVuc"].ToString();
            Experience = data.Rows[0]["KinhNghiem"].ToString();
            Position = data.Rows[0]["ChucVu"].ToString();
            Quantity = data.Rows[0]["SoLuongCanTuyen"].ToString();
            WorkMode = data.Rows[0]["CheDoLamViec"].ToString();
            Gender = data.Rows[0]["GioiTinh"].ToString();
            Career = data.Rows[0]["NganhNghe"].ToString();
            Skill = data.Rows[0]["KyNang"].ToString();
            ExpireDate= DateTime.Parse(data.Rows[0]["HanNopHoSo"].ToString());
            Status = int.Parse(data.Rows[0]["TrangThai"].ToString());
        }
    }
}
