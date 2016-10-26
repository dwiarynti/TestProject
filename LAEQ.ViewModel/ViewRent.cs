using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAEQ.ViewModel
{
    public class ViewRent
    {
       
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
        public decimal RentPrice { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string DeletedBy { get; set; }

        public string RentPriceText { get; set; }
        public string Machine { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }


        public List<ViewRent> ListRent { get; set; }

        public string CustomerName { get; set; }

    }
}
