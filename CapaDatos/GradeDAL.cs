using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GradeDAL:CadenaDAL
    {
        public bool RegisterGrade(GradeCLS grade)
        {
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                cn.Open();
                string sql = @"INSERT INTO Grades (EnrollmentID, GradeValue, GradeType, GradeDate)
                       VALUES (@EnrollmentID, @GradeValue, @GradeType, @GradeDate)";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@EnrollmentID", grade.EnrollmentID);
                    cmd.Parameters.AddWithValue("@GradeValue", grade.GradeValue);
                    cmd.Parameters.AddWithValue("@GradeType", grade.GradeType);
                    cmd.Parameters.AddWithValue("@GradeDate", grade.GradeDate);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public decimal GetStudentAverageGrade(int enrollmentId)
        {
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                cn.Open();
                string sql = "SELECT AVG(GradeValue) FROM Grades WHERE EnrollmentID = @EnrollmentID";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@EnrollmentID", enrollmentId);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                        return Convert.ToDecimal(result);
                    else
                        return 0;
                }
            }
        }


    }
}
