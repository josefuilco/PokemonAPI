using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace PokemonAPI.Controllers
{
    [EnableCors("RuleCORS")]
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : Controller
    {
        public readonly DbpokeMasterContext _dbcontext;

        public PokemonController(DbpokeMasterContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // Endpoint para traer todos los datos
        [HttpGet]
        public IActionResult GetPokemons() 
        {
            try
            {
                var pokemons = (from p in _dbcontext.Pokemons
                                join c in _dbcontext.Caracteristicas on p.IdCaracteristica equals c.IdCaracteristica
                                select new
                                {
                                    id = p.IdPokemon,
                                    pokemon = p.Nombre,
                                    tipo1 = p.Tipo1Data,
                                    tipo2 = p.Tipo2Data,
                                    caracteristicas = new
                                    {
                                        alimentacion = c.AlimentacionData,
                                        tamaño = c.TamañoData,
                                        peso = c.Peso + " kg"
                                    },
                                    rarezaData = p.RarezaData,
                                    datoCurioso = p.DatoCurioso
                                }
                                ).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = pokemons });
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrio un Error.", response = ex.Message });
            }
        }
        
        // Endpoint para traer un pokemon segun su id
        [HttpGet]
        [Route("{idPokemon:int}")]
        public IActionResult GetData(int idPokemon)
        {
            Pokemon? oPokemon = _dbcontext.Pokemons.Find(idPokemon);
            if (oPokemon == null)
            {
                return BadRequest("Pokemon no encontrado");
            }

            try
            {

                var pokemon = (from p in _dbcontext.Pokemons
                               join c in _dbcontext.Caracteristicas on p.IdCaracteristica equals c.IdCaracteristica
                               select new
                               {
                                   id = p.IdPokemon,
                                   pokemon = p.Nombre,
                                   tipo1 = p.Tipo1Data,
                                   tipo2 = p.Tipo2Data,
                                   caracteristicas = new
                                   {
                                       alimentacion = c.AlimentacionData,
                                       tamaño = c.TamañoData,
                                       peso = c.Peso + " kg"
                                   },
                                   rarezaData = p.RarezaData,
                                   datoCurioso = p.DatoCurioso
                               }
                               ).Where(a => a.id == idPokemon)
                               .FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = pokemon });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrio un Error.", response = ex.Message });
            }
        }

        // Endpoint para poder ver los tipos de los pokemons
        [HttpGet]
        [Route("Tipos")]
        public IActionResult GetTipos()
        {
            try
            {
                var tipos = (from t in _dbcontext.Tipos
                                select new
                                {
                                    id = t.IdTipo,
                                    tipo = t.Tipo1
                                }
                                ).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = tipos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrio un Error.", response = ex.Message });
            }
        }

        // Endpoint para poder ver las rarezas de los pokemons
        [HttpGet]
        [Route("Rarezas")]
        public IActionResult GetRareza()
        {
            try
            {
                var rareza = (from r in _dbcontext.Rarezas
                             select new
                             {
                                 id = r.IdRareza,
                                 tipo_rareza = r.ContentRareza
                             }
                             ).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = rareza });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrio un Error.", response = ex.Message });
            }
        }

        // Endpoint para poder ver los tipos de alimentacion
        [HttpGet]
        [Route("Alimentaciones")]
        public IActionResult GetAlimentacion()
        {
            try
            {
                var alimentacion = (from a in _dbcontext.Alimentaciones
                             select new
                             {
                                 id = a.IdAlimentacion,
                                 tipo_alimentacion = a.ContentAlimentacion
                             }
                             ).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = alimentacion });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrio un Error.", response = ex.Message });
            }
        }

        // Endpoint para guardar datos en SQLServer
        [HttpPost]
        public IActionResult PostPokemon([FromBody] Pokemon oPokemon)
        {
            try
            {
                _dbcontext.Pokemons.Add(oPokemon);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.InnerException?.Message });
            }
        }

        // Endpoint para modificar el dato curioso del pokemon en SQLServer
        [HttpPut]
        public IActionResult PutPokemon([FromBody] Pokemon oPokemon)
        {
            var pokemon = _dbcontext.Pokemons.Find(oPokemon.IdPokemon);
            if (pokemon == null)
            {
                return BadRequest("Pokemon no encontrado.");
            }
            try
            {
                pokemon.DatoCurioso = oPokemon.DatoCurioso is null ? pokemon.DatoCurioso : oPokemon.DatoCurioso;
                _dbcontext.Pokemons.Update(pokemon);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.InnerException?.Message });
            }
        }

        // Endpoint para borrar a un pokemon de la base de datos
        [HttpDelete]
        [Route("Borrar/{idPokemon:int}")]
        public IActionResult DeletePokemon(int idPokemon)
        {
            var pokemon = _dbcontext.Pokemons.Find(idPokemon);
            if (pokemon == null)
            {
                return BadRequest("Pokemon no encontrado.");
            }
            try
            {
                _dbcontext.Pokemons.Remove(pokemon);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.InnerException?.Message });
            }
        }
    }
}
