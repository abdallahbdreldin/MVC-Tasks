using System.ComponentModel.DataAnnotations;
using Task1.Models;

namespace Task1.VeiwModels
{
    public class CourseWithDeptListViewModel
    {
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }
        [Display(Name ="Department Id")]
        public int DeptId { get; set; }
        public List<Department> Departments { get; set; }
    }
}
