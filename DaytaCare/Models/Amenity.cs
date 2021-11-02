using System.ComponentModel.DataAnnotations;

namespace DaytaCare.Models
{
    public class Amenity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
