using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobManager.Models;

namespace JobManager.Services
{
    public class JobDataStoreLocalJson : IJobDataStore<Job>
    {
        public async Task AddJob(Job job)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteJob(Job job)
        {
            throw new NotImplementedException();
        }

        public async Task<Job> GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            var jobs = new List<Job>()
            {
                new Job {Id = 1, Name = "Job A Local Json File", Description = "This is job a."},
                new Job {Id = 1, Name = "Job A Local Json File", Description = "This is job b."},
                new Job {Id = 1, Name = "Job A Local Json File", Description = "This is job c."},
                new Job {Id = 1, Name = "Job A Local Json File", Description = "This is job d."}


            };
            return jobs;
        }

        public async Task UpdateJob(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
