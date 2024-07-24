using IgrejaCatalogo.Context;
using IgrejaCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IgrejaCatalogo.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class IgrejasController : Controller
    {
        private readonly AppDbContext _context;

        public IgrejasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "Igrejas")]
        public async Task<ActionResult<IEnumerable<Igreja>>> Get()
        {

            var igrejas = await _context.Igrejas.AsNoTracking().ToListAsync();
            return Ok(igrejas);


        }


        [HttpPost]
        public ActionResult Post(Igreja igreja)
        {
            if (igreja == null)
                return BadRequest();
            _context.Add(igreja);
            _context.SaveChanges();

            return new CreatedAtRouteResult("Igrejas", new { id = igreja.IgrejaId }, igreja);


        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Igreja igreja)
        {
            if (id != igreja.IgrejaId)
            {
                return BadRequest();
            }
            _context.Entry(igreja).State = EntityState.Modified;  
            _context.SaveChanges();
            return Ok(igreja);

        }


        [HttpDelete]

        public ActionResult Delete(int id)
        {
            var igreja = _context.Igrejas.FirstOrDefault(i => i.IgrejaId == id);
            if (igreja == null) { 
                return NotFound(); }
            _context.Remove(igreja);
            _context.SaveChanges(); 
            return Ok(igreja);
        }
    }
}
