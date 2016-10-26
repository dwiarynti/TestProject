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
    public class ProjectController : Controller
    {
        private LAEQEntities db = new LAEQEntities();
        private ProjectService service = new ProjectService();
        private MachineService serviceMachine = new MachineService();
        // GET: Project

        public JsonResult ListMachineNotInProjectAndRent(string name)
        {

            var Result = serviceMachine.GetMachineAvailable(name);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var project = service.GetListProject();
            return View(new ViewProject
            {
                ListProject = project
            });
        }

        [Authorize(Roles = Roles.CustomRole.Admin +","+ Roles.CustomRole.SO)]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewProject project)
        {
            var Data = new Project
            {
                MachineId = project.MachineId,
                Location = project.Location,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Remark = project.Remark
            };
            if(ModelState.IsValid)
            {
                db.Projects.Add(Data);
                db.SaveChanges();

                //<-- Update Status in tbl Machine to "Project" -->
                Machine machine = db.Machines.Find(Data.MachineId);
                machine.Status = "Project";
                db.Entry(machine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + Data.Id);
            }
            return View(project);
        }
        public ActionResult Details (int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = service.GetProject(id);
            if(project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }
        [Authorize(Roles =Roles.CustomRole.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = service.GetProject(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewProject project)
        {
            var Data = new Project
            {
                Id = project.Id,
                MachineId = project.MachineId,
                Location = project.Location,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Remark = project.Remark
            };
            if (ModelState.IsValid)
            {
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details/" + Data.Id);
            }
            return View(project);
        }
        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = service.GetProject(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Return(ViewProject project)
        {
            var Data = new Project
            {
                Id = project.Id,
                MachineId = project.MachineId,
                Location = project.Location,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Remark = project.Remark,
                ReturnDate = project.ReturnDate
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
            return View(project);
        }

        [Authorize(Roles = Roles.CustomRole.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = service.GetProject(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Project project = db.Projects.Find(id);
            project.DeletedBy = User.Identity.Name;
            project.DeletedDate = DateTime.Now;
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}