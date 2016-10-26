using LAEQ.DataContexts;
using LAEQ.EntityModel;
using LAEQ.Services;
using LAEQ.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LAEQ.Controllers
{
    [Authorize(Roles = Roles.CustomRole.Admin)]
    public class MachineController : Controller
    {
        private LAEQEntities db = new LAEQEntities();
        private MachineService service = new MachineService();

        // GET: Machine
        public ActionResult Index()
        {
            var machine = service.GetListMachine();
            return View(new ViewMachine
            {
                ListMachine = machine
            }
            );
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewMachine machine)
        {
            var machines = new Machine
            {
                MachineID = machine.MachineID,
                SerialNumber = machine.SerialNumber,
                Brand = machine.Brand,
                Model = machine.Model,
                Year = machine.Year,
                Capacity = machine.Capacity,
                Status = "Available",
                PM = machine.PM,
                Calibration = machine.Calibration,
                CalibrationDate = machine.CalibrationDate,
                PMDate = machine.PMDate,
                Remark = machine.Remark,
                CreatedDate = DateTime.Now,
                CreatedBy = User.Identity.Name

            };
            if (ModelState.IsValid)
            {
                db.Machines.Add(machines);
                db.SaveChanges();
                return RedirectToAction("Details/" + machines.Id);
            }
            return View(machine);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var machine = service.GetMachine(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var machine = service.GetMachine(id);
            if(machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewMachine machine)
        {
            var machines = new Machine
            {
                Id = machine.Id,
                MachineID = machine.MachineID,
                SerialNumber = machine.SerialNumber,
                Brand = machine.Brand,
                Model = machine.Model,
                Year = machine.Year,
                Capacity = machine.Capacity,
                Status = machine.Status,
                PM = machine.PM,
                Calibration = machine.Calibration,
                CalibrationDate = machine.CalibrationDate,
                PMDate = machine.PMDate,
                Remark = machine.Remark,
                UpdatedBy = User.Identity.Name,
                UpdatedDate = DateTime.Now
            };
            if (ModelState.IsValid)
            {
                db.Entry(machines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + machines.Id);
            }
            return View(machines);

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var machine = service.GetMachine(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Machine machine = db.Machines.Find(id);
            machine.DeletedBy = User.Identity.Name;
            machine.DeletedDate = DateTime.Now;
            db.Entry(machine).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}