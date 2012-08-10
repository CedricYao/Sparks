using System.Linq;
using System.Web.Mvc;
using Sparks.Persistence;
using WebSample.Core.Model;
using WebSample.UI.Models.Home;

namespace WebSample.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        private readonly IRepository _repository;

        public ActionResult Index()
        {
            var persons =_repository.Query<Person>().ToArray();
            var views = persons.Select(x => new IndexViewModel {FirstName = x.FirstName, LastName = x.LastName, Phone = x.Phone}).ToArray();

            return View(views);
        }
    }
}