---------------------------------------------------------------------
-- Microsoft SQL Server 2008 T-SQL Fundamentals
--
-- Script that creates the sample database CNT
--
-- Supported versions of SQL Server: 2005, 2008
--
-- Based originally on the Northwind sample database
-- with changes in both schema and data to fit the book's needs
--
-- Last updated: 20081202
---------------------------------------------------------------------

---------------------------------------------------------------------
-- Create Database
---------------------------------------------------------------------

USE master;

-- Drop database
IF DB_ID('CNT') IS NOT NULL DROP DATABASE CNT;

-- If database could not be created due to open connections, abort
IF @@ERROR = 3702 
   RAISERROR('Database cannot be dropped because there are still open connections.', 127, 127) WITH NOWAIT, LOG;

-- Create database
CREATE DATABASE CNT;
GO

USE CNT;
GO


-- Create table pacientes
-- ----------------------------
-- Table structure for Paciente
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Paciente]') AND type IN ('U'))
	DROP TABLE [dbo].[Paciente]
GO

CREATE TABLE [dbo].[Paciente] (
  [PacienteId] int  IDENTITY(1,1) NOT NULL,
  [Documento] nvarchar(12) COLLATE Modern_Spanish_CI_AS  NULL,
  [Nombres] nvarchar(20) COLLATE Modern_Spanish_CI_AS  NULL,
  [Apellidos] nvarchar(20) COLLATE Modern_Spanish_CI_AS  NULL,
  [Edad] bigint  NOT NULL,
  [Direccion] nvarchar(40) COLLATE Modern_Spanish_CI_AS  NULL,
  [Sexo] bit  NOT NULL,
  [Peso] decimal(18,2)  NOT NULL,
  [Estatura] bigint  NOT NULL,
  [Fumador] bit  NOT NULL,
  [Dieta] bit  NOT NULL,
  [PesoEstatura] bigint  NOT NULL,
  [Prioridad] float(53)  NOT NULL,
  [Riesgo] float(53)  NOT NULL,
  [TiempoFumando] bigint  NOT NULL,
  [Estado] int  NOT NULL
)
GO

ALTER TABLE [dbo].[Paciente] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Paciente
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Paciente] ON
GO

INSERT INTO [dbo].[Paciente] ([PacienteId], [Documento], [Nombres], [Apellidos], [Edad], [Direccion], [Sexo], [Peso], [Estatura], [Fumador], [Dieta], [PesoEstatura], [Prioridad], [Riesgo], [TiempoFumando], [Estado]) VALUES (N'1', N'123', N'Helmer', N'Fuentes', N'26', N'hg', N'1', N'34.00', N'2', N'0', N'1', N'56', N'1', N'9', N'0', N'0')
GO

INSERT INTO [dbo].[Paciente] ([PacienteId], [Documento], [Nombres], [Apellidos], [Edad], [Direccion], [Sexo], [Peso], [Estatura], [Fumador], [Dieta], [PesoEstatura], [Prioridad], [Riesgo], [TiempoFumando], [Estado]) VALUES (N'2', N'1234', N'martha', N'Diaz', N'10', N'hg', N'1', N'34.00', N'2', N'0', N'1', N'56', N'3', N'6', N'0', N'0')
GO

INSERT INTO [dbo].[Paciente] ([PacienteId], [Documento], [Nombres], [Apellidos], [Edad], [Direccion], [Sexo], [Peso], [Estatura], [Fumador], [Dieta], [PesoEstatura], [Prioridad], [Riesgo], [TiempoFumando], [Estado]) VALUES (N'3', N'12356', N'YUNERIS', N'FUENTES', N'12', N'Calle 16B #27-05 villa corelca', N'1', N'48.00', N'34', N'1', N'1', N'0', N'3', N'5', N'4', N'0')
GO

INSERT INTO [dbo].[Paciente] ([PacienteId], [Documento], [Nombres], [Apellidos], [Edad], [Direccion], [Sexo], [Peso], [Estatura], [Fumador], [Dieta], [PesoEstatura], [Prioridad], [Riesgo], [TiempoFumando], [Estado]) VALUES (N'4', N'1065824874', N'HELMER', N'FUENTES', N'12', N'calle 16b # 27 -05 villa corelca', N'1', N'48.00', N'34', N'1', N'1', N'0', N'6', N'4', N'4', N'0')
GO

INSERT INTO [dbo].[Paciente] ([PacienteId], [Documento], [Nombres], [Apellidos], [Edad], [Direccion], [Sexo], [Peso], [Estatura], [Fumador], [Dieta], [PesoEstatura], [Prioridad], [Riesgo], [TiempoFumando], [Estado]) VALUES (N'5', N'678', N'YUNERIS', N'FUENTES', N'12', N'Calle 16B #27-05 villa corelca', N'1', N'48.00', N'34', N'1', N'1', N'0', N'5', N'3', N'4', N'0')
GO

INSERT INTO [dbo].[Paciente] ([PacienteId], [Documento], [Nombres], [Apellidos], [Edad], [Direccion], [Sexo], [Peso], [Estatura], [Fumador], [Dieta], [PesoEstatura], [Prioridad], [Riesgo], [TiempoFumando], [Estado]) VALUES (N'6', N'1234567939', N'SEGUNDO', N'FUENTES', N'12', N'villa corelca 2323232', N'1', N'48.00', N'34', N'1', N'1', N'0', N'6', N'3', N'4', N'0')
GO

INSERT INTO [dbo].[Paciente] ([PacienteId], [Documento], [Nombres], [Apellidos], [Edad], [Direccion], [Sexo], [Peso], [Estatura], [Fumador], [Dieta], [PesoEstatura], [Prioridad], [Riesgo], [TiempoFumando], [Estado]) VALUES (N'7', N'1943892564', N'SEGUNDO', N'FUENTES', N'2323', N'villa corelca 2323232', N'1', N'48.00', N'34', N'1', N'1', N'0', N'7', N'1', N'6', N'0')
GO

SET IDENTITY_INSERT [dbo].[Paciente] OFF
GO


-- ----------------------------
-- Auto increment value for Paciente
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Paciente]', RESEED, 8)
GO


-- ----------------------------
-- Primary Key structure for table Paciente
-- ----------------------------
ALTER TABLE [dbo].[Paciente] ADD CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED ([PacienteId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

