USE [DANIELQUISPE]
GO
/****** Object:  Table [dbo].[HIJOS]    Script Date: 11/09/2022 19:47:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HIJOS](
	[Idhijo] [int] NOT NULL,
	[idpersonal] [int] NULL,
	[tipodoc] [varchar](1) NULL,
	[numerodoc] [varchar](1) NULL,
	[apPaterno] [varchar](1) NULL,
	[apMaterno] [varchar](1) NULL,
	[mombre1] [varchar](1) NULL,
	[nombre2] [varchar](1) NULL,
	[nombrecompleto] [varchar](1) NULL,
	[fechaNac] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Idhijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONAL]    Script Date: 11/09/2022 19:47:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONAL](
	[idpersonal] [int] NOT NULL,
	[tipodoc] [varchar](1) NULL,
	[numerodoc] [varchar](1) NULL,
	[apPaterno] [varchar](1) NULL,
	[apMaterno] [varchar](1) NULL,
	[mombre1] [varchar](1) NULL,
	[nombre2] [varchar](1) NULL,
	[nombrescomple] [varchar](1) NULL,
	[fechaNsc] [date] NULL,
	[fechaInges] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idpersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_HIJOS]    Script Date: 11/09/2022 19:47:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_HIJOS](
	[Idhijo] [int] NOT NULL,
	[idpersonal] [int] NULL,
	[tipodoc] [varchar](10) NULL,
	[numerodoc] [varchar](100) NULL,
	[apPaterno] [varchar](100) NULL,
	[apMaterno] [varchar](100) NULL,
	[mombre1] [varchar](100) NULL,
	[nombre2] [varchar](100) NULL,
	[nombrecompleto] [varchar](100) NULL,
	[fechaNac] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Idhijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tb_HIJOS] ([Idhijo], [idpersonal], [tipodoc], [numerodoc], [apPaterno], [apMaterno], [mombre1], [nombre2], [nombrecompleto], [fechaNac]) VALUES (2, 2, N'2', N'34567654', N'luce', N'mamani', N'juanita', N'paola', N'Luciana', CAST(N'2022-02-02' AS Date))
INSERT [dbo].[tb_HIJOS] ([Idhijo], [idpersonal], [tipodoc], [numerodoc], [apPaterno], [apMaterno], [mombre1], [nombre2], [nombrecompleto], [fechaNac]) VALUES (3, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'David Daniel', CAST(N'2022-09-05' AS Date))
GO
/****** Object:  StoredProcedure [dbo].[INSERTARhijo]    Script Date: 11/09/2022 19:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTARhijo](
@idpersonal  int,
@tipodoc    varchar(59),
@numerodoc  varchar(50),
@apPaterno  varchar(50),
@apMaterno varchar(30),
@mombre1   varchar(20),
@nombre2 varchar(20),
@nombrescomple  varchar(20),
@fechaNac        date,
@fechaInges     date
)
as
GO
