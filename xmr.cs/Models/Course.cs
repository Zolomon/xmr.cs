using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace xmr.cs.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
        //public virtual ICollection<TagLink> TagLinks { get; set; }
    }
}