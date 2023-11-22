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
    [Route("api/[controller]")]
    public class JogadorController : ControllerBase
    {

        private readonly ILogger<JogadorController> _logger;
        private readonly hoopContext _context;


         public JogadorController(ILogger<JogadorController> logger, hoopContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Jogador>> Get()
        {
            var jogadores = _context.Jogadores.ToList();
            if(jogadores is null)
                return NotFound();  


            return jogadores;
        }

        [HttpGet ("{id:int}", Name ="GetJogador")]
        public ActionResult<Jogador> Get(int id)
        {
            var jogador = _context.Jogadores.FirstOrDefault(p => p.ID == id);
            if(jogador is null)
                return NotFound("Jogador não encontado.");

                return jogador;
        }

        [HttpPost]
        public ActionResult Post(Jogador jogador){
            _context.Jogadores.Add(jogador);
            _context.SaveChanges();


            return new CreatedAtRouteResult ("GetJogador", new{ id = jogador.ID}, jogador);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Jogador jogador){
            if(id != jogador.ID)
                return BadRequest();

            _context.Entry(jogador).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(jogador);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var jogador = _context.Jogadores.FirstOrDefault(p => p.ID == id);

            if(jogador is null)
            return NotFound();

            _context.Jogadores.Remove(jogador);
            _context.SaveChanges();

            return Ok(jogador);
        }
    }
}