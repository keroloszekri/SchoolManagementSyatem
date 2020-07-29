using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Computony.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=ITI")
        {

        }

        public DbSet<Cat> Cat { get; set; }
        public DbSet<SubCat> SubCat { get; set; }
        public DbSet<Student> Products { get; set; }


    }
}