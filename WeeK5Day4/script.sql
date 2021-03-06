USE [master]
GO
/****** Object:  Database [NegozioElettronica]    Script Date: 26-Aug-21 3:33:03 PM ******/
CREATE DATABASE [NegozioElettronica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NegozioElettronica', FILENAME = N'C:\Users\julia.furnari\NegozioElettronica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NegozioElettronica_log', FILENAME = N'C:\Users\julia.furnari\NegozioElettronica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NegozioElettronica] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NegozioElettronica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ARITHABORT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NegozioElettronica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NegozioElettronica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NegozioElettronica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NegozioElettronica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NegozioElettronica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NegozioElettronica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NegozioElettronica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NegozioElettronica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NegozioElettronica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NegozioElettronica] SET  MULTI_USER 
GO
ALTER DATABASE [NegozioElettronica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NegozioElettronica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NegozioElettronica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NegozioElettronica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NegozioElettronica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NegozioElettronica] SET QUERY_STORE = OFF
GO
USE [NegozioElettronica]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [NegozioElettronica]
GO
/****** Object:  Table [dbo].[Prodotto]    Script Date: 26-Aug-21 3:33:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prodotto](
	[Marca] [nvarchar](50) NOT NULL,
	[Modello] [nvarchar](50) NOT NULL,
	[QuantitàInMagazzino] [int] NOT NULL,
	[MemoriaGB] [float] NULL,
	[SistemaOperativo] [nvarchar](50) NULL,
	[TouchScreen] [bit] NULL,
	[Pollici] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoProdotto] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Prodotto]  WITH CHECK ADD  CONSTRAINT [ck_SO] CHECK  (([SistemaOperativo]='Windows' OR [SistemaOperativo]='Mac' OR [SistemaOperativo]='Linux'))
GO
ALTER TABLE [dbo].[Prodotto] CHECK CONSTRAINT [ck_SO]
GO
ALTER TABLE [dbo].[Prodotto]  WITH CHECK ADD  CONSTRAINT [ck_TP] CHECK  (([TipoProdotto]='Cellulare' OR [TipoProdotto]='Pc' OR [TipoProdotto]='Tv'))
GO
ALTER TABLE [dbo].[Prodotto] CHECK CONSTRAINT [ck_TP]
GO
USE [master]
GO
ALTER DATABASE [NegozioElettronica] SET  READ_WRITE 
GO
