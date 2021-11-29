USE [MedicionHumedadDB]
GO
/****** Object:  Table [dbo].[Checkin]    Script Date: 5/25/2020 11:47:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Checkin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReservaId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
	[FechaCheckin] [datetime] NOT NULL,
	[EdificioId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Checkin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Checkout]    Script Date: 5/25/2020 11:47:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Checkout](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReservaId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
	[FechaCheckout] [datetime] NOT NULL,
	[EdificioId] [int] NOT NULL,
	[CheckinId] [int] NOT NULL,
 CONSTRAINT [PK_Checkout] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Edificio]    Script Date: 5/25/2020 11:47:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Edificio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Edificio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Espacio]    Script Date: 5/25/2020 11:47:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Espacio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[PisoId] [int] NOT NULL,
 CONSTRAINT [PK_Espacio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Piso]    Script Date: 5/25/2020 11:47:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Piso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NOT NULL,
	[EdificioId] [int] NOT NULL,
 CONSTRAINT [PK_Piso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 5/25/2020 11:47:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaDesde] [datetime] NOT NULL,
	[FechaHasta] [datetime] NOT NULL,
	[EspacioId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
	[CreadaEn] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 5/25/2020 11:47:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GUID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[EsPersonalAuxiliar] [bit] NOT NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Checkin]  WITH CHECK ADD  CONSTRAINT [FK_Checkin_Edificio] FOREIGN KEY([EdificioId])
REFERENCES [dbo].[Edificio] ([Id])
GO
ALTER TABLE [dbo].[Checkin] CHECK CONSTRAINT [FK_Checkin_Edificio]
GO
ALTER TABLE [dbo].[Checkin]  WITH CHECK ADD  CONSTRAINT [FK_Checkin_Reserva] FOREIGN KEY([ReservaId])
REFERENCES [dbo].[Reserva] ([Id])
GO
ALTER TABLE [dbo].[Checkin] CHECK CONSTRAINT [FK_Checkin_Reserva]
GO
ALTER TABLE [dbo].[Checkin]  WITH CHECK ADD  CONSTRAINT [FK_Checkin_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([Id])
GO
ALTER TABLE [dbo].[Checkin] CHECK CONSTRAINT [FK_Checkin_Staff]
GO
ALTER TABLE [dbo].[Checkout]  WITH CHECK ADD  CONSTRAINT [FK_Checkout_Checkin] FOREIGN KEY([CheckinId])
REFERENCES [dbo].[Checkin] ([Id])
GO
ALTER TABLE [dbo].[Checkout] CHECK CONSTRAINT [FK_Checkout_Checkin]
GO
ALTER TABLE [dbo].[Checkout]  WITH CHECK ADD  CONSTRAINT [FK_Checkout_Edificio] FOREIGN KEY([EdificioId])
REFERENCES [dbo].[Edificio] ([Id])
GO
ALTER TABLE [dbo].[Checkout] CHECK CONSTRAINT [FK_Checkout_Edificio]
GO
ALTER TABLE [dbo].[Checkout]  WITH CHECK ADD  CONSTRAINT [FK_Checkout_Reserva] FOREIGN KEY([ReservaId])
REFERENCES [dbo].[Reserva] ([Id])
GO
ALTER TABLE [dbo].[Checkout] CHECK CONSTRAINT [FK_Checkout_Reserva]
GO
ALTER TABLE [dbo].[Checkout]  WITH CHECK ADD  CONSTRAINT [FK_Checkout_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([Id])
GO
ALTER TABLE [dbo].[Checkout] CHECK CONSTRAINT [FK_Checkout_Staff]
GO
ALTER TABLE [dbo].[Espacio]  WITH CHECK ADD  CONSTRAINT [FK_Espacio_Piso] FOREIGN KEY([PisoId])
REFERENCES [dbo].[Piso] ([Id])
GO
ALTER TABLE [dbo].[Espacio] CHECK CONSTRAINT [FK_Espacio_Piso]
GO
ALTER TABLE [dbo].[Piso]  WITH CHECK ADD  CONSTRAINT [FK_Piso_Edificio] FOREIGN KEY([EdificioId])
REFERENCES [dbo].[Edificio] ([Id])
GO
ALTER TABLE [dbo].[Piso] CHECK CONSTRAINT [FK_Piso_Edificio]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Espacio] FOREIGN KEY([EspacioId])
REFERENCES [dbo].[Espacio] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Espacio]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([Id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Staff]
GO
