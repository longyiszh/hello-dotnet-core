using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPit.Models
{
    public interface IProjectSettings
    {
        string ConnectionString { get; set; }
        public string DBName { get; set; }

    }
    public class ProjectSettings: IProjectSettings
    {
        public string ConnectionString { get; set; }
        public string DBName { get; set; }
    }
}
