using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DTO
{
    internal class ApplyCV
    {
        int idCV;
        int idPost;
        DateTime submitDay;
        int comfirm;

        public int IdCV { get => idCV; set => idCV = value; }
        public int IdPost { get => idPost; set => idPost = value; }
        public DateTime SubmitDay { get => submitDay; set => submitDay = value; }
        public int Comfirm { get => comfirm; set => comfirm = value; }

        public ApplyCV(int idCV, int idPost, DateTime submitDay)
        {
            IdCV = idCV;
            IdPost = idPost;
            SubmitDay = submitDay;
        }
        public ApplyCV(DataRow row)
        {
            IdCV = int.Parse(row["IdCV"].ToString());
            IdPost = int.Parse(row["IdPost"].ToString());
            SubmitDay = DateTime.Parse(row["NgayNop"].ToString());
            Comfirm = int.Parse(row["Duyet"].ToString());
        }
    }
}
