using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace JobsForYou.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

      
        [Display(Name="Job Name")]
        public string JobTitle { get; set; }

       
        [Display(Name = "Company")]
        public string Company { get; set; }

       
        [Display(Name = "Job Required")]
        public string JobRequired { get; set; }

       
        [Display(Name = "Career Level")]
        public string CareerLevel { get; set; }

       
        [Display(Name = "Job Type")]
        public string JobType { get; set; }

        
        [Display(Name = "Job Desc")]
        public string JobDesc { get; set; }

        
        [Display(Name = "Salary")]
        public string JobSalary { get; set; }

        
        [Display(Name = "Vacancies")]
        public string Vacancies { get; set; }

        
        [Display(Name = "Timing")]
        public string TimeAdd { set; get; }

       
        [Display(Name = "About The Job")]
        public string AboutJob { get; set; }

        
        [Display(Name = "Experience Needed")]
        public string Experience { get; set; }
       
        [Display(Name = "Job Image")]
        public string JobImage { get; set; }

        //public string UserId { get; set; }

        [Display(Name="Category Name")]
        public int CatNo { get; set; }


        public virtual string userid { get; set; }
        public virtual Category Cats { get; set; }
        public virtual ApplicationUser user { get; set; }

      
    }
}