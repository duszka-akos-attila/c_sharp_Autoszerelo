using API.Dto;
using API.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service
{
    public interface IJobService
    {
        public void AddJob(JobDto jobDto);
        public List<JobListDto> GetJobs();
    }
}
