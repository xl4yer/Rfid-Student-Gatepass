using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeIn.Models
{
    public class students
    {
        public string studID { get; set; } = "";
        public byte[]? photo { get; set; }
        public string fname { get; set; } = "";
        public string mname { get; set; } = "";
        public string lname { get; set; } = "";
        public DateTime? bdate { get; set; } = DateTime.Now;
        public string gender { get; set; } = "";
        public string gradelvl { get; set; } = "";
        public string address { get; set; } = "";
        public string contact { get; set; } = "";
        public string guardian { get; set; } = "";
        public string gcontact { get; set; } = "";
        public string fullname { get; set; } = "";
    }
}
