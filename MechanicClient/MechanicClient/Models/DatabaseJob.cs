using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicClient.Models
{
    public class DatabaseJob
    {
        [JsonConstructor]
        public DatabaseJob(int id, string firstName, string lastName, string carModel, string licensePlate, DateTime createdAt, string state, string description)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CarModel = carModel;
            LicensePlate = licensePlate;
            CreatedAt = createdAt;
            State = state;
            Description = description;
        }

        public DatabaseJob()
        {

        }

        public DatabaseJob(Job job)
        {
            this.Id = job.Id;
            this.CarModel = job.CarModel;
            this.LicensePlate = job.LicensePlate;
            this.Description = job.Description;
            this.CreatedAt = job.RegistrationDate;
            this.State = job.Status;
            this.FirstName = job.ClientName.Split(' ')[0];
            this.LastName = job.ClientName.Split(' ')[1];
        }


        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CarModel { get; set; }

        public string LicensePlate { get; set; }

        public DateTime CreatedAt { get; set; }

        public string State { get; set; }

        public string Description { get; set; }
    }
}
