CREATE database XinViec
GO

Use XinViec
GO

Create table Account
(
	Id INT IDENTITY PRIMARY KEY,
	Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
	Email NVARCHAR(100),
	Role INT default 0 NOT NULL --0 là ứng viên , 1 là nhà tuyển dụng
)
GO


Create table ApplicantInfo
(
	Id INT PRIMARY KEY REFERENCES Account(Id),
	Ten NVARCHAR(100) NOT NULL,
	GioiTinh NVARCHAR(5) NOT NULL,
	SDT NVARCHAR(20) NOT NULL,
	NgaySinh date NOT NULL
)
GO

Create table EmployerInfo
(
	Id INT PRIMARY KEY REFERENCES Account(Id),
	Ten NVARCHAR(100) NOT NULL,
	GioiTinh NVARCHAR(5) NOT NULL,
	SDT NVARCHAR(20) NOT NULL,
	ChucVu NVARCHAR(100),
	TenCongTy NVARCHAR(100),
	DiaChiCongTy NVARCHAR(200),
	Website NVARCHAR(100),
	MSThue NVARCHAR(100),
	SDTCongTY NVARCHAR(100),
	EmailCongTY NVARCHAR(100),
	QuyMo NVARCHAR(100),
	ChungChi NVARCHAR(100),
	Logo NVARCHAR(100),
	GioiThieu ntext Default N'Không có'
)
GO

Create table Post
(
	Id INT IDENTITY PRIMARY KEY,
	IdEmployer INT FOREIGN KEY REFERENCES EmployerInfo(Id),
	TenCongViec NVARCHAR(100),
	HanNopHoSo date,
	TrangThai int default 1, -- 1 là đang hiển thị, 0 là pause
)
GO

Create table PostDetail
(
	Id INT PRIMARY KEY REFERENCES Post(Id),
	MoTa ntext,
	YeuCau ntext,
	QuyenLoi ntext,
	DiaChi ntext,
	Luong NVARCHAR(50),
	KhuVuc NVARCHAR(50),
	KinhNghiem NVARCHAR(50),
	ChucVu NVARCHAR(50),
	SoLuongCanTuyen NVARCHAR(50),
	CheDoLamViec NVARCHAR(50),
	GioiTinh NVARCHAR(50),
	NganhNghe NVARCHAR(50),
	KyNang NVARCHAR(50)
)
GO

Create table Cv
(
	Id INT IDENTITY PRIMARY KEY,
	IdApplicant INT FOREIGN KEY REFERENCES ApplicantInfo(Id),
	NgayTao date,
	NgaySua date,
	TenCV ntext,
	HoVaTen ntext,
	ViTriUngTuyen ntext,
	Avatar NVARCHAR(150),
	SDT NVARCHAR(50),
	GioiTinh NVARCHAR(50),
	Email NVARCHAR(50),
	NgaySinh date,
	TrangCaNhan NVARCHAR(150),
	DiaChi NVARCHAR(150),
	NganhHoc NVARCHAR(150),
	TenTruong NVARCHAR(150),
	ThoiGianHoc NVARCHAR(150),
	ThanhTich NVARCHAR(150),
	CongViecCu NVARCHAR(150),
	CongTyCu NVARCHAR(150),
	ThoiGianLamViec NVARCHAR(150),
	MoTaKinhNghiem NVARCHAR(150),
	TenDuAn NVARCHAR(150),
	ViTriTrongDuAn NVARCHAR(150),
	ThoiGianLamDuAn NVARCHAR(150),
	MoTaHoatDong NVARCHAR(150),
	MucTieu NVARCHAR(150),
	KyNang NVARCHAR(150),
	ChungChi NVARCHAR(150),
	SoThich NVARCHAR(150),
	ThongTinThem NVARCHAR(150)
)
GO

Create table ApplyCV
(
	IdCV INT FOREIGN KEY REFERENCES Cv(Id),
	IdPost INT FOREIGN KEY REFERENCES Post(Id),
	NgayNop date ,
	Duyet int default 0, --0:chua duyet 1:da duyet
	XacNhan int default 0,--0 la chua xac nhan, 1 la di
	CONSTRAINT PK_ApplyCV PRIMARY KEY (IdCV,IdPost)
)
GO

Create table FavJob
(
	IdApplicant INT FOREIGN KEY REFERENCES ApplicantInfo(Id),
	IdPost INT FOREIGN KEY REFERENCES Post(Id),
	CONSTRAINT PK_FavJob PRIMARY KEY (IdApplicant,IdPost)
)
GO

Create table FavCompany
(
	IdApplicant INT FOREIGN KEY REFERENCES ApplicantInfo(Id),
	IdEmployer INT FOREIGN KEY REFERENCES EmployerInfo(Id),
	CONSTRAINT PK_FavCompany PRIMARY KEY (IdApplicant,IdEmployer)
)
GO

Create table FavCV
(
	IdEmployer INT FOREIGN KEY REFERENCES EmployerInfo(Id),
	IdCV INT FOREIGN KEY REFERENCES Cv(Id),
	CONSTRAINT PK_FavCV PRIMARY KEY (IdEmployer,IdCV)
)
GO


