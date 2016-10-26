using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAEQ.ViewModel
{
    public class ViewCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Website { get; set; }

      
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string DeletedBy { get; set; }

        //<-- GET List Contact By Id -->
        public List<ViewCustomerContact> CustomerContact { get; set; }
        //<-- END -->

        public List<ViewCustomer> ListCustomer { get; set; }

        public string ContactName { get; set; }
        public string Title { get; set; }
        public string JobPosition { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Notes { get; set; }

        public ViewCustomerContact ContactCustomerId { get; set; }
    }
}
