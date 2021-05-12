using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Dto
{
    public class JobListDto
    {   
        public JobListDto()
        {

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
