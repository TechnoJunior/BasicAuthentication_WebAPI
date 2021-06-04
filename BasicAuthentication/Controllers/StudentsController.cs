using BasicAuthentication.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicAuthentication.Controllers
{
    public class StudentsController : ApiController
    {
        public IHttpActionResult Get()
        {
            using(StudentDBEntities student = new StudentDBEntities())
            {
                return Ok(student.Students.ToList());
            }
        }
    }
}
