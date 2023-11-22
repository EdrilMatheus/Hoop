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
    public class TimeController : ControllerBase
    {
       
        private readonly ILogger<TimeController> _logger;
        private readonly hoopContext _context;


         public TimeController(ILogger<TimeController> logger, hoopContext context)
        {
            _logger = logger;
            _context = context;
        } 

        [HttpGet]
        public ActionResult<IEnumerable<Time>> Get()
        {
            var time = _context.Times.ToList();
            if(time is null)
                return NotFound();  


            return time;
        }

        [HttpGet ("{id:int}", Name ="GetTimes")]
        public ActionResult<Time> Get(int id)
        {
            var time = _context.Times.FirstOrDefault(p => p.ID == id);
            if(time is null)
                return NotFound("Time não encontado.");

                return time;
        }

        [HttpPost]
        public ActionResult Post(Time times){
            _context.Times.Add(times);
            _context.SaveChanges();


            return new CreatedAtRouteResult ("GetTimes", new{ id = times.ID}, times);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Time times){
            if(id != times.ID)
                return BadRequest();

            _context.Entry(times).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(times);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var times = _context.Times.FirstOrDefault(t => t.ID == id);

            if(times is null)
            return NotFound();

            _context.Times.Remove(times);
            _context.SaveChanges();

            return Ok(times);
        }
    }
}