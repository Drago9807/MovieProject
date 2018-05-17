using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectDB.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime MovieProjectionDate { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
