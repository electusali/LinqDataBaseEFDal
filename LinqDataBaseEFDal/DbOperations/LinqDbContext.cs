using System;
using System.Collections.Generic;
using System.Text;
using LinqDataBaseEFDal.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinqDataBaseEFDal.DbOperations
{
    public class LinqDbContext :DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "LinqDatabase");
        }
    }
}
