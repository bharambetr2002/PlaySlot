using System;

namespace api.Models.DTOs.Turf
{
    public class CreateTurfDto
    {
        public string Name { get; set; }
        public string OwnerContactName { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }

        public DateTime OriginDate { get; set; }
        // public TimeOnly OpensAt { get; set; }
        // public TimeOnly ClosesAt { get; set; }
    }

    public class TurfListDto
    {
        public string Name { get; set; }
        public string OwnerContactName { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }

        public DateTime OriginDate { get; set; }

    }
    public class TurfDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerContactName { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }

        public DateTime OriginDate { get; set; }
        public int Rating { get; set; }
    }

    // TODO - Create a put DTO
}
