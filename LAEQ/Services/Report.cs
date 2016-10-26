using LAEQ.DataContexts;
using LAEQ.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAEQ.Services
{
    public class Report
    {
        private LAEQEntities db = new LAEQEntities();

        public decimal? CountRent ()
        {
            var YearNow = DateTime.Now.Year;
            
                var data = (from a in db.Rents
                            where a.DeletedDate == null
                            && a.StartDate.Year == YearNow
                            select a).Count();
             
            return data;
        }

        public decimal? CountProject()
        {
            var YearNow = DateTime.Now.Year;

            var data = (from a in db.Projects
                        where a.DeletedDate == null
                        && a.StartDate.Year == YearNow
                        select a).Count();

            return data;
        }

       public List<ViewMachine> ListMachineRent(DateTime? date1 , DateTime? date2)
        {
            var data = new List<ViewMachine>();
            if (date1 != null && date2 != null)
            {
                var query = from a in db.Rents
                            where a.DeletedDate == null
                            && a.StartDate >= date1
                            && a.EndDate <= date2
                            select new ViewMachine
                            {
                                Id = a.Id,
                                MachineID = a.Machines.MachineID,
                                SerialNumber = a.Machines.SerialNumber,
                                Status = "Rent",
                                CustomerId = a.CustomerId,
                                CustomerName = a.Customers.Name,
                                StartDate = a.StartDate,
                                EndDate = a.EndDate
                                

                            };
                data = query.ToList();
            }
            else if (date1 != null && date2 == null)
            {
                var query = from a in db.Rents
                            where a.DeletedDate == null
                            && a.EndDate <= date2
                            select new ViewMachine
                            {
                                Id = a.Id,
                                MachineID = a.Machines.MachineID,
                                SerialNumber = a.Machines.SerialNumber,
                                Status = "Rent",
                                CustomerId = a.CustomerId,
                                CustomerName = a.Customers.Name,
                                StartDate = a.StartDate,
                                EndDate = a.EndDate

                            };
                data = query.ToList();
            }
            else if (date1 == null && date2 != null)
            {
                var query = from a in db.Rents
                            where a.DeletedDate == null
                            && a.StartDate >= date2
                            select new ViewMachine
                            {
                                Id = a.Id,
                                MachineID = a.Machines.MachineID,
                                SerialNumber = a.Machines.SerialNumber,
                                Status = "Rent",
                                CustomerId = a.CustomerId,
                                CustomerName = a.Customers.Name,
                                StartDate = a.StartDate,
                                EndDate = a.EndDate
                            };
                data = query.ToList();
            }
            return data;
        }

        public List<ViewMachine> ListMachineProject(DateTime? date1, DateTime? date2)
        {
            var data = new List<ViewMachine>();
            if (date1 != null && date2 != null)
            {
                var query = from a in db.Projects
                            where a.DeletedDate == null
                            && a.StartDate >= date1
                            && a.EndDate <= date2
                            select new ViewMachine
                            {
                                Id = a.Id,
                                MachineID = a.Machines.MachineID,
                                SerialNumber = a.Machines.SerialNumber,
                                Status = "Project",
                                Location = a.Location,
                                StartDate = a.StartDate,
                                EndDate = a.EndDate


                            };
                data = query.ToList();
            }
            else if (date1 != null && date2 == null)
            {
                var query = from a in db.Projects
                            where a.DeletedDate == null
                            && a.EndDate <= date2
                            select new ViewMachine
                            {
                                Id = a.Id,
                                MachineID = a.Machines.MachineID,
                                SerialNumber = a.Machines.SerialNumber,
                                Status = "Project",
                                Location = a.Location,
                                StartDate = a.StartDate,
                                EndDate = a.EndDate
                            };
                data = query.ToList();
            }
            else if (date1 == null && date2 != null)
            {
                var query = from a in db.Projects
                            where a.DeletedDate == null
                            && a.StartDate >= date2
                            select new ViewMachine
                            {
                                Id = a.Id,
                                MachineID = a.Machines.MachineID,
                                SerialNumber = a.Machines.SerialNumber,
                                Status = "Project",
                                Location = a.Location,
                                StartDate = a.StartDate,
                                EndDate = a.EndDate
                            };
                data = query.ToList();
            }
            return data;
        }


    }
}