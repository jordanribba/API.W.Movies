using API.W.Movies.Services;
using API.W.Movies.DAL.Dtos.Movie;
using API.W.Movies.DAL.Models;
using API.W.Movies.Repository;
using API.W.Movies.Repository.IRepository;
using AutoMapper;

namespace API.W.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<MovieDto?> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            return movie == null ? null : _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateDto dto)
        {
            ValidateMovieCreateDto(dto);

            var movie = _mapper.Map<Movie>(dto);
            var created = await _movieRepository.CreateMovieAsync(movie);
            return _mapper.Map<MovieDto>(created);
        }

        public async Task<MovieDto> UpdateMovieAsync(int id, MovieCreateDto dto)
        {
            var existing = await _movieRepository.GetMovieAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Movie not found.");

            ValidateMovieCreateDto(dto);

            existing.Name = dto.Name;
            existing.Duration = dto.Duration;
            existing.Clasification = dto.Clasification;
            

            var updated = await _movieRepository.UpdateMovieAsync(existing);
            return _mapper.Map<MovieDto>(updated);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            return await _movieRepository.DeleteMovieAsync(id);
        }

        private void ValidateMovieCreateDto(MovieCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("El nombre es requerido.");
            if (dto.Name.Length > 100)
                throw new ArgumentException("el nombre no puede exceder 100 caracteres.");
            if (dto.Duration <= 0)
                throw new ArgumentException("La duracion debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(dto.Clasification))
                throw new ArgumentException("La clasificacion es requerida.");
            if (dto.Clasification.Length > 10)
                throw new ArgumentException("La clasificacion no puede exceder 10 caracteres.");
        }
    }
}
