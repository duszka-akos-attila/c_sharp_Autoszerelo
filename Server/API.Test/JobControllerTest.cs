using API.Controllers;
using API.Dto;
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
        private static readonly JobDto jobDto = new JobDto("Test", "Test", "TestCar", "TestPlate", "Test");       

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
            var expected = "Job with id:25 doesn't exist.";

            // Act 
            var result = jobController.GetById(25);

            // Assert
            var actionResult = Assert.IsType<ActionResult<JobListDto>>(result);
            var value = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            Assert.Equal(value.Value, expected);
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

        [Fact]
        public void Update_WithValidParameters_ShouldReturnOkResult()
        {
            // Arrange
            JobController jobController = new JobController(mock.Object);

            // Act 
            var result = jobController.Update(1, jobDto);

            // Assert 
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Update_WithInValidId_ShouldReturnNotFoundObjectResult()
        {
            // Arrange 
            mock.Setup(p => p.UpdateJob(25,jobDto)).Throws(new JobNotFoundException("Job with id:25 doesn't exist."));
            JobController jobController = new JobController(mock.Object);
            var expected = "Job with id:25 doesn't exist.";


            // Act 
            var result = jobController.Update(25, jobDto);

            // Assert
            var actionResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(actionResult.Value, expected);

        }

        [Fact]
        public void UpdateState_WithInvalidId_SholudReturnNotFoundObjectResult()
        {
            // Arrange 
            mock.Setup(p => p.UpdateJobState(25, "Befejezett")).Throws(new JobNotFoundException("Job with id:25 doesn't exist."));
            JobController jobController = new JobController(mock.Object);
            var expected = "Job with id:25 doesn't exist.";

            // Act 
            var result = jobController.UpdateState(25, "Befejezett");

            // Assert
            var actionResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(actionResult.Value, expected);
        }

        [Fact]
        public void UpdateState_WithValidId_ShouldReturnOkResult()
        {
            // Arrange 
            JobController jobController = new JobController(mock.Object);

            // Act 
            var result = jobController.UpdateState(1, "Befejezett");

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Post_WithValidParametersSholud_ReturnOkResult()
        {
            // Arrange
            JobController jobController = new JobController(mock.Object);

            // Act
            var result = jobController.Post(jobDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
