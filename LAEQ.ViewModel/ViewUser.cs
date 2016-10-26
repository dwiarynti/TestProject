using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAEQ.ViewModel
{
    public class ViewUser
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string RoleId { get; set; }

        public string Role { get; set; }

        public IList<string> roleNames { get; set; }
        public List<ViewUser> ListUser { get; set; }
    }
}
