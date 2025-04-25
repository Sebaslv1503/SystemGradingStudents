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

    }
}
