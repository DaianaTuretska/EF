
namespace DAL.Entities
{
    public class Cinema : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public int SeanceId { get; set; }
        public Seance Seance { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
