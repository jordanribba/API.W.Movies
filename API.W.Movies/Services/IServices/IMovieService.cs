using API.W.Movies.DAL.Dtos.Movie;
using API.W.Movies.DAL.Models;

namespace API.W.Movies.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMoviesAsync();
        Task<MovieDto?> GetMovieAsync(int id);
        Task<MovieDto> CreateMovieAsync(MovieCreateDto dto);
        Task<MovieDto> UpdateMovieAsync(int id, MovieCreateDto dto);
        Task<bool> DeleteMovieAsync(int id);
    }
}
