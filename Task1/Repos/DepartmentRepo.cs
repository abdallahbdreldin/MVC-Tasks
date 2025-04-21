using Task1.Models;

namespace Task1.Repos
{
    public class DepartmentRepo : Repo<Department> , IDepartmentRepo
    {
        private readonly CompanyContext context;

        public DepartmentRepo(CompanyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
