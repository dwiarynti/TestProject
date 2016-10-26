using LAEQ.DataContexts;
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
    public class ReportController : Controller
    {
        private LAEQEntities db = new LAEQEntities();
        private Report service = new Report();
    
        // GET: Report
        public ActionResult Report()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDataReport(DateTime? date1 , DateTime? date2, string type)
        {
            List<ViewMachine> rent = new List<ViewMachine>();
            List<ViewMachine> project = new List<ViewMachine>();
            if (type == "rent")
            {
                rent = service.ListMachineRent(date1, date2);
            }
            else if (type == "project")
            {
                project = service.ListMachineProject(date1, date2);
            }
            else
            {
                rent = service.ListMachineRent(date1, date2);
                project = service.ListMachineProject(date1, date2);
            }
              
            return PartialView(new ViewReport
            {
                Rent = rent,
                Project = project
            });
        }
      


       
    }
}