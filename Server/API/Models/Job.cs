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
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String CarModel { get; set; }
        [Required]
        [MaxLength(6)]
        public String LicensePlate { get; set; }
        [Required]
        public String Description { get; set; }
        public String State { get; set; } = "Felvett munka.";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
