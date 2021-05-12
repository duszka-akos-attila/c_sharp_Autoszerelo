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

        public List<JobListDto> GetJobs()
        {
            List<Job> jobs = JobRepository.GetAll().ToList();

            List<JobListDto> jobListDtos = jobs.ConvertAll(jobs => ConvertModelToDto(jobs));

            return jobListDtos;
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
