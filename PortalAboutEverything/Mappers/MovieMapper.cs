using PortalAboutEverything.Data.Model;
using PortalAboutEverything.Models.Movie;
using PortalAboutEverything.Services;

namespace PortalAboutEverything.Mappers
{
    public class MovieMapper
    {
        private PathHelper _pathHelper;

        public MovieMapper(PathHelper pathHelper)
        {
            _pathHelper = pathHelper;
        }

        public MovieIndexViewModel MapToIndex(Movie movie)
            => new MovieIndexViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                ReleaseYear = movie.ReleaseYear,
                Director = movie.Director,
                Budget = movie.Budget,
                CountryOfOrigin = movie.CountryOfOrigin,
                HasCover = _pathHelper.IsMovieImageExist(movie.Id),
            };

        public Movie MapCreateViewModelToMovie(MovieCreateViewModel movieCreateViewModel)
            => new Movie
            {
                Name = movieCreateViewModel.Name,
                Description = movieCreateViewModel.Description,
                ReleaseYear = movieCreateViewModel.ReleaseYear,
                Director = movieCreateViewModel.Director,
                Budget = movieCreateViewModel.Budget,
                CountryOfOrigin = movieCreateViewModel.CountryOfOrigin,
            };

        public MovieUpdateViewModel MapToUpdate(Movie movie)
            => new MovieUpdateViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                ReleaseYear = movie.ReleaseYear,
                Director = movie.Director,
                Budget = movie.Budget,
                CountryOfOrigin = movie.CountryOfOrigin,
            };

        public Movie MapUpdateViewModelToMovie(MovieUpdateViewModel movieUpdateViewModel)
            => new Movie
            {
                Id = movieUpdateViewModel.Id,
                Name = movieUpdateViewModel.Name,
                Description = movieUpdateViewModel.Description,
                ReleaseYear = movieUpdateViewModel.ReleaseYear,
                Director = movieUpdateViewModel.Director,
                Budget = movieUpdateViewModel.Budget,
                CountryOfOrigin = movieUpdateViewModel.CountryOfOrigin,
            };
    }
}
