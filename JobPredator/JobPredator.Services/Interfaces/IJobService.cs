

using JobPredator.Models;


namespace JobPredator.Services.Interfaces
{
    public interface IJobService
    {

        Task<IEnumerable<Job>> Get();
        Task<Job> GetById(int id);
        Task<bool> Save (Job job);
        Task<bool> Delete(int id);


    }
}
