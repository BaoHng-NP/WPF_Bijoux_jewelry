USE [master]
GO
/****** Object:  Database [DiamondShopDB]    Script Date: 7/25/2024 5:35:47 PM ******/
CREATE DATABASE [DiamondShopDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DiamondShopDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DiamondShopDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DiamondShopDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DiamondShopDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DiamondShopDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DiamondShopDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DiamondShopDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DiamondShopDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DiamondShopDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DiamondShopDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DiamondShopDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DiamondShopDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DiamondShopDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DiamondShopDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DiamondShopDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DiamondShopDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DiamondShopDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DiamondShopDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DiamondShopDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DiamondShopDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DiamondShopDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DiamondShopDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DiamondShopDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DiamondShopDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DiamondShopDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DiamondShopDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DiamondShopDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DiamondShopDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DiamondShopDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DiamondShopDB] SET  MULTI_USER 
GO
ALTER DATABASE [DiamondShopDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DiamondShopDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DiamondShopDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DiamondShopDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DiamondShopDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DiamondShopDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DiamondShopDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [DiamondShopDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DiamondShopDB]

GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](200) NULL,
	[password] [varchar](200) NULL,
	[phone] [varchar](200) NULL,
	[dob] [date] NULL,
	[email] [varchar](200) NOT NULL,
	[fullname] [nvarchar](max) NOT NULL,
	[role] [int] NOT NULL,
	[created] [datetime] NOT NULL,
	[status] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diamond]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diamond](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[size] [float] NOT NULL,
	[imageUrl] [nvarchar](max) NOT NULL,
	[diamond_color_id] [int] NOT NULL,
	[diamond_origin_id] [int] NOT NULL,
	[diamond_clarity_id] [int] NOT NULL,
	[price] [float] NOT NULL,
	[status] [tinyint] NOT NULL,
	[created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diamond_Clarity]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diamond_Clarity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diamond_Color]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diamond_Color](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diamond_Origin]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diamond_Origin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Metal]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Metal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[buy_price_per_gram] [float] NOT NULL,
	[sale_price_per_gram] [float] NOT NULL,
	[imageUrl] [nvarchar](max) NOT NULL,
	[specific_weight] [float] NOT NULL,
	[deactivated] [tinyint] NOT NULL,
	[created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Status]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[account_id] [int] NOT NULL,
	[product_price] [float] NOT NULL,
	[profit_rate] [float] NOT NULL,
	[production_price] [float] NOT NULL,
	[deposit_has_paid] [float] NOT NULL,
	[total_price] [float] NOT NULL,
	[order_status_id] [int] NOT NULL,
	[note] [nvarchar](max) NULL,
	[design_staff_id] [int] NULL,
	[production_staff_id] [int] NULL,
	[created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[imageUrl] [nvarchar](max) NOT NULL,
	[product_type_id] [int] NOT NULL,
	[mounting_size] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Diamond]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Diamond](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[diamond_id] [int] NOT NULL,
	[count] [int] NOT NULL,
	[price] [float] NOT NULL,
	[status] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Metal]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Metal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[metal_id] [int] NOT NULL,
	[weight] [float] NOT NULL,
	[status] [tinyint] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Type]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Production_Process]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Production_Process](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[production_status_id] [int] NOT NULL,
	[imageUrl] [nvarchar](max) NULL,
	[created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Production_Status]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Production_Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quote]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quote](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[account_id] [int] NOT NULL,
	[quote_status_id] [int] NOT NULL,
	[product_price] [float] NOT NULL,
	[production_price] [float] NOT NULL,
	[profit_rate] [float] NOT NULL,
	[total_price]  AS (([product_price]*((100)+[profit_rate]))/(100)+[production_price]) PERSISTED NOT NULL,
	[note] [nvarchar](max) NULL,
	[design_staff_id] [int] NULL,
	[production_staff_id] [int] NULL,
	[created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quote_Status]    Script Date: 7/25/2024 5:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quote_Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [username], [password], [phone], [dob], [email], [fullname], [role], [created], [status]) VALUES (1, N'customer', N'123', N'123123123', CAST(N'2024-07-12' AS Date), N'123@gmail.com', N'Nguyen Van A', 1, CAST(N'2024-07-12T15:30:00.000' AS DateTime), 0)
