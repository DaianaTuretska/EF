using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Seance : BaseEntity
    {
        public string City { get; set; }
        public string  During { get; set; }
        public float DataTime { get; set; }
        public float PlaceCount { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
