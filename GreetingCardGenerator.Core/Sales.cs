using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace GreetingCardGenerator.Core
{
    public class Sales
    {
        [Key]
        public int SALES_ID { get; set; }

        [ForeignKey("Member")]
        public int CUSTOMER_ID { get; set; }
        public virtual Member Member { get; set; }

        [ForeignKey("Template")]
        public int TEMPLATE_ID { get; set; }
        public virtual Template Template { get; set; }

        [Required]
        public string NAME_INITS { get; set; }
        [Required]
        public string GREETING_TEXT { get; set; }
        [Required]
        public string CARD_IMAGE { get; set; }
        [Required]
        public  int AMOUNT { get; set; }
        [Required]
        public DateTime T_DATE { get; set; }






    }
}
