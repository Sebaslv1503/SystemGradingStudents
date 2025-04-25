using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class StudentDAL:CadenaDAL
    {
        public bool registerStudents(StudentCLS student)
        {
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                cn.Open();
                string sql = "INSERT INTO Students (FirstName, LastName, email)" +
                    "VALUES (@Name, @LastName, @Email);";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Name", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@Email", student.email);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool RegisterStudentInCourse(StudentEnrollmentCLS enrollment)
        {
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                cn.Open();
                string sql = @"
                    INSERT INTO Enrollments (StudentID, CourseID)
                    VALUES (@StudentID, @CourseID);";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", enrollment.StudentID);
                    cmd.Parameters.AddWithValue("@CourseID", enrollment.CourseID);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public List<StudentCLS> GetAllStudents()
        {
            List<StudentCLS> list = new List<StudentCLS>();

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                cn.Open();
                string sql = "SELECT StudentID, FirstName, LastName FROM Students";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new StudentCLS
                        {
                            StudentID = (int)dr["StudentID"],
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString()
                        });
                    }
                }
            }

            return list;
        }


    }
}
