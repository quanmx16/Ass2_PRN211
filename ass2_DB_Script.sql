USE [master]
GO
/****** Object:  Database [FStore]    Script Date: 10/20/2022 11:26:57 PM ******/
CREATE DATABASE [FStore]

GO
ALTER DATABASE [FStore] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [FStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [FStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FStore] SET  MULTI_USER 
GO
ALTER DATABASE [FStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FStore] SET QUERY_STORE = OFF
GO
USE [FStore]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 10/20/2022 11:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CompanyName] [varchar](40) NOT NULL,
	[City] [varchar](15) NOT NULL,
	[Country] [varchar](15) NOT NULL,
	[Password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/20/2022 11:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[RequiredDate] [datetime] NULL,
	[ShippedDate] [datetime] NULL,
	[Freight] [money] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 10/20/2022 11:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/20/2022 11:26:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductName] [varchar](40) NOT NULL,
	[Weight] [varchar](20) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitsInStock] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (1, N'quan@gmail.com', N'fpt', N'hcm2', N'vn', N'123')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (2, N'admin@fstore.com', N'fpt', N'hn', N'vn', N'admin@@')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (3, N'khanh@gmail.com', N'kms', N'hcm', N'vn', N'123')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (6, N'khanhtieunhi@gmail.com', N'NAB', N'Ha Noi', N'vn', N'123')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (7, N'son@gmail.com', N'nashtech', N'Da Nang', N'Laos', N'123')
SET IDENTITY_INSERT [dbo].[Member] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (1, 1, CAST(N'2022-01-01T11:22:33.210' AS DateTime), CAST(N'2022-01-02T11:22:33.210' AS DateTime), CAST(N'2022-03-01T11:22:33.210' AS DateTime), 16.0000)
INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (2, 1, CAST(N'2022-01-02T10:21:32.300' AS DateTime), CAST(N'2022-01-03T10:21:32.300' AS DateTime), CAST(N'2022-01-03T10:30:32.300' AS DateTime), 19.0000)
INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (3, 3, CAST(N'2022-01-04T09:20:01.300' AS DateTime), CAST(N'2022-01-05T09:20:01.300' AS DateTime), CAST(N'2022-01-05T09:20:01.300' AS DateTime), 20.0000)
INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (5, 7, CAST(N'2022-01-05T03:20:01.300' AS DateTime), CAST(N'2022-01-06T03:20:01.300' AS DateTime), CAST(N'2022-01-06T03:20:01.300' AS DateTime), 21.0000)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (1, 1, 8.0000, 2, 0.1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (1, 3, 3.0000, 3, 0.05)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (2, 6, 25.0000, 2, 0)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (2, 7, 50.0000, 1, 0.2)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (3, 1, 8.0000, 4, 0.1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (3, 3, 3.0000, 8, 0.06)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (5, 1, 8.0000, 4, 0.1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (5, 6, 25.0000, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (1, 1, N'PRN Book', N'500g', 9.0000, 9)
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (3, 2, N'Ball Point Pen', N'100g', 3.0000, 99)
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (6, 2, N'Ruler', N'50g', 25.0000, 10)
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (7, 1, N'Anime Book', N'300g', 50.0000, 19)
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (8, 2, N'Bag', N'100g', 100.0000, 9)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([MemberId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Member]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
USE [master]
GO
ALTER DATABASE [FStore] SET  READ_WRITE 
GO
