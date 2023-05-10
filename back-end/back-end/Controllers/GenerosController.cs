using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using back_end.Entidades;
using back_end.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace back_end.Controllers
{
    [Route("api/generos")]
    [ApiController]
	public class GenerosController : ControllerBase
	{
        private readonly IRepositorio repositorio;
        private readonly WeatherForecastController weatherForecastController;

        public GenerosController(IRepositorio repositorio, WeatherForecastController weatherForecastController)
		{
            this.repositorio = repositorio;
            this.weatherForecastController = weatherForecastController;
        }

        [HttpGet]
        [HttpGet("listado")]
        [HttpGet("/listadogeneros")]
        public ActionResult<List<Genero>> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("guid")]
        public ActionResult<Guid> GetGuid()
        {
            return Ok(new { GUID_GenerosController = repositorio.ObtenerGuid(),
                Guid_WeatherForecastController = weatherForecastController.ObtenerWeatherForecastController()
            }); 
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string nombre)
        {

            var genero = await repositorio.ObtenerPorId(Id);

            if (genero == null)
                return NotFound();

            return genero;
            //return Ok(genero);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
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