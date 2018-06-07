using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectDB.Entities
{
    public class Genre
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        [Key]
        public int GenreId { get; set; }

        [StringLength(50)]
        public string GenreType { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
