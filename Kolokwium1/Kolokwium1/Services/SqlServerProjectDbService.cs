using Kolokwium1.DTOs;
using Kolokwium1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium1.Services
{
    public class SqlServerProjectDbService : IProjectDService
    {
        public List<MyTask> GetProjectInfo(int id)
        {
            List<MyTask> lists = new List<MyTask>();
            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19088;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select Project.Name, Task.Description, Task.Deadline, Task.Name, TaskType.Name FROM Task"+
                                        "INNER JOIN TaskType ON Task.IdTaskType = Task.IdTaskType"
                                        + "INNER JOIN Project ON Task.IdProject = Project.IdProject"
                                        + "WHERE Project.IdProject = @id"
                                        + "ORDER BY Task.Deadline desc ";
                command.Parameters.AddWithValue("id", id);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var task= new MyTask();
                    task.ProjectName = dr["Project.Name"].ToString();
                    task.Description = dr["Task.Description"].ToString();
                    task.Deadline = (DateTime)dr["Task.Deadline"];
                    task.TaskName = dr["Task.Name"].ToString();
                    task.TaskType= dr["TaskType.Name"].ToString();
                    lists.Add(task);
                }
                dr.Close();
            }
            return lists;
            }

        public TaskResponse PostTask(TaskRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
