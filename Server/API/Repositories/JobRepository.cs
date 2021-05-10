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
        public static IList<Job> GetJobs()
        {
            using (var database = new JobContext())
            {
                var jobs = database.Jobs.OrderByDescending(job => job.CreatedAt).ToList();

                return jobs;
            }
        }

        public static void AddJob(JobDto jobDto)
        {
            using (var database = new JobContext())
            {
                Job job = new Job(jobDto.FirstName, jobDto.LastName, jobDto.CarModel, jobDto.LicensePlate, jobDto.Description);

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

        public static void UpdateJob(long id, JobDto job)
        {
            using (var database = new JobContext())
            {
                var jobToUpdate = database.Jobs.FirstOrDefault(job => job.Id == id);

                if (job == null)
                {
                    throw new JobNotFoundException($"Job with id:{id} not found.");
                }

                jobToUpdate.LastName = job.LastName;
                jobToUpdate.FirstName = job.FirstName;
                jobToUpdate.CarModel = job.CarModel;
                jobToUpdate.LicensePlate = job.LicensePlate;
                jobToUpdate.Description = job.Description;

                database.Jobs.Update(jobToUpdate);
                database.SaveChanges();
            }
        }
    }
}
