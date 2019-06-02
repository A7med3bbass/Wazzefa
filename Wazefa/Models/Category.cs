using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobsForYou.Models
{
    public class Category
    {
        [Key]
        public int CatNo { get; set; }
        [Required]
        [Display(Name="Category Name")]
        public string CatName { get; set; }
       
        [Display(Name="Category Desc")]
        public string CatDesc { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}