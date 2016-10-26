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
    public class CustomerController : Controller
    {
        private LAEQEntities db = new LAEQEntities();
        private CustomerService service = new CustomerService();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewCustomer customer)
        {
            var Data = new Customer
            {
                Name = customer.Name,
                Type = customer.Type,
                Address1 = customer.Address1,
                Address2 = customer.Address2,
                Website = customer.Website,
                CreatedBy = User.Identity.Name,
                CreatedDate = DateTime.Now
            };
            var DataContact = new CustomerContact
            {
                Title = customer.Title,
                JobPosition = customer.JobPosition,
                ContactName = customer.ContactName,
                Email = customer.Email,
                Phone = customer.Phone,
                Mobile = customer.Mobile,
                Notes = customer.Notes,
                CreatedBy = User.Identity.Name,
                CreatedDate = DateTime.Now
            };

            if(ModelState.IsValid)
            {
                db.Customers.Add(Data);
                db.SaveChanges();
                DataContact.CustomerId = Data.Id;
                db.CustomerContacts.Add(DataContact);
                db.SaveChanges();
                return RedirectToAction("Details/" + Data.Id);

            }
            return View(customer);
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = service.GetCustomer(id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = service.GetCustomer(id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (ViewCustomer customer)
        {
            var Data = new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Type = customer.Type,
                Address1 = customer.Address1,
                Address2 = customer.Address2,
                Website = customer.Website,
                UpdatedBy = User.Identity.Name,
                UpdatedDate = DateTime.Now,
               
            };
            if (ModelState.IsValid)
            {
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + Data.Id);
            }
            return View(customer);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = service.GetCustomer(id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (int id)
        {
            Customer customer = db.Customers.Find(id);
            customer.DeletedBy = User.Identity.Name;
            customer.DeletedDate = DateTime.Now;
          
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        
          
            return RedirectToAction("Index");
        }

           



        public ActionResult CreateContact(int? id)
        {
            var contact = service.CustomerCreateContact(id);
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContact(ViewCustomerContact contact)
        {
            var Data = new CustomerContact
            {
                CustomerId = contact.CustomerId,
                Title = contact.Title,
                JobPosition = contact.JobPosition,
                ContactName = contact.ContactName,
                Email = contact.Email,
                Phone = contact.Phone,
                Mobile = contact.Mobile,
                Notes = contact.Notes,
                CreatedBy = User.Identity.Name,
                CreatedDate = DateTime.Now
            };
            if(ModelState.IsValid)
            {
                db.CustomerContacts.Add(Data);
                db.SaveChanges();
                return RedirectToAction("Details/" + Data.CustomerId);
            }
            return View(contact);
        }

        public ActionResult EditContact(int? id)
        {
            var contact = service.GetContactId(id);
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContact(ViewCustomerContact contact)
        {
            var Data = new CustomerContact
            {
                Id = contact.Id,
                CustomerId = contact.CustomerId,
                ContactName = contact.ContactName,
                Title = contact.Title,
                JobPosition = contact.JobPosition,
                Email = contact.Email,
                Phone = contact.Phone,
                Mobile = contact.Mobile,
                Notes = contact.Notes,
                UpdatedDate = DateTime.Now,
                UpdatedBy = User.Identity.Name
            };
            if (ModelState.IsValid)
            {
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + Data.CustomerId);
            }
            return View(contact);
        }

        public ActionResult DeleteContact(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = service.GetContactId(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteContact(int id)
        {
            CustomerContact Data = db.CustomerContacts.Find(id);
            Data.DeletedBy = User.Identity.Name;
            Data.DeletedDate = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + Data.CustomerId);
            }
            return View(Data);
        }

        public ActionResult _ListCustomer(string name)
        {
            var Customer = service.GetListCustomerName(name);

            return PartialView(new ViewCustomer
            {
                ListCustomer = Customer
            });
        }

  

    }
}