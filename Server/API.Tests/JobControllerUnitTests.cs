using API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace API.Tests
{
    [TestClass]
    public class JobControllerUnitTests
    {
        private static Job job1 = new Job("John", "Test", "TestCar1", "aaa111", "test1");
        private static Job job2 = new Job("Jack", "Test", "TestCar2", "bbb222", "test2");
        private static List<Job> jobs = new List<Job>()
        {
            job1, job2
        };

        [TestMethod]
        public void Post_WithValidArguments_ShouldSaveJob()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
