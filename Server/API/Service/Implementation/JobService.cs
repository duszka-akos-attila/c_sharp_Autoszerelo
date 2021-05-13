using API.Dto;
using API.Models;
using API.Repositories;
using API.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Implementation
{
    public class JobService : IJobService
    {
        public void AddJob(JobDto jobDto)
        {
            Job job = new Job(jobDto.FirstName, jobDto.LastName, jobDto.CarModel, jobDto.LicensePlate, jobDto.Description);

            JobRepository.Create(job);
        }

        public JobListDto GetJobById(long id)
        {
            Job job = JobRepository.GetById(id);

            if (job == null)
            {
                throw new JobNotFoundException($"Job with id:{id} doesn't exist.");
            }

            return ConvertModelToDto(job);

        }

        public List<JobListDto> GetJobs()
        {
            List<Job> jobs = JobRepository.GetAll().ToList();

            List<JobListDto> jobListDtos = jobs.ConvertAll(jobs => ConvertModelToDto(jobs));

            return jobListDtos;
        }

        public void UpdateJob(long id, JobDto jobDto)
        {
            Job job = JobRepository.GetById(id);

            if (job == null)
            {
                throw new JobNotFoundException($"Job with id:{id} doesn't exist.");
            }

            job.FirstName = jobDto.FirstName;
            job.LastName = jobDto.LastName;
            job.CarModel = jobDto.CarModel;
            job.LicensePlate = jobDto.LicensePlate;
            job.Description = jobDto.Description;

            JobRepository.Update(job);

        }

        public void UpdateJobState(long id, string state)
        {
            Job job = JobRepository.GetById(id);

            if (job == null)
            {
                throw new JobNotFoundException($"Job with id:{id} doesn't exist.");
            }

            job.State = state;
            JobRepository.Update(job);
        }

        private JobListDto ConvertModelToDto(Job job)
        {
            JobListDto jobListDto = new JobListDto();
            jobListDto.Id = job.Id;
            jobListDto.FirstName = job.FirstName;
            jobListDto.LastName = job.LastName;
            jobListDto.CarModel = job.CarModel;
            jobListDto.LicensePlate = job.LicensePlate;
            jobListDto.Description = job.Description;
            jobListDto.State = job.State;
            jobListDto.CreatedAt = job.CreatedAt;

            return jobListDto;
        }     

    }
}
