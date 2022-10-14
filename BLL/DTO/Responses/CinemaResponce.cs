namespace BLL.DTO.Responses
{
    public class CinemaResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int SeanceId { get; set; }
        public string City { get; set; }
        public string During { get; set; }
        public float DataTime { get; set; }
        public float PlaceCount { get; set; }
    }
}
