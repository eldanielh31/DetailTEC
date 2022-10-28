USE [DETAILTEC2]
GO
/****** Object:  Table [dbo].[Carro]    Script Date: 10/27/2022 6:52:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carro](
	[placa] [varchar](10) NOT NULL,
	[cedula] [nchar](30) NOT NULL,
	[color] [nchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC,
	[placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 10/27/2022 6:52:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citas](
	[cita_id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[cedula] [nchar](30) NOT NULL,
	[placa] [int] NOT NULL,
	[suc_id] [bigint] NOT NULL,
	[lavado_id] [bigint] NOT NULL,
	[trabajador_id] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cita_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 10/27/2022 6:52:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[cliente_nombre] [nchar](30) NOT NULL,
	[cedula] [nchar](30) NOT NULL,
	[fecha_nac] [nchar](30) NULL,
	[direccion] [nchar](80) NULL,
	[telefono1] [nchar](10) NULL,
	[telefono2] [bigint] NULL,
	[email] [nchar](40) NULL,
	[usuario] [nchar](40) NULL,
	[psw_cliente] [nchar](20) NULL,
	[puntos] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 10/27/2022 6:52:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[fact_id] [int] IDENTITY(1,1) NOT NULL,
	[cita_id] [int] NOT NULL,
	[snacks_consumidos] [int] NOT NULL,
	[bebidas_consumidas] [int] NOT NULL,
	[precio_servicio] [int] NOT NULL,
	[monto] [int] NOT NULL,
	[iva]  AS ([Monto]*(0.13)),
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[fact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lavados]    Script Date: 10/27/2022 6:52:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lavados](
	[lavado_id] [bigint] IDENTITY(1,1) NOT NULL,
	[lavado_nombre] [nchar](30) NOT NULL,
	[costo] [int] NOT NULL,
	[precio] [int] NOT NULL,
	[duracion] [nchar](20) NOT NULL,
	[puntos_otorga] [int] NOT NULL,
	[puntos_redimir] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[lavado_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lavados_productos]    Script Date: 10/27/2022 6:52:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lavados_productos](
	[lavado_id] [bigint] NOT NULL,
	[producto] [nchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[lavado_id] ASC,
	[producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 10/27/2022 6:52:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[nombre] [varchar](20) NOT NULL,
	[marca] [varchar](20) NULL,
	[costo] [int] NULL,
	[proveedor_id] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 10/27/2022 6:52:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[proveedor_id] [bigint] IDENTITY(1,1) NOT NULL,
	[proveedor_nombre] [nchar](20) NOT NULL,
	[proveedor_apellido1] [nchar](20) NOT NULL,
	[proveedor_apellido2] [nchar](20) NULL,
	[ced_juridica] [bigint] NOT NULL,
	[direccion] [nchar](40) NOT NULL,
	[email] [nchar](20) NOT NULL,
	[contacto_nombre] [nchar](20) NOT NULL,
	[contacto_numero] [bigint] NOT NULL,
	[suc_id] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[proveedor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 10/27/2022 6:52:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursales](
	[suc_id] [bigint] IDENTITY(1,1) NOT NULL,
	[suc_nombre] [nchar](20) NOT NULL,
	[provincia] [nchar](20) NOT NULL,
	[canton] [nchar](20) NOT NULL,
	[distrito] [nchar](20) NOT NULL,
	[telefono] [bigint] NOT NULL,
	[apertura] [date] NOT NULL,
	[gerente_id] [bigint] NOT NULL,
	[ingreso_gerente] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[suc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trabajadores]    Script Date: 10/27/2022 6:52:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trabajadores](
	[trabajador_id] [bigint] IDENTITY(1,1) NOT NULL,
	[cedula] [bigint] NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NOT NULL,
	[ingreso] [date] NOT NULL,
	[nacimiento] [date] NOT NULL,
	[edad]  AS (datediff(year,[nacimiento],getdate())),
	[password_trab] [varchar](20) NOT NULL,
	[rol] [varchar](20) NOT NULL,
	[pago] [varchar](20) NOT NULL,
	[email] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[trabajador_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carro]  WITH CHECK ADD FOREIGN KEY([cedula])
REFERENCES [dbo].[Clientes] ([cedula])
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([cedula])
REFERENCES [dbo].[Clientes] ([cedula])
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([lavado_id])
REFERENCES [dbo].[Lavados] ([lavado_id])
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([suc_id])
REFERENCES [dbo].[Sucursales] ([suc_id])
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([trabajador_id])
REFERENCES [dbo].[Trabajadores] ([trabajador_id])
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD FOREIGN KEY([cita_id])
REFERENCES [dbo].[Citas] ([cita_id])
GO
ALTER TABLE [dbo].[Lavados_productos]  WITH CHECK ADD FOREIGN KEY([lavado_id])
REFERENCES [dbo].[Lavados] ([lavado_id])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([proveedor_id])
REFERENCES [dbo].[Proveedores] ([proveedor_id])
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD FOREIGN KEY([suc_id])
REFERENCES [dbo].[Sucursales] ([suc_id])
GO
