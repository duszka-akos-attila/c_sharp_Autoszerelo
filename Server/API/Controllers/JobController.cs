using API.Dto;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("/api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            var jobs = JobRepository.GetJobs();
            return Ok(jobs);
        }

        [HttpPost]
        public ActionResult Post(Job job)
        {
            JobRepository.AddJob(job);

            return Ok();
        }

        [HttpPut("state/{id}")]
        public ActionResult Update(long id, String state)
        {
            try
            {
                JobRepository.UpdateJobState(id, state);

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
                Job job = JobRepository.GetJob(id);

                return Ok(job);
            }
            catch (JobNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPut("{id}")]
        public ActionResult Update(long id, JobUpdateDto jobUpdateDto)
        {
            try
            {
                JobRepository.UpdateJob(id, jobUpdateDto);

                return Ok();
            }
            catch (JobNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

    }
}
