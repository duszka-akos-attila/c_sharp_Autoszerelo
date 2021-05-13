using API.Models;
using API.Service;
using API.Service.Dto;
using Moq;
using System;
using Xunit;

namespace API.Test
{
    public class JobControllerTest
    {
        private Mock<IJobService> mock = new Mock<IJobService>();

        private readonly JobListDto jobListDto = new JobListDto(1,"Test", "Test","TestCar", "TestPlate", "Desc", "Felvett munka.", DateTime.Now);
        private readonly Job job = new Job("Test", "Test", "TestCar", "TestPlate", "Desc");

        [Fact]
        public void Get_ShouldReturnDtoList()
        {

        }
    }
}
