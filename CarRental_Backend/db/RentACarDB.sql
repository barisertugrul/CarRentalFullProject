USE [master]
GO
/****** Object:  Database [RentACar]    Script Date: 10.4.2021 01:31:59 ******/
CREATE DATABASE [RentACar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RentACar', FILENAME = N'C:\Users\baris\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\RentACar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RentACar_log', FILENAME = N'C:\Users\baris\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\RentACar.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RentACar] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RentACar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RentACar] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [RentACar] SET ANSI_NULLS ON 
GO
ALTER DATABASE [RentACar] SET ANSI_PADDING ON 
GO
ALTER DATABASE [RentACar] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [RentACar] SET ARITHABORT ON 
GO
ALTER DATABASE [RentACar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RentACar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RentACar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RentACar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RentACar] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [RentACar] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [RentACar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RentACar] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [RentACar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RentACar] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RentACar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RentACar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RentACar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RentACar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RentACar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RentACar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RentACar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RentACar] SET RECOVERY FULL 
GO
ALTER DATABASE [RentACar] SET  MULTI_USER 
GO
ALTER DATABASE [RentACar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RentACar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RentACar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RentACar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RentACar] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RentACar] SET QUERY_STORE = OFF
GO
USE [RentACar]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [RentACar]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 10.4.2021 01:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 10.4.2021 01:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[ImagePath] [varchar](max) NOT NULL,
	[Date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 10.4.2021 01:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[CarName] [nchar](25) NOT NULL,
	[ModelYear] [smallint] NOT NULL,
	[DailyPrice] [money] NOT NULL,
	[Description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 10.4.2021 01:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 10.4.2021 01:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CardName] [nvarchar](25) NOT NULL,
	[CardHolder] [nvarchar](50) NOT NULL,
	[CardNumber] [nchar](16) NOT NULL,
	[ExpYear] [nchar](4) NOT NULL,
	[ExpMonth] [nchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10.4.2021 01:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 10.4.2021 01:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 10.4.2021 01:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[RentStartDate] [date] NOT NULL,
	[RentEndDate] [date] NOT NULL,
	[ReturnDate] [date] NULL,
	[Amount] [money] NOT NULL,
	[PayConfirm] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 10.4.2021 01:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10.4.2021 01:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Name]) VALUES (1, N'Honda')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (2, N'Mercedes')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (3, N'BMW')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (4, N'Wolksvagen')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 

INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1002, 1, N'Images/93e74ca6-4262-48d3-a589-6c61211d1236.jpg', CAST(N'2021-03-12' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1003, 1, N'Images/c68d705e-571f-47e8-afda-671ef1ed9695.jpg', CAST(N'2021-03-12' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1004, 2, N'Images/e132460f-2992-45e1-9ac3-7d47e0d57d3e.jpg', CAST(N'2021-03-12' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2002, 2, N'Images/6c386939-ae41-43c0-9b49-0a1cd510692c.jpg', CAST(N'2021-03-24' AS Date))
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (1, 2, 1, N'Merso                    ', 2018, 120.0000, N'Merso description')
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (2, 3, 2, N'Be-em-ve                 ', 2020, 350.0000, N'ffjfjhoiuohvex')
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (1002, 4, 3, N'Test Car                 ', 2014, 125.0000, N'Test car information')
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (1003, 2, 3, N'Merso 2                  ', 2018, 180.0000, N'Merso 2 information')
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (2002, 3, 2, N'Be-em-ve-2               ', 2020, 350.0000, N'Be-em-ve hakkinda açiklama')
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (3002, 2, 1, N'M                        ', 2018, 0.0000, N'M description')
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (4002, 2, 1, N'M                        ', 2018, 0.0000, N'M description')
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (5002, 2, 1, N'M                        ', 2018, 0.0000, N'M description')
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (5003, 2, 1, N'M                        ', 2018, 0.0000, N'M description')
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (6002, 2, 1, N'T T                      ', 2018, 110.0000, N'T T description')
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description]) VALUES (7002, 2, 1, N'T T                      ', 2018, 110.0000, N'T T description')
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([Id], [Name]) VALUES (1, N'Black')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (2, N'White')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (3, N'Blue')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (1, 2, N'ERT')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'editor')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (3, N'user')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (4, N'car.add')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (5, N'car.update')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (6, N'car.delete')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (7, N'rental.add')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (8, N'rental.update')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (9, N'rental.delete')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentStartDate], [RentEndDate], [ReturnDate], [Amount], [PayConfirm]) VALUES (2, 1, 1, CAST(N'2021-03-13' AS Date), CAST(N'2021-03-19' AS Date), NULL, 0.0000, 0)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentStartDate], [RentEndDate], [ReturnDate], [Amount], [PayConfirm]) VALUES (3, 1, 1, CAST(N'2021-03-06' AS Date), CAST(N'2021-03-21' AS Date), NULL, 0.0000, 0)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentStartDate], [RentEndDate], [ReturnDate], [Amount], [PayConfirm]) VALUES (1002, 2, 1, CAST(N'2021-03-18' AS Date), CAST(N'2021-03-24' AS Date), NULL, 0.0000, 0)
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentStartDate], [RentEndDate], [ReturnDate], [Amount], [PayConfirm]) VALUES (1003, 1, 1, CAST(N'2021-04-13' AS Date), CAST(N'2021-04-22' AS Date), NULL, 0.0000, 0)
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 

INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1, 3, 1)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (2, 3, 4)
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (2, N'Baris', N'Ertugrul', N'barisertugrul@ertyazilim.com', 0x3132333435, 0x3132333435, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (3, N'Baris', N'Ertugrul', N'barisertugrul@barisertugrul.com', 0xFE986BAE1FF51F926AC201037956099577482836573E59599A6D8B7F8E90C8A6FD416F08F141D6AAC7A9D911B84629350FE0ED5CC9B82E2BE22C447B0E6EACD1, 0x7DCE2EC673F0E1D4F23C3DB75AE27FD15981C14C25AD1F39BF6178390BF987B52D6B4C51EB806C6263BF3755F81270BE5F2F1DDFA731DAF4F27C912F81776674B4E1950E72788A8201ADAB026EE96744C5C64E1EF9C85355821C967D12C29D61A673655CDA8424171613C046A89D5E88808C310790BE73D12F81A42490FA0625, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (4, N'Baris', N'Ertugrul', N'barisertugrul1@barisertugrul.com', 0x24FCB5C7B9DC1302C70A3D50B49D8680CD17B0FC3EE51CD64A255A9FEDC896DB537B8BA7A016714D7447ACF572092D5DF866B492DD2A7F3A3D1E7D6C6A0CF2E9, 0x619F94B5B21647B7ECCAFF3DF00ED79A463EDD774AB7F61706359614458F2F0E0DA57776987BB5AB7B29AE1E4C6EB03F416F4349778599FE36B763C7243B71024BE976C247DFA4FB4927C23E05897889C6D101B2FDEE5197ACC0C98BE946A3388A5B9D3A295D40FEE3AC3F35AD50DA3BB3245BD0BB8E295F92BD4359C9CB6A5A, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Rentals] ADD  DEFAULT ((0)) FOR [PayConfirm]
GO
ALTER TABLE [dbo].[CarImages]  WITH CHECK ADD  CONSTRAINT [FK_Table_toCars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[CarImages] CHECK CONSTRAINT [FK_Table_toCars]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_ToBrands] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_ToBrands]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_ToColors] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_ToColors]
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_CreditCards_ToCustomers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_CreditCards_ToCustomers]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_ToUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_ToUsers]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_ToCars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_ToCars]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_ToCustomers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_ToCustomers]
GO
USE [master]
GO
ALTER DATABASE [RentACar] SET  READ_WRITE 
GO
