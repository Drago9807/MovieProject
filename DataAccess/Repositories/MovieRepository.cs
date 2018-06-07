using MovieProjectDB;
using MovieProjectDB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
        
    {
        private MovieProjectDBContext _context;

        public MovieRepository(MovieProjectDBContext movieContext)
        {
            this._context = movieContext;
        }

        public IEnumerable<Movie> GetMovies()

        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieByID(int id)
        {
             return _context.Movies.Find(id);
        }

        public void InsertMovie(Movie movie)

        {
            _context.Movies.Add(movie);
        }

        public void DeleteMovie(int movieID)

        {
            Movie movie = _context.Movies.Find(movieID);
            _context.Movies.Remove(movie);
        }



        public void UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        IEnumerable<Movie> IMovieRepository.GetMovies()
        {
            throw new NotImplementedException();
        }

        User IMovieRepository.GetMovieByID(int movieId)
        {
            throw new NotImplementedException();
        }

        void IMovieRepository.InsertMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        void IMovieRepository.DeleteMovie(int movieID)
        {
            throw new NotImplementedException();
        }

        void IMovieRepository.UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        void IMovieRepository.Save()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
