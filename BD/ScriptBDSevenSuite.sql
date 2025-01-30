USE [master]
GO
/****** Object:  Database [SevenSuite]    Script Date: 30/1/2025 4:12:12 a. m. ******/
CREATE DATABASE [SevenSuite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SevenSuite', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SevenSuite.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SevenSuite_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SevenSuite_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SevenSuite] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SevenSuite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SevenSuite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SevenSuite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SevenSuite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SevenSuite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SevenSuite] SET ARITHABORT OFF 
GO
ALTER DATABASE [SevenSuite] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SevenSuite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SevenSuite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SevenSuite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SevenSuite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SevenSuite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SevenSuite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SevenSuite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SevenSuite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SevenSuite] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SevenSuite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SevenSuite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SevenSuite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SevenSuite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SevenSuite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SevenSuite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SevenSuite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SevenSuite] SET RECOVERY FULL 
GO
ALTER DATABASE [SevenSuite] SET  MULTI_USER 
GO
ALTER DATABASE [SevenSuite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SevenSuite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SevenSuite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SevenSuite] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SevenSuite]
GO
/****** Object:  Table [dbo].[EstadoCivil]    Script Date: 30/1/2025 4:12:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoCivil](
	[Id_estado_civil] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nchar](20) NOT NULL,
 CONSTRAINT [PK_estado_civil] PRIMARY KEY CLUSTERED 
(
	[Id_estado_civil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeveClie]    Script Date: 30/1/2025 4:12:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeveClie](
	[id_clie] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [nvarchar](15) NULL,
	[nombre] [nvarchar](100) NULL,
	[genero] [nchar](1) NULL,
	[fecha_nac] [date] NULL,
	[id_estado_civil] [int] NOT NULL,
 CONSTRAINT [PK_SEVECLIE] PRIMARY KEY CLUSTERED 
(
	[id_clie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EstadoCivil] ON 
GO
INSERT [dbo].[EstadoCivil] ([Id_estado_civil], [descripcion]) VALUES (1, N'Soltero/a           ')
GO
INSERT [dbo].[EstadoCivil] ([Id_estado_civil], [descripcion]) VALUES (2, N'Casado/a            ')
GO
INSERT [dbo].[EstadoCivil] ([Id_estado_civil], [descripcion]) VALUES (3, N'Divorciado/a        ')
GO
INSERT [dbo].[EstadoCivil] ([Id_estado_civil], [descripcion]) VALUES (4, N'Viudo/a             ')
GO
SET IDENTITY_INSERT [dbo].[EstadoCivil] OFF
GO
SET IDENTITY_INSERT [dbo].[SeveClie] ON 
GO
INSERT [dbo].[SeveClie] ([id_clie], [cedula], [nombre], [genero], [fecha_nac], [id_estado_civil]) VALUES (1, N'7069553', N'Elias', N'M', CAST(N'1964-10-19' AS Date), 2)
GO
INSERT [dbo].[SeveClie] ([id_clie], [cedula], [nombre], [genero], [fecha_nac], [id_estado_civil]) VALUES (2, N'234566777', N'Jose Martinez', N'M', CAST(N'2025-01-10' AS Date), 3)
GO
INSERT [dbo].[SeveClie] ([id_clie], [cedula], [nombre], [genero], [fecha_nac], [id_estado_civil]) VALUES (3, N'66777', N'Maria', N'F', CAST(N'2025-01-14' AS Date), 3)
GO
INSERT [dbo].[SeveClie] ([id_clie], [cedula], [nombre], [genero], [fecha_nac], [id_estado_civil]) VALUES (6, N'23232', N'ewewewew', N'M', CAST(N'2025-01-30' AS Date), 4)
GO
SET IDENTITY_INSERT [dbo].[SeveClie] OFF
GO
USE [master]
GO
ALTER DATABASE [SevenSuite] SET  READ_WRITE 
GO
