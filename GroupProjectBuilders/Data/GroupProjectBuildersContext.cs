#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupProjectBuilders.Models;

    public class GroupProjectBuildersContext : DbContext
    {
        public GroupProjectBuildersContext (DbContextOptions<GroupProjectBuildersContext> options)
            : base(options)
        {
        }

        public DbSet<GroupProjectBuilders.Models.Journal> Journal { get; set; }
    }
