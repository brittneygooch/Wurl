using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wurl.Data.Model
{
    public class Post : AuditObject
    {
        public int PostId { get; set; }
        public int EventId { get; set; }
        public int RespondedTo { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
