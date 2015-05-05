using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wurl.Data.Model
{
    public class AuditObject
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
        public bool IsDeleted { get; set; }
    }
}
