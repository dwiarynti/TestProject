using LAEQ.DataContexts;
using LAEQ.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAEQ.Services
{
    public class CustomerService
    {
        private LAEQEntities db = new LAEQEntities();

        //<-- GET Customer By Id -->
        public ViewCustomer GetCustomer(int? id)
        {
            var Customer = (from customer in db.Customers
                            where customer.Id == id
                            select new ViewCustomer
                            {
                                Id = customer.Id,
                                Name = customer.Name,
                                Type = customer.Type,
                                Address1 = customer.Address1,
                                Address2 = customer.Address2,
                                Website = customer.Website,
                                
                               
                            }
                            ).ToList();
            foreach(var item in Customer)
            {
                item.CustomerContact = GetContact(item.Id);
            }
            return Customer.FirstOrDefault();
        }

        //<-- END -->

        //<-- GET List Customer  -->
        public List<ViewCustomer> GetListCustomer()
        {
            var CustomerResult = new List<ViewCustomer>();
            var Customer = (from customer in db.Customers
                            where customer.DeletedBy == null
                            select new ViewCustomer
                            {
                                Id = customer.Id,
                                Name = customer.Name,
                                Type = customer.Type,
                                Address1 = customer.Address1,
                                Address2 = customer.Address2,
                                Website = customer.Website,
                               
                            }
                            ).ToList();
            CustomerResult = Customer.ToList();
            return CustomerResult;
        }
        //<-- END -->


        //<-- GET List Contact By Id -->
        public List<ViewCustomerContact> GetContact(int customerId)
        {
            var contact = new List<ViewCustomerContact>();
            var data = (from a in db.CustomerContacts
                        where a.DeletedBy == null
                        && a.CustomerId == customerId
                        select new ViewCustomerContact
                        {
                            Id = a.Id,
                            CustomerId = a.CustomerId,
                            Title = a.Title,
                            ContactName = a.ContactName,
                            JobPosition = a.JobPosition,
                            Email = a.Email,
                            Phone = a.Phone,
                            Mobile = a.Mobile,
                            Notes = a.Notes
                        });
            contact = data.ToList();
            return contact;
                      
        }
        //<-- END -->


        //<-- GET Contact By Id -->
        public ViewCustomerContact GetContactId(int? id)
        {
            var Contact = (from a in db.CustomerContacts
                        where a.Id == id
                        select new ViewCustomerContact
                        {
                            Id = a.Id,
                            CustomerId = a.CustomerId,
                            ContactName = a.ContactName,
                            Title = a.Title,
                            JobPosition = a.JobPosition,
                            Email = a.Email,
                            Phone = a.Phone,
                            Mobile = a.Mobile,
                            Notes = a.Notes,
                            Type = a.Customers.Type,
                            Name = a.Customers.Name
                        });
            return Contact.FirstOrDefault();
        }


        //<-- END -->

        //<-- GET List Customer  -->
        public List<ViewCustomer> GetListCustomerName(string name)
        {
            var CustomerResult = new List<ViewCustomer>();
            var Customer = (from customer in db.Customers
                            where customer.DeletedBy == null
                            && customer.Name.Contains(name)
                            select new ViewCustomer
                            {
                                Id = customer.Id,
                                Name = customer.Name,
                                Type = customer.Type,
                                Address1 = customer.Address1,
                                Address2 = customer.Address2,
                                Website = customer.Website,

                            }
                            ).ToList();
            CustomerResult = Customer.ToList();
            foreach(var item in CustomerResult)
            {
                item.ContactCustomerId = ContactCustomerId(item.Id);
            }
            return CustomerResult;
        }

        //<-- END -->

        public ViewCustomerContact ContactCustomerId (int customerId)
        {
            var Contact = from a in db.CustomerContacts.OrderByDescending(a => a.CreatedDate)
                          where a.DeletedDate == null
                          && a.CustomerId == customerId
                          select new ViewCustomerContact
                          {
                              Id = a.Id,
                              CustomerId = a.CustomerId,
                              ContactName  =a.ContactName,
                              Title = a.Title,
                              JobPosition = a.JobPosition,
                              Email = a.Email,
                              Phone = a.Phone,
                              Mobile = a.Mobile,
                              Notes = a.Notes
                          };
            return Contact.FirstOrDefault();
                          
        }

        public ViewCustomerContact CustomerCreateContact (int? customerId)
        {
            var Contact = from customer in db.Customers
                          where customer.Id == customerId
                          select new ViewCustomerContact
                          {
                              CustomerId = customer.Id,
                              Name = customer.Name,
                              Type = customer.Type,
                          };
            return Contact.FirstOrDefault();
        }

        public List<ViewCustomer> GetListCustomerContains(string name)
        {
            var CustomerResult = new List<ViewCustomer>();
            var Customer = (from customer in db.Customers
                            where customer.DeletedBy == null
                            && customer.Name.Contains(name)
                            select new ViewCustomer
                            {
                                Id = customer.Id,
                                Name = customer.Name,
                                Type = customer.Type,
                                Address1 = customer.Address1,
                                Address2 = customer.Address2,
                                Website = customer.Website,

                            }
                            ).ToList();
            CustomerResult = Customer.ToList();
            return CustomerResult;
        }

    }
}