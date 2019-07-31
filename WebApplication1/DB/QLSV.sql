/****** Object:  Index [unique_masv]    Script Date: 7/30/2019 5:41:53 PM ******/
ALTER TABLE [dbo].[SinhVien] DROP CONSTRAINT [unique_masv]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 7/30/2019 5:41:53 PM ******/
DROP TABLE [dbo].[SinhVien]
GO
/****** Object:  Database [sinhvien]    Script Date: 7/30/2019 5:41:53 PM ******/
DROP DATABASE [sinhvien]
GO
/****** Object:  Database [sinhvien]    Script Date: 7/30/2019 5:41:53 PM ******/
CREATE DATABASE [sinhvien]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_Gen5_2', MAXSIZE = 32 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [sinhvien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sinhvien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sinhvien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sinhvien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sinhvien] SET ARITHABORT OFF 
GO
ALTER DATABASE [sinhvien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sinhvien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sinhvien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sinhvien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sinhvien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sinhvien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sinhvien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sinhvien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sinhvien] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [sinhvien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sinhvien] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [sinhvien] SET  MULTI_USER 
GO
ALTER DATABASE [sinhvien] SET ENCRYPTION ON
GO
ALTER DATABASE [sinhvien] SET QUERY_STORE = ON
GO
ALTER DATABASE [sinhvien] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO)
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 7/30/2019 5:41:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[maSV] [nvarchar](50) NULL,
	[hoTenSV] [nvarchar](50) NULL,
	[diaChi] [nvarchar](50) NULL,
	[soDienThoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SinhVien] ON 

INSERT [dbo].[SinhVien] ([id], [maSV], [hoTenSV], [diaChi], [soDienThoai]) VALUES (1, N'A1', N'Trần Cảnh Dinh', N'Quảng Trị', N'0975469232')
INSERT [dbo].[SinhVien] ([id], [maSV], [hoTenSV], [diaChi], [soDienThoai]) VALUES (2, N'A2', N'Bùi Thị Thu Huyền', N'Vũng Tàu', N'0987789878')
INSERT [dbo].[SinhVien] ([id], [maSV], [hoTenSV], [diaChi], [soDienThoai]) VALUES (3, N'A3', N'Phạm Thế Anh', N'Hải Phòng', N'0987893984')
INSERT [dbo].[SinhVien] ([id], [maSV], [hoTenSV], [diaChi], [soDienThoai]) VALUES (4, N'A4', N'Nguyễn Thị Nhi', N'Nam Định', N'0382842929')
INSERT [dbo].[SinhVien] ([id], [maSV], [hoTenSV], [diaChi], [soDienThoai]) VALUES (5, N'A5', N'Võ Hạ Châm', N'Hồ Chí Minh', N'0896469568')
INSERT [dbo].[SinhVien] ([id], [maSV], [hoTenSV], [diaChi], [soDienThoai]) VALUES (8, N'A8', N'Phùng Minh Cương', N'HO CHI MINH', N'0359340248')
INSERT [dbo].[SinhVien] ([id], [maSV], [hoTenSV], [diaChi], [soDienThoai]) VALUES (9, N'A9', N'Lâm Tặc', N'Đà Nẵng', N'0876378323')
INSERT [dbo].[SinhVien] ([id], [maSV], [hoTenSV], [diaChi], [soDienThoai]) VALUES (10, N'A6', N'Phi Hồng', N'Trung Quốc', N'01234566789')
INSERT [dbo].[SinhVien] ([id], [maSV], [hoTenSV], [diaChi], [soDienThoai]) VALUES (11, N'A7', N'Đã Thêm', N'860/80/42', N'0975469232')
SET IDENTITY_INSERT [dbo].[SinhVien] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [unique_masv]    Script Date: 7/30/2019 5:41:55 PM ******/
ALTER TABLE [dbo].[SinhVien] ADD  CONSTRAINT [unique_masv] UNIQUE NONCLUSTERED 
(
	[maSV] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO
ALTER DATABASE [sinhvien] SET  READ_WRITE 
GO