--INSERT INTO Cv (IdApplicant, NgayTao, NgaySua, TenCV, HoVaTen, ViTriUngTuyen, Avatar, SDT, GioiTinh, Email, NgaySinh, TrangCaNhan, DiaChi, NganhHoc, TenTruong, ThoiGianHoc, ThanhTich, CongViecCu, CongTyCu, ThoiGianLamViec, MoTaKinhNghiem, TenDuAn, ViTriTrongDuAn, ThoiGianLamDuAn, MoTaHoatDong, MucTieu, KyNang, ChungChi, SoThich,ThongTinThem)
--SELECT * FROM EmployerInfo WHERE Id = @Id
--SELECT * FROM Post inner join PostDetail on Post.id = PostDetail.id WHERE Post.id = 3
--INSERT INTO EmployerInfo(Id,Ten,GioiTinh,SDT,ChucVu,TenCongTy,DiaChiCongTy) VALUES (1,N'Hưởng',N'Nam',N'0111111111',N'Nhân viên',N'TNHH ABC',N'test')
--INSERT INTO PostDetail(Id,MoTa,YeuCau,QuyenLoi,DiaChi,Luong,KhuVuc,KinhNghiem,ChucVu,SoLuongCanTuyen,CheDoLamViec,GioiTinh,NganhNghe,KyNang) VALUES()

--select * from Cv where id = 3
--select * from PostDetail

--Alter table EmployerInfo add GioiThieu ntext Default N'Không có'
--Alter table ApplyCV add 

--SELECT * FROM Post inner join PostDetail on Post.id = PostDetail.id WHERE 

--UPDATE Cv SET IdApplicant = 2 , NgayTao = '2004-2-20' , NgaySua = '2004-2-20' , TenCV = '2004-2-20' ,HoVaTen= '2004-2-20' , ViTriUngTuyen = '2004-2-20' , Avatar = 'F:\HK2\Lap trinh window\Đồ án\currently\AppXinViecWPF\Image\bg_login.jpg' , SDT = '2004-2-20' , GioiTinh = '2004-2-20' , Email = '2004-2-20' , NgaySinh = '2004-2-20' , TrangCaNhan = '2004-2-20' , DiaChi = '2004-2-20' , NganhHoc = '2004-2-20' , TenTruong = '2004-2-20' , ThoiGianHoc = '2004-2-20' , ThanhTich = '2004-2-20' , CongViecCu = '2004-2-20' , CongTyCu = '2004-2-20' , ThoiGianLamViec = '2004-2-20' , MoTaKinhNghiem = '2004-2-20' , TenDuAn = '2004-2-20' , ViTriTrongDuAn = '2004-2-20' , ThoiGianLamDuAn = '2004-2-20' , MoTaHoatDong = '2004-2-20' , MucTieu = '2004-2-20' , KyNang = '2004-2-20' , ChungChi = '2004-2-20' , SoThich = '2004-2-20' , ThongTinThem = '2004-2-20' WHERE Id = 4
--//string query = $"UPDATE Cv SET IdApplicant = N'{cv.IdApplicant}' , NgayTao = N'{cv.NgayTao.ToString("yyyy-MM-dd")}' , NgaySua = N'{DateTime.Now.ToString("yyyy-MM-dd")}' , TenCV = N'{cv.TenCV}' ,HoVaTen= N'{cv.HoVaTen}' , ViTriUngTuyen = N'{cv.ViTriUngTuyen}' , Avatar = N'{cv.Avatar}' , SDT = N'{cv.SDT}' , GioiTinh = N'{cv.GioiTinh}' , Email = N'{cv.Email}' , NgaySinh = N'{cv.NgaySinh.ToString("yyyy-MM-dd")}' , TrangCaNhan = N'{cv.TrangCaNhan}' , DiaChi = N'{cv.DiaChi}' , NganhHoc = @N'{cv.NganhHoc}' , TenTruong = N'{cv.TenTruong}' , ThoiGianHoc = N'{cv.ThoiGianHoc}' , ThanhTich = N'{cv.ThanhTich}' , CongViecCu = N'{cv.CongViecCu}' , CongTyCu = N'{cv.CongTyCu}' , ThoiGianLamViec = N'{cv.ThoiGianLamViec}' , MoTaKinhNghiem = N'{cv.MoTaKinhNghiem}' , TenDuAn = N'{cv.TenDuAn}' , ViTriTrongDuAn = N'{cv.ViTriTrongDuAn}' , ThoiGianLamDuAn = N'{cv.ThoiGianLamDuAn}' , MoTaHoatDong = N'{cv.MoTaHoatDong}' , MucTieu = N'{cv.MucTieu}' , KyNang = N'{cv.KyNang}' , ChungChi = N'{cv.ChungChi}' , SoThich = N'{cv.SoThich}' , ThongTinThem = N'{cv.ThongTinThem}' WHERE Id = {cv.Id}";
--//DataProvider.Instance.ExecuteNonQuery(query);
--INSERT INTO FavJob (IdApplicant,IdPost) VALUES (2,11)

--UPDATE ApplyCV SET Duyet=1 WHERE IdCV = 11 AND IdPost = 13

--SELECT COUNT(*) FROM FavCompany WHERE IdEmployer = 1
--SELECT IdEmployer FROM FavCompany GROUP BY IdEmployer ORDER BY COUNT(IdApplicant) DESC