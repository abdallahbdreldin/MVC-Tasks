using System.ComponentModel.DataAnnotations;
using Task1.Models;

namespace Task1.VeiwModels
{
    public class CourseWithDeptListViewModel
    {
        [Unique]
        public string Name { get; set; }
        [Even]
        public int Degree { get; set; }
        [Even]
        public int MinDegree { get; set; }
        public int Hours { get; set; }
        [Display(Name ="Department Id")]
        public int DeptId { get; set; }
        public List<Department> Departments { get; set; }
    }
}
