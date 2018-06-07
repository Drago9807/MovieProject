using MovieProjectDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    interface IMovieRepository : IDisposable
    {
        IEnumerable<Movie> GetMovies();

        User GetMovieByID(int movieId);

        void InsertMovie(Movie movie);

        void DeleteMovie(int movieID);

        void UpdateMovie(Movie movie);

        void Save();
    }
}
