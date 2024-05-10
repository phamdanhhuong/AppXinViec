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
	ThongTinThem NVARCHAR(150),
	TrangThai INT DEFAULT 0 --0: ko cong khai, 1 : cong khai
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

Create table PVDay
(
	Id INT IDENTITY PRIMARY KEY,
	Chon int default 0, -- 0 la khong duoc chon, 1 la duoc chon
	IdCV INT FOREIGN KEY REFERENCES Cv(Id),
	IdPost INT FOREIGN KEY REFERENCES Post(Id),
	Ngay date ,
	ThoiGian NVARCHAR(150),
	DiaDiem NVARCHAR(150)
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

Create table PostCV
(
	Id INT IDENTITY PRIMARY KEY,
	IdCV INT FOREIGN KEY REFERENCES Cv(Id),
	TieuDe ntext,
	NoiDung ntext,
	NgayDang date
)
GO
