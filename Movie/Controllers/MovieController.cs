using Movie.App_Start;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie.Controllers
{
    public class MovieController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<MovieModel> GetAllMovies()
        {
            return _context.MovieModels.Where(x => !x.IsDeleted).ToList();
        }

        public MovieModel GetMovieById(int id)
        {
            return _context.MovieModels.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        [BasicAuthentication]
        [HttpPost]
        public HttpResponseMessage Create(MovieModel movieModel)
        {
            try
            {
                _context.MovieModels.Add(movieModel);
                _context.SaveChanges();
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.Created);
                return responseMessage;
            }
            catch (Exception ex)
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return responseMessage;
            }
        }

        [BasicAuthentication]
        [HttpPut]
        public HttpResponseMessage Update(MovieModel movieModel)
        {
            try
            {
                var movie = GetMovieById(movieModel.Id);
                if (movie == null)
                {
                    HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    return responseMessage;
                }
                else
                {
                    _context.MovieModels.AddOrUpdate(movieModel);
                    _context.SaveChanges();
                    HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                    return responseMessage;
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return responseMessage;
            }
        }
        [BasicAuthentication]
        public HttpResponseMessage Delete(int id)
        {
            var movie = GetMovieById(id);
            if (movie != null)
            {
                _context.MovieModels.Remove(movie);
                _context.SaveChanges();
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                return responseMessage;
            }
            else
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                return responseMessage;
            }
        }
    }
}
