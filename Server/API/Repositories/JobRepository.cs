using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class JobRepository
    {
        public static IList<Job> GetJobs()
        {
            using (var database = new JobContext())
            {
                var jobs = database.Jobs.OrderByDescending(job => job.CreatedAt).ToList();

                return jobs;
            }
        }

        public static void AddJob(Job job)
        {
            using (var database = new JobContext())
            {
                database.Jobs.Add(job);

                database.SaveChanges();
            }
        }

        public static void UpdateJobState(long id, String state)
        {
            using (var database = new JobContext())
            {
                var job = database.Jobs.FirstOrDefault(job => job.Id == id);

                if (job == null)
                {
                    throw new JobNotFoundException($"Job with id:{id} not found.");
                }
                job.State = state;
                database.Jobs.Update(job);
                database.SaveChanges();
            }
        }

        public static Job GetJob(long id)
        {
            using (var database = new JobContext())
            {
                var job = database.Jobs.FirstOrDefault(job => job.Id == id);

                if (job == null)
                {
                    throw new JobNotFoundException($"Job with id:{id} not found.");
                }

                return job;
            }
        }
    }
}
