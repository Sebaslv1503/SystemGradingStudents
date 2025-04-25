using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CourseBL
    {
        public List<CourseCLS> GetAllCourses()
        {
            CourseDAL dal = new CourseDAL();
            return dal.GetAllCourses();
        }

    }
}
