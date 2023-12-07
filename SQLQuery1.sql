USE master;
DROP DATABASE IF EXISTS CasoEstudioMN;

CREATE DATABASE CasoEstudioMN;
GO

USE CasoEstudioMN;
GO

CREATE TABLE CasasSistema (
    IdCasa BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    DescripcionCasa VARCHAR(30) NOT NULL,
    PrecioCasa DECIMAL(10,2) NOT NULL,
    UsuarioAlquiler VARCHAR(30) NULL,
    FechaAlquiler DATETIME NULL
);
GO

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa], [PrecioCasa], [UsuarioAlquiler], [FechaAlquiler])
VALUES ('Casa en San José', 190000, null, null);

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa], [PrecioCasa], [UsuarioAlquiler], [FechaAlquiler])
VALUES ('Casa en Alajuela', 145000, null, null);

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa], [PrecioCasa], [UsuarioAlquiler], [FechaAlquiler])
VALUES ('Casa en Cartago', 115000, null, null);

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa], [PrecioCasa], [UsuarioAlquiler], [FechaAlquiler])
VALUES ('Casa en Heredia', 122000, null, null);

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa], [PrecioCasa], [UsuarioAlquiler], [FechaAlquiler])
VALUES ('Casa en Guanacaste', 105000, null, null);

CREATE PROCEDURE ConsultarCasas
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdCasa,
        DescripcionCasa,
        PrecioCasa,
        UsuarioAlquiler,
        FechaAlquiler
    FROM 
        CasasSistema
    WHERE 
        PrecioCasa BETWEEN 115000 AND 180000;
END;



