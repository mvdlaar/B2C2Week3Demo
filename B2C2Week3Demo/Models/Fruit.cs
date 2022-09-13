using System.ComponentModel.DataAnnotations;

namespace B2C2Week3Demo.Models
{
    public class Fruit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        public string Kleur { get; set; }
    }
}
