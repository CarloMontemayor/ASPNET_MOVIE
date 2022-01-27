using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.App_Start
{
    public class MovieSecurity
    {
        public static bool Login(string email, string password)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                return _context.UserModels.Any(x => x.Email == email && x.Password == password);
            }

        }
    }
}