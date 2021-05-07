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
                var jobs = database.Jobs.ToList();

                return jobs;
            }
        }
    }
}
