using LAEQ.DataContexts;
using LAEQ.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAEQ.Services
{
    public class ProjectService
    {
        private LAEQEntities db = new LAEQEntities();

        //<-- GET List Project  -->
        public List<ViewProject> GetListProject()
        {
            var ProjectResult = new List<ViewProject>();
            var Project = (from project in db.Projects
                           where project.DeletedBy == null
                           select new ViewProject
                           {
                               Id = project.Id,
                               MachineId = project.MachineId,
                               Location = project.Location,
                               StartDate= project.StartDate,
                               EndDate = project.EndDate,
                               ReturnDate = project.ReturnDate,
                               Remark = project.Remark,
                               Machine = project.Machines.MachineID,
                               SerialNumber = project.Machines.SerialNumber,
                               Status = project.Machines.Status
                           });
            ProjectResult = Project.ToList();
            return ProjectResult;
        }

        //<--  End -->

        //<-- GET  Project By Id  -->
        public ViewProject GetProject(int? id)
        {
           
            var Project = (from project in db.Projects
                           where project.Id == id
                           select new ViewProject
                           {
                               Id = project.Id,
                               MachineId = project.MachineId,
                               Location = project.Location,
                               StartDate = project.StartDate,
                               EndDate = project.EndDate,
                               ReturnDate = project.ReturnDate,
                               Remark = project.Remark,
                               Machine = project.Machines.MachineID,
                               SerialNumber = project.Machines.SerialNumber,
                               Status = project.Machines.Status
                           });
            
            return Project.FirstOrDefault();
        }

        //<--  End -->
    }
}