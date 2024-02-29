-- Eliminamos las restricciones de FK
ALTER TABLE Pokemons DROP CONSTRAINT FK__Pokemons__idCara__4BAC3F29;
ALTER TABLE Pokemons DROP CONSTRAINT FK__Pokemons__idRare__48CFD27E;
ALTER TABLE Pokemons DROP CONSTRAINT FK__Pokemons__Tipo1__49C3F6B7;
ALTER TABLE Pokemons DROP CONSTRAINT FK__Pokemons__Tipo2__4AB81AF0;
ALTER TABLE Caracteristicas DROP CONSTRAINT FK__Caracteri__idAli__4316F928;
ALTER TABLE Caracteristicas DROP CONSTRAINT FK__Caracteri__idTam__440B1D61;
GO

-- Eliminamos las tablas
DROP TABLE IF EXISTS Pokemons;
DROP TABLE IF EXISTS Caracteristicas;
DROP TABLE IF EXISTS Rarezas;
DROP TABLE IF EXISTS Alimentaciones;
DROP TABLE IF EXISTS Tamaños;
DROP TABLE IF EXISTS Tipos;
GO

-- Cambiamos a MASTER y eliminamos la base de datos
USE master;
DROP DATABASE IF EXISTS DBPokeMaster;
GO