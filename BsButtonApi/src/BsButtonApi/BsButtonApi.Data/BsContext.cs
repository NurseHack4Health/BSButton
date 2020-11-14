using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BsButtonApi.Data.Models;

namespace BsButtonApi.Data
{
    public class BsContext : DbContext
    {
        public DbSet<BsSource> Sources { get; set; }


        public DbSet<BsUnconfirmedReport> UnconfirmedReports { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=;Integrated Security=True");
        }

    }



    
}