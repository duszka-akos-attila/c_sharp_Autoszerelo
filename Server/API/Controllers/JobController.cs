using API.Dto;
using API.Models;
using API.Repositories;
using API.Service;
using API.Service.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("/api/job")]
    [ApiController]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobListDto>> Get()
        {
            var jobs = _jobService.GetJobs();
            return Ok(jobs);
        }

        [HttpPost]
        public ActionResult Post(JobDto jobDto)
        {
            _jobService.AddJob(jobDto);

            return Ok();
        }

        
        [HttpPut("state/{id}")]
        public ActionResult Update(long id, String state)
        {
            try
            {
                _jobService.UpdateJobState(id, state);

                return Ok();
            } catch (JobNotFoundException e)
            {

                return NotFound(e.Message);
            }
           
        }
        

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            try
            {
                JobListDto job = _jobService.GetJobById(id);

                return Ok(job);
            }
            catch (JobNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        
        [HttpPut("{id}")]
        public ActionResult Update(long id, JobDto jobDto)
        {
            try
            {
                _jobService.UpdateJob(id, jobDto);

                return Ok();
            }
            catch (JobNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
        
    }
}
