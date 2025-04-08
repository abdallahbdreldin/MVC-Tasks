using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Task1.Models;
using Task1.VeiwModels;

namespace Task1.Controllers
{
    public class TraineeController : Controller
    {
        CompanyContext _context = new CompanyContext();
        public IActionResult Details(int tid , int cid)
        {
            var trainee = _context.Trainees.FirstOrDefault(t => t.Id == tid);
            var course = _context.Courses.FirstOrDefault(t => t.Id == cid);
            var degree = _context.CrsResult
                         .Where(cr => cr.Trainee_Id == tid && cr.Crs_Id == cid)
                         .Select(d => d.Degree)
                         .FirstOrDefault();
            string status = "";
            if (course != null)
            {
               status = degree >= course.MinDegree ? "Passed" : "Failed";
            }

            TraineeCourseWithResultViewModel traineeResult = new()
            {
                TraineeName = trainee?.Name,
                CourseName = course?.Name,
                Degree = degree,
                Status = status
            };

            return View(traineeResult);
        }
    }
}
