USE [master]
GO
/****** Object:  Database [metal]    Script Date: 4/18/2020 1:51:19 AM ******/
CREATE DATABASE [metal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'metal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\metal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'metal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\metal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [metal] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [metal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [metal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [metal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [metal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [metal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [metal] SET ARITHABORT OFF 
GO
ALTER DATABASE [metal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [metal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [metal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [metal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [metal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [metal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [metal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [metal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [metal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [metal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [metal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [metal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [metal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [metal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [metal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [metal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [metal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [metal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [metal] SET  MULTI_USER 
GO
ALTER DATABASE [metal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [metal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [metal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [metal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [metal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [metal] SET QUERY_STORE = OFF
GO
USE [metal]
GO
/****** Object:  Table [dbo].[archivos]    Script Date: 4/18/2020 1:51:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[archivos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreReal] [nvarchar](50) NULL,
	[nombreFisico] [nvarchar](50) NULL,
 CONSTRAINT [PK_archivos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 4/18/2020 1:51:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cliente] [nvarchar](50) NULL,
	[telefono] [nvarchar](50) NULL,
	[celular] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[cuit] [nvarchar](50) NULL,
	[direccion] [nvarchar](50) NULL,
	[localidad] [nvarchar](50) NULL,
	[provincia] [nvarchar](50) NULL,
	[fechaalta] [date] NULL,
	[apellido] [nvarchar](50) NULL,
	[nombre] [nvarchar](50) NULL,
	[dni] [nvarchar](50) NULL,
	[telefonoc] [nvarchar](50) NULL,
	[celularc] [nvarchar](50) NULL,
	[emailc] [nvarchar](50) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[material]    Script Date: 4/18/2020 1:51:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[material](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_material] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ordentrabajo]    Script Date: 4/18/2020 1:51:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordentrabajo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NULL,
	[fechaRecepcion] [date] NULL,
	[fechaEntrega] [date] NULL,
	[trabajo] [nvarchar](50) NULL,
	[cantidad] [int] NULL,
	[idTamanio] [int] NULL,
	[idMaterial] [int] NULL,
	[idTerminacion] [int] NULL,
	[observaciones] [nvarchar](50) NULL,
	[enCurso] [bit] NULL,
	[pausado] [bit] NULL,
	[finalizado] [bit] NULL,
	[entregado] [bit] NULL,
	[cancelado] [bit] NULL,
	[idPago] [int] NULL,
	[monto] [decimal](18, 0) NULL,
 CONSTRAINT [PK_trabajos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pago]    Script Date: 4/18/2020 1:51:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_pago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tamanio]    Script Date: 4/18/2020 1:51:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tamanio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_tamanio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[terminacion]    Script Date: 4/18/2020 1:51:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[terminacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_terminacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trabajosArchivos]    Script Date: 4/18/2020 1:51:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trabajosArchivos](
	[id] [uniqueidentifier] NOT NULL,
	[idTrabajos] [int] NULL,
	[idArchivos] [int] NULL,
 CONSTRAINT [PK_trabajosArchivos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[trabajosArchivos]  WITH CHECK ADD  CONSTRAINT [FK_trabajosArchivos_archivos] FOREIGN KEY([idArchivos])
REFERENCES [dbo].[archivos] ([id])
GO
ALTER TABLE [dbo].[trabajosArchivos] CHECK CONSTRAINT [FK_trabajosArchivos_archivos]
GO
USE [master]
GO
ALTER DATABASE [metal] SET  READ_WRITE 
GO
