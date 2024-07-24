using IgrejaCatalogo.Context;
using IgrejaCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IgrejaCatalogo.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("Todos")]

        public ActionResult<IEnumerable<Categoria>> GetTodos()
        {
            return _context.Categorias.Include(i => i.Igrejas).Where(c => c.CategoiaId <= 5).ToList();

        }

        [HttpGet("BuscaPorNome/{name}")]

        public  ActionResult<IEnumerable<Categoria>> GetPorNomes(string name)
        { 
        var categorias = _context.Categorias.Include(i => i.Igrejas).Where(c => c.Igrejas.Any(i => i.Name.Contains(name))).ToList();
            return Ok (categorias);
        }

        [HttpGet("BuscaPorBairro/{bairro}")]
        public ActionResult<IEnumerable<Categoria>> GetPorBairro(string bairro)
        { if (bairro == null) { return NotFound("nao"); }
            var categorias = _context.Categorias
                                     .Include(i => i.Igrejas)
                                     .Where(c => c.Igrejas.Any(i => i.Bairro.Contains(bairro)))
                                     .ToList();
            if (categorias == null || !categorias.Any())
            {
                return NotFound(); // Ou algum outro status que faça sentido
            }


            return Ok(categorias);
        }

        [HttpGet("BuscaPorLogradouro/{logradouro}")]
        public ActionResult<IEnumerable<Categoria>> GetPorLogradouro(string logradouro)
        {
            var categorias = _context.Categorias
                                     .Include(i => i.Igrejas)
                                     .Where(c => c.Igrejas.Any(i => i.Logradouro.Contains(logradouro)))
                                     .ToList();
            return categorias;
        }



        [HttpGet("Categorias")]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {

            var categoria = await _context.Igrejas.AsNoTracking().ToListAsync();
            return Ok(categoria);


        }
        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria == null)
                return BadRequest();
            _context.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("Igrejas", new { id = categoria.CategoiaId }, categoria);


        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoiaId)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);

        }


        [HttpDelete]

        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoiaId == id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }
    }
}
