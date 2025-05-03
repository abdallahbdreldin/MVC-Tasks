using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;
using Task1.Repos;

namespace Task1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly CompanyContext _context;
        private readonly IInstructorRepo _repo;

        public InstructorController(CompanyContext context , IInstructorRepo repo)
        {
            _context = context;
            _repo = repo;
        }

        [Authorize]
        public IActionResult Index()
        {
            var instructors = _context.Instructors
                                .AsNoTracking()
                                .Include(d => d.Department)
                                .Include(c => c.Course)
                                .ToList();
            return View(instructors);
        }


        public IActionResult Details(int id)
        {
            var instructor = _context.Instructors
                                .Include(d => d.Department)
                                .Include(c => c.Course)
                                .SingleOrDefault(d => d.Id == id);
            return View(instructor);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewSave(Instructor ins)
        {
            if (ins.Name != null)
            {
                _context.Instructors.Add(ins);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add", ins);
        }

        public IActionResult Edit(int id)
        {
            Instructor ins = _context.Instructors.FirstOrDefault(d => d.Id == id);
            return View(ins);
        }

        [HttpPost]
        public IActionResult EditSave(Instructor ins)
        {
            if (ins.Name != null)
            {
                Instructor insDb = _context.Instructors.Find(ins.Id);

                insDb.Name = ins.Name;
                insDb.ImageUrl = ins.ImageUrl;
                insDb.Address = ins.Address;
                insDb.Salary = ins.Salary;
                insDb.Dept_Id = ins.Dept_Id;
                insDb.Crs_Id = ins.Crs_Id;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", ins);
        }

        public IActionResult GetInsCard(int id)
        {
            Instructor ins = _repo.GetById(id);
            if (ins == null)
            {
                return NotFound();
            }

            return PartialView("_InsCardPartial",ins);
        }
    }
}
