using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class EnrollmentDAL: CadenaDAL
    {
        public List<EnrollmentCLS> GetAllEnrollments()
        {
            List<EnrollmentCLS> list = new List<EnrollmentCLS>();

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                cn.Open();
                string sql = @"
            SELECT e.EnrollmentID, s.FirstName + ' ' + s.LastName AS StudentName,
                   c.CourseName
            FROM Enrollments e
            INNER JOIN Students s ON e.StudentID = s.StudentID
            INNER JOIN Courses c ON e.CourseID = c.CourseID";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(new EnrollmentCLS
                        {
                            EnrollmentID = (int)dr["EnrollmentID"],
                            StudentName = dr["StudentName"].ToString(),
                            CourseName = dr["CourseName"].ToString()
                        });
                    }
                }
            }

            return list;
        }

    }
}
