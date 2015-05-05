using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wurl.Data.Model
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public string HostId { get; set; }
        public string UserId { get; set; }
        public virtual string User { get; set; }
        public bool IsAttending { get; set; }

    }
}
