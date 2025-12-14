using System;

namespace api.Models.Entities
{
    public class Turf
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string OwnerContactName { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }

        public DateTime OriginDate { get; set; }
        public int Rating { get; set; } = 0;

        // public TimeOnly OpensAt { get; set; }
        // public TimeOnly ClosesAt { get; set; }
    }
}
