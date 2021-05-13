using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class JobDto
    {
        public JobDto(String FirstName, String LastName, String CarModel, String LicensePlate, String Description)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CarModel = CarModel;
            this.LicensePlate = LicensePlate;
            this.Description = Description;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String CarModel { get; set; }
        public String LicensePlate { get; set; }
        public String Description { get; set; }
    }
}
