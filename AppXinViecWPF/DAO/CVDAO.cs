using AppXinViecWPF.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public CV GetCVById(int id)
        {
            CV cV = null;

            return cV;
        }

        public void CreateCV(CV cv)
        {
            string query = "INSERT INTO Cv(IdApplicant, NgayTao, NgaySua, TenCV, HoVaTen, ViTriUngTuyen, Avatar, SDT, GioiTinh, Email, NgaySinh, TrangCaNhan, DiaChi, NganhHoc, TenTruong, ThoiGianHoc, ThanhTich, CongViecCu, CongTyCu, ThoiGianLamViec, MoTaKinhNghiem, TenDuAn, ViTriTrongDuAn, ThoiGianLamDuAn, MoTaHoatDong, MucTieu, KyNang, ChungChi, SoThich, ThongTinThem) VALUES( @IdApplicant , @NgayTao , @NgaySua , @TenCV , @HoVaTen , @ViTriUngTuyen , @Avatar , @SDT , @GioiTinh , @Email , @NgaySinh , @TrangCaNhan , @DiaChi , @NganhHoc , @TenTruong , @ThoiGianHoc , @ThanhTich , @CongViecCu , @CongTyCu , @ThoiGianLamViec , @MoTaKinhNghiem , @TenDuAn , @ViTriTrongDuAn , @ThoiGianLamDuAn , @MoTaHoatDong , @MucTieu , @KyNang , @ChungChi , @SoThich , @ThongTinThem )";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] {cv.IdApplicant,cv.NgayTao.ToString("yyyy-MM-dd"), cv.NgaySua.ToString("yyyy-MM-dd"), cv.TenCV,cv.HoVaTen,cv.ViTriUngTuyen,cv.Avatar,cv.SDT,cv.GioiTinh,cv.Email,cv.NgaySinh.ToString("yyyy-MM-dd"), cv.TrangCaNhan,cv.DiaChi,cv.NganhHoc,cv.TenTruong,cv.ThoiGianHoc,cv.ThanhTich,cv.CongViecCu,cv.CongTyCu,cv.ThoiGianLamViec,cv.MoTaKinhNghiem,cv.TenDuAn,cv.ViTriTrongDuAn,cv.ThoiGianLamDuAn,cv.MoTaHoatDong,cv.MucTieu,cv.KyNang,cv.ChungChi,cv.SoThich,cv.ThongTinThem});
        }
    }
}
