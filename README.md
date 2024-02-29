# POKEMON WEB API - ASP.NET CORE

## Introduccion
En esta documentacion proporcionare las intrucciones paso a paso para poder levantar el proyecto. El proyecto cuenta con una interfaz grafica documentada en Swagger, para facilitar las pruebas de la API.
Este proyecto contiene requisitos previos para ser usado.

## Requisitos Previos
 1. Tener instalado SQL Server.
 2. Ejecutar el archivo Create_Query.sql en SQL Server (El archivo se encuentra en la carpeta DataBaseQuery, en el mismo se encuentra la forma de revertir la base de datos).
 3. Tener instalado Visual Studio Community 2022.
 4. Tener el SDK de NET 8 Runtime (a largo plazo). 
 5. Abrir la solucion que se encuentra en la carpeta PokemonAPI.
 6. Instalar los paquetes desde NuGet de EntityFrameworkCore.Tools y EntityFrameworkCore.SqlServer.
 7. Tener postman para probar los endpoints de la API.

## Clonar el Repositorio
 1. Abre una terminal.
 2. Ejecuta el comando para clonar el repositorio del proyecto.

## Configuracion del Proyecto
 1. Entra al directorio raiz del proyecto de WEB API de PokemonAPI.
 2. Abre el archivo de configuracion `appsettings.json` y encontraras una llave llamada "ConnectionString", dentro de la llave hay otra llave llamada "Connection": "Server=(local);Database=DBPokeMaster;Trusted_Connection=True; TrustServerCertificate=True;", modifica el valor de Server segun el nombre con el que tengas registrado en tu SQL Server (Pruebe ejecutando sin mas, regularmente cuando esta en local toma un usuario local de SQL Server).
 3. Asegurate que esa cadena de conexion esta adaptada a tu SQL Server.

## Levantar el Proyecto
 1. Ya que esta configurado el proyecto, se puede levantar dando al boton de correr (http) en el Visual Studio Community.

## Endpoints Disponibles
 1. Tenemos en total 5 peticiones GET.
 2. Tenemos 1 peticion POST que sirve para guardar datos en la base de datos.
 3. Tenemos 1 peticion PUT para actualizar datos curiosos de los pokemons.
 4. Tenemos 1 peticion DELETE para eliminar a un pokemon de la base de datos.

## Proyecto Desplegado

### Descripción
La API REST fue subida a un servicio ftp llamado somee, nos brinda una base de datos en la web y 150mb de espacio para nuestro proyecto, lo cual me permitió poder desplegar la Pokemon Api, el subdominio que puse fue de **pokemasterapi** por el nombre de la prueba tecnica. 

### URLs
 
 1. Swagger UI
 - https://pokemasterapi.somee.com/swagger/index.html
 2. Endpoint GET Listar
 - https://pokemasterapi.somee.com/api/Pokemon
 3. Endpoint GET Traer un pokemon
 - https://pokemasterapi.somee.com/api/Pokemon/{id}
 4. Endpoint GET ver tipos
 - https://pokemasterapi.somee.com/api/Pokemon/Tipos
 5. Endpoint GET ver Rarezas
 - https://pokemasterapi.somee.com/api/Pokemon/Rarezas
 6. Endpoint GET ver alimentaciones
 - https://pokemasterapi.somee.com/api/Pokemon/Alimentaciones
 7. Endpoint POST guardar pokemon
 - https://pokemasterapi.somee.com/api/Pokemon
 8. Endpoint PUT cambiar dato curioso
 - https://pokemasterapi.somee.com/api/Pokemon
 9. Endpoint DELETE borrar un pokemom
 - https://pokemasterapi.somee.com/api/Pokemon/Borrar/{id} 