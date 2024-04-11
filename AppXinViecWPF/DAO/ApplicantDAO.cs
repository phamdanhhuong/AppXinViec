using AppXinViecWPF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DAO
{
    internal class ApplicantDAO
    {
        public ApplicantDAO() { }
        private static ApplicantDAO instance;

        public static ApplicantDAO Instance 
        {
            get
            {
                if(instance == null)
                    instance = new ApplicantDAO();
                return instance;
            }
            private set => instance = value; 
        }
        public void Add(ApplicantDTO applicant)
        {
            //// Lay ID
            object Id = null;
            string sqlStrGetId = string.Format("SELECT Max(Id) as LastID FROM Account");
            Id=DataProvider.Instance.ExecuteScalar(sqlStrGetId);
            //// them thong tin
            string sqlStr = string.Format("INSERT INTO  ApplicantInfo (Id,Ten,GioiTinh,SDT,NgaySinh) VALUES ({0},'{1}','{2}','{3}','{4}')",int.Parse(Id.ToString()),applicant.Name,applicant.Gender,applicant.Phone,applicant.Birth.ToString("yyyy-MM-dd"));
            DataProvider.Instance.ExecuteNonQuery(sqlStr);
        }
        public void AddFavJob(int IdJob)
        {
            string query = string.Format("INSERT INTO FavJob (IdApplicant,IdPost) VALUES ({0},{1})",AccountDAO.UserID,IdJob);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void DeleteFavJob(int IdJob)
        {
            string query = string.Format("DELETE FROM FavJob WHERE IdPost = {0} ", IdJob);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int[] GetAllFavIdJob()
        {
            string query = string.Format("SELECT IdPost FROM FavJob WHERE IdApplicant = {0} ", AccountDAO.UserID);
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            int[] dt = new int[dataTable.Rows.Count];
            int index = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                dt[index] = (int)row["IdPost"];
                index++;
            }
            return dt;
        }
    }
}

