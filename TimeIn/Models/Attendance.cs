using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeIn.Models
{
    public class attendance
    {
        public int attendanceID { get; set; }
        public string studID { get; set; } = "";
        public DateTime? timeIN { get; set; }
        public DateTime? timeOUT { get; set; }
        public string fullname { get; set; } = "";
        public byte[]? photo { get; set; }
        public string gradelvl { get; set; } = "";
    }
}
