using AppXinViecWPF.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DAO
{
    internal class PostDAO
    {
        public PostDAO() { }
        private static PostDAO instance;

        public static PostDAO Instance 
        {
            get
            {
                if (instance == null)   
                    instance = new PostDAO();
                return instance;
            } 
            private set => instance = value; 
        }

        public void CreatePost(PostDTO post)
        {
            //
            string query = string.Format("INSERT INTO Post(IdEmployer,TenCongViec,HanNopHoSo) VALUES ( @IdEmployer , @TenCongViec , @HanNopHoSo )");
            DataProvider.Instance.ExecuteNonQuery(query,new object[] {post.IdEmployer,post.NameJob,post.ExpireDate.ToString("yyyy-MM-dd") });
            //
            query = "SELECT Max(Id) as LastID FROM Post";
            object Id = DataProvider.Instance.ExecuteScalar(query);
            //
            query = "INSERT INTO PostDetail(Id,MoTa,YeuCau,QuyenLoi,DiaChi,Luong,KhuVuc,KinhNghiem,ChucVu,SoLuongCanTuyen,CheDoLamViec,GioiTinh,NganhNghe,KyNang) VALUES( @Id , @MoTa , @YeuCau , @QuyenLoi , @DiaChi , @Luong , @KhuVuc , @KinhNghiem , @ChucVu , @SoLuongCanTuyen , @CheDoLamViec , @GioiTinh , @NganhNghe , @KyNang )";
            DataProvider.Instance.ExecuteNonQuery(query,new object[] { int.Parse(Id.ToString()), post.Jd, post.Requirement, post.Interest, post.Address, post.Salary, post.Location, post.Experience, post.Position, post.Quantity, post.WorkMode, post.Gender, post.Career, post.Skill });
        }

        public void UpdatePost(PostDTO post)
        {
            //
            string query = string.Format("UPDATE Post SET TenCongViec = @TenCongViec ,HanNopHoSo = @HanNopHoSo WHERE Id = @Id ");
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { post.NameJob, post.ExpireDate.ToString("yyyy-MM-dd") , post.IdPost});
            //
            query = "UPDATE PostDetail SET MoTa = @MoTa ,YeuCau = @YeuCau ,QuyenLoi = @QuyenLoi , DiaChi = @DiaChi , Luong = @Luong , KhuVuc = @KhuVuc ,KinhNghiem = @KinhNghiem , ChucVu = @ChucVu , SoLuongCanTuyen = @SoLuongCanTuyen , CheDoLamViec = @CheDoLamViec , GioiTinh = @GioiTinh , NganhNghe = @NganhNghe , KyNang = @KyNang WHERE Id = @Id ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { post.Jd, post.Requirement, post.Interest, post.Address, post.Salary, post.Location, post.Experience, post.Position, post.Quantity, post.WorkMode, post.Gender, post.Career, post.Skill , post.IdPost});
        }

        public PostDTO GetPostById(int id) 
        {
            string query = string.Format("SELECT * FROM Post inner join PostDetail on Post.id = PostDetail.id WHERE Post.id = {0}", id);
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            PostDTO post = new PostDTO(dataTable);
            return post;
        }
        public int[] GetAllIdPostById(int id)
        {
            string query = string.Format("SELECT * FROM Post Where IdEmployer = {0}",id);
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            int[] dt = new int[dataTable.Rows.Count];
            int index=0;
            foreach (DataRow row in dataTable.Rows)
            {
                dt[index]=(int)row["Id"];
                index++;
            }
            return dt;
        }
        public int[] GetAllIdNotPause()
        {
            string query = string.Format("SELECT * FROM Post Where TrangThai = 1");
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            int[] dt = new int[dataTable.Rows.Count];
            int index = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                dt[index] = (int)row["Id"];
                index++;
            }
            return dt;
        }
        public int[] SearchPost(string NameJob,string Location,string Exp,string Salary) 
        {
            int[] result = null;
            string query = "SELECT * FROM Post inner join PostDetail on Post.id = PostDetail.id WHERE ";
            bool isFirst = true;
            if (!string.IsNullOrWhiteSpace(NameJob))
            {
                query += $"TenCongViec LIKE N'%{NameJob}%' ";
                isFirst = false;
            }
            if (!string.IsNullOrWhiteSpace(Location))
            {
                if (!isFirst)
                {
                    query += "AND ";
                }
                query += $"KhuVuc = N'{Location}' ";
                isFirst = false;

            }
            if (!string.IsNullOrWhiteSpace(Exp))
            {
                if (!isFirst)
                {
                    query += "AND ";
                }
                query += $"KinhNghiem = N'{Exp}' ";
                isFirst = false;

            }
            if (!string.IsNullOrWhiteSpace(Salary))
            {
                if (!isFirst)
                {
                    query += "AND ";
                }
                query += $"Luong = N'{Salary}' ";
                isFirst = false;

            }
            query += "AND TrangThai = 1";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            result = new int[dataTable.Rows.Count];
            int index = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                result[index] = (int)row["Id"];
                index++;
            }
            return result;
        }
        public int[] SearchPostByName(string Name)
        {
            int[] result = null;
            string query = string.Format("SELECT * FROM Post WHERE TenCongViec LIKE N'%{0}%' AND IdEmployer = {1}",Name,AccountDAO.UserID);
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            result = new int[dataTable.Rows.Count];
            int index = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                result[index] = (int)row["Id"];
                index++;
            }
            return result;
        }
        public void DeletePostById(int id)
        {
            string query = string.Format("DELETE FROM PostDetail WHERE Id = {0}", id);
            DataProvider.Instance.ExecuteNonQuery(query);
            query = string.Format("DELETE FROM Post WHERE Id = {0}", id);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}

