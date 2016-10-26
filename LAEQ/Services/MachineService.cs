using LAEQ.DataContexts;
using LAEQ.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAEQ.Services
{
    public class MachineService
    {
        private LAEQEntities db = new LAEQEntities();

        //<-- GET Machine By Id -->
        public ViewMachine GetMachine (int? id)
        {
            var Machine = (from machine in db.Machines
                           where machine.Id == id
                           select new ViewMachine
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
                               Remark = machine.Remark
                           });
            return Machine.FirstOrDefault();
        }

        //<--  End -->


        //<-- GET List Machine -->
        public List<ViewMachine> GetListMachine()
        {
            var MachineResult = new List<ViewMachine>();
            var Machine = (from machine in db.Machines
                           where machine.DeletedBy == null
                           select new ViewMachine
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
                               Remark = machine.Remark
                           });
            MachineResult = Machine.ToList();
            return MachineResult;
        }

        //<--  End -->

        //<-- GET Machine Not In Project and Rent -->
        public List<ViewMachine> ListMachineNotInProjectAndRent(string name)
        {
            var ListMachine = new List<ViewMachine>();
            var Project = (from a in db.Projects
                           where a.DeletedDate == null
                           && a.ReturnDate != null
                           select a.MachineId);
            var GroupProject = from MachineId in Project
                               group MachineId by new { MachineId }
                               into data
                               select data.FirstOrDefault();
            var Rent = (from a in db.Rents
                        where a.DeletedDate == null
                        && a.ReturnDate != null
                        select a.MachineId);
            var GroupRent = from MachineId in Project
                            group MachineId by new { MachineId }
                            into data
                            select data.FirstOrDefault();


            var Machine = (from a in db.Machines
                           where a.DeletedDate == null
                           select new ViewMachine
                           {
                               Id = a.Id,
                               MachineID = a.MachineID,
                               SerialNumber = a.SerialNumber,
                               Brand = a.Brand,
                               Model = a.Model,
                               Year = a.Year,
                               Capacity = a.Capacity,
                               Status = a.Status,
                               PM = a.PM,
                               Calibration = a.Calibration,
                               CalibrationDate = a.CalibrationDate,
                               PMDate = a.PMDate,
                               Remark = a.Remark

                           });
            ListMachine = Machine.ToList();
            var ResultNotInProject = ListMachine.Where(p => !GroupProject.Any(p1 => p1 == p.Id));
            var ResultNotInRent = ResultNotInProject.Where(p => !Rent.Any(p1 => p1 == p.Id));
            var Result = from a in ResultNotInRent
                         where a.MachineID.Contains(name)
                         select a;

            return Result.ToList();
        }

        public List<ViewMachine> GetMachineAvailable(string name)
        {
            var data = new List<ViewMachine>();
            var query = from a in db.Machines
                        where a.DeletedDate == null
                        && a.Status == "Available"
                        && a.MachineID.Contains(name)
                        select new ViewMachine
                        {
                            Id = a.Id,
                            MachineID = a.MachineID,
                            SerialNumber = a.SerialNumber,
                            Brand = a.Brand,
                            Model = a.Model,
                            Year = a.Year,
                            Capacity = a.Capacity,
                            Status = a.Status,
                            PM = a.PM,
                            Calibration = a.Calibration,
                            CalibrationDate = a.CalibrationDate,
                            PMDate = a.PMDate,
                            Remark = a.Remark
                        };
            data = query.ToList();
            return data;
        }

       

    }
}