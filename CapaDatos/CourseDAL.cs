using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CourseDAL:CadenaDAL
    {
        public List<CourseCLS> GetAllCourses()
        {
            List<CourseCLS> list = new List<CourseCLS>();

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                cn.Open();
                string sql = "SELECT CourseID, NRCCode, CourseName FROM Courses";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new CourseCLS
                        {
                            CourseID = (int)dr["CourseID"],
                            NRCCode = dr["NRCCode"].ToString(),
                            CourseName = dr["CourseName"].ToString()
                        });
                    }
                }
            }

            return list;
        }

    }
}
