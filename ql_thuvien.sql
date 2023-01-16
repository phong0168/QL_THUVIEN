USE [ql_thuvien]
GO
/****** Object:  Table [dbo].[SACH]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACH](
	[MASH] [char](6) NOT NULL,
	[MATG] [char](6) NOT NULL,
	[MANXB] [char](6) NOT NULL,
	[MALOAI] [char](6) NOT NULL,
	[MAKE] [char](6) NOT NULL,
	[TENSH] [nvarchar](40) NOT NULL,
	[NAMXB] [int] NULL,
	[SOLUONG] [int] NULL,
 CONSTRAINT [PK_SACH] PRIMARY KEY CLUSTERED 
(
	[MASH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCGIA]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCGIA](
	[MADG] [char](6) NOT NULL,
	[TENDG] [nvarchar](40) NOT NULL,
	[NGAYSINH] [datetime] NULL,
	[GIOITINH] [nvarchar](5) NULL,
	[LIENHE] [char](10) NULL,
 CONSTRAINT [PK_DOCGIA] PRIMARY KEY CLUSTERED 
(
	[MADG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUMUONTRA]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUMUONTRA](
	[MAMUONTRA] [char](6) NOT NULL,
	[MANV] [char](6) NOT NULL,
	[MATHE] [char](6) NOT NULL,
	[NGAYMUON] [datetime] NOT NULL,
 CONSTRAINT [PK_PHIEUMUONTRA] PRIMARY KEY CLUSTERED 
(
	[MAMUONTRA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THETHUVIEN]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THETHUVIEN](
	[MATHE] [char](6) NOT NULL,
	[MADG] [char](6) NOT NULL,
	[NGAYBD] [datetime] NOT NULL,
	[NGAYKT] [datetime] NOT NULL,
	[GHICHU] [char](60) NULL,
 CONSTRAINT [PK_THETHUVIEN] PRIMARY KEY CLUSTERED 
(
	[MATHE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_MUONTRA]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_MUONTRA](
	[MASH] [char](6) NOT NULL,
	[MAMUONTRA] [char](6) NOT NULL,
	[GHICHU] [nvarchar](60) NULL,
	[DATRA] [bit] NULL,
	[NGAYTRA] [datetime] NULL,
 CONSTRAINT [PK_CT_MUONTRA] PRIMARY KEY CLUSTERED 
(
	[MASH] ASC,
	[MAMUONTRA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_1]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT dbo.DOCGIA.TENDG, dbo.PHIEUMUONTRA.MAMUONTRA, dbo.SACH.TENSH, dbo.CT_MUONTRA.NGAYTRA, dbo.PHIEUMUONTRA.NGAYMUON
FROM   dbo.CT_MUONTRA INNER JOIN
             dbo.PHIEUMUONTRA ON dbo.CT_MUONTRA.MAMUONTRA = dbo.PHIEUMUONTRA.MAMUONTRA INNER JOIN
             dbo.SACH ON dbo.CT_MUONTRA.MASH = dbo.SACH.MASH INNER JOIN
             dbo.THETHUVIEN ON dbo.PHIEUMUONTRA.MATHE = dbo.THETHUVIEN.MATHE INNER JOIN
             dbo.DOCGIA ON dbo.THETHUVIEN.MADG = dbo.DOCGIA.MADG
GO
/****** Object:  Table [dbo].[KE]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KE](
	[MAKE] [char](6) NOT NULL,
	[VITRI] [nvarchar](10) NULL,
 CONSTRAINT [PK_KE] PRIMARY KEY CLUSTERED 
(
	[MAKE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISACH]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISACH](
	[MALOAI] [char](6) NOT NULL,
	[TENLOAI] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_LOAISACH] PRIMARY KEY CLUSTERED 
(
	[MALOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [char](6) NOT NULL,
	[TENNV] [nvarchar](40) NOT NULL,
	[GIOITINH] [nvarchar](5) NULL,
	[LIENHE] [char](10) NULL,
	[CCCD] [char](15) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHAXUATBAN]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAXUATBAN](
	[MANXB] [char](6) NOT NULL,
	[TENNXB] [nvarchar](40) NOT NULL,
	[DCNXB] [nvarchar](60) NULL,
	[SDTNXB] [char](10) NULL,
 CONSTRAINT [PK_NHAXUATBAN] PRIMARY KEY CLUSTERED 
(
	[MANXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TACGIA]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TACGIA](
	[MATG] [char](6) NOT NULL,
	[TENTG] [nvarchar](40) NOT NULL,
	[DIACHI] [nvarchar](60) NULL,
 CONSTRAINT [PK_TACGIA] PRIMARY KEY CLUSTERED 
(
	[MATG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DOCGIA] ([MADG], [TENDG], [NGAYSINH], [GIOITINH], [LIENHE]) VALUES (N'DG01  ', N'Đinh Duy Minh', CAST(N'2004-11-04T00:00:00.000' AS DateTime), N'Nam', N'0123423564')
GO
INSERT [dbo].[DOCGIA] ([MADG], [TENDG], [NGAYSINH], [GIOITINH], [LIENHE]) VALUES (N'DG02  ', N'Trương Mạnh Hùng', CAST(N'2002-02-02T00:00:00.000' AS DateTime), N'Nam', N'0123113564')
GO
INSERT [dbo].[DOCGIA] ([MADG], [TENDG], [NGAYSINH], [GIOITINH], [LIENHE]) VALUES (N'DG03  ', N'Nguyễn Thị Ngọc', CAST(N'2001-05-02T00:00:00.000' AS DateTime), N'Nữ', N'0127823564')
GO
INSERT [dbo].[KE] ([MAKE], [VITRI]) VALUES (N'K01   ', N'A1')
GO
INSERT [dbo].[KE] ([MAKE], [VITRI]) VALUES (N'K02   ', N'A2')
GO
INSERT [dbo].[KE] ([MAKE], [VITRI]) VALUES (N'K03   ', N'A3')
GO
INSERT [dbo].[KE] ([MAKE], [VITRI]) VALUES (N'K04   ', N'A5')
GO
INSERT [dbo].[LOAISACH] ([MALOAI], [TENLOAI]) VALUES (N'S     ', N'Sách')
GO
INSERT [dbo].[LOAISACH] ([MALOAI], [TENLOAI]) VALUES (N'TC    ', N'Tạp chí')
GO
INSERT [dbo].[LOAISACH] ([MALOAI], [TENLOAI]) VALUES (N'TR    ', N'Truyện')
GO
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [LIENHE], [CCCD]) VALUES (N'NV01  ', N'Phạm Chí Tâm', N'Nam', N'0123456689', N'012345678944   ')
GO
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [LIENHE], [CCCD]) VALUES (N'NV02  ', N'Nguyễn Minh Thư', N'Nữ', N'0123256789', N'012345678944   ')
GO
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [LIENHE], [CCCD]) VALUES (N'NV03  ', N'Lê Thanh Liêm', N'Nam', N'0123456784', N'012345678944   ')
GO
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [DCNXB], [SDTNXB]) VALUES (N'NXB01 ', N'Đại học quốc gia TP.HCM', N'Quận 1, TP.HCM', N'0876534875')
GO
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [DCNXB], [SDTNXB]) VALUES (N'NXB02 ', N'Đại học quốc gia Hà Nội', N'Quận 1 Cầu Giấy, Hà Nội', N'0476547657')
GO
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [DCNXB], [SDTNXB]) VALUES (N'NXB03 ', N'Thanh Niên', N'Quận 3, TP. HCM', N'0876547566')
GO
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [DCNXB], [SDTNXB]) VALUES (N'NXB04 ', N'Tổng Hợp', N'Quận Thanh Xuân, Hà Nội', N'0487684767')
GO
INSERT [dbo].[NHAXUATBAN] ([MANXB], [TENNXB], [DCNXB], [SDTNXB]) VALUES (N'NXB05 ', N'Nhi Đồng', N'Quận 10, TP. HCM', N'0876574676')
GO
INSERT [dbo].[SACH] ([MASH], [MATG], [MANXB], [MALOAI], [MAKE], [TENSH], [NAMXB], [SOLUONG]) VALUES (N'1     ', N'TG001 ', N'NXB01 ', N'S     ', N'K01   ', N'Toán rời rạc', 1998, 22)
GO
INSERT [dbo].[SACH] ([MASH], [MATG], [MANXB], [MALOAI], [MAKE], [TENSH], [NAMXB], [SOLUONG]) VALUES (N'2     ', N'TG002 ', N'NXB05 ', N'TR    ', N'K01   ', N'Dế mèn phiêu lưu ký', 1997, 29)
GO
INSERT [dbo].[SACH] ([MASH], [MATG], [MANXB], [MALOAI], [MAKE], [TENSH], [NAMXB], [SOLUONG]) VALUES (N'3     ', N'TG005 ', N'NXB05 ', N'TR    ', N'K02   ', N'Bàn có 5 chỗ ngồi', 2000, 13)
GO
INSERT [dbo].[SACH] ([MASH], [MATG], [MANXB], [MALOAI], [MAKE], [TENSH], [NAMXB], [SOLUONG]) VALUES (N'4     ', N'TG003 ', N'NXB04 ', N'TC    ', N'K03   ', N'Tạp chí Tin học và Điều khiển số 6/2015', 2015, 10)
GO
INSERT [dbo].[SACH] ([MASH], [MATG], [MANXB], [MALOAI], [MAKE], [TENSH], [NAMXB], [SOLUONG]) VALUES (N'5     ', N'TG003 ', N'NXB04 ', N'TC    ', N'K04   ', N'Tạp chí Tin học và Điều khiển số 9/2015', 2015, 10)
GO
INSERT [dbo].[TACGIA] ([MATG], [TENTG], [DIACHI]) VALUES (N'TG001 ', N'Nguyễn Hữu Anh', N'Q1, TPHCM')
GO
INSERT [dbo].[TACGIA] ([MATG], [TENTG], [DIACHI]) VALUES (N'TG002 ', N'Tô Hoài', N'Bình Thạnh')
GO
INSERT [dbo].[TACGIA] ([MATG], [TENTG], [DIACHI]) VALUES (N'TG003 ', N'Nguyễn Quang Sáng', N'Trảng Bàng, Tây Ninh')
GO
INSERT [dbo].[TACGIA] ([MATG], [TENTG], [DIACHI]) VALUES (N'TG004 ', N'Hồ Tùng Mậu', N'Trảng Bom, Tây Ninh')
GO
INSERT [dbo].[TACGIA] ([MATG], [TENTG], [DIACHI]) VALUES (N'TG005 ', N'Nguyễn Nhật Ánh', N'Q1, TPHCM')
GO
INSERT [dbo].[THETHUVIEN] ([MATHE], [MADG], [NGAYBD], [NGAYKT], [GHICHU]) VALUES (N'1     ', N'DG01  ', CAST(N'2022-11-13T00:00:00.000' AS DateTime), CAST(N'2023-12-01T00:00:00.000' AS DateTime), N'                                                            ')
GO
INSERT [dbo].[THETHUVIEN] ([MATHE], [MADG], [NGAYBD], [NGAYKT], [GHICHU]) VALUES (N'2     ', N'DG02  ', CAST(N'2021-10-10T00:00:00.000' AS DateTime), CAST(N'2022-10-10T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[THETHUVIEN] ([MATHE], [MADG], [NGAYBD], [NGAYKT], [GHICHU]) VALUES (N'3     ', N'DG03  ', CAST(N'2022-06-05T00:00:00.000' AS DateTime), CAST(N'2023-06-05T00:00:00.000' AS DateTime), NULL)
GO
ALTER TABLE [dbo].[CT_MUONTRA] ADD  CONSTRAINT [df_datra]  DEFAULT ((0)) FOR [DATRA]
GO
ALTER TABLE [dbo].[CT_MUONTRA]  WITH CHECK ADD  CONSTRAINT [FK_CT_MUONTRA_PHIEUMUONTRA] FOREIGN KEY([MAMUONTRA])
REFERENCES [dbo].[PHIEUMUONTRA] ([MAMUONTRA])
GO
ALTER TABLE [dbo].[CT_MUONTRA] CHECK CONSTRAINT [FK_CT_MUONTRA_PHIEUMUONTRA]
GO
ALTER TABLE [dbo].[CT_MUONTRA]  WITH CHECK ADD  CONSTRAINT [FK_CT_MUONTRA_SACH] FOREIGN KEY([MASH])
REFERENCES [dbo].[SACH] ([MASH])
GO
ALTER TABLE [dbo].[CT_MUONTRA] CHECK CONSTRAINT [FK_CT_MUONTRA_SACH]
GO
ALTER TABLE [dbo].[PHIEUMUONTRA]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUMUONTRA_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[PHIEUMUONTRA] CHECK CONSTRAINT [FK_PHIEUMUONTRA_NHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUMUONTRA]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUMUONTRA_THETHUVIEN] FOREIGN KEY([MATHE])
REFERENCES [dbo].[THETHUVIEN] ([MATHE])
GO
ALTER TABLE [dbo].[PHIEUMUONTRA] CHECK CONSTRAINT [FK_PHIEUMUONTRA_THETHUVIEN]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH_KE] FOREIGN KEY([MAKE])
REFERENCES [dbo].[KE] ([MAKE])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_SACH_KE]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH_LOAISACH] FOREIGN KEY([MALOAI])
REFERENCES [dbo].[LOAISACH] ([MALOAI])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_SACH_LOAISACH]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH_NHAXUATBAN] FOREIGN KEY([MANXB])
REFERENCES [dbo].[NHAXUATBAN] ([MANXB])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_SACH_NHAXUATBAN]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH_TACGIA] FOREIGN KEY([MATG])
REFERENCES [dbo].[TACGIA] ([MATG])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_SACH_TACGIA]
GO
ALTER TABLE [dbo].[THETHUVIEN]  WITH CHECK ADD  CONSTRAINT [FK_THETHUVIEN_DOCGIA] FOREIGN KEY([MADG])
REFERENCES [dbo].[DOCGIA] ([MADG])
GO
ALTER TABLE [dbo].[THETHUVIEN] CHECK CONSTRAINT [FK_THETHUVIEN_DOCGIA]
GO
ALTER TABLE [dbo].[DOCGIA]  WITH CHECK ADD  CONSTRAINT [chk_giotinh] CHECK  (([gioitinh]=N'Nữ' OR [gioitinh]='Nam'))
GO
ALTER TABLE [dbo].[DOCGIA] CHECK CONSTRAINT [chk_giotinh]
GO
ALTER TABLE [dbo].[DOCGIA]  WITH CHECK ADD  CONSTRAINT [chk_lienhe] CHECK  (([lienhe] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[DOCGIA] CHECK CONSTRAINT [chk_lienhe]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [chk_cccd] CHECK  (([cccd] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [chk_cccd]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [chk_giotinh1] CHECK  (([gioitinh]=N'Nữ' OR [gioitinh]='Nam'))
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [chk_giotinh1]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [chk_lienhe1] CHECK  (([LIENHE] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [chk_lienhe1]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD CHECK  (([SOLUONG]>=(0)))
GO
/****** Object:  Trigger [dbo].[ktr_ngayhentra]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[ktr_ngayhentra] on [dbo].[CT_MUONTRA]
for insert, update
as  
	if exists(select * from inserted i, PHIEUMUONTRA d where i.MAMUONTRA = d.MAMUONTRA
			  and i.NGAYTRA < d.NGAYMUON)
    begin 
		print N'Ngày hẹn trả không được nhỏ hơn ngày ngày mượn'
		rollback tran
	end
GO
ALTER TABLE [dbo].[CT_MUONTRA] ENABLE TRIGGER [ktr_ngayhentra]
GO
/****** Object:  Trigger [dbo].[update_sl_muon]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[update_sl_muon]
on [dbo].[CT_MUONTRA]
for insert
as
begin 
	update sach set SOLUONG = SOLUONG - 1
	where mash = (select mash from inserted)
end
GO
ALTER TABLE [dbo].[CT_MUONTRA] ENABLE TRIGGER [update_sl_muon]
GO
/****** Object:  Trigger [dbo].[update_sl_tra]    Script Date: 22/12/2022 3:20:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[update_sl_tra]
on [dbo].[CT_MUONTRA]
for update
as
if update(datra)
begin 
	update sach set SOLUONG = SOLUONG + 1
	from SACH, inserted
	where sach.MASH = inserted.MASH
end
GO
ALTER TABLE [dbo].[CT_MUONTRA] ENABLE TRIGGER [update_sl_tra]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CT_MUONTRA"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 206
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "PHIEUMUONTRA"
            Begin Extent = 
               Top = 9
               Left = 336
               Bottom = 206
               Right = 558
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SACH"
            Begin Extent = 
               Top = 9
               Left = 615
               Bottom = 206
               Right = 837
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "THETHUVIEN"
            Begin Extent = 
               Top = 9
               Left = 894
               Bottom = 206
               Right = 1116
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DOCGIA"
            Begin Extent = 
               Top = 9
               Left = 1173
               Bottom = 206
               Right = 1395
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'      Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
