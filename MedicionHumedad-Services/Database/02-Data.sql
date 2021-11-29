USE [MedicionHumedadDB]
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 
GO
INSERT [dbo].[Staff] ([Id], [GUID], [Nombre], [Apellido], [Activo], [EsPersonalAuxiliar], [Password]) VALUES (1, N'dgravisaco001', N'Diego', N'Gravisaco', 1, 1, N'Racing13')
GO
INSERT [dbo].[Staff] ([Id], [GUID], [Nombre], [Apellido], [Activo], [EsPersonalAuxiliar], [Password]) VALUES (2, N'jprada001', N'Josefina', N'Prada', 1, 0, N'Racing13')
GO
INSERT [dbo].[Staff] ([Id], [GUID], [Nombre], [Apellido], [Activo], [EsPersonalAuxiliar], [Password]) VALUES (3, N'bwayne001', N'Bruce', N'Wayne', 1, 0, N'Racing13')
GO
INSERT [dbo].[Staff] ([Id], [GUID], [Nombre], [Apellido], [Activo], [EsPersonalAuxiliar], [Password]) VALUES (4, N'pparker001', N'Peter', N'Parker', 1, 1, N'Racing13')
GO
INSERT [dbo].[Staff] ([Id], [GUID], [Nombre], [Apellido], [Activo], [EsPersonalAuxiliar], [Password]) VALUES (5, N'kren001', N'Kylo', N'Ren', 1, 1, N'Racing13')
GO
INSERT [dbo].[Staff] ([Id], [GUID], [Nombre], [Apellido], [Activo], [EsPersonalAuxiliar], [Password]) VALUES (6, N'hsolo001', N'Han', N'Solo', 1, 0, N'Racing13')
GO
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[Edificio] ON 
GO
INSERT [dbo].[Edificio] ([Id], [Nombre]) VALUES (1, N'Tampa, FL - 4040 Boy Scout Blvd')
GO
INSERT [dbo].[Edificio] ([Id], [Nombre]) VALUES (2, N'New York, NY - 300 Madison')
GO
SET IDENTITY_INSERT [dbo].[Edificio] OFF
GO
SET IDENTITY_INSERT [dbo].[Piso] ON 
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (2, 2, 1)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (3, 3, 1)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (4, 4, 1)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (5, 5, 1)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (6, 6, 1)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (7, 7, 1)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (8, 8, 1)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (9, 9, 1)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (10, 10, 1)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (11, 1, 2)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (12, 2, 2)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (13, 3, 2)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (14, 4, 2)
GO
INSERT [dbo].[Piso] ([Id], [Numero], [EdificioId]) VALUES (15, 5, 2)
GO
SET IDENTITY_INSERT [dbo].[Piso] OFF
GO
SET IDENTITY_INSERT [dbo].[Espacio] ON 
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (1, N'101 Workspace Aisle 14', 1)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (2, N'102 Workspace Aisle 17', 1)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (3, N'103 Workspace Aisle 12', 1)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (4, N'104 Workspace Aisle 13', 1)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (5, N'2008 Collaboration 08', 2)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (6, N'2009 Collaboration 09', 2)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (7, N'2201 Collaboration 201', 2)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (8, N'3121 Main 121', 3)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (10, N'45 Open Space', 4)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (11, N'46 Open Space', 4)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (12, N'49 Open Space', 4)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (13, N'5090 Big Desk 90', 5)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (14, N'5088 Big Desk 88', 5)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (15, N'5022 Big Desk 22', 5)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (16, N'5011 Big Desk 11', 5)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (17, N'677 Workspace 77', 6)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (18, N'688 Workspace 88', 6)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (19, N'727 Stand Up desktop', 7)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (20, N'733 Stand Up desktop 33', 7)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (21, N'746 Stand Up desktop 46', 7)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (22, N'8003 Individual Room 003', 8)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (23, N'8004 Individual Room 004', 8)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (24, N'8307 Individual Room 307', 8)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (25, N'907 Open Table 07', 9)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (26, N'908 Open Table 08', 9)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (27, N'1010 Private space 10', 10)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (28, N'1023 Private space 23', 10)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (29, N'1031 Private space 31', 10)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (30, N'105 NY space', 11)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (31, N'107 NY space', 11)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (32, N'228 NY space', 12)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (33, N'231 NY space', 12)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (34, N'276 NY space', 12)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (35, N'288 NY space', 12)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (36, N'379 NY space', 13)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (37, N'344 NY space', 13)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (38, N'365 NY space', 13)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (39, N'422 NY space', 14)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (40, N'490 NY space', 14)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (41, N'444 NY space', 14)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (42, N'452 NY space', 14)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (43, N'486 NY space', 14)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (44, N'411 NY space', 14)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (45, N'523 NY space', 15)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (46, N'565 NY space', 15)
GO
INSERT [dbo].[Espacio] ([Id], [Descripcion], [PisoId]) VALUES (47, N'523 NY space', 15)
GO
SET IDENTITY_INSERT [dbo].[Espacio] OFF
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (1, CAST(N'2020-05-26T12:00:00.000' AS DateTime), CAST(N'2020-05-26T21:00:00.000' AS DateTime), 18, 1, CAST(N'2020-05-25T06:43:34.427' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (2, CAST(N'2020-05-26T09:00:00.000' AS DateTime), CAST(N'2020-05-26T17:00:00.000' AS DateTime), 11, 1, CAST(N'2020-05-25T02:55:35.677' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (3, CAST(N'2020-05-26T08:00:00.000' AS DateTime), CAST(N'2020-05-26T17:00:00.000' AS DateTime), 47, 1, CAST(N'2020-05-25T04:10:53.617' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (4, CAST(N'2020-05-27T08:00:00.000' AS DateTime), CAST(N'2020-05-27T17:00:00.000' AS DateTime), 30, 1, CAST(N'2020-05-25T10:50:26.780' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (5, CAST(N'2020-05-27T08:00:00.000' AS DateTime), CAST(N'2020-05-27T17:00:00.000' AS DateTime), 30, 1, CAST(N'2020-05-25T10:58:27.887' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (6, CAST(N'2020-05-27T08:00:00.000' AS DateTime), CAST(N'2020-05-27T17:00:00.000' AS DateTime), 31, 1, CAST(N'2020-05-25T10:59:43.287' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (7, CAST(N'2020-05-27T08:00:00.000' AS DateTime), CAST(N'2020-05-27T17:00:00.000' AS DateTime), 30, 1, CAST(N'2020-05-25T11:12:27.190' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (8, CAST(N'2020-05-27T08:00:00.000' AS DateTime), CAST(N'2020-05-27T17:00:00.000' AS DateTime), 31, 1, CAST(N'2020-05-25T11:12:57.747' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (9, CAST(N'2020-05-27T08:00:00.000' AS DateTime), CAST(N'2020-05-27T17:00:00.000' AS DateTime), 30, 1, CAST(N'2020-05-25T11:13:26.287' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (10, CAST(N'2020-05-27T08:00:00.000' AS DateTime), CAST(N'2020-05-27T17:00:00.000' AS DateTime), 30, 1, CAST(N'2020-05-25T11:18:13.203' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (11, CAST(N'2020-05-27T08:00:00.000' AS DateTime), CAST(N'2020-05-27T17:00:00.000' AS DateTime), 30, 2, CAST(N'2020-05-25T11:21:21.997' AS DateTime), 0)
GO
INSERT [dbo].[Reserva] ([Id], [FechaDesde], [FechaHasta], [EspacioId], [StaffId], [CreadaEn], [Active]) VALUES (12, CAST(N'2020-05-27T08:00:00.000' AS DateTime), CAST(N'2020-05-27T17:00:00.000' AS DateTime), 31, 2, CAST(N'2020-05-25T11:21:28.663' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
SET IDENTITY_INSERT [dbo].[Checkin] ON 
GO
INSERT [dbo].[Checkin] ([Id], [ReservaId], [StaffId], [FechaCheckin], [EdificioId], [Active]) VALUES (2, 3, 1, CAST(N'2020-05-25T04:16:20.807' AS DateTime), 2, 0)
GO
INSERT [dbo].[Checkin] ([Id], [ReservaId], [StaffId], [FechaCheckin], [EdificioId], [Active]) VALUES (3, 3, 1, CAST(N'2020-05-25T10:27:15.000' AS DateTime), 2, 0)
GO
INSERT [dbo].[Checkin] ([Id], [ReservaId], [StaffId], [FechaCheckin], [EdificioId], [Active]) VALUES (4, 3, 1, CAST(N'2020-05-25T10:28:19.510' AS DateTime), 2, 0)
GO
INSERT [dbo].[Checkin] ([Id], [ReservaId], [StaffId], [FechaCheckin], [EdificioId], [Active]) VALUES (5, 3, 1, CAST(N'2020-05-25T10:49:22.447' AS DateTime), 2, 0)
GO
INSERT [dbo].[Checkin] ([Id], [ReservaId], [StaffId], [FechaCheckin], [EdificioId], [Active]) VALUES (6, 4, 1, CAST(N'2020-05-25T10:56:58.183' AS DateTime), 2, 0)
GO
INSERT [dbo].[Checkin] ([Id], [ReservaId], [StaffId], [FechaCheckin], [EdificioId], [Active]) VALUES (7, 5, 1, CAST(N'2020-05-25T10:59:53.183' AS DateTime), 2, 0)
GO
INSERT [dbo].[Checkin] ([Id], [ReservaId], [StaffId], [FechaCheckin], [EdificioId], [Active]) VALUES (8, 7, 1, CAST(N'2020-05-25T11:12:38.893' AS DateTime), 2, 0)
GO
INSERT [dbo].[Checkin] ([Id], [ReservaId], [StaffId], [FechaCheckin], [EdificioId], [Active]) VALUES (9, 8, 1, CAST(N'2020-05-25T11:13:37.227' AS DateTime), 2, 0)
GO
INSERT [dbo].[Checkin] ([Id], [ReservaId], [StaffId], [FechaCheckin], [EdificioId], [Active]) VALUES (10, 10, 1, CAST(N'2020-05-25T11:20:44.753' AS DateTime), 2, 0)
GO
SET IDENTITY_INSERT [dbo].[Checkin] OFF
GO
SET IDENTITY_INSERT [dbo].[Checkout] ON 
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (1, 3, 1, CAST(N'2020-05-25T04:16:48.833' AS DateTime), 2, 2)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (2, 3, 1, CAST(N'2020-05-25T04:18:54.330' AS DateTime), 2, 2)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (3, 3, 1, CAST(N'2020-05-25T04:20:47.787' AS DateTime), 2, 2)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (4, 3, 1, CAST(N'2020-05-25T04:28:58.757' AS DateTime), 2, 2)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (5, 3, 1, CAST(N'2020-05-25T04:32:23.623' AS DateTime), 2, 2)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (6, 3, 1, CAST(N'2020-05-25T04:33:22.863' AS DateTime), 2, 2)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (7, 3, 1, CAST(N'2020-05-25T04:34:42.193' AS DateTime), 2, 2)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (8, 3, 1, CAST(N'2020-05-25T10:26:06.627' AS DateTime), 2, 2)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (9, 3, 1, CAST(N'2020-05-25T10:27:23.090' AS DateTime), 2, 3)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (10, 3, 1, CAST(N'2020-05-25T10:28:35.190' AS DateTime), 2, 4)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (11, 3, 1, CAST(N'2020-05-25T10:49:56.557' AS DateTime), 2, 5)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (12, 4, 1, CAST(N'2020-05-25T10:57:10.310' AS DateTime), 2, 6)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (13, 5, 1, CAST(N'2020-05-25T11:06:11.597' AS DateTime), 2, 7)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (14, 7, 1, CAST(N'2020-05-25T11:13:16.167' AS DateTime), 2, 8)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (15, 8, 1, CAST(N'2020-05-25T11:13:41.430' AS DateTime), 2, 9)
GO
INSERT [dbo].[Checkout] ([Id], [ReservaId], [StaffId], [FechaCheckout], [EdificioId], [CheckinId]) VALUES (16, 10, 1, CAST(N'2020-05-25T11:20:51.610' AS DateTime), 2, 10)
GO
SET IDENTITY_INSERT [dbo].[Checkout] OFF
GO
