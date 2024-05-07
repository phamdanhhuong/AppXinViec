using AppXinViecWPF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DAO
{
    internal class PostCVDAO
    {
        public PostCVDAO() { }
        private static PostCVDAO instance;

        public static PostCVDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PostCVDAO();
                return instance;
            }
            private set => instance = value;
        }
        //Create PostCV
        public void createPostCV(PostCV postCV)
        {
            string query = string.Format("INSERT INTO PostCV (TieuDe, NoiDung, IdCV, NgayDang) VALUES (N'{0}', N'{1}', {2}, '{3}')", postCV.Title, postCV.Content,postCV.IdCV,DateTime.Now.ToString("yyyy-MM-dd"));
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        //Get all PostCV
        public List<PostCV> getAllPostCV()
        {
            List<PostCV> list = new List<PostCV>();
            string query = "SELECT * FROM PostCV";
            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (System.Data.DataRow item in data.Rows)
            {
                PostCV postCV = new PostCV(item);
                list.Add(postCV);
            }
            return list;
        }
        public List<PostCV> getAllPostCVByUserId()
        {
            List<PostCV> list = new List<PostCV>();
            string query = "SELECT * FROM PostCV";
            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (System.Data.DataRow item in data.Rows)
            {
                PostCV postCV = new PostCV(item);
                list.Add(postCV);
            }
            int[] ids = CVDAO.Instance.GetAllIdCvById(AccountDAO.UserID);
            List<PostCV> list2 = new List<PostCV>();
            foreach (PostCV postCV in list)
            {
                foreach (int id in ids)
                {
                    if (postCV.IdCV == id)
                    {
                        list2.Add(postCV);
                    }
                }
            }
            return list2;
        }
        //Get PostCV by Id
        public PostCV getPostCVById(int id)
        {
            string query = string.Format("SELECT * FROM PostCV WHERE Id = {0}", id);
            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);
            PostCV postCV = new PostCV(data.Rows[0]);
            return postCV;
        }
        //Delete PostCV by Id
        public void deletePostCVById(int id)
        {
            string query = string.Format("DELETE FROM PVDay_2 WHERE IdPostCV = {0}", id);
            DataProvider.Instance.ExecuteNonQuery(query);
            query = string.Format("DELETE FROM PostCV WHERE Id = {0}", id);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        //Update PostCV
        public void updatePostCV(PostCV postCV)
        {
            string query = string.Format("UPDATE PostCV SET TieuDe = N'{0}', NoiDung = N'{1}', IdCV = {2} WHERE Id = {3}", postCV.Title, postCV.Content, postCV.IdCV, postCV.Id);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
