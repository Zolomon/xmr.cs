using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xmr.cs.Models
{
    public class Exam
    {
        [Key]
        public int ID { get; set; }
        public int CourseID { get; set; }


        public string Code { get; set; }

        
        public Course Course { get; set; }

        public virtual ICollection<Problem> Problems { get; set; }
        //public virtual ICollection<TagLink> TagLinks { get; set; }
    }
}