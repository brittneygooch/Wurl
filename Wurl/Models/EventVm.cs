using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wurl.Data.Model;

namespace Wurl.Models
{
    public class EventVm
    {
        public Event ThatEvent { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}