using Task1.Models;

namespace Task1.Repos
{
    public class CourseRepo : Repo<Course> , ICourseRepo
    {
        private readonly CompanyContext context;

        public CourseRepo(CompanyContext context):base(context)
        {
            this.context = context;
        }
    }
}
