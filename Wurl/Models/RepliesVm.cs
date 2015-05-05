using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wurl.Data.Model;

namespace Wurl.Models
{
    public class RepliesVm
    {
        public Post ThatPost { get; set; }
        public List<PostObjVm> AllReplies { get; set; }
        public string UserId { get; set; }
    }
}