INSERT [dbo].[Account] ([id], [username], [password], [phone], [dob], [email], [fullname], [role], [created], [status]) VALUES (2, N'manager', N'123', N'123123123', CAST(N'2024-07-13' AS Date), N'123@gmail.com', N'Nguyen Van B', 2, CAST(N'2024-07-13T15:30:00.000' AS DateTime), 0)
INSERT [dbo].[Account] ([id], [username], [password], [phone], [dob], [email], [fullname], [role], [created], [status]) VALUES (3, N'salestaff', N'123', N'123123123', CAST(N'2024-07-14' AS Date), N'123@gmail.com', N'Nguyen Van C', 3, CAST(N'2024-07-14T15:30:00.000' AS DateTime), 0)
INSERT [dbo].[Account] ([id], [username], [password], [phone], [dob], [email], [fullname], [role], [created], [status]) VALUES (4, N'designstaff', N'123', N'123123123', CAST(N'2024-07-15' AS Date), N'123@gmail.com', N'Nguyen Van D', 4, CAST(N'2024-07-15T15:30:00.000' AS DateTime), 0)
INSERT [dbo].[Account] ([id], [username], [password], [phone], [dob], [email], [fullname], [role], [created], [status]) VALUES (5, N'productionstaff', N'123', N'123123123', CAST(N'2024-07-16' AS Date), N'123@gmail.com', N'Nguyen Van E', 5, CAST(N'2024-07-16T15:30:00.000' AS DateTime), 0)
INSERT [dbo].[Account] ([id], [username], [password], [phone], [dob], [email], [fullname], [role], [created], [status]) VALUES (6, N'customer2', N'123', N'0123123123', CAST(N'2024-07-26' AS Date), N'123@gmail.com', N'Nguyen Van F', 1, CAST(N'2024-07-16T15:30:00.000' AS DateTime), 0)
INSERT [dbo].[Account] ([id], [username], [password], [phone], [dob], [email], [fullname], [role], [created], [status]) VALUES (7, N'designstaff2', N'123', N'0123123123', CAST(N'2024-07-25' AS Date), N'123@gmail.com', N'Nguyen Van G', 4, CAST(N'2024-07-16T15:30:00.000' AS DateTime), 0)
INSERT [dbo].[Account] ([id], [username], [password], [phone], [dob], [email], [fullname], [role], [created], [status]) VALUES (9, N'designstaff2', N'123', N'0123123123', CAST(N'2024-07-25' AS Date), N'123@gmail.com', N'Nguyen Van H', 5, CAST(N'2024-07-16T15:30:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Diamond] ON 

INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (1, 5.2, N'image.jpg', 1, 1, 1, 54500000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (2, 5.2, N'image.jpg', 1, 1, 2, 52800000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (3, 5.2, N'image.jpg', 1, 1, 3, 49800000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (4, 5.2, N'image.jpg', 1, 1, 4, 46600000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (5, 5.2, N'image.jpg', 1, 1, 5, 42100000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (6, 5.2, N'image.jpg', 2, 1, 1, 52000000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (7, 5.2, N'image.jpg', 2, 1, 2, 50200000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (8, 5.2, N'image.jpg', 2, 1, 3, 47200000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (9, 5.2, N'image.jpg', 2, 1, 4, 45100000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (10, 5.2, N'image.jpg', 2, 1, 5, 40800000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (11, 5.2, N'image.jpg', 3, 1, 1, 35000000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (12, 5.2, N'image.jpg', 3, 1, 2, 33300000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (13, 5.2, N'image.jpg', 3, 1, 3, 45500000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (14, 5.2, N'image.jpg', 3, 1, 4, 43200000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (15, 5.2, N'image.jpg', 3, 1, 5, 38600000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (16, 5.2, N'image.jpg', 4, 1, 1, 32000000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (17, 5.2, N'image.jpg', 4, 1, 2, 31100000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (18, 5.2, N'image.jpg', 4, 1, 3, 43000000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (19, 5.2, N'image.jpg', 4, 1, 4, 40800000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Diamond] ([id], [size], [imageUrl], [diamond_color_id], [diamond_origin_id], [diamond_clarity_id], [price], [status], [created]) VALUES (20, 5.2, N'image.jpg', 4, 1, 5, 36500000, 0, CAST(N'2024-08-06T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Diamond] OFF
GO
SET IDENTITY_INSERT [dbo].[Diamond_Clarity] ON 

INSERT [dbo].[Diamond_Clarity] ([id], [name]) VALUES (1, N'IF')
INSERT [dbo].[Diamond_Clarity] ([id], [name]) VALUES (2, N'VVS1')
INSERT [dbo].[Diamond_Clarity] ([id], [name]) VALUES (3, N'VVS2')
INSERT [dbo].[Diamond_Clarity] ([id], [name]) VALUES (4, N'VS1')
INSERT [dbo].[Diamond_Clarity] ([id], [name]) VALUES (5, N'VS2')
SET IDENTITY_INSERT [dbo].[Diamond_Clarity] OFF
GO
SET IDENTITY_INSERT [dbo].[Diamond_Color] ON 

INSERT [dbo].[Diamond_Color] ([id], [name]) VALUES (1, N'D')
INSERT [dbo].[Diamond_Color] ([id], [name]) VALUES (2, N'E')
INSERT [dbo].[Diamond_Color] ([id], [name]) VALUES (3, N'J')
INSERT [dbo].[Diamond_Color] ([id], [name]) VALUES (4, N'F')
SET IDENTITY_INSERT [dbo].[Diamond_Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Diamond_Origin] ON 

INSERT [dbo].[Diamond_Origin] ([id], [name]) VALUES (1, N'Natural')
INSERT [dbo].[Diamond_Origin] ([id], [name]) VALUES (2, N'Lab')
SET IDENTITY_INSERT [dbo].[Diamond_Origin] OFF
GO
SET IDENTITY_INSERT [dbo].[Metal] ON 

INSERT [dbo].[Metal] ([id], [name], [buy_price_per_gram], [sale_price_per_gram], [imageUrl], [specific_weight], [deactivated], [created]) VALUES (1, N'10K Gold', 5000000, 800000, N'main.jpg', 0.0136, 0, CAST(N'2024-05-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Metal] ([id], [name], [buy_price_per_gram], [sale_price_per_gram], [imageUrl], [specific_weight], [deactivated], [created]) VALUES (2, N'14K Gold', 6000000, 1760000, N'main.jpg', 0.0147, 0, CAST(N'2024-05-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Metal] ([id], [name], [buy_price_per_gram], [sale_price_per_gram], [imageUrl], [specific_weight], [deactivated], [created]) VALUES (3, N'18K Gold', 7000000, 186666, N'main.jpg', 0.0156, 0, CAST(N'2024-05-24T00:00:00.000' AS DateTime))
INSERT [dbo].[Metal] ([id], [name], [buy_price_per_gram], [sale_price_per_gram], [imageUrl], [specific_weight], [deactivated], [created]) VALUES (4, N'10K Rose Gold', 5200000, 1525333, N'main.jpg', 0.0132, 0, CAST(N'2024-03-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Metal] ([id], [name], [buy_price_per_gram], [sale_price_per_gram], [imageUrl], [specific_weight], [deactivated], [created]) VALUES (5, N'14K Rose Gold', 6200000, 6820000, N'main.jpg', 0.0143, 0, CAST(N'2024-03-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Metal] ([id], [name], [buy_price_per_gram], [sale_price_per_gram], [imageUrl], [specific_weight], [deactivated], [created]) VALUES (6, N'18K Rose Gold', 7200000, 7920000, N'main.jpg', 0.0152, 0, CAST(N'2024-03-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Metal] ([id], [name], [buy_price_per_gram], [sale_price_per_gram], [imageUrl], [specific_weight], [deactivated], [created]) VALUES (7, N'Silver', 700000, 770000, N'main.jpg', 0.0105, 0, CAST(N'2024-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Metal] ([id], [name], [buy_price_per_gram], [sale_price_per_gram], [imageUrl], [specific_weight], [deactivated], [created]) VALUES (8, N'Platinum', 900000, 990000, N'main.jpg', 0.0214, 0, CAST(N'2024-05-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Metal] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_Status] ON 

INSERT [dbo].[Order_Status] ([id], [name]) VALUES (1, N'Deposit')
INSERT [dbo].[Order_Status] ([id], [name]) VALUES (2, N'Designing')
INSERT [dbo].[Order_Status] ([id], [name]) VALUES (3, N'Manufacturing')
INSERT [dbo].[Order_Status] ([id], [name]) VALUES (4, N'Payment')
INSERT [dbo].[Order_Status] ([id], [name]) VALUES (5, N'Comeplete')
INSERT [dbo].[Order_Status] ([id], [name]) VALUES (6, N'Cancel')
SET IDENTITY_INSERT [dbo].[Order_Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([id], [product_id], [account_id], [product_price], [profit_rate], [production_price], [deposit_has_paid], [total_price], [order_status_id], [note], [design_staff_id], [production_staff_id], [created]) VALUES (1, 15, 1, 60240000, 4, 15000, 31332300, 62664600, 6, N'55555', 4, 5, CAST(N'2024-07-24T01:40:16.687' AS DateTime))
INSERT [dbo].[Orders] ([id], [product_id], [account_id], [product_price], [profit_rate], [production_price], [deposit_has_paid], [total_price], [order_status_id], [note], [design_staff_id], [production_staff_id], [created]) VALUES (2, 16, 1, 95600000, 5, 15000, 25732500, 51465000, 3, N'nhan don gian 1 diamond', 4, 5, CAST(N'2024-07-24T04:16:24.927' AS DateTime))
INSERT [dbo].[Orders] ([id], [product_id], [account_id], [product_price], [profit_rate], [production_price], [deposit_has_paid], [total_price], [order_status_id], [note], [design_staff_id], [production_staff_id], [created]) VALUES (3, 17, 1, 55080000, 6, 20000, 51027000, 102054000, 3, N'nhan don gian', 4, 5, CAST(N'2024-07-24T04:22:30.277' AS DateTime))
INSERT [dbo].[Orders] ([id], [product_id], [account_id], [product_price], [profit_rate], [production_price], [deposit_has_paid], [total_price], [order_status_id], [note], [design_staff_id], [production_staff_id], [created]) VALUES (4, 18, 1, 51175999, 6, 20000, 0, 54266558.94, 1, N'nhan', 4, 9, CAST(N'2024-07-25T15:17:25.803' AS DateTime))
INSERT [dbo].[Orders] ([id], [product_id], [account_id], [product_price], [profit_rate], [production_price], [deposit_has_paid], [total_price], [order_status_id], [note], [design_staff_id], [production_staff_id], [created]) VALUES (5, 11, 1, 55850666, 2, 1500, 0, 56969179.32, 1, N'123', 7, 9, CAST(N'2024-07-25T15:24:39.870' AS DateTime))
INSERT [dbo].[Orders] ([id], [product_id], [account_id], [product_price], [profit_rate], [production_price], [deposit_has_paid], [total_price], [order_status_id], [note], [design_staff_id], [production_staff_id], [created]) VALUES (6, 19, 6, 52701332, 6, 10000, 27936705.96, 55873411.92, 3, N'123123', 4, 5, CAST(N'2024-07-25T16:23:45.787' AS DateTime))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (1, N'', 1, 0)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (2, N'', 1, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (3, N'', 1, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (4, N'', 2, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (5, N'', 3, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (6, N'', 2, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (7, N'', 1, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (8, N'', 1, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (9, N'', 2, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (10, N'', 1, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (11, N'', 3, 5)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (12, N'', 1, 5)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (13, N'', 1, 3)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (14, N'', 2, 5)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (15, N'', 1, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (16, N'', 1, 5)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (17, N'', 1, 5)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (18, N'', 1, 2)
INSERT [dbo].[Product] ([id], [imageUrl], [product_type_id], [mounting_size]) VALUES (19, N'', 1, 3)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Diamond] ON 

INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (12, 13, 3, 1, 49800000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (13, 13, 3, 1, 49800000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (15, 12, 3, 1, 49800000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (16, 1, 2, 1, 52800000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (17, 11, 2, 1, 52800000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (18, 10, 3, 1, 49800000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (19, 14, 3, 1, 49800000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (20, 15, 4, 1, 46600000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (21, 16, 4, 1, 46600000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (22, 16, 4, 1, 46600000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (23, 17, 3, 1, 49800000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (25, 18, 4, 1, 46600000, 1)
INSERT [dbo].[Product_Diamond] ([id], [product_id], [diamond_id], [count], [price], [status]) VALUES (26, 19, 4, 1, 46600000, 1)
SET IDENTITY_INSERT [dbo].[Product_Diamond] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Metal] ON 

INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (11, 13, 1, 3, 1, 2400000)
INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (13, 12, 2, 2, 1, 3520000)
INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (14, 1, 1, 3, 1, 2400000)
INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (15, 11, 4, 2, 1, 3050666)
INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (16, 10, 5, 2, 1, 13640000)
INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (17, 14, 3, 123, 1, 22959918)
INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (18, 15, 5, 2, 1, 13640000)
INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (19, 16, 1, 3, 1, 2400000)
INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (20, 17, 2, 3, 1, 5280000)
INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (21, 18, 4, 3, 1, 4575999)
INSERT [dbo].[Product_Metal] ([id], [product_id], [metal_id], [weight], [status], [price]) VALUES (22, 19, 4, 4, 1, 6101332)
SET IDENTITY_INSERT [dbo].[Product_Metal] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Type] ON 

INSERT [dbo].[Product_Type] ([id], [name]) VALUES (1, N'Ring')
INSERT [dbo].[Product_Type] ([id], [name]) VALUES (2, N'Band')
INSERT [dbo].[Product_Type] ([id], [name]) VALUES (3, N'Pendant')
SET IDENTITY_INSERT [dbo].[Product_Type] OFF
GO
SET IDENTITY_INSERT [dbo].[Production_Status] ON 

INSERT [dbo].[Production_Status] ([id], [name]) VALUES (1, N'Unrealized')
INSERT [dbo].[Production_Status] ([id], [name]) VALUES (2, N'Casting')
INSERT [dbo].[Production_Status] ([id], [name]) VALUES (3, N'Assembly')
INSERT [dbo].[Production_Status] ([id], [name]) VALUES (4, N'Polishing')
INSERT [dbo].[Production_Status] ([id], [name]) VALUES (5, N'Finished')
SET IDENTITY_INSERT [dbo].[Production_Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Quote] ON 

INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (1, 1, 1, 5, 55200000, 1, 1, N'1', 1, 1, CAST(N'2024-07-22T13:53:29.000' AS DateTime))
INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (2, 10, 1, 2, 63440000, 0, 0, N'', NULL, NULL, CAST(N'2024-07-22T02:05:53.537' AS DateTime))
INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (3, 11, 1, 4, 55850666, 1500, 2, N'123', 7, 9, CAST(N'2024-07-22T21:54:48.390' AS DateTime))
INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (4, 12, 1, 2, 53320000, 14000, 5, N'sssss', NULL, NULL, CAST(N'2024-07-22T22:11:01.347' AS DateTime))
INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (5, 13, 1, 4, 102000000, 15000, 5, N'nhan don gian ', 4, 5, CAST(N'2024-07-23T22:54:50.843' AS DateTime))
INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (6, 14, 6, 1, 0, 0, 0, N'nhan toooo', NULL, NULL, CAST(N'2024-07-24T00:26:34.953' AS DateTime))
INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (7, 15, 1, 4, 60240000, 15000, 4, N'55555', 4, 5, CAST(N'2024-07-24T01:38:52.877' AS DateTime))
INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (8, 16, 1, 4, 49000000, 15000, 5, N'nhan don gian 1 diamond', 4, 5, CAST(N'2024-07-24T04:15:04.680' AS DateTime))
INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (9, 17, 1, 4, 97180000, 15000, 5, N'nhan don gian', 4, 5, CAST(N'2024-07-24T04:21:30.483' AS DateTime))
INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (10, 18, 1, 4, 51175999, 20000, 6, N'nhan', 4, 9, CAST(N'2024-07-25T14:30:16.577' AS DateTime))
INSERT [dbo].[Quote] ([id], [product_id], [account_id], [quote_status_id], [product_price], [production_price], [profit_rate], [note], [design_staff_id], [production_staff_id], [created]) VALUES (11, 19, 6, 4, 52701332, 10000, 6, N'123123', 4, 5, CAST(N'2024-07-25T16:05:49.100' AS DateTime))
SET IDENTITY_INSERT [dbo].[Quote] OFF
GO
SET IDENTITY_INSERT [dbo].[Quote_Status] ON 

INSERT [dbo].[Quote_Status] ([id], [name]) VALUES (1, N'Received')
INSERT [dbo].[Quote_Status] ([id], [name]) VALUES (2, N'Priced')
INSERT [dbo].[Quote_Status] ([id], [name]) VALUES (3, N'Assigned')
INSERT [dbo].[Quote_Status] ([id], [name]) VALUES (4, N'Completed')
INSERT [dbo].[Quote_Status] ([id], [name]) VALUES (5, N'Cancelled')
SET IDENTITY_INSERT [dbo].[Quote_Status] OFF
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (NULL) FOR [username]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (NULL) FOR [password]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (NULL) FOR [phone]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (NULL) FOR [dob]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (NULL) FOR [note]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (NULL) FOR [design_staff_id]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (NULL) FOR [production_staff_id]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT (NULL) FOR [mounting_size]
GO
ALTER TABLE [dbo].[Production_Process] ADD  DEFAULT (NULL) FOR [imageUrl]
GO
ALTER TABLE [dbo].[Quote] ADD  DEFAULT (NULL) FOR [note]
GO
ALTER TABLE [dbo].[Quote] ADD  DEFAULT (NULL) FOR [design_staff_id]
GO
ALTER TABLE [dbo].[Quote] ADD  DEFAULT (NULL) FOR [production_staff_id]
GO
ALTER TABLE [dbo].[Diamond]  WITH CHECK ADD FOREIGN KEY([diamond_color_id])
REFERENCES [dbo].[Diamond_Color] ([id])
GO
ALTER TABLE [dbo].[Diamond]  WITH CHECK ADD FOREIGN KEY([diamond_origin_id])
REFERENCES [dbo].[Diamond_Origin] ([id])
GO
ALTER TABLE [dbo].[Diamond]  WITH CHECK ADD FOREIGN KEY([diamond_clarity_id])
REFERENCES [dbo].[Diamond_Clarity] ([id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([design_staff_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([order_status_id])
REFERENCES [dbo].[Order_Status] ([id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([production_staff_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([product_type_id])
REFERENCES [dbo].[Product_Type] ([id])
GO
ALTER TABLE [dbo].[Product_Diamond]  WITH CHECK ADD FOREIGN KEY([diamond_id])
REFERENCES [dbo].[Diamond] ([id])
GO
ALTER TABLE [dbo].[Product_Diamond]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Product_Metal]  WITH CHECK ADD FOREIGN KEY([metal_id])
REFERENCES [dbo].[Metal] ([id])
GO
ALTER TABLE [dbo].[Product_Metal]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Production_Process]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[Production_Process]  WITH CHECK ADD FOREIGN KEY([production_status_id])
REFERENCES [dbo].[Production_Status] ([id])
GO
ALTER TABLE [dbo].[Production_Process]  WITH CHECK ADD FOREIGN KEY([production_status_id])
REFERENCES [dbo].[Production_Status] ([id])
GO
ALTER TABLE [dbo].[Quote]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Quote]  WITH CHECK ADD FOREIGN KEY([design_staff_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Quote]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Quote]  WITH CHECK ADD FOREIGN KEY([production_staff_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Quote]  WITH CHECK ADD FOREIGN KEY([quote_status_id])
REFERENCES [dbo].[Quote_Status] ([id])
GO
USE [master]
GO
ALTER DATABASE [DiamondShopDB] SET  READ_WRITE 
GO
