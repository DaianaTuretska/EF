
namespace BLL.DTO.Responses
{
   
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int SeanceTime { get; set; }
        public int CinemaId { get; set; }
    }
}
