using System.Web.Mvc;
using Examples.Filler.ViewModels;
using Examples.Filler.ViewModels.Fillers;

namespace Examples.Filler.Controllers
{
    public class HomeController : Controller
    {
        private readonly IViewModelFiller<CountryViewModel> _countryFiller;

        public HomeController(IViewModelFiller<CountryViewModel> countryFiller) {
            _countryFiller = countryFiller;
        }

        public ActionResult Index() {
            var vm = new CountryViewModel();

            _countryFiller.Fill(vm);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(CountryViewModel vm) {
            if (!ModelState.IsValid)
                return View(vm);

            // do some job

            return RedirectToAction("Index", "Home");
        }
    }
}