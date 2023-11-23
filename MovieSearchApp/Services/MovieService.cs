using MovieSearchApp.Models;
using System.Text.Json;

namespace MovieSearchApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public MovieService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string title)
        {
            var apiKey = _configuration["OMDB:ApiKey"];
            var response = await _httpClient.GetStringAsync($"http://www.omdbapi.com/?s={title}&apikey={apiKey}");
            var searchResults = JsonSerializer.Deserialize<SearchResponse>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return searchResults?.Search;
        }

        public async Task<Movie> GetMovieDetailsAsync(string imdbId)
        {
            var apiKey = _configuration["OMDB:ApiKey"];
            var response = await _httpClient.GetStringAsync($"http://www.omdbapi.com/?i={imdbId}&apikey={apiKey}");
            var movieDetails = JsonSerializer.Deserialize<Movie>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return movieDetails;
        }
    }

    public class SearchResponse
    {
        public List<Movie> Search { get; set; }
    }

}

