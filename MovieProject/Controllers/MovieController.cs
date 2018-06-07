using System.Data;
using MovieProject.DataAccess.Repositories; //<<<<tuk e problemut !!!???
using System.Linq;
using System.Web.Mvc;
using MovieProjectDB;
using System.Net;
using MovieProjectDB.Entities;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class MovieController : Controller
    {
        public MovieRepository _movieRepository;

        public MovieController()

        {
            this._movieRepository = new MovieRepository(new MovieProjectDBContext());
        }

        public ActionResult Index()
        {
            var movies = from movie in _movieRepository.GetMovie()
                         select movie;
            return View(movies);
        }

        public ViewResult Details(int id)
        {
            Models.MovieModel info = _movieRepository.GetBookByID(id);
            return View(info);
        }

        public ActionResult Create()
        {
            return View(new Models.MovieModel());
        }

        [HttpPost]
        public ActionResult Create(Models.MovieModel movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _movieRepository.InsertMovie(movie);
                    _movieRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)

            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(movie);
        }
        public ActionResult Edit(int id)
        {
            Models.MovieModel movie = _movieRepository.GetMovieByID(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Models.MovieModel movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _movieRepository.UpdateMovie(movie);

                    _movieRepository.Save();

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(movie);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Models.MovieModel movie = _movieRepository.GetMovieByID(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Models.MovieModel movie = _movieRepository.GetMovieByID(id);
                _movieRepository.DeleteMovie(id);
                _movieRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
        //private MovieProjectDBContext db = new MovieProjectDBContext();

        //// GET: Movies  
        //public ActionResult Index()
        //{
        //    return View(db.Movies.ToList());
        //}

        //// GET: Movies/Details/5  
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Movie movie = db.Movies.Find(id);
        //    if (movie == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movie);
        //}

        //// GET: Movies/Create  
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Movies/Create  
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for   
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.  
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Name,ReleaseDate,Category")] Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Movies.Add(movie);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(movie);
        //}

        //// GET: Movies/Edit/5  
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Movie movie = db.Movies.Find(id);
        //    if (movie == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movie);
        //}

        //// POST: Movies/Edit/5  
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for   
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.  
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Name,ReleaseDate,Category")] MovieModel movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(movie).State = Model.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(movie);
        //}

        //// GET: Movies/Delete/5  
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Movie movie = db.Movies.Find(id);
        //    if (movie == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(movie);
        //}

        //// POST: Movies/Delete/5  
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Movie movie = db.Movies.Find(id);
        //    db.Movies.Remove(movie);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
