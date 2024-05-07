using AppXinViecWPF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DAO
{
    internal class PVDayDAO
    {
        public PVDayDAO() { }
        private static PVDayDAO instance;
        public static PVDayDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PVDayDAO();
                return instance;
            }
            private set { instance = value; }
        }
        // Add , Update, Delete

        public void AddPVDay(PVDay pVDay)
        {
            string query = string.Format("INSERT INTO PVDay(IdPost, IdCV, Ngay, ThoiGian, DiaDiem) VALUES ({0},{1},'{2}','{3}','{4}')", pVDay.IdPost,pVDay.IdCV,pVDay.Date.ToString("yyyy-MM-dd"), pVDay.Time,pVDay.Address);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void AddPVDay_2(PVDay pVDay)
        {
            string query = string.Format("INSERT INTO PVDay(IdPostCV, IdEmployer, Ngay, ThoiGian, DiaDiem) VALUES ({0},{1},'{2}','{3}','{4}')", pVDay.IdPostCV, pVDay.IdEmployer, pVDay.Date.ToString("yyyy-MM-dd"), pVDay.Time, pVDay.Address);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void UpdatePVDay(PVDay pVDay)
        {
            string query = string.Format("UPDATE PVDay SET Ngay = '{0}', ThoiGian = '{1}', DiaDiem = '{2}' WHERE Id = {3}", pVDay.Date.ToString("yyyy-MM-dd"), pVDay.Time,pVDay.Address,pVDay.Id);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void DeletePVDay(int id)
        {
            string query = "DELETE FROM PVDay WHERE Id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        // delete by idpost
        public void DeletePVDayByIdPost(int id)
        {
            string query = "DELETE FROM PVDay WHERE IdPost = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        // delete by idcv
        public void DeletePVDayByIdCV(int id)
        {
            string query = "DELETE FROM PVDay WHERE IdCV = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        // Delete by idpost and idcv
        public void DeletePVDayByIdPostAndIdCV(int idpost, int idcv)
        {
            string query = "DELETE FROM PVDay WHERE IdPost = " + idpost + " AND IdCV = " + idcv;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        // Update pick
        public void UpdatePick(int id, int pick)
        {
            string query = "UPDATE PVDay SET Chon = " + pick + " WHERE Id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        // get all
        public List<PVDay> GetAll()
        {
            List<PVDay> list = new List<PVDay>();
            string query = "SELECT * FROM PVDay";
            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (System.Data.DataRow item in data.Rows)
            {
                PVDay pVDay = new PVDay(item);
                list.Add(pVDay);
            }
            return list;
        }
        //get picked by idpost and idcv
        public PVDay GetPickedByIdPostAndIdCV(int idpost, int idcv)
        {
            string query = "SELECT * FROM PVDay WHERE IdPost = " + idpost + " AND IdCV = " + idcv + " AND Chon = 1";
            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (System.Data.DataRow item in data.Rows)
            {
                PVDay pVDay = new PVDay(item);
                return pVDay;
            }
            return null;
        }
        // get by id
        public PVDay GetById(int id)
        {
            string query = "SELECT * FROM PVDay WHERE Id = " + id;
            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (System.Data.DataRow item in data.Rows)
            {
                PVDay pVDay = new PVDay(item);
                return pVDay;
            }
            return null;
        }
        //Get all by idpost and idcv
        public List<PVDay> GetAllByIdPostAndIdCV(int idpost, int idcv)
        {
            List<PVDay> list = new List<PVDay>();
            string query = "SELECT * FROM PVDay WHERE IdPost = " + idpost + " AND IdCV = " + idcv;
            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (System.Data.DataRow item in data.Rows)
            {
                PVDay pVDay = new PVDay(item);
                list.Add(pVDay);
            }
            return list;
        }
    }
}
