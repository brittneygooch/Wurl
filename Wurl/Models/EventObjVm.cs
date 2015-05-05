using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wurl.Models
{
    public class EventObjVm
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ImgUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual string User { get; set; }
    }
}