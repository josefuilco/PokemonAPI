CREATE DATABASE DBPokeMaster;
GO

USE DBPokeMaster;
GO

CREATE TABLE Tipos (
	idTipo INT PRIMARY KEY IDENTITY(1,1),
	Tipo VARCHAR(15) NOT NULL
);
GO

CREATE TABLE Alimentaciones (
	idAlimentacion INT PRIMARY KEY IDENTITY(1,1),
	Alimentacion VARCHAR(15) UNIQUE NOT NULL
);
GO

CREATE TABLE Rarezas (
	idRareza INT PRIMARY KEY IDENTITY(1,1),
	Rareza VARCHAR(15) UNIQUE NOT NULL
);
GO

CREATE TABLE Tamaños (
	idTamaño INT PRIMARY KEY IDENTITY(1,1),
	Tamaño VARCHAR(15) UNIQUE NOT NULL
);
GO

CREATE TABLE Caracteristicas (
	idCaracteristica INT PRIMARY KEY IDENTITY(1,1),
	idAlimentacion INT NOT NULL FOREIGN KEY REFERENCES Alimentaciones(idAlimentacion),
	idTamaño INT NOT NULL FOREIGN KEY REFERENCES Tamaños(idTamaño),
	Peso DECIMAL(4,1) NOT NULL,
	CONSTRAINT CK_Peso CHECK (Peso > 0)
);
GO

-- La tabla Pokemons y Caracteristicas son las tendran todo los datos de la tabla principal
CREATE TABLE Pokemons (
	idPokemon INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(15) UNIQUE NOT NULL,
	idRareza INT NOT NULL FOREIGN KEY REFERENCES Rarezas(idRareza),
	Tipo1 INT NOT NULL FOREIGN KEY REFERENCES Tipos(idTipo),
	Tipo2 INT FOREIGN KEY REFERENCES Tipos(idTipo),
	idCaracteristica INT NOT NULL FOREIGN KEY REFERENCES Caracteristicas(idCaracteristica),
	Dato_Curioso TEXT NOT NULL
);
GO

-- Inserto los valores para cada tabla
INSERT INTO Tipos (Tipo) VALUES
('Eléctrico'),
('Planta'),
('Veneno'),
('Fuego'),
('Agua'),
('Normal'),
('Hada'),
('Lucha'),
('Psíquico'),
('Fantasma'),
('Roca'),
('Tierra'),
('Hielo'),
('Dragon'),
('Volador');
GO

INSERT INTO Alimentaciones (Alimentacion) VALUES
('Omnívoro'),
('Herbívoro'),
('Carnívoro');
GO

INSERT INTO Rarezas (Rareza) VALUES
('Común'),
('Poco Común'),
('Raro'),
('Legendario');
GO

INSERT INTO Tamaños (Tamaño) VALUES
('Pequeño'),
('Mediano'),
('Grande');
GO

INSERT INTO Caracteristicas (idAlimentacion, idTamaño, Peso) VALUES
(1, 1, 6.0),
(2, 1, 6.9),
(3, 1, 8.5),
(3, 1, 9.0),
(2, 1, 5.5),
(3, 1, 4.2),
(1, 1, 19.6),
(3, 2, 19.5),
(3, 1, 19.5),
(3, 1, 0.1),
(2, 3, 210.0),
(1, 2, 32.4),
(2, 1, 2.5),
(3, 1, 1.0),
(3, 1, 6.5),
(2, 3, 460.0),
(3, 2, 40.6),
(2, 3, 220.0),
(3, 3, 210.0),
(3, 2, 122.0),
(1, 1, 4.0),
(3, 3, 52.6),
(3, 3, 60.0),
(3, 3, 55.4);
GO

