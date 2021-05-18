using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterClient.Models
{
    public class Job
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public string CarModel { get; set; }

        public string LicensePlate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public Job(DatabaseJobList databaseJob)
        {
            this.Id = (int)databaseJob.Id;
            this.CarModel = databaseJob.CarModel;
            this.LicensePlate = databaseJob.LicensePlate;
            this.Description = databaseJob.Description;
            this.RegistrationDate = databaseJob.CreatedAt;
            this.Status = databaseJob.State;
            this.ClientName = databaseJob.FirstName + " " + databaseJob.LastName;
        }

        public Job(int id, string clientName, string carModel, string licensePlate, DateTime registrationDate, string status, string description)
        {
            Id = id;
            ClientName = clientName;
            CarModel = carModel;
            LicensePlate = licensePlate;
            RegistrationDate = registrationDate;
            Status = status;
            Description = description;
        }

        public Job()
        {

        }
    }
}
