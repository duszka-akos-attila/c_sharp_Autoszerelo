using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterClient.Models
{
    class DatabaseJob
    {
        [JsonConstructor]
        public DatabaseJob(string firstName, string lastName, string carModel, string licensePlate, string description)
        {
            FirstName = firstName;
            LastName = lastName;
            CarModel = carModel;
            LicensePlate = licensePlate;
            Description = description;
        }

        public DatabaseJob(Job job)
        {
            this.FirstName = job.ClientName.Split(' ')[0];
            this.LastName = job.ClientName.Split(' ')[1];
            this.CarModel = job.CarModel;
            this.LicensePlate = job.LicensePlate;
            this.Description = job.Description;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String CarModel { get; set; }
        public String LicensePlate { get; set; }
        public String Description { get; set; }

    }
}