/*
	* Guia de idTipo
	1 Eléctrico
	2 Planta
	3 Veneno
	4 Fuego
	5 Agua
	6 Normal
	7 Hada
	8 Lucha
	9 Psíquico
	10 Fantasma
	11 Roca
	12 Tierra
	13 Hielo
	14 Dragon
	15 Volador
*/
INSERT INTO Pokemons (Nombre, idRareza, tipo1, tipo2, idCaracteristica, Dato_Curioso) VALUES 
('Pikachu', 1, 1, null, 1, 'Siempre tiene energía estática en su cuerpo.'),
('Bulbasaur', 1, 2, 3, 2, 'El bulbo en su espalda puede absorber nutrientes del sol.'),
('Charmander', 1, 4, null, 3, 'La llama en su cola indica su estado emocional.'),
('Squirtle', 1, 5, null, 4, 'Puede disparar agua a alta presión desde su boca.'),
('Jigglypuff', 1, 6, 7, 5, 'Canta una canción de cuna que hace dormir a quien la escucha.'),
('Meowth', 1, 6, null, 6, 'Le encantan las monedas brillantes.'),
('Psyduck', 1, 5, null, 7, 'Siempre tiene dolor de cabeza.'),
('Machop', 2, 8, null, 8, 'Entrena levantando rocas.'),
('Abra', 2, 9, null, 9, 'Puede leer la mente de otros.'),
('Gastly', 2, 10, 3, 10, 'Está compuesto por gases venenosos.'),
('Onix', 2, 11, 12, 11, 'Vive en cuevas subterráneas.'),
('Drowzee', 2, 9, null, 12, 'Se alimenta de los sueños de las personas.'),
('Exeggcute', 2, 2, 9, 13, 'Consiste en seis huevos de semillas.'),
('Koffing', 2, 3, null, 14, 'Se infla para aumentar su tamaño.'),
('Cubone', 2, 12, null, 15, 'Lleva una calavera de su madre fallecida.'),
('Snorlax', 3, 6, null, 16, 'Puede dormir durante días seguidos.'),
('Jynx', 3, 13, 9, 17, 'Su baile hipnotiza a sus oponentes.'),
('Lapras', 3, 5, 13, 18, 'Es conocido por su dulce canto.'),
('Dragonite', 3, 14, 15, 19, 'Puede volar a grandes velocidades.'),
('Mewtwo', 4, 9, null, 20, 'Fue creado artificialmente en un laboratorio.'),
('Mew', 4, 9, null, 21, 'Contiene el ADN de todos los Pokémon.'),
('Zapdos', 4, 1, 15, 22, 'Su cuerpo genera electricidad estática.'),
('Moltres', 4, 4, 15, 23, 'Tiene la habilidad de controlar el fuego.'),
('Articuno', 4, 13, 15, 24, 'Puede congelar el aire a su alrededor.');
GO

-- Mostramos los datos
WITH Tipo1 AS (
    SELECT Pokemons.idPokemon, Tipos.Tipo
    FROM Pokemons
    INNER JOIN Tipos ON Pokemons.Tipo1 = Tipos.idTipo
),
Tipo2 AS (
    SELECT Pokemons.idPokemon, Tipos.Tipo
    FROM Pokemons
    INNER JOIN Tipos ON Pokemons.Tipo2 = Tipos.idTipo
)
SELECT
	Pokemons.Nombre AS Pokemon,
	CONCAT(Tipo1.Tipo, CASE WHEN Tipo2.Tipo IS NOT NULL THEN CONCAT('/', Tipo2.Tipo) ELSE '' END) AS Tipo,
	Alimentaciones.Alimentacion,
	Tamaños.Tamaño,
	CONCAT(Caracteristicas.Peso, ' Kg') AS Peso,
	Rarezas.Rareza,
	Pokemons.Dato_Curioso AS 'Dato Curioso'
FROM
	Pokemons
INNER JOIN
	Caracteristicas ON Pokemons.idCaracteristica = Caracteristicas.idCaracteristica
INNER JOIN
	Alimentaciones ON Caracteristicas.idAlimentacion = Alimentaciones.idAlimentacion
INNER JOIN
	Tamaños ON Caracteristicas.idTamaño = Tamaños.idTamaño
INNER JOIN
	Rarezas ON Pokemons.idRareza = Rarezas.idRareza
LEFT JOIN
    Tipo1 ON Pokemons.idPokemon = Tipo1.idPokemon
LEFT JOIN
    Tipo2 ON Pokemons.idPokemon = Tipo2.idPokemon;
GO