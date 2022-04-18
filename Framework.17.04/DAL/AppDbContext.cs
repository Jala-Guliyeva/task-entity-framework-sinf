using Framework._17._04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework._17._04.DAL
{
    internal class AppDbContext: DbContext

    {
       
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=EntityTask;Trusted_Connection=True;");
        }
    }
}
