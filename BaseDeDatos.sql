CREATE DATABASE SistemaRegistro;
GO

-- Usar base de datos
USE SistemaRegistro;
GO

-- Tabla de Compras
CREATE TABLE Compras (
    CompraId INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(200) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Saldo DECIMAL(10,2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL, 
    Fecha DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de Abonos
CREATE TABLE Abonos (
    AbonoId INT PRIMARY KEY IDENTITY(1,1),
    CompraId INT NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CompraId) REFERENCES Compras(CompraId)
);