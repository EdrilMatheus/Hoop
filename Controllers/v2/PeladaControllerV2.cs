using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hoop.Model;
using hoop.Context;

namespace hoop.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = "Bearer")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/pelada")]
    public class PeladaControllerV2 : ControllerBase
    {

        private readonly ILogger<PeladaController> _logger;
        private readonly hoopContext _context;


         public PeladaControllerV2(ILogger<PeladaController> logger, hoopContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Pelada>> Get()
        {
            var peladas = _context.Peladas.ToList();
            if(peladas is null)
                return NotFound();  


            return peladas;
        }

        [HttpGet ("{id:int}", Name ="GetPelada")]
        public ActionResult<Pelada> Get(int id)
        {
            var pelada = _context.Peladas.FirstOrDefault(p => p.ID == id);
            if(pelada is null)
                return NotFound("Pelada não encontada.");

                return pelada;
        }

        [HttpPost]
        public ActionResult Post(Pelada pelada){
            _context.Peladas.Add(pelada);
            _context.SaveChanges();


            return new CreatedAtRouteResult ("GetPelada", new{ id = pelada.ID}, pelada);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Pelada pelada){
            if(id != pelada.ID)
                return BadRequest();

            _context.Entry(pelada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(pelada);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var pelada = _context.Peladas.FirstOrDefault(p => p.ID == id);

            if(pelada is null)
            return NotFound();

            _context.Peladas.Remove(pelada);
            _context.SaveChanges();

            return Ok(pelada);
        }
    }
}