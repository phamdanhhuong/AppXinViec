using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DTO
{
    internal class PVDay
    {
        int id;
        int idPost;
        int idCV;
        int idPostCV;
        int idEmployer;
        DateTime date;
        string time;
        string address;
        int pick;

        public int Id { get => id; set => id = value; }
        public int IdPost { get => idPost; set => idPost = value; }
        public int IdCV { get => idCV; set => idCV = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }
        public string Address { get => address; set => address = value; }
        public int Pick { get => pick; set => pick = value; }
        public int IdPostCV { get => idPostCV; set => idPostCV = value; }
        public int IdEmployer { get => idEmployer; set => idEmployer = value; }

        public PVDay( int idpost, int idcv, DateTime date, string time, string address)
        {
            Id = -1;
            Pick = 0;
            IdPost = idpost;
            IdCV = idcv;
            Date = date;
            Time = time;
            Address = address;
            IdPostCV = -1;
            IdEmployer = -1;
        }
        public PVDay(System.Data.DataRow row)
        {
            Id = (int)row["Id"];
            IdPost = (int)row["IdPost"];
            IdCV = (int)row["IdCV"];
            Date = (DateTime)row["Ngay"];
            Time = row["ThoiGian"].ToString();
            Address = row["DiaDiem"].ToString();
            Pick = (int)row["Chon"];
        }
        public PVDay(System.Data.DataRow row,int i)
        {
            Id = (int)row["Id"];
            IdPostCV = (int)row["IdPostCV"];
            IdEmployer = (int)row["IdEmployer"];
            Date = (DateTime)row["Ngay"];
            Time = row["ThoiGian"].ToString();
            Address = row["DiaDiem"].ToString();
            Pick = (int)row["Chon"];
        }
        public bool NotNull()
        {
            var properties = typeof(PVDay).GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(this);

                if (value == null || value.ToString() == "")
                {
                    System.Windows.MessageBox.Show($"{property.Name} trống");
                    return false;
                }
            }
            return true;
        }
    }
}
