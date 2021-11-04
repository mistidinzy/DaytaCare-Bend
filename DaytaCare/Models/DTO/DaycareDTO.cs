using System;
using System.Collections.Generic;

namespace DaytaCare.Models.DTO
{
    public class DaycareDTO
    {
        public int DaycareId {get; set;}

        public string Name { get; set; }

        public string DaycareType { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public decimal Price { get; set; }

        public int LicenseNumber { get; set; }

        public bool Availability { get; set; }

        public List<AmenityDTO> Amenities { get; set; }
    }
}
