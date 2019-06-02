using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;

namespace JobsForYou.Models
{
    public class ApplyJobs
    {
        public int id { get; set; }
        public string message { get; set; }
        public DateTime applyTime { get; set; }

        public int JobId { get; set; }
        public string Userid { get; set; }

        public virtual Job job { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}