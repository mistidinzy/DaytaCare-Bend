using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaytaCare.Models.DTO
{
    public class CreateDaycareDto
    {
        public DaycareType DaycareType { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public decimal Price { get; set; }

        public int LicenseNumber { get; set; }

        public bool Availability { get; set; }
        public List<int> AmenityId { get; set; }
    }
}
