using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserContactNumber { get; set; }
        // public string UserBio { get; set; }
        public string UserLocation { get; set; }
        // public string UserProfilePicture { get; set; }
        // public string UserAddress { get; set; }
    }
}