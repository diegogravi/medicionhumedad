USE [MedicionHumedadDB]
GO
SET IDENTITY_INSERT [dbo].[Fruto] ON 
GO
INSERT [dbo].[Fruto] ([Id], [Nombre]) VALUES (1, N'Tomate')
GO
INSERT [dbo].[Fruto] ([Id], [Nombre]) VALUES (2, N'Frutilla')
GO
SET IDENTITY_INSERT [dbo].[Fruto] OFF
GO
SET IDENTITY_INSERT [dbo].[Plantacion] ON 
GO
INSERT [dbo].[Plantacion] ([Id], [Nombre]) VALUES (1, N'Tampa, FL')
GO
INSERT [dbo].[Plantacion] ([Id], [Nombre]) VALUES (2, N'Plant City, FL')
GO
SET IDENTITY_INSERT [dbo].[Plantacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 
GO
INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (1, N'Agricultor')
GO
INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (2, N'Recolector-Irrigador')
GO
INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (3, N'Admin')
GO
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([Id], [GUID], [Nombre], [Apellido], [Activo], [Password], [PlantacionId], [RolId]) VALUES (1, N'dgravisaco001', N'Diego', N'Gravisaco', 1, N'Racing13', 1, 3)
GO
INSERT [dbo].[Usuario] ([Id], [GUID], [Nombre], [Apellido], [Activo], [Password], [PlantacionId], [RolId]) VALUES (2, N'jprada001', N'Josefina', N'Prada', 1, N'Racing13', 1, 2)
GO
INSERT [dbo].[Usuario] ([Id], [GUID], [Nombre], [Apellido], [Activo], [Password], [PlantacionId], [RolId]) VALUES (3, N'bwayne001', N'Bruce', N'Wayne', 1, N'Racing13', 1, 1)
GO
INSERT [dbo].[Usuario] ([Id], [GUID], [Nombre], [Apellido], [Activo], [Password], [PlantacionId], [RolId]) VALUES (4, N'pparker001', N'Peter', N'Parker', 0, N'Racing13', 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicion] ON 
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (1, CAST(40.88 AS Decimal(18, 2)), CAST(N'2021-12-18T18:04:00.0000000-05:00' AS DateTimeOffset), N'Primera medicion', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (2, CAST(41.12 AS Decimal(18, 2)), CAST(N'2021-12-13T18:04:00.0000000-05:00' AS DateTimeOffset), N'Segunda', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (3, CAST(41.54 AS Decimal(18, 2)), CAST(N'2021-12-14T18:04:00.0000000-05:00' AS DateTimeOffset), N'Tercera', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (4, CAST(39.92 AS Decimal(18, 2)), CAST(N'2021-12-15T18:04:00.0000000-05:00' AS DateTimeOffset), N'Cuarta', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (5, CAST(40.23 AS Decimal(18, 2)), CAST(N'2021-12-16T18:04:00.0000000-05:00' AS DateTimeOffset), N'Quinta', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (6, CAST(42.22 AS Decimal(18, 2)), CAST(N'2021-12-17T18:04:00.0000000-05:00' AS DateTimeOffset), N'Sexta', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (7, CAST(40.11 AS Decimal(18, 2)), CAST(N'2021-12-19T18:04:00.0000000-05:00' AS DateTimeOffset), N'Septima', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (8, CAST(41.25 AS Decimal(18, 2)), CAST(N'2021-12-20T18:04:00.0000000-05:00' AS DateTimeOffset), N'Octaba', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (9, CAST(41.72 AS Decimal(18, 2)), CAST(N'2021-12-21T18:04:00.0000000-05:00' AS DateTimeOffset), N'Novena', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (10, CAST(40.19 AS Decimal(18, 2)), CAST(N'2021-12-22T18:04:00.0000000-05:00' AS DateTimeOffset), N'Decima', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (11, CAST(40.01 AS Decimal(18, 2)), CAST(N'2021-12-12T18:04:00.0000000-05:00' AS DateTimeOffset), N'Decima primera', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (12, CAST(42.99 AS Decimal(18, 2)), CAST(N'2021-12-11T18:04:00.0000000-05:00' AS DateTimeOffset), N'Decima segunda', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (13, CAST(42.04 AS Decimal(18, 2)), CAST(N'2021-12-10T18:04:00.0000000-05:00' AS DateTimeOffset), N'Decima tercera', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (14, CAST(41.87 AS Decimal(18, 2)), CAST(N'2021-12-09T18:04:00.0000000-05:00' AS DateTimeOffset), N'Decima cuarta', 1, 1, 1)
GO
INSERT [dbo].[Medicion] ([Id], [Porcentaje], [Fecha], [Descripcion], [FrutoId], [UsuarioId], [SensorId]) VALUES (19, CAST(38.00 AS Decimal(18, 2)), CAST(N'2021-12-07T13:00:00.0000000+00:00' AS DateTimeOffset), N'Ingresada manualmente', 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Medicion] OFF
GO
SET IDENTITY_INSERT [dbo].[Sensor] ON 
GO
INSERT [dbo].[Sensor] ([Id], [FechaCreacion], [Activo], [PlantacionId]) VALUES (1, CAST(N'2021-12-18T18:03:00.0000000-05:00' AS DateTimeOffset), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Sensor] OFF
GO
