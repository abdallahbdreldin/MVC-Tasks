using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id {  get; set; }
        public List<CrsResult> CrsResults { get; set; } = new List<CrsResult>();
        public Department Department { get; set; }
    }
}
