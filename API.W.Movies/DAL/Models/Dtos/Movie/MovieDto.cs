namespace API.W.Movies.DAL.Dtos.Movie
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Clasification { get; set; } = string.Empty;
        public string? Director { get; set; }
        public string? Synopsis { get; set; }
    }
}
