using API.Dto;
using API.Models;
using API.Repositories;
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
    }
}
