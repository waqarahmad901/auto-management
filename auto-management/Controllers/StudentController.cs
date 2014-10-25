using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
using System.Threading.Tasks;

namespace auto_management.Controllers
{
    public class StudentController : ApiController
    {
        private IAutoManagementContext context = null;
        public StudentController()
        {
            context = new AutoManagementContext();
        }
        public StudentController(IAutoManagementContext cont)
        {
            this.context = cont;
        }


        public IHttpActionResult Get()
        {

            var user = context.GetStudents();

            return this.Ok(user);
        }
        [HttpPost]
        public IHttpActionResult Post(Student stu)
        {
            context.AddStudent(stu);
            return this.Ok();
        }

    }
}
