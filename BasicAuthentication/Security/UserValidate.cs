using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthentication.Security
{
    public class UserValidate
    {
        public static bool login(String username, String password)
        {
            using(StudentsDBEntities teacher = new StudentsDBEntities())
            {
                return teacher.Teachers.Any(user => user.T_Name.Equals(username, StringComparison.OrdinalIgnoreCase) && user.T_Pass == password);
            }
        }
    }
}