USE [master]
GO

/****** Object:  Database [Airline]    Script Date: 15/04/2019 19:24:18 ******/
--CREATE DATABASE [Airline]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'Airline', FILENAME = N'C:\Airline.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'Airline_log', FILENAME = N'C:\Airline_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
--GO

ALTER DATABASE [Airline] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Airline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Airline] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Airline] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Airline] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Airline] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Airline] SET ARITHABORT OFF 
GO

ALTER DATABASE [Airline] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Airline] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Airline] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Airline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Airline] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Airline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Airline] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Airline] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Airline] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Airline] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Airline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Airline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Airline] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Airline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Airline] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Airline] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Airline] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Airline] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Airline] SET  MULTI_USER 
GO

ALTER DATABASE [Airline] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Airline] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Airline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Airline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Airline] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Airline] SET  READ_WRITE 
GO


