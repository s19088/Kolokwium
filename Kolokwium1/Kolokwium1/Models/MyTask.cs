using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Models
{
    public class MyTask
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; } 
        public string TaskName { get; set; } 
        public string TaskType { get; set; } 
    }
}
