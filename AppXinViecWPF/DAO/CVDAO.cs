using AppXinViecWPF.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AppXinViecWPF.DAO
{
    internal class CVDAO
    {
        CVDAO() { }
        private static CVDAO instance;
        public static CVDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CVDAO();
                return instance;
            }
            private set { instance = value; }
        }


        public void CreateCV(CV cv)
        {
            string query = "INSERT INTO Cv(IdApplicant, NgayTao, NgaySua, TenCV, HoVaTen, ViTriUngTuyen, Avatar, SDT, GioiTinh, Email, NgaySinh, TrangCaNhan, DiaChi, NganhHoc, TenTruong, ThoiGianHoc, ThanhTich, CongViecCu, CongTyCu, ThoiGianLamViec, MoTaKinhNghiem, TenDuAn, ViTriTrongDuAn, ThoiGianLamDuAn, MoTaHoatDong, MucTieu, KyNang, ChungChi, SoThich, ThongTinThem) VALUES( @IdApplicant , @NgayTao , @NgaySua , @TenCV , @HoVaTen , @ViTriUngTuyen , @Avatar , @SDT , @GioiTinh , @Email , @NgaySinh , @TrangCaNhan , @DiaChi , @NganhHoc , @TenTruong , @ThoiGianHoc , @ThanhTich , @CongViecCu , @CongTyCu , @ThoiGianLamViec , @MoTaKinhNghiem , @TenDuAn , @ViTriTrongDuAn , @ThoiGianLamDuAn , @MoTaHoatDong , @MucTieu , @KyNang , @ChungChi , @SoThich , @ThongTinThem )";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] {cv.IdApplicant,cv.NgayTao.ToString("yyyy-MM-dd"), cv.NgaySua.ToString("yyyy-MM-dd"), cv.TenCV,cv.HoVaTen,cv.ViTriUngTuyen,cv.Avatar,cv.SDT,cv.GioiTinh,cv.Email,cv.NgaySinh.ToString("yyyy-MM-dd"), cv.TrangCaNhan,cv.DiaChi,cv.NganhHoc,cv.TenTruong,cv.ThoiGianHoc,cv.ThanhTich,cv.CongViecCu,cv.CongTyCu,cv.ThoiGianLamViec,cv.MoTaKinhNghiem,cv.TenDuAn,cv.ViTriTrongDuAn,cv.ThoiGianLamDuAn,cv.MoTaHoatDong,cv.MucTieu,cv.KyNang,cv.ChungChi,cv.SoThich,cv.ThongTinThem});
        }
        public void EditCV(CV cv)
        {
            //string query = $"UPDATE Cv SET IdApplicant = @IdApplicant , NgayTao= @NgayTao , NgaySua= @NgaySua ,TenCV= @TenCV ,HoVaTen= @HoVaTen ,ViTriUngTuyen= @ViTriUngTuyen ,Avatar= @Avatar ,SDT= @SDT ,GioiTinh= @GioiTinh ,Email= @Email ,NgaySinh= @NgaySinh ,TrangCaNhan= @TrangCaNhan ,DiaChi= @DiaChi ,NganhHoc= @NganhHoc ,TenTruong= @TenTruong ,ThoiGianHoc= @ThoiGianHoc ,ThanhTich= @ThanhTich ,CongViecCu= @CongViecCu ,CongTyCu= @CongTyCu ,ThoiGianLamViec= @ThoiGianLamViec ,MoTaKinhNghiem= @MoTaKinhNghiem ,TenDuAn= @TenDuAn ,ViTriTrongDuAn= @ViTriTrongDuAn ,ThoiGianLamDuAn= @ThoiGianLamDuAn ,MoTaHoatDong= @MoTaHoatDong ,MucTieu= @MucTieu ,KyNang= @KyNang ,ChungChi= @ChungChi ,SoThich= @SoThich ,ThongTinThem= @ThongTinThem WHERE Id = {cv.Id}";
            //DataProvider.Instance.ExecuteNonQuery(query, new object[] { cv.IdApplicant, cv.NgayTao.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), cv.TenCV, cv.HoVaTen, cv.ViTriUngTuyen, cv.Avatar, cv.SDT, cv.GioiTinh, cv.Email, cv.NgaySinh.ToString("yyyy-MM-dd"), cv.TrangCaNhan, cv.DiaChi, cv.NganhHoc, cv.TenTruong, cv.ThoiGianHoc, cv.ThanhTich, cv.CongViecCu, cv.CongTyCu, cv.ThoiGianLamViec, cv.MoTaKinhNghiem, cv.TenDuAn, cv.ViTriTrongDuAn, cv.ThoiGianLamDuAn, cv.MoTaHoatDong, cv.MucTieu, cv.KyNang, cv.ChungChi, cv.SoThich, cv.ThongTinThem });
            string query = $"UPDATE Cv SET IdApplicant = N'{cv.IdApplicant}' , NgayTao = N'{cv.NgayTao.ToString("yyyy-MM-dd")}' , NgaySua = N'{DateTime.Now.ToString("yyyy-MM-dd")}' , TenCV = N'{cv.TenCV}' ,HoVaTen= N'{cv.HoVaTen}' , ViTriUngTuyen = N'{cv.ViTriUngTuyen}' , Avatar = N'{cv.Avatar}' , SDT = N'{cv.SDT}' , GioiTinh = N'{cv.GioiTinh}' , Email = N'{cv.Email}' , NgaySinh = N'{cv.NgaySinh.ToString("yyyy-MM-dd")}' , TrangCaNhan = N'{cv.TrangCaNhan}' , DiaChi = N'{cv.DiaChi}' , NganhHoc = N'{cv.NganhHoc}' , TenTruong = N'{cv.TenTruong}' , ThoiGianHoc = N'{cv.ThoiGianHoc}' , ThanhTich = N'{cv.ThanhTich}' , CongViecCu = N'{cv.CongViecCu}' , CongTyCu = N'{cv.CongTyCu}' , ThoiGianLamViec = N'{cv.ThoiGianLamViec}' , MoTaKinhNghiem = N'{cv.MoTaKinhNghiem}' , TenDuAn = N'{cv.TenDuAn}' , ViTriTrongDuAn = N'{cv.ViTriTrongDuAn}' , ThoiGianLamDuAn = N'{cv.ThoiGianLamDuAn}' , MoTaHoatDong = N'{cv.MoTaHoatDong}' , MucTieu = N'{cv.MucTieu}' , KyNang = N'{cv.KyNang}' , ChungChi = N'{cv.ChungChi}' , SoThich = N'{cv.SoThich}' , ThongTinThem = N'{cv.ThongTinThem}' WHERE Id = {cv.Id}";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int[] GetAllIdCvById(int id)
        {
            string query = string.Format("SELECT * FROM Cv Where IdApplicant = {0}", id);
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

        public CV GetCvById(int id)
        {
            string query = string.Format("SELECT * FROM Cv Where Id = {0}", id);
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            CV dt = new CV(dataTable);
            return dt;
        }
        public void DeleteCvById(int id)
        {
            string query = string.Format("DELETE FROM Cv WHERE Id = {0}", id);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
