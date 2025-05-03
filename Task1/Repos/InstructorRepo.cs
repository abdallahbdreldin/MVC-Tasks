using Task1.Models;

namespace Task1.Repos
{
    public class InstructorRepo : Repo<Instructor> , IInstructorRepo
    {
        private readonly CompanyContext context;

        public InstructorRepo(CompanyContext context):base(context)
        {
            this.context = context;
        }
    }
}
