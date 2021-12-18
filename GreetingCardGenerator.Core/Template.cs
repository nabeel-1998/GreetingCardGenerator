using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GreetingCardGenerator.Core
{
    public class Template
    {
        [Key]
        public int TEMPLATE_ID { get; set; }
        [Required]
        public string IMAGE { get; set; }

        [Required]
        public OCCASSION OCCASSION { get; set; }

    }
}
