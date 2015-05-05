using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wurl.Data.Model;

namespace Wurl.Models
{
    public class ReplyVm
    {
        public int ReplyId { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int PostId { get; set; }
        public bool IsDeleted { get; set; }
    }
}