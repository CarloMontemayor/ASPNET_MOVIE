using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") 
        {
            
        }

        public DbSet<MovieModel> MovieModels { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
    }
}