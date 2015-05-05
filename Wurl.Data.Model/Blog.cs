using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wurl.Data.Model
{
  public class Blog : AuditObject
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
    }
}
