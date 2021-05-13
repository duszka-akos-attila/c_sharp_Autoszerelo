using API.Controllers;
using API.Models;
using API.Service;
using API.Service.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace API.Test
{
    public class JobControllerTest
    {
        private Mock<IJobService> mock = new Mock<IJobService>();

        private static readonly JobListDto jobListDto = new JobListDto(1, "Test", "Test", "TestCar", "TestPlate", "Desc", "Felvett munka.", DateTime.Now);
        private static readonly Job job = new Job(1, "Test", "Test", "TestCar", "TestPlate", "Desc", "Felvett munka.", DateTime.Now);

        private readonly List<JobListDto> jobs = new List<JobListDto>()
        {
            jobListDto
        };

        [Fact]
        public void Get_ShouldReturnDtoList()
        {
            // Arrange
            mock.Setup(p => p.GetJobs()).Returns(jobs);
            JobController jobController = new JobController(mock.Object);

            // Act 
            var result = jobController.Get();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<JobListDto>>>(result);
            var returnValue = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<JobListDto>>(returnValue.Value);
            Assert.Equal(jobs, returnValue.Value);
        }

        [Fact]
        public void GetById_WithInvalidParameters_ShouldReturnNotFound()
        {
            // Arrange
            mock.Setup(p => p.GetJobById(25)).Throws(new JobNotFoundException("Job with id:25 doesn't exist."));
            JobController jobController = new JobController(mock.Object);

            // Act 
            var result = jobController.GetById(25);

            // Assert
            var actionResult = Assert.IsType<ActionResult<JobListDto>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public void GetById_WithValidParameters_ShouldReturnDto()
        {
            // Arrange 
            mock.Setup(p => p.GetJobById(1)).Returns(jobListDto);
            JobController jobController = new JobController(mock.Object);

            // Act
            var result = jobController.GetById(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<JobListDto>>(result);
            var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.IsType<JobListDto>(returnValue.Value);
            Assert.Equal(returnValue.Value, jobListDto);
        }
    }
}
