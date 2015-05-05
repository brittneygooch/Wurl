using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wurl.Models
{
    public class PostObjVm
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
        public int ReplyId { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual string User { get; set; }
    }
}