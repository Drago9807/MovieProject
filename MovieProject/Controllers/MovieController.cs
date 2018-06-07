using System.Data;
using DataAccess.Repositories; //<<<<tuk e problemut !!!???
using System.Linq;
using System.Web.Mvc;
using MovieProjectDB;

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
}