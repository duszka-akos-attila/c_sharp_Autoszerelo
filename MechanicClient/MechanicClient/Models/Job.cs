using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicClient.Models
{
    public class Job : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public string CarModel { get; set; }

        public string LicensePlate { get; set; }

        public DateTime RegistrationDate { get; set; } 

        public string Status { get; set; }

        public string Description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public Job(DatabaseJob databaseJob)
        {
            this.Id = databaseJob.Id;
            this.CarModel = databaseJob.CarModel;
            this.LicensePlate = databaseJob.LicensePlate;
            this.Description = databaseJob.Description;
            this.RegistrationDate = databaseJob.CreatedAt;
            this.Status = databaseJob.State;
            this.ClientName = databaseJob.FirstName + " " + databaseJob.LastName;
        }

        public void PropertyHasChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Status"));
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id &&
                   ClientName == job.ClientName &&
                   CarModel == job.CarModel &&
                   LicensePlate == job.LicensePlate &&
                   RegistrationDate == job.RegistrationDate &&
                   Status == job.Status &&
                   Description == job.Description;
        }
    }
}
