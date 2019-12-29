using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPit.Models
{
    public class GetListOptions
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public List<string> Includes { get; set; } = new List<string>() { };
        public List<string> Excludes { get; set; } = new List<string>() { };
        public string OrderBy { get; set; }
        public string Order { get; set; }
    }
}
