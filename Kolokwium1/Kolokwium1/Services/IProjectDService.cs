using Kolokwium1.DTOs;
using Kolokwium1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Services
{
    public interface IProjectDService
    {
        public List<MyTask> GetProjectInfo(int id);
        public TaskResponse PostTask(TaskRequest request);
    }
}
