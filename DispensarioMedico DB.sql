USE [master]
GO
/****** Object:  Database [DispensarioMedico]    Script Date: 26/7/18 12:52:26 a. m. ******/
CREATE DATABASE [DispensarioMedico]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DispensarioMedico', FILENAME = N'C:\Users\scarlaC\DispensarioMedico.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DispensarioMedico_log', FILENAME = N'C:\Users\scarlaC\DispensarioMedico_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DispensarioMedico] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DispensarioMedico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DispensarioMedico] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DispensarioMedico] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DispensarioMedico] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DispensarioMedico] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DispensarioMedico] SET ARITHABORT OFF 
GO
ALTER DATABASE [DispensarioMedico] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DispensarioMedico] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DispensarioMedico] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DispensarioMedico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DispensarioMedico] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DispensarioMedico] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DispensarioMedico] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DispensarioMedico] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DispensarioMedico] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DispensarioMedico] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DispensarioMedico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DispensarioMedico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DispensarioMedico] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DispensarioMedico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DispensarioMedico] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DispensarioMedico] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DispensarioMedico] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DispensarioMedico] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DispensarioMedico] SET  MULTI_USER 
GO
ALTER DATABASE [DispensarioMedico] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DispensarioMedico] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DispensarioMedico] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DispensarioMedico] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DispensarioMedico] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DispensarioMedico] SET QUERY_STORE = OFF
GO
USE [DispensarioMedico]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DispensarioMedico]
GO
/****** Object:  Table [dbo].[Farmacos]    Script Date: 26/7/18 12:52:27 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Farmacos](
	[IdFarmaco] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[PrincipioActivo] [varchar](50) NOT NULL,
	[IdViaAdministracion] [int] NOT NULL,
	[FormaFarmaceutica] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Farmacos] PRIMARY KEY CLUSTERED 
(
	[IdFarmaco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 26/7/18 12:52:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicamentos]    Script Date: 26/7/18 12:52:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicamentos](
	[IdMedicamento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](70) NOT NULL,
	[IdFarmaco] [int] NOT NULL,
	[IdMarca] [int] NOT NULL,
	[IdUbicacion] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Dosis] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Medicamentos] PRIMARY KEY CLUSTERED 
(
	[IdMedicamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 26/7/18 12:52:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[IdMedico] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](70) NOT NULL,
	[Cedula] [varchar](11) NOT NULL,
	[Especialidad] [varchar](50) NOT NULL,
	[IdTandaTrabajo] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED 
(
	[IdMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 26/7/18 12:52:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[IdPaciente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](70) NOT NULL,
	[Cedula] [varchar](11) NOT NULL,
	[NoCarnet] [int] NOT NULL,
	[IdTipoPaciente] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[IdPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_Visitas]    Script Date: 26/7/18 12:52:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_Visitas](
	[IdVisita] [int] IDENTITY(1,1) NOT NULL,
	[IdMedico] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[FechaVisita] [date] NOT NULL,
	[HoraVisita] [time](7) NOT NULL,
	[Sintomas] [varchar](70) NOT NULL,
	[IdMedicamento] [int] NOT NULL,
	[Recomendaciones] [varchar](70) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Registro_Visitas] PRIMARY KEY CLUSTERED 
(
	[IdVisita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TandaTrabajo]    Script Date: 26/7/18 12:52:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TandaTrabajo](
	[IdTandaTrabajo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TandaTrabajo] PRIMARY KEY CLUSTERED 
(
	[IdTandaTrabajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPaciente]    Script Date: 26/7/18 12:52:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPaciente](
	[IdTipoPaciente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoPaciente] PRIMARY KEY CLUSTERED 
(
	[IdTipoPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicacion]    Script Date: 26/7/18 12:52:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicacion](
	[IdUbicacion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Estante] [varchar](50) NOT NULL,
	[Tramo] [varchar](50) NOT NULL,
	[Celda] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Ubicacion] PRIMARY KEY CLUSTERED 
(
	[IdUbicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ViaAdmin]    Script Date: 26/7/18 12:52:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViaAdmin](
	[IdViaAdministracion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ViaAdmin] PRIMARY KEY CLUSTERED 
(
	[IdViaAdministracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Farmacos]  WITH CHECK ADD  CONSTRAINT [FK_Farmacos_ViaAdmin] FOREIGN KEY([IdViaAdministracion])
REFERENCES [dbo].[ViaAdmin] ([IdViaAdministracion])
GO
ALTER TABLE [dbo].[Farmacos] CHECK CONSTRAINT [FK_Farmacos_ViaAdmin]
GO
ALTER TABLE [dbo].[Medicamentos]  WITH CHECK ADD  CONSTRAINT [FK_Medicamentos_Farmacos1] FOREIGN KEY([IdFarmaco])
REFERENCES [dbo].[Farmacos] ([IdFarmaco])
GO
ALTER TABLE [dbo].[Medicamentos] CHECK CONSTRAINT [FK_Medicamentos_Farmacos1]
GO
ALTER TABLE [dbo].[Medicamentos]  WITH CHECK ADD  CONSTRAINT [FK_Medicamentos_Marcas] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marcas] ([IdMarca])
GO
ALTER TABLE [dbo].[Medicamentos] CHECK CONSTRAINT [FK_Medicamentos_Marcas]
GO
ALTER TABLE [dbo].[Medicamentos]  WITH CHECK ADD  CONSTRAINT [FK_Medicamentos_Ubicacion] FOREIGN KEY([IdUbicacion])
REFERENCES [dbo].[Ubicacion] ([IdUbicacion])
GO
ALTER TABLE [dbo].[Medicamentos] CHECK CONSTRAINT [FK_Medicamentos_Ubicacion]
GO
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medicos_TandaTrabajo] FOREIGN KEY([IdTandaTrabajo])
REFERENCES [dbo].[TandaTrabajo] ([IdTandaTrabajo])
GO
ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [FK_Medicos_TandaTrabajo]
GO
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Pacientes_TipoPaciente] FOREIGN KEY([IdTipoPaciente])
REFERENCES [dbo].[TipoPaciente] ([IdTipoPaciente])
GO
ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_Pacientes_TipoPaciente]
GO
ALTER TABLE [dbo].[Registro_Visitas]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Visitas_Medicamentos] FOREIGN KEY([IdMedicamento])
REFERENCES [dbo].[Medicamentos] ([IdMedicamento])
GO
ALTER TABLE [dbo].[Registro_Visitas] CHECK CONSTRAINT [FK_Registro_Visitas_Medicamentos]
GO
ALTER TABLE [dbo].[Registro_Visitas]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Visitas_Medicos] FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([IdMedico])
GO
ALTER TABLE [dbo].[Registro_Visitas] CHECK CONSTRAINT [FK_Registro_Visitas_Medicos]
GO
ALTER TABLE [dbo].[Registro_Visitas]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Visitas_Pacientes] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Pacientes] ([IdPaciente])
GO
ALTER TABLE [dbo].[Registro_Visitas] CHECK CONSTRAINT [FK_Registro_Visitas_Pacientes]
GO
USE [master]
GO
ALTER DATABASE [DispensarioMedico] SET  READ_WRITE 
GO
