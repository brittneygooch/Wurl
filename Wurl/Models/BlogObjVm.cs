using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wurl.Models
{
    public class BlogObjVm
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual string User { get; set; }
    }
}