using Kolokwium1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.DTOs
{
    public class TaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int IdTeam { get; set; }
        public int IdAssignedTo { get; set; }
        public int IdCreator { get; set; }
        public MyTaskTypes Task { get; set; }
    }
}
