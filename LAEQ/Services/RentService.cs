using LAEQ.DataContexts;
using LAEQ.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAEQ.Services
{
    public class RentService
    {
        private LAEQEntities db = new LAEQEntities();

        //<-- GET List Rent  -->
        public List<ViewRent> GetListRent()
        {
            var RentResult = new List<ViewRent>();
            var Rent = (from rent in db.Rents
                           where rent.DeletedBy == null
                           select new ViewRent
                           {
                               Id = rent.Id,
                               MachineId = rent.MachineId,
                               CustomerId = rent.CustomerId,
                               StartDate = rent.StartDate,
                               EndDate = rent.EndDate,
                               ReturnDate = rent.ReturnDate,
                               Remark = rent.Remark,
                               Machine = rent.Machines.MachineID,
                               SerialNumber = rent.Machines.SerialNumber,
                               Status = rent.Machines.Status,
                               RentPrice = rent.RentPrice,
                               CustomerName = rent.Customers.Name
                           });
            RentResult = Rent.ToList();
            return RentResult;
        }

        //<--  End -->

        //<-- GET  Rent  by Id-->
        public ViewRent GetRent(int? id)
        {
            var Rent = (from rent in db.Rents
                        where rent.Id == id
                        select new ViewRent
                        {
                            Id = rent.Id,
                            MachineId = rent.MachineId,
                            CustomerId = rent.CustomerId,
                            CustomerName = rent.Customers.Name,
                            StartDate = rent.StartDate,
                            EndDate = rent.EndDate,
                            RentPrice = rent.RentPrice,
                            ReturnDate = rent.ReturnDate,
                            Remark = rent.Remark,
                            Machine = rent.Machines.MachineID,
                            SerialNumber = rent.Machines.SerialNumber,
                            Status = rent.Machines.Status
                        });

            return Rent.FirstOrDefault();
        }
    }
}