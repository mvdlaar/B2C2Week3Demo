using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace B2C2Week3Demo.Models
{
    public class Fruit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [DisplayName("Fruitkleur")]
        public string Kleur { get; set; }
    }
}
