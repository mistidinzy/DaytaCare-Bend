using System;
using System.Collections.Generic;
using System.Linq;

namespace DaytaCare.Models.DTO
{
    public class ParentSearchDto
    {
        public string City { get; set; }

        public string State { get; set; }

        public int? AmenityId { get; set; }

        public bool? Availability { get; set; }

        public List<DaycareType> DaycareType { get; set; }
    }
}
