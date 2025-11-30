namespace API.W.Movies.DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Duration { get; set; } // en minutos
        public string Clasification { get; set; } = string.Empty;
    
    }
}
