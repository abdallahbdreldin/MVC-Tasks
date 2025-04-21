using Task1.Models;

namespace Task1.Repos
{
    public class TraineeRepo : Repo<Trainee> , ITraineeRepo
    {
        private readonly CompanyContext context;

        public TraineeRepo(CompanyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
