CREATE DATABASE PruebaTecnicaDB;
GO

USE PruebaTecnicaDB;
GO

CREATE TABLE Paises (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(200) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    PaisId INT NOT NULL,
    FOREIGN KEY (PaisId) REFERENCES Paises(Id)
);
GO

INSERT INTO Paises (Nombre) VALUES
('Chile'), ('Argentina'), ('Colombia'), ('México');
GO

INSERT INTO Clientes (Nombre, Telefono, PaisId) VALUES
('Juan Pérez', '+56984024951', 1),
('María Gómez', '+54984024952', 2),
('Carlos Ruiz', '+57984024953', 3),
('Ana López', '+52984024954', 4);
GO

CREATE PROCEDURE GetClientesPaginados
    @PageNumber INT = 1,
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.Id,
        c.Nombre,
        c.Telefono,
        p.Nombre AS Pais
    FROM Clientes c
    INNER JOIN Paises p ON c.PaisId = p.Id
    ORDER BY c.Id
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END;
GO