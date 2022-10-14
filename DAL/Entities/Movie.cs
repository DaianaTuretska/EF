using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Entities
{
    public class Movie : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public float Price { get; set; }
    public int SeanceTime { get; set; }
    public int CinemaId { get; set; }
    public Cinema Cinema { get; set; }
    }
}

