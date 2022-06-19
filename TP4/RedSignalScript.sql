CREATE DATABASE [RedSignal];
GO
USE [RedSignal];
GO
CREATE TABLE [RedSignal].dbo.Clientes
	(
		Dni VARCHAR(10) PRIMARY KEY ,
		Nombre VARCHAR(100) NOT NULL,
		Apellido VARCHAR(100) NOT NULL,
		Localidad VARCHAR(50) NOT NULL,
		Tiene_Telefono BIT NOT NULL,
		Tiene_Int BIT NOT NULL,
		Tiene_Tv BIT NOT NULL,
	);
GO
INSERT INTO Clientes VALUES ('44554525','Julian','Nieva','BuenosAires',1,1,1)
INSERT INTO Clientes VALUES ('44892868','Nabila','Salome','EntreRios',0,1,1)
INSERT INTO Clientes VALUES ('43897656','Federico','Hernandez','Cordoba',0,0,1)
GO
CREATE TABLE [RedSignal].dbo.Reclamos
	(
		Codigo VARCHAR(10) PRIMARY KEY,
		Dni_Cliente VARCHAR(10) NOT NULL,
		Servicio_Reclamado VARCHAR(80) NOT NULL,
	);
GO