using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wurl.Data.Model
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string UserId { get; set; }
        public string DisplayName { get; set; }        
        public string Country { get; set; }
        public string City { get; set; }
        public string About { get; set; }
        public virtual List<ApplicationUser> Friends { get; set; }
    }
}
