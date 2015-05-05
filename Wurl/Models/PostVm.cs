using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wurl.Data.Model;

namespace Wurl.Models
{
    public class PostVm
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}