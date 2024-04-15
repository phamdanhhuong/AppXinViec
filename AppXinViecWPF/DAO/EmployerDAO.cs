using AppXinViecWPF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DAO
{
    internal class EmployerDAO
    {
        public EmployerDAO() { }
        private static EmployerDAO instance;

        public static EmployerDAO Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployerDAO();
                }
                return instance;
            } 
            private set => instance = value; 
        }
        public void Add(EmployerDTO employer)
        {
            //// Lay ID
            object Id = null;
            string sqlStrGetId = string.Format("SELECT Max(Id) as LastID FROM Account");
            Id = DataProvider.Instance.ExecuteScalar(sqlStrGetId);
            //// them thong tin
            string sqlStr = string.Format("INSERT INTO  EmployerInfo (Id,Ten,GioiTinh,SDT,ChucVu,TenCongTy,DiaChiCongTy,Website,MSThue,SDTCongTY,EmailCongTY,QuyMo,ChungChi,Logo) VALUES ( @Id , @Ten , @GioiTinh , @SDT , @ChucVu , @TenCongTy , @DiaChiCongTy , @Website , @MSThue , @SDTCongTY , @EmailCongTY , @QuyMo , @ChungChi , @Logo )");
            DataProvider.Instance.ExecuteNonQuery(sqlStr, new object[] { int.Parse(Id.ToString()), employer.Name, employer.Gender, employer.Phone, employer.Position, employer.NameCompany, employer.AddressCompany, employer.Website, employer.TaxCode, employer.PhoneCompany, employer.EmailCompany, employer.HumanScale , employer.CertificatePath, employer.LogoPath});
        }
        public void UpdateInfo(EmployerDTO employer)
        {
            string query = string.Format("UPDATE EmployerInfo SET Ten = N'{0}', GioiTinh = N'{1}', SDT = N'{2}', ChucVu = N'{3}', GioiThieu = N'{4}', Logo = N'{5}' WHERE Id = {6} ", employer.Name,employer.Gender,employer.Phone,employer.Position,employer.Intro,employer.LogoPath,AccountDAO.UserID);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public EmployerDTO GetInfoById(int id) 
        {
            string query = string.Format("SELECT * FROM EmployerInfo WHERE Id = {0} ",id);
            DataTable data= DataProvider.Instance.ExecuteQuery(query);
            EmployerDTO info = new EmployerDTO(data);
            return info;
        }
    }
}
