using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterClient.Models
{
    class DatabaseJobList
    {
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
