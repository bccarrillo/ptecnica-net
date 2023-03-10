USE [db_a93584_demo]
GO
/****** Object:  Table [dbo].[Autores]    Script Date: 3/02/2023 9:02:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[apellidos] [varchar](45) NULL,
 CONSTRAINT [PK_Autores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autores_has_libros]    Script Date: 3/02/2023 9:02:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autores_has_libros](
	[autores_id] [int] NULL,
	[libros_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editoriales]    Script Date: 3/02/2023 9:02:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editoriales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[sede] [varchar](45) NULL,
 CONSTRAINT [PK_Editoriales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 3/02/2023 9:02:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[editoriales_id] [int] NULL,
	[titulo] [varchar](45) NULL,
	[sinopsis] [text] NULL,
	[n_paginas] [varchar](45) NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 3/02/2023 9:02:06 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[fecha] [date] NULL,
	[clave] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[tipo_id] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_tipos] FOREIGN KEY([tipo_id])
REFERENCES [dbo].[UsuarioTipos] ([Id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_tipos]
GO
