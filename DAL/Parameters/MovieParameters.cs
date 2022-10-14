namespace DAL.Parameters
{
    public class MovieParameters : PaginationParameters
    {
        public int MinPrice { get; set; } = 0;
        public int? MaxPrice { get; set; }

        public int MinSeanceTime { get; set; } = 0;
        public int? MaxSeanceTime { get; set; }

        public string Name { get; set; } = "";

        public int? CinemaId { get; set; }

        public bool ValidPriceRange => MaxPrice == null || MinPrice <= MaxPrice;
        public bool ValidSeanceTimeRange => MaxSeanceTime == null || MinSeanceTime <= MaxSeanceTime;
    }
}
