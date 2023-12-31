USE [master]
GO
/****** Object:  Database [BankAccountMgmt]    Script Date: 7/12/2023 8:19:58 AM ******/
CREATE DATABASE [BankAccountMgmt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BankAccountMgmt', FILENAME = N'D:\Kendu\CLEAN\Databases\BankAccountMgmt.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BankAccountMgmt_log', FILENAME = N'D:\Kendu\CLEAN\Databases\BankAccountMgmt_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BankAccountMgmt] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankAccountMgmt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BankAccountMgmt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET ARITHABORT OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BankAccountMgmt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BankAccountMgmt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BankAccountMgmt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BankAccountMgmt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BankAccountMgmt] SET  MULTI_USER 
GO
ALTER DATABASE [BankAccountMgmt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BankAccountMgmt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BankAccountMgmt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BankAccountMgmt] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BankAccountMgmt] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BankAccountMgmt] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BankAccountMgmt] SET QUERY_STORE = OFF
GO
USE [BankAccountMgmt]
GO
/****** Object:  Table [dbo].[BankAccount]    Script Date: 7/12/2023 8:19:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankAccount](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[AccountType] [varchar](50) NULL,
	[Currency] [varchar](10) NULL,
	[Balance] [money] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_BankAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/12/2023 8:19:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[PhoneNumber] [varchar](15) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 7/12/2023 8:19:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EventType] [nvarchar](250) NOT NULL,
	[Payload] [nvarchar](max) NOT NULL,
	[IsDispatched] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [date] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 7/12/2023 8:19:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [uniqueidentifier] NOT NULL,
	[BankAccountId] [uniqueidentifier] NOT NULL,
	[TransactionType] [varchar](50) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Amount] [money] NOT NULL,
	[Reference] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/12/2023 8:19:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Password] [nvarchar](4000) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BankAccount]  WITH CHECK ADD  CONSTRAINT [FK_BankAccount_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[BankAccount] CHECK CONSTRAINT [FK_BankAccount_Customer]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_BankAccount] FOREIGN KEY([BankAccountId])
REFERENCES [dbo].[BankAccount] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_BankAccount]
GO
USE [master]
GO
ALTER DATABASE [BankAccountMgmt] SET  READ_WRITE 
GO
