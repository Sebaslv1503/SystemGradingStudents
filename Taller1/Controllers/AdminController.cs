using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;
using static CapaNegocio.StudentBL;

namespace Taller1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Grade()
        {
            return View();
        }
        public IActionResult Enrollments()
        {
            return View();
        }
        public IActionResult RegisterToCourse()
        {
            StudentBL studentBL = new StudentBL();
            CourseBL courseBL = new CourseBL();
            ViewBag.Students = studentBL.GetAllStudents();
            ViewBag.Courses = courseBL.GetAllCourses();
            return View();
        }

        [HttpPost]
        public JsonResult Register(StudentCLS student)
        {
            StudentBL studentBL = new StudentBL();
            bool registrado = studentBL.registerStudents(student);
            return Json(new { success = registrado });
        }
        [HttpPost]
        public JsonResult RegisterToCourse(StudentEnrollmentCLS enrollment)
        {
            StudentBL studentBL = new StudentBL();
            bool success = studentBL.RegisterStudentInCourse(enrollment);
            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult RegisterGrade([FromBody] GradeCLS grade)
        {
            GradeBL GradeBL = new GradeBL();
            bool result = GradeBL.RegisterGrade(grade);
            return Json(new { success = result });
        }

        [HttpGet]
        public JsonResult ListEnrollments()
        {
            var enrollments = EnrollmentBL.GetAllEnrollments();
            return Json(new { success = true, data = enrollments });
        }

        [HttpGet]
        public JsonResult GetStudentAverage(int enrollmentId)
        {
            var avg = GradeBL.GetStudentAverageGrade(enrollmentId);
            return Json(new { success = true, average = avg });
        }



    }
}
