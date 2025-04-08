using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;
using Task1.VeiwModels;

namespace Task1.Controllers
{
    public class CourseController : Controller
    {
        CompanyContext _conctext = new();
        public IActionResult Result(int id)
        {
            var course = (from Course in _conctext.Courses
                         join CrsResult in _conctext.CrsResult
                         on Course.Id equals CrsResult.Crs_Id
                         join Trainee in _conctext.Trainees
                         on CrsResult.Trainee_Id equals Trainee.Id
                         where Course.Id == id
                         select new CourseWithTraineeResult
                         {
                             CourseName = Course.Name,
                             TraineeName = Trainee.Name,
                             Degree = CrsResult.Degree,
                             Status = CrsResult.Degree > Course.MinDegree ? "Passed" : "Failed"
                         }).ToList();
                         
            return View(course);
        }
    }
}
