using AppXinViecWPF.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXinViecWPF.DTO
{
    internal class CV
    {
        int id;
        int idApplicant;
        DateTime ngayTao;
        DateTime ngaySua;
        string tenCV;
        string hoVaTen;
        string viTriUngTuyen;
        string avatar;
        string sDT;
        string gioiTinh;
        string email;
        DateTime ngaySinh;
        string trangCaNhan;
        string diaChi;
        string nganhHoc;
        string tenTruong;
        string thoiGianHoc;
        string thanhTich;
        string congViecCu;
        string congTyCu;
        string thoiGianLamViec;
        string moTaKinhNghiem;
        string tenDuAn;
        string viTriTrongDuAn;
        string thoiGianLamDuAn;
        string moTaHoatDong;
        string mucTieu;
        string kyNang;
        string chungChi;
        string soThich;
        string thongTinThem;

        public int Id { get => id; set => id = value; }
        public int IdApplicant { get => idApplicant; set => idApplicant = value; }
        public DateTime NgayTao { get => ngayTao; set => ngayTao = value; }
        public DateTime NgaySua { get => ngaySua; set => ngaySua = value; }
        public string TenCV { get => tenCV; set => tenCV = value; }
        public string HoVaTen { get => hoVaTen; set => hoVaTen = value; }
        public string ViTriUngTuyen { get => viTriUngTuyen; set => viTriUngTuyen = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string Email { get => email; set => email = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string TrangCaNhan { get => trangCaNhan; set => trangCaNhan = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NganhHoc { get => nganhHoc; set => nganhHoc = value; }
        public string TenTruong { get => tenTruong; set => tenTruong = value; }
        public string ThoiGianHoc { get => thoiGianHoc; set => thoiGianHoc = value; }
        public string ThanhTich { get => thanhTich; set => thanhTich = value; }
        public string CongViecCu { get => congViecCu; set => congViecCu = value; }
        public string CongTyCu { get => congTyCu; set => congTyCu = value; }
        public string ThoiGianLamViec { get => thoiGianLamViec; set => thoiGianLamViec = value; }
        public string MoTaKinhNghiem { get => moTaKinhNghiem; set => moTaKinhNghiem = value; }
        public string TenDuAn { get => tenDuAn; set => tenDuAn = value; }
        public string ViTriTrongDuAn { get => viTriTrongDuAn; set => viTriTrongDuAn = value; }
        public string ThoiGianLamDuAn { get => thoiGianLamDuAn; set => thoiGianLamDuAn = value; }
        public string MoTaHoatDong { get => moTaHoatDong; set => moTaHoatDong = value; }
        public string MucTieu { get => mucTieu; set => mucTieu = value; }
        public string KyNang { get => kyNang; set => kyNang = value; }
        public string ChungChi { get => chungChi; set => chungChi = value; }
        public string SoThich { get => soThich; set => soThich = value; }
        public string ThongTinThem { get => thongTinThem; set => thongTinThem = value; }

        public CV(int idApplicant, string tenCV, string hoVaTen, string viTriUngTuyen, string avatar, string sDT, string gioiTinh, string email, DateTime ngaySinh, string trangCaNhan, string diaChi, string nganhHoc, string tenTruong, string thoiGianHoc, string thanhTich, string congViecCu, string congTyCu, string thoiGianLamViec, string moTaKinhNghiem, string tenDuAn, string viTriTrongDuAn, string thoiGianLamDuAn, string moTaHoatDong, string mucTieu, string kyNang, string chungChi, string soThich, string thongTinThem)
        {
            IdApplicant = idApplicant;
            NgayTao = DateTime.Now;
            NgaySua = DateTime.Now;
            TenCV = tenCV;
            HoVaTen = hoVaTen;
            ViTriUngTuyen = viTriUngTuyen;
            Avatar = avatar;
            SDT = sDT;
            GioiTinh = gioiTinh;
            Email = email;
            NgaySinh = ngaySinh;
            TrangCaNhan = trangCaNhan;
            DiaChi = diaChi;
            NganhHoc = nganhHoc;
            TenTruong = tenTruong;
            ThoiGianHoc = thoiGianHoc;
            ThanhTich = thanhTich;
            CongViecCu = congViecCu;
            CongTyCu = congTyCu;
            ThoiGianLamViec = thoiGianLamViec;
            MoTaKinhNghiem = moTaKinhNghiem;
            TenDuAn = tenDuAn;
            ViTriTrongDuAn = viTriTrongDuAn;
            ThoiGianLamDuAn = thoiGianLamDuAn;
            MoTaHoatDong = moTaHoatDong;
            MucTieu = mucTieu;
            KyNang = kyNang;
            ChungChi = chungChi;
            SoThich = soThich;
            ThongTinThem = thongTinThem;
        }

        public CV(int id,int idApplicant, string tenCV, string hoVaTen, string viTriUngTuyen, string avatar, string sDT, string gioiTinh, string email, DateTime ngaySinh, string trangCaNhan, string diaChi, string nganhHoc, string tenTruong, string thoiGianHoc, string thanhTich, string congViecCu, string congTyCu, string thoiGianLamViec, string moTaKinhNghiem, string tenDuAn, string viTriTrongDuAn, string thoiGianLamDuAn, string moTaHoatDong, string mucTieu, string kyNang, string chungChi, string soThich, string thongTinThem)
        {
            Id = id;    
            IdApplicant = idApplicant;
            NgayTao = DateTime.Now;
            NgaySua = DateTime.Now;
            TenCV = tenCV;
            HoVaTen = hoVaTen;
            ViTriUngTuyen = viTriUngTuyen;
            Avatar = avatar;
            SDT = sDT;
            GioiTinh = gioiTinh;
            Email = email;
            NgaySinh = ngaySinh;
            TrangCaNhan = trangCaNhan;
            DiaChi = diaChi;
            NganhHoc = nganhHoc;
            TenTruong = tenTruong;
            ThoiGianHoc = thoiGianHoc;
            ThanhTich = thanhTich;
            CongViecCu = congViecCu;
            CongTyCu = congTyCu;
            ThoiGianLamViec = thoiGianLamViec;
            MoTaKinhNghiem = moTaKinhNghiem;
            TenDuAn = tenDuAn;
            ViTriTrongDuAn = viTriTrongDuAn;
            ThoiGianLamDuAn = thoiGianLamDuAn;
            MoTaHoatDong = moTaHoatDong;
            MucTieu = mucTieu;
            KyNang = kyNang;
            ChungChi = chungChi;
            SoThich = soThich;
            ThongTinThem = thongTinThem;
        }
        public CV(DataTable data)
        {
            Id = int.Parse(data.Rows[0]["Id"].ToString());
            IdApplicant = int.Parse(data.Rows[0]["IdApplicant"].ToString());
            NgayTao = DateTime.Parse(data.Rows[0]["NgayTao"].ToString()); ;
            NgaySua = DateTime.Parse(data.Rows[0]["NgaySua"].ToString()); ;
            TenCV = data.Rows[0]["TenCV"].ToString();
            HoVaTen = data.Rows[0]["HoVaTen"].ToString();
            ViTriUngTuyen = data.Rows[0]["ViTriUngTuyen"].ToString();
            Avatar = data.Rows[0]["Avatar"].ToString();
            SDT = data.Rows[0]["SDT"].ToString();
            GioiTinh = data.Rows[0]["GioiTinh"].ToString();
            Email = data.Rows[0]["Email"].ToString();
            NgaySinh = DateTime.Parse(data.Rows[0]["NgaySinh"].ToString()); ;
            TrangCaNhan = data.Rows[0]["TrangCaNhan"].ToString();
            DiaChi = data.Rows[0]["DiaChi"].ToString();
            NganhHoc = data.Rows[0]["NganhHoc"].ToString();
            TenTruong = data.Rows[0]["TenTruong"].ToString();
            ThoiGianHoc = data.Rows[0]["ThoiGianHoc"].ToString();
            ThanhTich = data.Rows[0]["ThanhTich"].ToString();
            CongViecCu = data.Rows[0]["CongViecCu"].ToString();
            CongTyCu = data.Rows[0]["CongTyCu"].ToString();
            ThoiGianLamViec = data.Rows[0]["ThoiGianLamViec"].ToString();
            MoTaKinhNghiem = data.Rows[0]["MoTaKinhNghiem"].ToString();
            TenDuAn = data.Rows[0]["TenDuAn"].ToString();
            ViTriTrongDuAn = data.Rows[0]["ViTriTrongDuAn"].ToString();
            ThoiGianLamDuAn = data.Rows[0]["ThoiGianLamDuAn"].ToString();
            MoTaHoatDong = data.Rows[0]["MoTaHoatDong"].ToString();
            MucTieu = data.Rows[0]["MucTieu"].ToString();
            KyNang = data.Rows[0]["KyNang"].ToString();
            ChungChi = data.Rows[0]["ChungChi"].ToString();
            SoThich = data.Rows[0]["SoThich"].ToString();
            ThongTinThem = data.Rows[0]["ThongTinThem"].ToString();
        }
    }
}
