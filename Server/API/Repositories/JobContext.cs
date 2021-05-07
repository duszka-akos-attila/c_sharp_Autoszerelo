using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class JobContext : DbContext
    {
        public JobContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
    }
}
