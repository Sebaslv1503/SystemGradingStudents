using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class GradeBL
    {
        public bool RegisterGrade(GradeCLS grade)
        {
            GradeDAL dal = new GradeDAL();
            return dal.RegisterGrade(grade);
        }
        public static decimal GetStudentAverageGrade(int enrollmentId)
        {
            GradeDAL dal = new GradeDAL();
            return dal.GetStudentAverageGrade(enrollmentId);
        }


    }
}
