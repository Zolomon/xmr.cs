using System.ComponentModel.DataAnnotations;

namespace xmr.cs.Models
{
    public class TagLink
    {
        [Key]
        public int ID { get; set; }
        public int TagID { get; set; }
        //public int CourseID { get; set; }
        //public int ExamID { get; set; }
        public int ProblemID { get; set; }

        public Tag Tag { get; set; }
        //public Course Course { get; set; }
        //public Exam Exam { get; set; }
        public Problem Problem { get; set; }
    }
}