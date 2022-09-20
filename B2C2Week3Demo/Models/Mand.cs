using System.ComponentModel.DataAnnotations;

namespace B2C2Week3Demo.Models
{
    public class Mand
    {
        [Key]
        public int Id { get; set; }
        public string? Materiaal { get; set; }
        public int? Volume { get; set; }
        public string? Kleur { get; set; }
        public ICollection<Fruit> Fruit { get; set; }
    }
}
