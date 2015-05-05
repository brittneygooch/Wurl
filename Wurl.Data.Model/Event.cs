using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wurl.Data.Model
{
    public class Event : AuditObject
    {
        public int EventId {get; set;}

        public string Title {get; set;}

        public string Location {get; set;}
        public string City { get; set; }

        public string Description {get; set;}

        public string UserId {get; set;}

        public string Date { get; set; }

        public string Time { get; set; }
        public string ImgUrl { get; set; }
        public int? Rating { get; set; }


    }
}
