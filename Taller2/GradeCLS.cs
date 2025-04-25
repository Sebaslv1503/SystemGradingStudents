using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class GradeCLS
    {
        public int GradeID { get; set; }
        public int EnrollmentID { get; set; }
        public decimal GradeValue { get; set; }
        public string GradeType { get; set; }
        public DateTime GradeDate { get; set; }
    }

}
