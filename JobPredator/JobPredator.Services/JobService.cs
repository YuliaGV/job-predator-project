
using JobPredator.DataAccess;
using JobPredator.Models;
using JobPredator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPredator.Services
{
    public class JobService : IJobService
    {

        DataContext _dataContext;

        public JobService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
       
        public async Task<IEnumerable<Job>> Get()
        {
            return await _dataContext.Jobs.ToListAsync();
        }

        public async Task<Job> GetById(int id)
        {
            return await _dataContext.Jobs.FirstOrDefaultAsync(job => job.Id == id);
        }

        public async Task<bool> Save(Job job)
        {
            bool exists = await _dataContext.Jobs
            .AnyAsync(j => j.Url == job.Url && j.Title == job.Title && j.Location == job.Location);

            if (exists)
            {
                return false;
            }

            _dataContext.Jobs.Add(job);
            await _dataContext.SaveChangesAsync();
            return true;

        }


        public async Task<bool> Delete(int id)
        {
            var currentJob = _dataContext.Jobs.Find(id);

            if (currentJob == null)
            {
                return false;
            }

            _dataContext.Jobs.Remove(currentJob);
            await _dataContext.SaveChangesAsync();
            return true;

        }







       
    }
}
