using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wurl.Models
{
    public class ImageVm
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long Size { get; set; }
        public string Url { get; set; }
    }
}