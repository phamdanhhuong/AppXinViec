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


SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [Username], [Password], [Email], [Role]) VALUES (1, N'user', N'1', N'exm@gmail.com', 0)
INSERT [dbo].[Account] ([Id], [Username], [Password], [Email], [Role]) VALUES (2, N'emp1', N'1', N'exam@gmail.com', 1)
INSERT [dbo].[Account] ([Id], [Username], [Password], [Email], [Role]) VALUES (3, N'emp2', N'1', N'exam@gmail.com', 1)
INSERT [dbo].[Account] ([Id], [Username], [Password], [Email], [Role]) VALUES (4, N'emp3', N'1', N'lotus@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[ApplicantInfo] ([Id], [Ten], [GioiTinh], [SDT], [NgaySinh]) VALUES (1, N'Pham A', N'Nam', N'0962153686', CAST(N'1996-01-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Cv] ON 

INSERT [dbo].[Cv] ([Id], [IdApplicant], [NgayTao], [NgaySua], [TenCV], [HoVaTen], [ViTriUngTuyen], [Avatar], [SDT], [GioiTinh], [Email], [NgaySinh], [TrangCaNhan], [DiaChi], [NganhHoc], [TenTruong], [ThoiGianHoc], [ThanhTich], [CongViecCu], [CongTyCu], [ThoiGianLamViec], [MoTaKinhNghiem], [TenDuAn], [ViTriTrongDuAn], [ThoiGianLamDuAn], [MoTaHoatDong], [MucTieu], [KyNang], [ChungChi], [SoThich], [ThongTinThem], [TrangThai]) VALUES (1, 1, CAST(N'2024-05-10' AS Date), CAST(N'2024-05-10' AS Date), N'Nhân viên IT', N'Phạm Văn A', N'Dev', N'Image\no_avatar_color.png', N'0962352478', N'Nam', N'exam@gmail.com', CAST(N'2004-01-20' AS Date), N'face.com', N'Thành phố Thủ Đức', N'CNTT', N'SPKT', N'2022-2026', N'9.0 GPA', N'Wep dev', N'TNNN ABC', N'2023-2024', N'Lập trình web', N'App xin việc', N'full-stack', N'2023-2024', N'Lập trình FE, BE', N'Làm PM', N'Lập trình OOP', N'Toiec 900', N'Phim', N'Không có', 0)
INSERT [dbo].[Cv] ([Id], [IdApplicant], [NgayTao], [NgaySua], [TenCV], [HoVaTen], [ViTriUngTuyen], [Avatar], [SDT], [GioiTinh], [Email], [NgaySinh], [TrangCaNhan], [DiaChi], [NganhHoc], [TenTruong], [ThoiGianHoc], [ThanhTich], [CongViecCu], [CongTyCu], [ThoiGianLamViec], [MoTaKinhNghiem], [TenDuAn], [ViTriTrongDuAn], [ThoiGianLamDuAn], [MoTaHoatDong], [MucTieu], [KyNang], [ChungChi], [SoThich], [ThongTinThem], [TrangThai]) VALUES (2, 1, CAST(N'2024-05-10' AS Date), CAST(N'2024-05-10' AS Date), N'Maketing', N'Nguyễn Văn A', N'Quảng bá', N'Image\no_avatar_color.png', N'091623731', N'Nữ', N'NVA@gmail.com', CAST(N'1996-02-20' AS Date), N'Face.com', N'Quận 2, TP HCM', N'Kinh tế ', N'SPKT', N'2022-2026', N'8.6 GPA', N'Bán hàng online', N'Shopee', N'2023-2024', N'Bán hàng online trên Shopee', N'Quảng cáo thuốc ', N'Thành viên', N'2023-2024', N'Viết bài quảng cáo', N'Lên làm quản lý', N'Giao tiếp', N'900 toiec', N'Không có', N'không có', 0)
SET IDENTITY_INSERT [dbo].[Cv] OFF
GO
INSERT [dbo].[EmployerInfo] ([Id], [Ten], [GioiTinh], [SDT], [ChucVu], [TenCongTy], [DiaChiCongTy], [Website], [MSThue], [SDTCongTY], [EmailCongTY], [QuyMo], [ChungChi], [Logo], [GioiThieu]) VALUES (2, N'Van B', N'Nam', N'0912367523', N'Nhan vien', N'TNHH FPT', N'HCM', N'fpt.com', N'01238172334', N'1900 1234', N'exam@gmail.com', N'300-500 người', N'Image\certificate.jpg', N'Image\download.png', N'Không có')
INSERT [dbo].[EmployerInfo] ([Id], [Ten], [GioiTinh], [SDT], [ChucVu], [TenCongTy], [DiaChiCongTy], [Website], [MSThue], [SDTCongTY], [EmailCongTY], [QuyMo], [ChungChi], [Logo], [GioiThieu]) VALUES (3, N'Thi C', N'Nữ', N'0965272345', N'Quản lý', N'TNHH VNG', N'Hà Nội', N'vng.com', N'01739372442', N'1800 1243', N'exam@gmail.com', N'trên 1000 người', N'Image\certificate.jpg', N'Image\VNG_GAMES_logo.jpg', N'Không có')
INSERT [dbo].[EmployerInfo] ([Id], [Ten], [GioiTinh], [SDT], [ChucVu], [TenCongTy], [DiaChiCongTy], [Website], [MSThue], [SDTCongTY], [EmailCongTY], [QuyMo], [ChungChi], [Logo], [GioiThieu]) VALUES (4, N'Dang D', N'Nam', N'0987247623', N'Trưởng phòng', N'TNHH LOTUS', N'Đồng Nai', N'lotus.com', N'0123824332', N'1700 1234', N'exam@gmail.com', N'500-1000 người', N'Image\certificate.jpg', N'Image\Ton_hoa_sen.jpg', N'Không có')
GO
INSERT [dbo].[FavCompany] ([IdApplicant], [IdEmployer]) VALUES (1, 3)
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([Id], [IdEmployer], [TenCongViec], [HanNopHoSo], [TrangThai]) VALUES (1, 2, N'IT Phần Mềm', CAST(N'2024-05-22' AS Date), 1)
INSERT [dbo].[Post] ([Id], [IdEmployer], [TenCongViec], [HanNopHoSo], [TrangThai]) VALUES (2, 2, N'Maketing Executive', CAST(N'2024-05-26' AS Date), 1)
INSERT [dbo].[Post] ([Id], [IdEmployer], [TenCongViec], [HanNopHoSo], [TrangThai]) VALUES (3, 3, N'IT Support', CAST(N'2024-05-19' AS Date), 1)
INSERT [dbo].[Post] ([Id], [IdEmployer], [TenCongViec], [HanNopHoSo], [TrangThai]) VALUES (4, 3, N'Digital Maketing', CAST(N'2024-05-12' AS Date), 1)
INSERT [dbo].[Post] ([Id], [IdEmployer], [TenCongViec], [HanNopHoSo], [TrangThai]) VALUES (5, 4, N'IT Infrastructure', CAST(N'2024-05-26' AS Date), 1)
INSERT [dbo].[Post] ([Id], [IdEmployer], [TenCongViec], [HanNopHoSo], [TrangThai]) VALUES (6, 4, N'Maketing Manager', CAST(N'2024-05-27' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[PostCV] ON 

INSERT [dbo].[PostCV] ([Id], [IdCV], [TieuDe], [NoiDung], [NgayDang]) VALUES (1, 1, N'Cần tìm việc IT', N'Tự hào chia sẻ với các bạn một chút về hành trình của mình trong lĩnh vực Công nghệ Thông tin (IT). Từ những ngày đầu tiên khi bắt đầu, mình luôn cảm thấy hồi hộp và không biết phải bắt đầu từ đâu. Nhưng nhờ vào sự quyết tâm và sự hỗ trợ từ cộng đồng, mình đã từng bước tiến lên và trở thành một người học và làm việc trong lĩnh vực này.
Một trong những điều quan trọng nhất mà mình đã học được là sự linh hoạt. Trong thế giới công nghệ đang phát triển nhanh chóng, việc phải thích nghi và học hỏi liên tục là điều không thể tránh khỏi. Mình đã trải qua nhiều dự án khác nhau, từ việc phát triển ứng dụng đến quản lý hệ thống lớn. Mỗi dự án mang đến cho mình những thách thức mới và cơ hội để phát triển kỹ năng.
', CAST(N'2024-05-10' AS Date))
SET IDENTITY_INSERT [dbo].[PostCV] OFF
GO
INSERT [dbo].[PostDetail] ([Id], [MoTa], [YeuCau], [QuyenLoi], [DiaChi], [Luong], [KhuVuc], [KinhNghiem], [ChucVu], [SoLuongCanTuyen], [CheDoLamViec], [GioiTinh], [NganhNghe], [KyNang]) VALUES (1, N'- Đề xuất giải pháp cho yêu cầu
- Tham gia vao việc khảo sát, xây dựng giải pháp tổng thể và chi tiết cho các phần mềm ứng dụng
- Lập trình ứng dụng và kiểm thử hệ thống
- Xử lý lỗi của các phần mềm ứng dụng
', N'Có kinh nghiệm và kiến thức xây dựng kiến trúc ứng dụng phần mềm.
Có kinh nghiệm về lập trình .NET Web/Form (.Net WinForm, .Net Framework, .Net Core, ASP.NET API, C#, Asp.Net MVC.)
Có hiểu biết về lập trình Backend-frontend, Javascript, Html, css, Angular, Bootrap, Typescript.
', N'- Bảo hiểm theo quy định của Nhà Nước
- Được tham gia các chuyến du lịch của Công ty
- Chế độ lương, thưởng và phúc lợi theo qui định của Công ty
', N'Hồ Chí Minh: Số 88 đường số 8, KDC Trung Sơn, Xã Bình Hưng, Bình Chánh', N'25 - 30 triệu', N'Thành phố Hồ Chí Minh', N'trên 2 năm', N'Nhân viên', N'5', N'Toàn thời gian', N'Không yêu cầu', N'IT', N'Lập trình
')
INSERT [dbo].[PostDetail] ([Id], [MoTa], [YeuCau], [QuyenLoi], [DiaChi], [Luong], [KhuVuc], [KinhNghiem], [ChucVu], [SoLuongCanTuyen], [CheDoLamViec], [GioiTinh], [NganhNghe], [KyNang]) VALUES (2, N'Lập kế hoạch và sáng tạo nội dung cho các kênh: Website, Fanpage, TikTok, Youtube,...
Thấu hiểu được insight khách hàng đưa ra content, target hợp lý. Phối hợp với Account Team , Designer lên ý tưởng và kế hoạch, tham gia sản xuất nội dung, và clip giới thiệu sản phẩm, công ty, nhà máy,..
Thực hiện các chiến dịch quảng cáo, theo dõi, đánh giá để tối ưu hóa về giao diện thiết kế, nội dung, chí phí tỉ lệ chuyển đổi của các chiến dịch.
', N'Có kiến thức về mảng bao bì là một lợi thế
Ưu tiên biết thiết kế hình ảnh, video,...
Có khả năng tư duy ngôn ngữ, diễn đạt ý tưởng tốt.
Có khả năng làm việc độc lập, theo nhóm và chịu được áp lực
Quan tâm và luôn cập nhật các xu hướng nội dung hot hay trendy trên social media.
', N'Được trang bị đầy đủ các thiết bị hiện đại để thực hiện công việc: hệ sinh thái Apple
Phụ cấp cơm trưa
Môi trường làm việc hiện đại, đầy đủ tiện nghi
Được hưởng tất cả các chế độ theo luật lao động
', N'Hà Nội', N'15 - 20 triệu', N'Hà Nội', N'trên 1 năm', N'Nhân viên', N'3', N'Toàn thời gian', N'Không yêu cầu', N'Marketing', N'Marketing
')
INSERT [dbo].[PostDetail] ([Id], [MoTa], [YeuCau], [QuyenLoi], [DiaChi], [Luong], [KhuVuc], [KinhNghiem], [ChucVu], [SoLuongCanTuyen], [CheDoLamViec], [GioiTinh], [NganhNghe], [KyNang]) VALUES (3, N'Hỗ trợ toàn bộ hệ thống gồm 100 máy tính và 10 máy in.
Cài đặt và cấu hình phần cứng, phần mềm, mạng máy tính, line điện thoại, ứng dụng cho các end users.
Cập nhật và chỉnh sửa nội dung hình ảnh trên web của công ty khi có yêu cầu.
', N'Độ tuổi: Từ 20 - 28
Biết sử dụng tiếng Anh.
', N'Được làm việc ở môi trường trẻ, năng động.
Được đào tạo, hướng dẫn tận tình.
Phụ cấp cơm trưa.
', N'Hồ Chí Minh: 545 Kinh Dương Vương, P.An Lạc, Bình Tân', N'5 - 7 triệu', N'Thành phố Hồ Chí Minh', N'trên 3 năm', N'Trưởng nhóm', N'4', N'Toàn thời gian', N'Nam', N'IT', N'English
')
INSERT [dbo].[PostDetail] ([Id], [MoTa], [YeuCau], [QuyenLoi], [DiaChi], [Luong], [KhuVuc], [KinhNghiem], [ChucVu], [SoLuongCanTuyen], [CheDoLamViec], [GioiTinh], [NganhNghe], [KyNang]) VALUES (4, N'Quản lý và triển khai các kênh digital marketing (Paid traffic):
Lên ý tưởng, kế hoạch và triển khai các chiến dịch quảng cáo trên các kênh: Tiktok, facebook, google, youtube,...Ưu tiên kênh Tiktok và Facebook.
Lên chủ đề nội dung, hình thức cho các kênh digital marketing nêu trên.
Triển khai các hoạt động quảng cáo trên các kênh trả phí
', N'Có kỹ năng làm việc nhóm
Có khả năng giao tiếp tốt
Trình độ: Đại học thuộc các ngành kinh tế, marketing, quản trị,...
', N'Tham gia các khóa học và kỹ năng chuyên nghiệp để tối ưu hóa bản thân
Thu nhập cạnh tranh, xem xét tăng lương 3 tháng/ lần (tùy năng lực)
Cơ hội thăng tiến và phát triển nghề theo khả năng không giới hạn
Môi trường làm việc năng động, chuyên nghiệp với nét văn hóa doanh nghiệp riêng
', N'Hà Nội: Số 10 Sunrise I - KĐT The Manor Central Park, p Đại Kim, Hoàng Mai', N'10 - 15 triệu', N'Hà Nội', N'trên 1 năm', N'Nhân viên', N'10', N'Toàn thời gian', N'Nữ', N'Marketing', N'Quản lý
')
INSERT [dbo].[PostDetail] ([Id], [MoTa], [YeuCau], [QuyenLoi], [DiaChi], [Luong], [KhuVuc], [KinhNghiem], [ChucVu], [SoLuongCanTuyen], [CheDoLamViec], [GioiTinh], [NganhNghe], [KyNang]) VALUES (5, N'• Provides 24x7 on-call production support for L2.
• Keep monitoring & troubleshooting system including server hardware\Storage\VMware\OS 24\7 SLAs
• Perform maintenance hardware (HPE, DELL), software (OS, ESXi, vCenter...)
', N'• 2+ years of experience in Windows/Linux
• Strong experience with VMware products
• 24x7 on call support
• MCSE or LPI certified Experience working with Linux/Windows
• Experience with Active Directory, DNS, SFTP, NTP, SSH, Syslog servers.
', N'• Working time: Monday – Friday (9:00 AM – 5:30 PM)
• Dynamic and flexible environment with positive teammates
• Competitive income with 13th-month salary
• Health insurance to protect your health, and annual health check
', N'- Hồ Chí Minh: 87A Hàm Nghi, Quận 1', N'Thỏa thuận', N'Thành phố Hồ Chí Minh', N'trên 3 năm', N'Trưởng nhóm', N'1', N'Toàn thời gian', N'Không yêu cầu', N'IT', N'DNS, SFTP, NTP, SSH
')
INSERT [dbo].[PostDetail] ([Id], [MoTa], [YeuCau], [QuyenLoi], [DiaChi], [Luong], [KhuVuc], [KinhNghiem], [ChucVu], [SoLuongCanTuyen], [CheDoLamViec], [GioiTinh], [NganhNghe], [KyNang]) VALUES (6, N'Lập kế hoạch và phát triển chiến lược marketing: chiến lược marketing tổng thể, chiến thuật và hoạt động hàng năm
Quản lý ngân sách MKT, giám sát & đánh giá hiệu quả của các chiến dịch marketing và đề xuất các giải pháp cải tiến.
Xây dựng, quản trị và phát triển thương hiệu.
', N'Tư duy sáng tạo đột phá.
Tư duy chiến lược & phản biện.
Phù hợp văn hóa doanh nghiệp - Yêu thiên nhiên & bảo vệ môi
Có ít nhất 5 năm kinh nghiệm làm việc trong lĩnh vực marketing, trong đó có ít nhất 2 năm kinh
', N'Thưởng theo KPI + Thưởng theo lợi nhuận Quý của Công ty
Giá trị nhân viên nhận được khi làm việc tại công ty
Cơ hội học tập và phát triển
Làm việc môi trường lành mạnh (thân và tâm)
Phúc lợi cạnh tranh
', N'Hà Nội', N'30 - 50 triệu', N'Hà Nội', N'trên 5 năm', N'Trưởng/Phó phòng', N'1', N'Toàn thời gian', N'Không yêu cầu', N'Marketing', N'Marketing
')
GO
INSERT [dbo].[ApplyCV] ([IdCV], [IdPost], [NgayNop], [Duyet], [XacNhan]) VALUES (1, 1, CAST(N'2024-05-10' AS Date), 1, 1)
INSERT [dbo].[ApplyCV] ([IdCV], [IdPost], [NgayNop], [Duyet], [XacNhan]) VALUES (1, 3, CAST(N'2024-05-10' AS Date), 0, 0)
GO
INSERT [dbo].[FavJob] ([IdApplicant], [IdPost]) VALUES (1, 1)
GO
SET IDENTITY_INSERT [dbo].[PVDay] ON 
INSERT [dbo].[PVDay] ([Id], [Chon], [IdCV], [IdPost], [Ngay], [ThoiGian], [DiaDiem]) VALUES (1, 1, 1, 1, CAST(N'2024-05-28' AS Date), N'10h', N'Qu?n 1')
INSERT [dbo].[PVDay] ([Id], [Chon], [IdCV], [IdPost], [Ngay], [ThoiGian], [DiaDiem]) VALUES (2, 0, 1, 1, CAST(N'2024-05-28' AS Date), N'12h', N'Qu?n 1')
SET IDENTITY_INSERT [dbo].[PVDay] OFF
GO