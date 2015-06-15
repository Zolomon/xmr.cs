using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace xmr.cs.Models
{
    public class Problem
    {
        [Key]
        public int ID { get; set; }

        public int Index { get; set; }
        //public int CourseID { get; set; }
        public int ExamID { get; set; }

        //public Course Course { get; set; }
        public Exam Exam { get; set; }

        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }

        public virtual ICollection<TagLink> TagLinks { get; set; }
        
    }
}