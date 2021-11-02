using System;
namespace DaytaCare.Models
{
    public class DaycareAmenity
    {
        public int DaycareId { get; set; }

        public int AmenityId { get; set; }

        public Daycare Daycare { get; set; }

        public Amenity Amenity { get; set; }

    }
}
