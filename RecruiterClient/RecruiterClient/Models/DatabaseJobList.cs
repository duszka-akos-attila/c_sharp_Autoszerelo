using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterClient.Models
{
    class DatabaseJobList
    {
        [JsonConstructor]
        public DatabaseJobList(long id, string firstName, string lastName, string carModel, string licensePlate, string description, string state, DateTime createdAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CarModel = carModel;
            LicensePlate = licensePlate;
            Description = description;
            State = state;
            CreatedAt = createdAt;
        }

        public long Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String CarModel { get; set; }
        public String LicensePlate { get; set; }
        public String Description { get; set; }
        public String State { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
