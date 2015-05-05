using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wurl.Models
{
    public class PostsVm
    {
        public List<PostObjVm> AllPosts { get; set; }
        public string UserId { get; set; }
    }
}