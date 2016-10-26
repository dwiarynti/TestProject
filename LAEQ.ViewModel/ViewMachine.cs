using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAEQ.ViewModel
{
    public class ViewMachine
    {
        public int Id { get; set; }
        [Required]
        public string MachineID { get; set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Nullable<int> Capacity { get; set; }
        public string Status { get; set; }
        public string PM { get; set; }
        public string Calibration { get; set; }
        public Nullable<System.DateTime> CalibrationDate { get; set; }
        public Nullable<System.DateTime> PMDate { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string DeletedBy { get; set; }

        public List<ViewMachine> ListMachine { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
    }
}
