using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xmr.cs.Models
{
    public class Answer
    {
        [Key, ForeignKey("Problem")]
        public int ID { get; set; }
        
        public int ProblemID { get; set; }
        public string FileName { get; set; }

        public Problem Problem { get; set; }
    }
}