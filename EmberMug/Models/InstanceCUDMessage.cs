using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMug.Models
{
    public class InstanceCUDMessage<T>
    {
        public bool OK { get; set; }
        public string Message { get; set; }
        public T Instance { get; set; }
    }
}
