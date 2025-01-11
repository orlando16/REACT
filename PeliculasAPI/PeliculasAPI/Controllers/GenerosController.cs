using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        //private readonly WeatherForecastController weatherForecastController;

        public GenerosController(IRepositorio repositorio, WeatherForecastController weatherForecastController)
        {
            this.repositorio = repositorio;
            this.weatherForecastController = weatherForecastController;
            //this.weatherForecastController = weatherForecastController;
        }

        [HttpGet] //api/generos
        [HttpGet("listado")] //api/generos/listado 
        [HttpGet("/listadogeneros")] //listadogeneros
        
        
        public ActionResult<List<Genero>> Get()
        {
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
         
            var genero = await repositorio.ObtenerPorId(Id);

            if (genero == null)
            { 
                return NotFound();  
            }

            return genero;
        }
        [HttpPost]
        public  ActionResult Post(  [FromBody] Genero genero)
        {
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
