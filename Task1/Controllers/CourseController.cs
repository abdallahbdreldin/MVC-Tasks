using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;
using Task1.VeiwModels;

namespace Task1.Controllers
{
    public class CourseController : Controller
    {
        CompanyContext _context = new();
        public IActionResult Result(int id)
        {
            var query = _context.CrsResult.Include(c => c.Course)
                            .Include(c => c.Trainee)
                            .Where(c => c.Crs_Id == id)
                            .Select(c => new CourseWithTraineeResult
                            {
                                CourseName = c.Course.Name,
                                TraineeName = c.Course.Name,
                                Degree = c.Course.Degree,
                                Status = c.Course.Degree > c.Course.MinDegree ? "Passed" : "Failed"
                            }).ToList();

            //var course = (from Course in _conctext.Courses
            //             join CrsResult in _conctext.CrsResult
            //             on Course.Id equals CrsResult.Crs_Id
            //             join Trainee in _conctext.Trainees
            //             on CrsResult.Trainee_Id equals Trainee.Id
            //             where Course.Id == id
            //             select new CourseWithTraineeResult
            //             {
            //                 CourseName = Course.Name,
            //                 TraineeName = Trainee.Name,
            //                 Degree = CrsResult.Degree,
            //                 Status = CrsResult.Degree > Course.MinDegree ? "Passed" : "Failed"
            //             }).ToList();
                         
            return View(query);
        }

        public IActionResult Index()
        {
            var Courses = _context.Courses
                    .AsNoTracking()
                    .Include(d => d.Department)
                    .ToList();

            return View(Courses);
        }

        public IActionResult Add()
        {
            CourseWithDeptListViewModel model = new();
            model.Departments = _context.Departments.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewSave(CourseWithDeptListViewModel coursevm)
        {
            if(coursevm.Name != null)
            {
                Course coursedb = new()
                {
                    Name = coursevm.Name,
                    Degree = coursevm.Degree,
                    MinDegree = coursevm.MinDegree,
                    Hours = coursevm.Hours,
                    Dept_Id = coursevm.DeptId
                };
                _context.Courses.Add(coursedb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            coursevm.Departments = _context.Departments.ToList();
            return View("Add",coursevm);
        }
    }
}
