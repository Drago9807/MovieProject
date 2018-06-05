using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectDB.Entities
{
    public class MovieGenre
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        [Required]
        public int MovieId { get; set; }

        [Required, ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
    }
}
