using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class JobContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
    }
}
