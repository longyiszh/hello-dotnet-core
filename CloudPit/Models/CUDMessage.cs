using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPit.Models
{
    public class CUDMessage
    {
        public bool OK { get; set; }
        public int NumAffected { get; set; }
        public string Message { get; set; }
    }
}
