using JobsForYou.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace test.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }
        public string Country { get; set; }
        public string phone { get; set; }
        public string UserImage { get; set; }

        public virtual ICollection<Job>  Jobs { get; set; }
        public DateTime? BirthDate { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<JobsForYou.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<JobsForYou.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<JobsForYou.Models.RolsViewModel> RolsViewModels { get; set; }

        public System.Data.Entity.DbSet<JobsForYou.Models.ApplyJobs> ApplyJobs { get; set; }

        //public System.Data.Entity.DbSet<test.Models.EditViewModel> EditViewModels { get; set; }

      

       
    }
}