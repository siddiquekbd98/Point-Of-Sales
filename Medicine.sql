USE [master]
GO
/****** Object:  Database [MedicineSales]    Script Date: 9/27/2021 11:56:19 PM ******/
CREATE DATABASE [MedicineSales]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Medicine', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Medicine.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Medicine_log', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Medicine_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MedicineSales] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MedicineSales].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MedicineSales] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MedicineSales] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MedicineSales] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MedicineSales] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MedicineSales] SET ARITHABORT OFF 
GO
ALTER DATABASE [MedicineSales] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MedicineSales] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MedicineSales] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MedicineSales] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MedicineSales] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MedicineSales] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MedicineSales] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MedicineSales] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MedicineSales] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MedicineSales] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MedicineSales] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MedicineSales] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MedicineSales] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MedicineSales] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MedicineSales] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MedicineSales] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MedicineSales] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MedicineSales] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MedicineSales] SET  MULTI_USER 
GO
ALTER DATABASE [MedicineSales] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MedicineSales] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MedicineSales] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MedicineSales] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MedicineSales] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MedicineSales] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MedicineSales] SET QUERY_STORE = OFF
GO
USE [MedicineSales]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/27/2021 11:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NULL,
	[Mobile] [int] NULL,
	[Address] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 9/27/2021 11:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[MedicineId] [int] IDENTITY(1,1) NOT NULL,
	[MedicineName] [varchar](50) NULL,
	[MedicineCategoryId] [int] NULL,
	[SalePrice] [decimal](18, 0) NULL,
	[Status] [varchar](50) NULL,
	[ImagePath] [varchar](50) NULL,
 CONSTRAINT [PK_Medicine] PRIMARY KEY CLUSTERED 
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicinePurchase]    Script Date: 9/27/2021 11:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicinePurchase](
	[MedicinePurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[MedicineId] [int] NULL,
	[MedicineSupplierId] [int] NULL,
	[SalePointID] [int] NULL,
	[PurchaseDate] [date] NULL,
	[ExpireDate] [varchar](50) NULL,
	[UnitPrice] [decimal](18, 8) NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [decimal](18, 8) NULL,
	[Vat] [decimal](18, 8) NULL,
	[GrandTotalPrice] [decimal](18, 8) NULL,
	[MedicineStockStatus] [varchar](50) NULL,
	[MemoNo] [int] NULL,
	[Comments] [varchar](50) NULL,
 CONSTRAINT [PK_MedicinePurchase] PRIMARY KEY CLUSTERED 
(
	[MedicinePurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicineSale]    Script Date: 9/27/2021 11:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicineSale](
	[MedicineSaleId] [int] IDENTITY(1,1) NOT NULL,
	[MedicineId] [int] NULL,
	[CustomerId] [int] NULL,
	[SalePointID] [int] NULL,
	[SaleDate] [date] NULL,
	[ExpireDate] [varchar](50) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[Vat] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[NetTotalPrice] [decimal](18, 2) NULL,
	[MedicineStockStatus] [varchar](50) NULL,
	[MemoNo] [int] NULL,
	[Comments] [varchar](50) NULL,
 CONSTRAINT [PK_MedicineSale] PRIMARY KEY CLUSTERED 
(
	[MedicineSaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicineStock]    Script Date: 9/27/2021 11:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicineStock](
	[MedicineStockId] [int] IDENTITY(1,1) NOT NULL,
	[MedicineId] [int] NULL,
	[SalePointID] [int] NULL,
	[Quantity] [int] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_MedicineStock] PRIMARY KEY CLUSTERED 
(
	[MedicineStockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicineSupplier]    Script Date: 9/27/2021 11:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicineSupplier](
	[MedicineSupplierId] [int] IDENTITY(1,1) NOT NULL,
	[MedicineSupplierName] [varchar](50) NULL,
	[Mobile] [int] NULL,
	[Address] [varchar](50) NULL,
	[ManagerName] [varchar](50) NULL,
 CONSTRAINT [PK_MedicineSupplier] PRIMARY KEY CLUSTERED 
(
	[MedicineSupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMedicineCategory]    Script Date: 9/27/2021 11:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMedicineCategory](
	[MedicineCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[MedicineCategoryName] [varchar](50) NULL,
 CONSTRAINT [PK_TblMedicineCategory] PRIMARY KEY CLUSTERED 
(
	[MedicineCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblSalePoint]    Script Date: 9/27/2021 11:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblSalePoint](
	[SalePointID] [int] IDENTITY(1,1) NOT NULL,
	[SalePointNo] [int] NULL,
	[SalePointName] [varchar](50) NULL,
	[SalePointManager] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
 CONSTRAINT [PK_Sale Point] PRIMARY KEY CLUSTERED 
(
	[SalePointID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblUser]    Script Date: 9/27/2021 11:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUser](
	[UserID] [int] NOT NULL,
	[Username] [varchar](50) NULL,
	[UserPass] [varchar](50) NULL,
	[UserType] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblUserRole]    Script Date: 9/27/2021 11:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserRole](
	[UserRoleID] [int] NOT NULL,
	[UserID] [int] NULL,
	[PageName] [varchar](50) NULL,
	[IsCreate] [bit] NULL,
	[IsRead] [bit] NULL,
	[IsUpdate] [bit] NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [CustomerName], [Mobile], [Address]) VALUES (1, N'Sobuj', 189575246, N'Dhaka')
INSERT [dbo].[Customer] ([CustomerId], [CustomerName], [Mobile], [Address]) VALUES (2, N'Rakib', 146589655, N'Kalshi')
INSERT [dbo].[Customer] ([CustomerId], [CustomerName], [Mobile], [Address]) VALUES (3, N'Khokon', 1548555, N'Uttara')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicine] ON 

INSERT [dbo].[Medicine] ([MedicineId], [MedicineName], [MedicineCategoryId], [SalePrice], [Status], [ImagePath]) VALUES (1, N'Napa Extra 50 mg', 1, CAST(595 AS Decimal(18, 0)), N'New', N'/uploads/Napa-Extra-Tablet.jpg')
INSERT [dbo].[Medicine] ([MedicineId], [MedicineName], [MedicineCategoryId], [SalePrice], [Status], [ImagePath]) VALUES (2, N'Tufnil 200 mg', 1, CAST(860 AS Decimal(18, 0)), N'New', N'/uploads/Tuffnil.jpg')
INSERT [dbo].[Medicine] ([MedicineId], [MedicineName], [MedicineCategoryId], [SalePrice], [Status], [ImagePath]) VALUES (3, N'Amoxilin Antibiotic', 5, CAST(27 AS Decimal(18, 0)), N'New', N'/uploads/DDF80F.jpg')
SET IDENTITY_INSERT [dbo].[Medicine] OFF
GO
SET IDENTITY_INSERT [dbo].[MedicinePurchase] ON 

INSERT [dbo].[MedicinePurchase] ([MedicinePurchaseId], [MedicineId], [MedicineSupplierId], [SalePointID], [PurchaseDate], [ExpireDate], [UnitPrice], [Quantity], [TotalPrice], [Vat], [GrandTotalPrice], [MedicineStockStatus], [MemoNo], [Comments]) VALUES (1, 1, 1, 1, CAST(N'2021-09-22' AS Date), N'2021-09-26', CAST(200.00000000 AS Decimal(18, 8)), 5, CAST(1000.00000000 AS Decimal(18, 8)), CAST(2.00000000 AS Decimal(18, 8)), CAST(1020.00000000 AS Decimal(18, 8)), N'New', 2323, N'Well')
INSERT [dbo].[MedicinePurchase] ([MedicinePurchaseId], [MedicineId], [MedicineSupplierId], [SalePointID], [PurchaseDate], [ExpireDate], [UnitPrice], [Quantity], [TotalPrice], [Vat], [GrandTotalPrice], [MedicineStockStatus], [MemoNo], [Comments]) VALUES (2, 3, 2, 2, CAST(N'2021-09-26' AS Date), N'2021-07-07', CAST(300.00000000 AS Decimal(18, 8)), 6, CAST(1800.00000000 AS Decimal(18, 8)), CAST(2.00000000 AS Decimal(18, 8)), CAST(1836.00000000 AS Decimal(18, 8)), N'New', 3424, N'Well')
INSERT [dbo].[MedicinePurchase] ([MedicinePurchaseId], [MedicineId], [MedicineSupplierId], [SalePointID], [PurchaseDate], [ExpireDate], [UnitPrice], [Quantity], [TotalPrice], [Vat], [GrandTotalPrice], [MedicineStockStatus], [MemoNo], [Comments]) VALUES (3, 3, 2, 2, CAST(N'2021-09-26' AS Date), N'2021-07-07', CAST(300.00000000 AS Decimal(18, 8)), 6, CAST(1800.00000000 AS Decimal(18, 8)), CAST(2.00000000 AS Decimal(18, 8)), CAST(1836.00000000 AS Decimal(18, 8)), N'New', 3424, N'Well')
INSERT [dbo].[MedicinePurchase] ([MedicinePurchaseId], [MedicineId], [MedicineSupplierId], [SalePointID], [PurchaseDate], [ExpireDate], [UnitPrice], [Quantity], [TotalPrice], [Vat], [GrandTotalPrice], [MedicineStockStatus], [MemoNo], [Comments]) VALUES (4, 2, 1, 1, CAST(N'2021-09-27' AS Date), N'2021-09-06', CAST(300.00000000 AS Decimal(18, 8)), 3, CAST(900.00000000 AS Decimal(18, 8)), CAST(3.00000000 AS Decimal(18, 8)), CAST(927.00000000 AS Decimal(18, 8)), N'New', 234, N'Well')
SET IDENTITY_INSERT [dbo].[MedicinePurchase] OFF
GO
SET IDENTITY_INSERT [dbo].[MedicineSale] ON 

INSERT [dbo].[MedicineSale] ([MedicineSaleId], [MedicineId], [CustomerId], [SalePointID], [SaleDate], [ExpireDate], [Rate], [Quantity], [TotalPrice], [Vat], [Discount], [NetTotalPrice], [MedicineStockStatus], [MemoNo], [Comments]) VALUES (1, 1, 1, 1, CAST(N'2021-09-27' AS Date), N'2021-09-27', CAST(300.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), NULL, N'New', 3434, N'Well')
SET IDENTITY_INSERT [dbo].[MedicineSale] OFF
GO
SET IDENTITY_INSERT [dbo].[MedicineStock] ON 

INSERT [dbo].[MedicineStock] ([MedicineStockId], [MedicineId], [SalePointID], [Quantity], [Status]) VALUES (1, 1, 1, 3, N'out')
INSERT [dbo].[MedicineStock] ([MedicineStockId], [MedicineId], [SalePointID], [Quantity], [Status]) VALUES (2, 3, 2, 12, N'in')
INSERT [dbo].[MedicineStock] ([MedicineStockId], [MedicineId], [SalePointID], [Quantity], [Status]) VALUES (3, 2, 1, 3, N'in')
SET IDENTITY_INSERT [dbo].[MedicineStock] OFF
GO
SET IDENTITY_INSERT [dbo].[MedicineSupplier] ON 

INSERT [dbo].[MedicineSupplier] ([MedicineSupplierId], [MedicineSupplierName], [Mobile], [Address], [ManagerName]) VALUES (1, N'Beximco Pharma', 1305499077, N'Dhanmondi', N'Afridi')
INSERT [dbo].[MedicineSupplier] ([MedicineSupplierId], [MedicineSupplierName], [Mobile], [Address], [ManagerName]) VALUES (2, N'Square', 1796670890, N'Uttara', N'Rasel')
SET IDENTITY_INSERT [dbo].[MedicineSupplier] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMedicineCategory] ON 

INSERT [dbo].[TblMedicineCategory] ([MedicineCategoryId], [MedicineCategoryName]) VALUES (1, N'Tablet')
INSERT [dbo].[TblMedicineCategory] ([MedicineCategoryId], [MedicineCategoryName]) VALUES (2, N'Powders')
INSERT [dbo].[TblMedicineCategory] ([MedicineCategoryId], [MedicineCategoryName]) VALUES (3, N'Syrup')
INSERT [dbo].[TblMedicineCategory] ([MedicineCategoryId], [MedicineCategoryName]) VALUES (4, N'suppositories')
INSERT [dbo].[TblMedicineCategory] ([MedicineCategoryId], [MedicineCategoryName]) VALUES (5, N'Capsules')
INSERT [dbo].[TblMedicineCategory] ([MedicineCategoryId], [MedicineCategoryName]) VALUES (6, N'Creams')
INSERT [dbo].[TblMedicineCategory] ([MedicineCategoryId], [MedicineCategoryName]) VALUES (7, N'Paste')
INSERT [dbo].[TblMedicineCategory] ([MedicineCategoryId], [MedicineCategoryName]) VALUES (8, N'Drops')
INSERT [dbo].[TblMedicineCategory] ([MedicineCategoryId], [MedicineCategoryName]) VALUES (9, N'ointment')
INSERT [dbo].[TblMedicineCategory] ([MedicineCategoryId], [MedicineCategoryName]) VALUES (10, N'Injection')
SET IDENTITY_INSERT [dbo].[TblMedicineCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[TblSalePoint] ON 

INSERT [dbo].[TblSalePoint] ([SalePointID], [SalePointNo], [SalePointName], [SalePointManager], [Address]) VALUES (1, 101, N'Lazz Pharma -  Kalshi', N'Omor', N'Kalshi')
INSERT [dbo].[TblSalePoint] ([SalePointID], [SalePointNo], [SalePointName], [SalePointManager], [Address]) VALUES (2, 102, N'Lazz Pharma -  Mirpur 10', N'Faruk', N'Mirpur 10')
INSERT [dbo].[TblSalePoint] ([SalePointID], [SalePointNo], [SalePointName], [SalePointManager], [Address]) VALUES (3, 103, N'Lazz Pharma -  Uttara', N'Shuvo', N'Uttara')
SET IDENTITY_INSERT [dbo].[TblSalePoint] OFF
GO
INSERT [dbo].[TblUser] ([UserID], [Username], [UserPass], [UserType]) VALUES (1, N'sadmin', N'12345', N'SuperAdmin')
INSERT [dbo].[TblUser] ([UserID], [Username], [UserPass], [UserType]) VALUES (2, N'user1', N'123', N'GeneralUser')
INSERT [dbo].[TblUser] ([UserID], [Username], [UserPass], [UserType]) VALUES (3, N'omor', N'123', N'SuperAdmin')
GO
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (1, 1, N'MedicineCategory', 1, 1, 1, 1)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (2, 3, N'SalePoints', 0, 1, 0, 0)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (3, 3, N'MedicineCategories', 0, 1, 0, 0)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (4, 1, N'SalePoints', 1, 1, 1, 1)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (5, 1, N'MedicineCategories', 1, 1, 1, 1)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (6, 2, N'SalePoints', 0, 1, 0, 0)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (7, 2, N'MedicineCategories', 0, 1, 0, 0)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (8, 1, N'MedicineSales', 1, 1, 1, 1)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (9, 1, N'Medicines', 1, 1, 1, 1)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (10, 1, N'MedicinePurchases', 1, 1, 1, 1)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (11, 1, N'MedicineStocks', 1, 1, 1, 1)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (12, 1, N'MedicineSuppliers', 1, 1, 1, 1)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (13, 1, N'Home', 1, 1, 1, 1)
INSERT [dbo].[TblUserRole] ([UserRoleID], [UserID], [PageName], [IsCreate], [IsRead], [IsUpdate], [IsDelete]) VALUES (14, 1, N'Customers', 1, 1, 1, 1)
GO
ALTER TABLE [dbo].[Medicine]  WITH CHECK ADD  CONSTRAINT [FK_Medicine_TblMedicineCategory] FOREIGN KEY([MedicineCategoryId])
REFERENCES [dbo].[TblMedicineCategory] ([MedicineCategoryId])
GO
ALTER TABLE [dbo].[Medicine] CHECK CONSTRAINT [FK_Medicine_TblMedicineCategory]
GO
ALTER TABLE [dbo].[MedicinePurchase]  WITH CHECK ADD  CONSTRAINT [FK_MedicinePurchase_Medicine] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicine] ([MedicineId])
GO
ALTER TABLE [dbo].[MedicinePurchase] CHECK CONSTRAINT [FK_MedicinePurchase_Medicine]
GO
ALTER TABLE [dbo].[MedicinePurchase]  WITH CHECK ADD  CONSTRAINT [FK_MedicinePurchase_MedicineSupplier] FOREIGN KEY([MedicineSupplierId])
REFERENCES [dbo].[MedicineSupplier] ([MedicineSupplierId])
GO
ALTER TABLE [dbo].[MedicinePurchase] CHECK CONSTRAINT [FK_MedicinePurchase_MedicineSupplier]
GO
ALTER TABLE [dbo].[MedicinePurchase]  WITH CHECK ADD  CONSTRAINT [FK_MedicinePurchase_TblSalePoint] FOREIGN KEY([SalePointID])
REFERENCES [dbo].[TblSalePoint] ([SalePointID])
GO
ALTER TABLE [dbo].[MedicinePurchase] CHECK CONSTRAINT [FK_MedicinePurchase_TblSalePoint]
GO
ALTER TABLE [dbo].[MedicineSale]  WITH CHECK ADD  CONSTRAINT [FK_MedicineSale_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[MedicineSale] CHECK CONSTRAINT [FK_MedicineSale_Customer]
GO
ALTER TABLE [dbo].[MedicineSale]  WITH CHECK ADD  CONSTRAINT [FK_MedicineSale_Medicine] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicine] ([MedicineId])
GO
ALTER TABLE [dbo].[MedicineSale] CHECK CONSTRAINT [FK_MedicineSale_Medicine]
GO
ALTER TABLE [dbo].[MedicineSale]  WITH CHECK ADD  CONSTRAINT [FK_MedicineSale_TblSalePoint] FOREIGN KEY([SalePointID])
REFERENCES [dbo].[TblSalePoint] ([SalePointID])
GO
ALTER TABLE [dbo].[MedicineSale] CHECK CONSTRAINT [FK_MedicineSale_TblSalePoint]
GO
ALTER TABLE [dbo].[MedicineStock]  WITH CHECK ADD  CONSTRAINT [FK_MedicineStock_Medicine] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicine] ([MedicineId])
GO
ALTER TABLE [dbo].[MedicineStock] CHECK CONSTRAINT [FK_MedicineStock_Medicine]
GO
ALTER TABLE [dbo].[MedicineStock]  WITH CHECK ADD  CONSTRAINT [FK_MedicineStock_TblSalePoint] FOREIGN KEY([SalePointID])
REFERENCES [dbo].[TblSalePoint] ([SalePointID])
GO
ALTER TABLE [dbo].[MedicineStock] CHECK CONSTRAINT [FK_MedicineStock_TblSalePoint]
GO
ALTER TABLE [dbo].[TblUserRole]  WITH CHECK ADD  CONSTRAINT [FK_TblUserRole_TblUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[TblUser] ([UserID])
GO
ALTER TABLE [dbo].[TblUserRole] CHECK CONSTRAINT [FK_TblUserRole_TblUser]
GO
USE [master]
GO
ALTER DATABASE [MedicineSales] SET  READ_WRITE 
GO
