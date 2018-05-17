using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectDB.Entities
{
    public class MovieTicketPrices
    {
        public int NormalPrice { get; set; }
        public int PriceForStudents { get; set; }
        public int PriceForDisabled { get; set; }
        public int PriceVipSection { get; set; }
    }
}
