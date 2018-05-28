namespace MovieProject.DataAccess.Repositories
{
    using MovieProjectDB.Entities;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Data.Common;
    using MovieProjectDB;
    using MovieProjectDB.DataAccess.Repositories;

    public class UnitOfWork
    {
        private MovieProjectDBContext context;

        private BaseRepository<User> userRepository;
        private BaseRepository<Genre> genreRepository;
        private BaseRepository<Movie> movieRepository;
        private BaseRepository<MovieGenre> movieGenreRepository;
        private BaseRepository<ProjectionPlace> projectionPlaceRepository;
        private BaseRepository<MovieTicketPrices> movieTicketPricesRepository;

        public UnitOfWork(MovieProjectDBContext ctx)
        {
            context = ctx;
        }

        public BaseRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new BaseRepository<User>();
                }

                return userRepository;
            }
        }

        public BaseRepository<Genre> GenreRepository
        {
            get
            {
                if (genreRepository == null)
                {
                    genreRepository = new BaseRepository<Genre>();
                }

                return genreRepository;
            }
        }

        public BaseRepository<Movie> MovieRepository
        {
            get
            {
                if (movieRepository == null)
                {
                    movieRepository = new BaseRepository<Movie>();
                }

                return movieRepository;
            }
        }

        public BaseRepository<MovieGenre> MovieGenreRepository
        {
            get
            {
                if (movieGenreRepository == null)
                {
                    movieGenreRepository = new BaseRepository<MovieGenre>();
                }

                return movieGenreRepository;
            }
        }

        public BaseRepository<ProjectionPlace> ProjectionPlaceRepository
        {
            get
            {
                if (projectionPlaceRepository == null)
                {
                    projectionPlaceRepository = new BaseRepository<ProjectionPlace>();
                }

                return projectionPlaceRepository;
            }
        }

        public BaseRepository<MovieTicketPrices> MovieTicketPricesRepository
        {
            get
            {
                if (movieTicketPricesRepository == null)
                {
                    movieTicketPricesRepository = new BaseRepository<MovieTicketPrices>();
                }

                return movieTicketPricesRepository;
            }
        }
        public DbTransaction Transaction { get; private set; }

        public virtual int SaveChanges() => context.SaveChanges();

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }

        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return context.Database.ExecuteSqlCommand(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await context.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters)
        {
            return await context.Database.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        }

        public virtual void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            if (objectContext.Connection.State != ConnectionState.Open)
            {
                objectContext.Connection.Open();
            }
            Transaction = objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public virtual bool Commit()
        {
            Transaction.Commit();
            return true;
        }

        public virtual void Rollback()
        {
            Transaction.Rollback();
        }
    }
}