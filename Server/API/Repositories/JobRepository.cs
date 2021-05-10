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
    }
}
