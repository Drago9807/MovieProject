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

        [StringLength(150)]
        public string MovieName { get; set; }

        [MaxLength(150)]
        public double MoviePrice { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
