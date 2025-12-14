using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.DTOs.User
{
    public class CreateUserDTO
    {
        public string UserName { get; set; }
        public int UserContactNumber { get; set; }
        public string UserLocation { get; set; }
    }
}