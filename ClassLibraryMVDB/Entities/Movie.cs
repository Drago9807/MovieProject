using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectDB.Entities
{
    public class Movie
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        [Key]
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public double MoviePrice { get; set; }

        public DateTime MovieProjectionDate { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
