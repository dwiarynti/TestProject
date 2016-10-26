using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAEQ.EntityModel
{
    public class Customer
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

        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }

    }
}
