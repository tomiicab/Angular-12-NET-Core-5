using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using back_end.Entidades;
using back_end.Filtros; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace back_end.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController : ControllerBase
	{
        private readonly ILogger<GenerosController> logger;
        private readonly ApplicationDbContext context;

        public GenerosController(ILogger<GenerosController> logger,
            ApplicationDbContext context)
		{
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        //[ResponseCache(Duration = 60)]//capa de cache activa durante 60seg.
        //[ServiceFilter(typeof(MiFiltroDeAccion))] 
        public async Task<ActionResult<List<Genero>>> Get()
        {
            return await context.Generos.ToListAsync();
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id)
        {
            throw new NotImplementedException();
            //return Ok(genero);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}