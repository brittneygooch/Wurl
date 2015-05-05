using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wurl.Data.Model
{
    public class Role : IdentityRole
    {
        //available roles for Wurl users
        public const string ADMIN = "Admin";
        public const string GENERAL = "General";
    }
}
