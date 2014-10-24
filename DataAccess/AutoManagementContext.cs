using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AutoManagementContext : IAutoManagementContext
    {
        private AutoManagement context = new AutoManagement();
        public List<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        public void AddStudent(Student st)
        {
            context.Students.Add(st);
            context.SaveChangesAsync();
        }
    }
}
