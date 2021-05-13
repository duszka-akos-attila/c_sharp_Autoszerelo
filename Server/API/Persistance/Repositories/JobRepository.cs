using API.Dto;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class JobRepository
    {
        public static IList<Job> GetAll()
        {
            using (var database = new JobContext())
            {
                var jobs = database.Jobs.OrderByDescending(job => job.CreatedAt).ToList();

                return jobs;
            }
        }

        public static void Create(Job job)
        {
            using (var database = new JobContext())
            {
                database.Jobs.Add(job);
                database.SaveChanges();
            }
        }

        public static Job GetById(long id)
        {
            using (var database = new JobContext())
            {
                var job = database.Jobs.FirstOrDefault(job => job.Id == id);

                return job;
            }
        }

        public static void Update(Job job)
        {
            using (var database = new JobContext())
            {
                database.Jobs.Update(job);
                database.SaveChanges();
            }
        }
    }
}
