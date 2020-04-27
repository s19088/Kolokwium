using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Models
{
    public class MyTask
    {
        public string ProjectName { get; set; } // Name z Project
        public string Description { get; set; } // Description z Task
        public DateTime Deadline { get; set; } // Deadline z Task
        public string TaskName { get; set; } // nazwa z Task
        public string TaskType { get; set; } // z TaskType wyciagnac Name
    }
}
