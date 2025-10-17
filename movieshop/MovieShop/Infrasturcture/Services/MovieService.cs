using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrasturcture.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieCard>> Get30HighestGrossingMovies()
        {
            var movies = await _movieRepository.Get30HighestGrossingMovies();
            var movieCards = new List<MovieCard>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCard { Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl });
            }

            return movieCards;
        }

        public async Task<MovieDetailModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetById(id);
            if (movie == null)
            {
                return null;
            }
            var movieDetail = new MovieDetailModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                OriginalLanguage = movie.OriginalLanguage,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Price = movie.Price,
                Rating = movie.Rating
            };
            movieDetail.Trailers = new List<TrailerModel>();
            foreach (var trailer in movie.Trailers)
            {
                movieDetail.Trailers.Add(new TrailerModel { Id = trailer.Id, Name = trailer.Name, TrailerUrl = trailer.TrailerUrl });

            }
            movieDetail.Genres = new List<GenreModel>();
            foreach (var genre in movie.GenresOfMovie)
            {
                movieDetail.Genres.Add(new GenreModel { Id = genre.GenreId, Name = genre.Genre.Name });
            }
            movieDetail.Casts = new List<CastModel>();
            foreach (var cast in movie.CastsOfMovie)
            {
                movieDetail.Casts.Add(new CastModel { Id = cast.CastId, Name = cast.Cast.Name, Character = cast.Character, ProfilePath = cast.Cast.ProfilePath });
            }
            return movieDetail;
        }

        public async Task<PageResultSet<MovieCard>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            var pagedMovies = await _movieRepository.GetMoviesByGenre(genreId, pageSize, pageNumber);
            var movieCards=new List<MovieCard>();

            //批量添加数据AddRange
            movieCards.AddRange(pagedMovies.Data.Select(m => new MovieCard { Id = m.Id, Title = m.Title, PosterUrl = m.PosterUrl }));
            return new PageResultSet<MovieCard>(movieCards, pageNumber,pagedMovies.PageSize,pagedMovies.Count);
        }
    }
}
