



using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;


namespace IgrejaCatalogo.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Igrejas = new Collection<Igreja>();
        }
        [Key]
        public int CategoiaId { get; set; }
        [Required]
        [StringLength(80)]
        public string? CategoriaName { get; set; }

        public ICollection<Igreja> Igrejas { get; set; }



    }
}
