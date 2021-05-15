using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicClient.Models
{
    class Job
    {
        private int Id { get; set; }

        private string ClientName { get; set; }

        private string CarModel { get; set; }

        private string LicensePlate { get; set; }

        private DateTime RegistrationDate { get; set; } 

        private int Status { get; set; }

        private string Description { get; set; }

        public Job(int id, string clientName, string carModel, string licensePlate, DateTime registrationDate, int status, string description)
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
