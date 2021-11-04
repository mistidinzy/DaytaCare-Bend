using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaytaCare.Models
{

    public enum DaycareType
    {
        InHomeUnregistered,
        InHomeA,
        InHomeB,
        InHomeC1,
        InHomeC2,
        LicensedCenter
    }

    public class Daycare
    {
        public int Id { get; set; }

        public DaycareType DaycareType { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int LicenseNumber { get; set; }

        public bool Availability { get; set; }

        //public DaycareAmenity DaycareAmenity { get; set; }
    }
}
