using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GreetingCardGenerator.Core
{
    public class Greeting_Draft
    {
        [Key]
        public int G_DRAFT_ID { get; set; }
        [Required]
        public string GREETING_TEXT { get; set; }
        [Required]
        public string NAME_INITS { get; set; }
        [Required]
        public DateTime D_DATE { get; set; }

        [ForeignKey("Member"),Required]
        public int CUSTOMER_ID { get; set; }
        public virtual Member Member { get; set; }

        //[ForeignKey("Patient")]
        //public int ParentID { get; set; }
        //public virtual Patient Patient { get; set; }
    }
}
