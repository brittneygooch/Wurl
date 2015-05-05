using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wurl.Data.Model;

namespace Wurl.Models
{
    public class EditVm
    {
        public Post ThisPost { get; set; }
        public Blog ThisBlog { get; set; }
        public Event ThisEvent { get; set; }
    }
}