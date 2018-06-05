namespace MovieProjectDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MovieProjectDB.Entities;

    public partial class MovieProjectDBContext : DbContext
    {
        public MovieProjectDBContext()
            : base("name=MovieProjectDBContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
