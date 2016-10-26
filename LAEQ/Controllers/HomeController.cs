using LAEQ.Services;
using LAEQ.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAEQ.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private Report service = new Report();
        public ActionResult Index()
        {
            var rent = service.CountRent();
            var project = service.CountProject();
            return View(new ViewReport
            {
                Projects = project,
                Rents = rent
            });
        }
      

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}