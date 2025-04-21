using System.ComponentModel.DataAnnotations;
using Task1.VeiwModels;

namespace Task1.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var courseFromRequest =
                validationContext.ObjectInstance as CourseWithDeptListViewModel;
            string name = value.ToString();

            CompanyContext companyContext = new CompanyContext();
            Course courseDb = companyContext.Courses
                                .FirstOrDefault(c => c.Name == name && c.Dept_Id == courseFromRequest.DeptId);
            
            if (courseDb == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Course Name already Existing");
        }
    }
}
