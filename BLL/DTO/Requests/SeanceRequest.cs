namespace BLL.DTO.Requests
{
    public class SeanceRequest
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string During { get; set; }
        public float DataTime { get; set; }
        public float PlaceCount { get; set; }
    }
}
