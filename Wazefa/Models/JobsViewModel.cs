using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsForYou.Models
{
    public class JobsViewModel
    {
        public string jobTitle { get; set; }
        public IEnumerable<ApplyJobs> items { get; set; }

    }
}