using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAEQ.ViewModel
{
    public class ViewReport
    {
        public List<ViewMachine> Rent { get; set; }
        public List<ViewMachine> Project { get; set; }

        public decimal? Rents { get; set; }
        public decimal? Projects { get; set; }

    }
}
