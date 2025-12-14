using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model.Entities;
using api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }

        public DbSet<Turf> Turfs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}