namespace MovieProjectDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MovieProjectDB.Entities;

    public partial class MovieProjectDBContext : DbContext
    {
        public MovieProjectDBContext() : base("name=MovieProjectDBContext")
        {
        }

        public DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
