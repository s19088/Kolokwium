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
                command.CommandText = "Select IndexNumber,FirstName,LastName,BirthDate,Semester,Name from Studies inner join enrollment on studies.idStudy=enrollment.idStudy" +
                    " inner join Student on enrollment.idEnrollment=student.idEnrollment where indexnumber=@index";
                command.Parameters.AddWithValue("index", Index);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    student = new Student();
                    student.IndexNumber = dr["IndexNumber"].ToString();
                    student.FirstName = dr["FirstName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                    student.BirthDate = dr["BirthDate"].ToString();
                    student.Semester = dr["Semester"].ToString();
                    student.Studies = dr["Name"].ToString();
                    Console.Out.WriteLine(student.ToString());
                }
                dr.Close();
            }
            }
        }
}
