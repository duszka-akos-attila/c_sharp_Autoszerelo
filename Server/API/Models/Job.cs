using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Job
    {
        [Key]
        public long Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String CarModel { get; set; }
        [MaxLength(6)]
        public String LicensePlate { get; set; }
        public String Description { get; set; }
        public String State { get; set; } = "Felvett munka.";
        public DateTime CraetedAt { get; set; } = DateTime.Now;

    }
}
