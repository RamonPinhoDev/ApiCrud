using IgrejaCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace IgrejaCatalogo.Context
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

      public   DbSet<Igreja> Igrejas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
