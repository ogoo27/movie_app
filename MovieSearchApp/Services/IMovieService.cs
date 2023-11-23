using MovieSearchApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MovieSearchApp.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> SearchMoviesAsync(string title);
        Task<Movie> GetMovieDetailsAsync(string imdbId);
    }
}
