using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICES_ClassLib
{
    public class ICES_Laws
    {
        public int ICES { get; set; }
        public string ICESLegislationNo { get; set; }
        public string ICESBillPolicy { get; set; }
        public string ICESName { get; set; }
        public string ICESProposedby { get; set; }
        public string ICESStatus { get; set; }
    }
    public class ICES_Comments
    {
        public int ICES { get; set; }
        public string ICESIDNO { get; set; }
        public string ICESName { get; set; }
        public string ICESInstitutionalEmail { get; set; }
        public string ICESComment { get; set; }
    }
}
