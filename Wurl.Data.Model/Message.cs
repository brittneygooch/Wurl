using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wurl.Data.Model
{
   public class Message : AuditObject
    {
        public int MessageId { get; set; }
        public string SendId { get; set; }
        public string PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
    }
}
