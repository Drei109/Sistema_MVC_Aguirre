USE [master]
GO
/****** Object:  Database [db_galeria_web2]    Script Date: 1/05/2018 13:56:20 ******/
CREATE DATABASE [db_galeria_web2]
 
ALTER DATABASE [db_galeria_web2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_galeria_web2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_galeria_web2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_galeria_web2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_galeria_web2] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_galeria_web2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_galeria_web2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_galeria_web2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_galeria_web2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_galeria_web2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_galeria_web2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_galeria_web2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_galeria_web2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_galeria_web2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_galeria_web2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_galeria_web2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_galeria_web2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_galeria_web2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_galeria_web2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_galeria_web2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_galeria_web2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_galeria_web2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_galeria_web2] SET RECOVERY FULL 
GO
ALTER DATABASE [db_galeria_web2] SET  MULTI_USER 
GO
ALTER DATABASE [db_galeria_web2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_galeria_web2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_galeria_web2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_galeria_web2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_galeria_web2] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_galeria_web2', N'ON'
GO
ALTER DATABASE [db_galeria_web2] SET QUERY_STORE = OFF
GO
USE [db_galeria_web2]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
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
USE [db_galeria_web2]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 1/05/2018 13:56:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[categoria_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[descripcion] [text] NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[categoria_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documento]    Script Date: 1/05/2018 13:56:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[documento_id] [int] IDENTITY(1,1) NOT NULL,
	[categoria_id] [int] NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[descripcion] [text] NULL,
	[extension] [varchar](4) NOT NULL,
	[tamanio] [varchar](20) NOT NULL,
	[tipo] [varchar](250) NOT NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[documento_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Galeria]    Script Date: 1/05/2018 13:56:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Galeria](
	[galeria_id] [int] IDENTITY(1,1) NOT NULL,
	[categoria_id] [int] NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[descripcion] [text] NULL,
	[imagen] [varchar](250) NOT NULL,
	[thumbail] [varchar](250) NOT NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[galeria_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 1/05/2018 13:56:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[persona_id] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[email] [varchar](100) NULL,
	[celular] [varchar](15) NULL,
	[estado] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 1/05/2018 13:56:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuario_id] [int] IDENTITY(1,1) NOT NULL,
	[persona_id] [int] NOT NULL,
	[usuario] [varchar](30) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[nivel] [varchar](50) NOT NULL,
	[avatar] [varchar](250) NULL,
	[estado] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 
GO
INSERT [dbo].[Categoria] ([categoria_id], [nombre], [descripcion], [estado]) VALUES (1, N'Cursos', N'Categoria 1 xxxxxx', N'A')
GO
INSERT [dbo].[Categoria] ([categoria_id], [nombre], [descripcion], [estado]) VALUES (2, N'Horarios', N'Categoria 2 xxxxxx', N'A')
GO
INSERT [dbo].[Categoria] ([categoria_id], [nombre], [descripcion], [estado]) VALUES (3, N'Docentes', N'Categoria 3 xxxxxx', N'A')
GO
INSERT [dbo].[Categoria] ([categoria_id], [nombre], [descripcion], [estado]) VALUES (4, N'Estudiantes', N'Categoria 3 xxxxxx', N'A')
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Documento] ON 
GO
INSERT [dbo].[Documento] ([documento_id], [categoria_id], [nombre], [descripcion], [extension], [tamanio], [tipo], [estado]) VALUES (2, 1, N'Doc1', N'desc1', N'docx', N'150', N'Documento', N'A')
GO
INSERT [dbo].[Documento] ([documento_id], [categoria_id], [nombre], [descripcion], [extension], [tamanio], [tipo], [estado]) VALUES (4, 2, N'Doc2', N'desc2', N'xlsx', N'150', N'Documento', N'I')
GO
SET IDENTITY_INSERT [dbo].[Documento] OFF
GO
SET IDENTITY_INSERT [dbo].[Galeria] ON 
GO
INSERT [dbo].[Galeria] ([galeria_id], [categoria_id], [nombre], [descripcion], [imagen], [thumbail], [estado]) VALUES (1, 1, N'Gal1', N'Galeria 1 descripcion', N'--', N'--', N'A')
GO
INSERT [dbo].[Galeria] ([galeria_id], [categoria_id], [nombre], [descripcion], [imagen], [thumbail], [estado]) VALUES (2, 2, N'Test2', N'Lorem ipsum', N'--', N'--', N'I')
GO
SET IDENTITY_INSERT [dbo].[Galeria] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 
GO
INSERT [dbo].[Persona] ([persona_id], [dni], [apellido], [nombre], [email], [celular], [estado]) VALUES (1, N'12345678', N'Lanchipa Valencia', N'Enrique', N'elanchipa@upt.pe', N'', N'A')
GO
INSERT [dbo].[Persona] ([persona_id], [dni], [apellido], [nombre], [email], [celular], [estado]) VALUES (2, N'223344', N'Ale Nieto', N'Tito', N'tito@gmail.com', N'', N'A')
GO
INSERT [dbo].[Persona] ([persona_id], [dni], [apellido], [nombre], [email], [celular], [estado]) VALUES (3, N'87654321', N'Rodriguez Marca', N'Elard', N'elardroma@hotmail.com', N'', N'A')
GO
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([usuario_id], [persona_id], [usuario], [clave], [nivel], [avatar], [estado]) VALUES (1, 1, N'elanchipa', N'123456', N'Administrador', N'foto1.jpg', N'A')
GO
INSERT [dbo].[Usuario] ([usuario_id], [persona_id], [usuario], [clave], [nivel], [avatar], [estado]) VALUES (2, 1, N'tale', N'1234', N'Supervisor', N'foto2.jpg', N'A')
GO
INSERT [dbo].[Usuario] ([usuario_id], [persona_id], [usuario], [clave], [nivel], [avatar], [estado]) VALUES (3, 1, N'eladroma', N'123', N'Usuario', N'foto3.jpg', N'A')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Persona__AB6E616456C8BDC5]    Script Date: 1/05/2018 13:56:21 ******/
ALTER TABLE [dbo].[Persona] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Persona__D87608A779DBE3ED]    Script Date: 1/05/2018 13:56:21 ******/
ALTER TABLE [dbo].[Persona] ADD UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__9AFF8FC6B494C35B]    Script Date: 1/05/2018 13:56:21 ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Documento]  WITH CHECK ADD FOREIGN KEY([categoria_id])
REFERENCES [dbo].[Categoria] ([categoria_id])
GO
ALTER TABLE [dbo].[Galeria]  WITH CHECK ADD FOREIGN KEY([categoria_id])
REFERENCES [dbo].[Categoria] ([categoria_id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([persona_id])
REFERENCES [dbo].[Persona] ([persona_id])
GO
USE [master]
GO
ALTER DATABASE [db_galeria_web2] SET  READ_WRITE 
GO
