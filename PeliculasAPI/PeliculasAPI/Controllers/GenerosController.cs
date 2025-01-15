using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using PeliculasAPI.Entidades;
using PeliculasAPI.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController: ControllerBase
    {
        private readonly IRepositorio repositorio;
        private readonly WeatherForecastController weatherForecastController;
        private readonly ILogger<GenerosController> logger;

        //private readonly WeatherForecastController weatherForecastController;

        public GenerosController(IRepositorio repositorio, 
            WeatherForecastController weatherForecastController,
            ILogger<GenerosController> logger)
        {
            this.repositorio = repositorio;
            this.weatherForecastController = weatherForecastController;
            this.logger = logger;
            //this.weatherForecastController = weatherForecastController;
        }

        [HttpGet] //api/generos
        [HttpGet("listado")] //api/generos/listado 
        [HttpGet("/listadogeneros")] //listadogeneros
        [ResponseCache(Duration = 60)]

        public ActionResult<List<Genero>> Get()
        {
            logger.LogInformation("Vamos a mostrar los generos");
            return repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("guid")]// api/generos/guid
        public ActionResult<Guid> GetGUID()
        {
            return Ok(new
            {
                GUID_GenerosController = repositorio.ObtenerGUID(),
                GUID_WeatherForecastController = weatherForecastController.ObtenerGUIDWeatherforecastController()
            });
        }
        [HttpGet("{Id:int}")] // api/generos/ejemplo
        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string nombre)
        {

            logger.LogDebug($"Obteniendo un genero por el id {Id}");
            var genero = await repositorio.ObtenerPorId(Id);

            if (genero == null)
            {
                logger.LogWarning($"No pudimos encontrar el genero de id {Id}");
                return NotFound();  
            }

            return genero;
        }
        [HttpPost]
        public  ActionResult Post(  [FromBody] Genero genero)
        {
            repositorio.CrearGenero(genero);
            return NoContent();

        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}
