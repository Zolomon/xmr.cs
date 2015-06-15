using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace xmr.cs.Models
{
    public class Tag
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<TagLink> TagLinks { get; set; }
    }
}