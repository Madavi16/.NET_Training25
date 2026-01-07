using System;
using System.Data.Entity;
using System.Linq;

namespace Code_frist_Demo
{
    public class Model1 : DbContext
    {
       
        public Model1()
            : base("name=Model1")
        {
            Configuration.LazyLoadingEnabled = true;
        }


        public virtual DbSet<IPL> IPLs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<EmployeeEf> employees { get; set; }


       
    }

  
}