using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrasturcture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrasturcture.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Movie> Get30HighestGrossingMovies()
        {
            //select top 30 * from movies order by revenue desc
            var movies=_dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }

        public IEnumerable<Movie> Get30HighestRatedMovies()
        {
            throw new NotImplementedException();
        }

        public override Movie GetById(int id)
        {
            //var movie= _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            var movie=_dbContext.Movies.Include(m=>m.GenresOfMovie).ThenInclude(mg=>mg.Genre).Include(m=>m.Trailers).FirstOrDefault(m => m.Id == id);


            return movie;
        }


    }
}
