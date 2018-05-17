using MovieProjectDB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectDB
{
    public class MovieProjectDBContext : DbContext
    {
        public DbSet<User> User { get; set; }
    }
}
