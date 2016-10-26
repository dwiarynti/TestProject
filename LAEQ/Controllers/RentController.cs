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
    [Authorize]
    public class RentController : Controller
    {
       
        private LAEQEntities db = new LAEQEntities();
        private RentService service = new RentService();
        private MachineService serviceMachine = new MachineService();
        private CustomerService serviceCustomer = new CustomerService();
       
        public JsonResult ListMachineNotInProjectAndRent(string name)
        {
            var Result = serviceMachine.GetMachineAvailable(name);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListCustomer(string name)
        {
            var Result = serviceCustomer.GetListCustomerContains(name);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        // GET: Rent
        public ActionResult Index()
        {
            var rent = service.GetListRent();
            return View( new ViewRent
            {
                ListRent = rent
            });
        }
        [Authorize(Roles = Roles.CustomRole.Admin +","+ Roles.CustomRole.SO)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewRent rent)
        {
            if(rent.RentPriceText != null)
            {
                var PriceText = rent.RentPriceText;
                PriceText.Replace(",", string.Empty);
                var Price = Convert.ToDecimal(PriceText);
                rent.RentPrice = Price;
            }
            var Data = new Rent
            { 
                MachineId = rent.MachineId,
                CustomerId = rent.CustomerId,
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                Remark = rent.Remark,
                RentPrice = rent.RentPrice
            };
            if (ModelState.IsValid)
            {
                db.Rents.Add(Data);
                db.SaveChanges();

                //<-- Update Status in tbl Machine to "Rent" -->
                Machine machine = db.Machines.Find(Data.MachineId);
                machine.Status = "Rent";
                db.Entry(machine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + Data.Id);
            }
            return View(rent);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rent = service.GetRent(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }
        [Authorize(Roles = Roles.CustomRole.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rent = service.GetRent(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewRent rent)
        {
            if (rent.RentPriceText != null)
            {
                var PriceText = rent.RentPriceText;
                PriceText.Replace(",", string.Empty);
                var Price = Convert.ToDecimal(PriceText);
                rent.RentPrice = Price;
            }
            var Data = new Rent
            {
                Id = rent.Id,
                MachineId = rent.MachineId,
                CustomerId = rent.CustomerId,
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                ReturnDate = rent.ReturnDate,
                RentPrice = rent.RentPrice,
                Remark = rent.Remark,
               
            };
            if (ModelState.IsValid)
            {
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details/" + Data.Id);
            }
            return View(rent);
        }
        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rent = service.GetRent(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Return(ViewRent rent)
        {
            if (rent.RentPriceText != null)
            {
                var PriceText = rent.RentPriceText;
                PriceText.Replace(",", string.Empty);
                var Price = Convert.ToDecimal(PriceText);
                rent.RentPrice = Price;
            }
            var Data = new Rent
            {
                Id = rent.Id,
                StartDate = rent.StartDate,
                MachineId = rent.MachineId,
                CustomerId = rent.CustomerId,
                EndDate = rent.EndDate,
                ReturnDate = rent.ReturnDate,
                RentPrice = rent.RentPrice,
                Remark = rent.Remark,

            };
            if (ModelState.IsValid)
            {
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();

                //<-- Update Status in tbl Machine to "Project" -->
                Machine machine = db.Machines.Find(Data.MachineId);
                machine.Status = "Available";
                db.Entry(machine).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details/" + Data.Id);
            }
            return View(rent);
        }
        [Authorize(Roles = Roles.CustomRole.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rent = service.GetRent(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Rent rent = db.Rents.Find(id);
            rent.DeletedBy = User.Identity.Name;
            rent.DeletedDate = DateTime.Now;
            db.Entry(rent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}