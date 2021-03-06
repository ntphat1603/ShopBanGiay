USE [ShopOnline]
GO
/****** Object:  Table [dbo].[DatHang]    Script Date: 6/6/2021 7:21:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NhanVien_ID] [int] NULL,
	[KhachHang_ID] [int] NULL,
	[DienThoaiGiaoHang] [nvarchar](20) NULL,
	[DiaChiGiaoHang] [nvarchar](255) NULL,
	[NgayDatHang] [datetime] NULL,
	[TinhTrang] [smallint] NULL,
 CONSTRAINT [PK_DatHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DatHang_ChiTiet]    Script Date: 6/6/2021 7:21:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatHang_ChiTiet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DatHang_ID] [int] NULL,
	[Giay_ID] [int] NULL,
	[SoLuong] [smallint] NULL,
	[DonGia] [int] NULL,
	[Size] [int] NULL,
 CONSTRAINT [PK_DatHang_ChiTiet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Giay]    Script Date: 6/6/2021 7:21:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giay](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NhaSanXuat_ID] [int] NULL,
	[LoaiGiay_ID] [int] NULL,
	[TenGiay] [nvarchar](255) NULL,
	[Size] [int] NULL,
	[DonGia] [int] NULL,
	[SoLuong] [int] NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[MoTa] [ntext] NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/6/2021 7:21:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](100) NULL,
	[DienThoai] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](255) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiGiay]    Script Date: 6/6/2021 7:21:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiGiay](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](255) NULL,
 CONSTRAINT [PK_LoaiSach] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/6/2021 7:21:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](100) NULL,
	[DienThoai] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](255) NULL,
	[Quyen] [bit] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 6/6/2021 7:21:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaSanXuat] [nvarchar](255) NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Giay] ON 

INSERT [dbo].[Giay] ([ID], [NhaSanXuat_ID], [LoaiGiay_ID], [TenGiay], [Size], [DonGia], [SoLuong], [HinhAnh], [MoTa]) VALUES (1, 1, 1, N'ADIDAD', 35, 300000, 100, N'Storage/647b1651-71c8-4ec2-846e-f11f2a21df10.jpg', N'TỐT')
INSERT [dbo].[Giay] ([ID], [NhaSanXuat_ID], [LoaiGiay_ID], [TenGiay], [Size], [DonGia], [SoLuong], [HinhAnh], [MoTa]) VALUES (2, 1, 2, N'asd', 40, 100000, 1000, N'Storage/2f6b4637-e348-4f92-98d0-c751d820c421.jpg', N'sad')
SET IDENTITY_INSERT [dbo].[Giay] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (1, N'Minh', N'0961825152', N'Long Xuyên An Giang', N'dqminh', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiGiay] ON 

INSERT [dbo].[LoaiGiay] ([ID], [TenLoai]) VALUES (1, N'Giày thể thao')
INSERT [dbo].[LoaiGiay] ([ID], [TenLoai]) VALUES (2, N'Giày Sandal')
SET IDENTITY_INSERT [dbo].[LoaiGiay] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [HoVaTen], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Quyen]) VALUES (1, N'Cường', N'0961825152', N'Long Xuyên An Giang', N'ltpcuong', N'356a192b7913b04c54574d18c28d46e6395428ab', 1)
INSERT [dbo].[NhanVien] ([ID], [HoVaTen], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Quyen]) VALUES (2, N'Phát', N'0123456789', N'Cần thơ', N'ntphat', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', 0)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[NhaSanXuat] ON 

INSERT [dbo].[NhaSanXuat] ([ID], [TenNhaSanXuat]) VALUES (1, N'Bitis')
SET IDENTITY_INSERT [dbo].[NhaSanXuat] OFF
ALTER TABLE [dbo].[DatHang]  WITH CHECK ADD  CONSTRAINT [FK_DatHang_KhachHang] FOREIGN KEY([KhachHang_ID])
REFERENCES [dbo].[KhachHang] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DatHang] CHECK CONSTRAINT [FK_DatHang_KhachHang]
GO
ALTER TABLE [dbo].[DatHang]  WITH CHECK ADD  CONSTRAINT [FK_DatHang_NhanVien] FOREIGN KEY([NhanVien_ID])
REFERENCES [dbo].[NhanVien] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DatHang] CHECK CONSTRAINT [FK_DatHang_NhanVien]
GO
ALTER TABLE [dbo].[DatHang_ChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_DatHang_ChiTiet_DatHang] FOREIGN KEY([DatHang_ID])
REFERENCES [dbo].[DatHang] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DatHang_ChiTiet] CHECK CONSTRAINT [FK_DatHang_ChiTiet_DatHang]
GO
ALTER TABLE [dbo].[DatHang_ChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_DatHang_ChiTiet_Giay] FOREIGN KEY([Giay_ID])
REFERENCES [dbo].[Giay] ([ID])
GO
ALTER TABLE [dbo].[DatHang_ChiTiet] CHECK CONSTRAINT [FK_DatHang_ChiTiet_Giay]
GO
ALTER TABLE [dbo].[Giay]  WITH CHECK ADD  CONSTRAINT [FK_Giay_NhaSanXuat] FOREIGN KEY([NhaSanXuat_ID])
REFERENCES [dbo].[NhaSanXuat] ([ID])
GO
ALTER TABLE [dbo].[Giay] CHECK CONSTRAINT [FK_Giay_NhaSanXuat]
GO
ALTER TABLE [dbo].[Giay]  WITH CHECK ADD  CONSTRAINT [FK_Sach_LoaiSach] FOREIGN KEY([LoaiGiay_ID])
REFERENCES [dbo].[LoaiGiay] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Giay] CHECK CONSTRAINT [FK_Sach_LoaiSach]
GO
