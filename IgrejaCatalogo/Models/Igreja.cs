using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IgrejaCatalogo.Models
{
    public class Igreja
    {
        public int IgrejaId { get; set; }
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }
        [Required]
        [StringLength(300)]
        public string? Logradouro { get; set; }
        [Required]
        [StringLength(80)]
        public string? Bairro { get; set; }
        [Required]
        
        public int Telefone { get; set; }
        [Required]
       
        public DateTime DateFundacao { get; set; }
        [Required]
        [StringLength(300)]
        public string ?ParocoResponsavel { get; set; }
        [Required]
        [StringLength(80)]
        public string? Diocese { get; set; }

        public int CategoiaId { get; set; }
        [JsonIgnore]
        public Categoria? CodCategoria { get; set;}
    }
}
