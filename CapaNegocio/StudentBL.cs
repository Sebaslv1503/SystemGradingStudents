using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class StudentBL
    {
        public bool registerStudents(StudentCLS student)
        {
            StudentDAL studentDAL = new StudentDAL();
            return studentDAL.registerStudents(student);
        }
        public bool RegisterStudentInCourse(StudentEnrollmentCLS enrollment)
        {
            StudentDAL dal = new StudentDAL();
            return dal.RegisterStudentInCourse(enrollment);
        }
        public List<StudentCLS> GetAllStudents()
        {
            StudentDAL dal = new StudentDAL();
            return dal.GetAllStudents();
        }

    }
}
