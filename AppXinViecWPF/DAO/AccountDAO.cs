using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DAO
{
    internal class AccountDAO
    {
        public AccountDAO() { }

        private static int userID;

        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set { instance = value; }
        }

        public static int UserID { get => userID; set => userID = value; }

        public void CreateAccount(string username, string password, int role)
        {
            string sqlStr = string.Format("INSERT INTO  Account (Username,Password,Role) VALUES ('{0}','{1}',{2})",username,password,role);
            DataProvider.Instance.ExecuteNonQuery(sqlStr);
        }
        public bool Login(string username, string password)
        {
            string query = string.Format("Select * from dbo.Account where Username = '{0}' and Password = '{1}'",username,password);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if(dt.Rows.Count > 0)
                UserID = int.Parse(dt.Rows[0]["Id"].ToString());
            return dt.Rows.Count > 0;
        }
        public bool IsEmployer(string username, string password)
        {
            string query = string.Format("Select * from dbo.Account where Username = '{0}' and Password = '{1}'", username, password);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (int.Parse(dt.Rows[0]["Role"].ToString()) == 0)
                return false;
            return true;
        }
        public bool IsEmployerById(int id)
        {
            string query = string.Format("Select * from dbo.Account where Id = {0}", id);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (int.Parse(dt.Rows[0]["Role"].ToString()) == 0)
                return false;
            return true;
        }
    }
}
