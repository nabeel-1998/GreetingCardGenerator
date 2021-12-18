using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GreetingCardGenerator.Core
{
    public class Greetings
    {
        [Key]
        public int GREETING_ID { get; set; }
        [Required]
        public string LETTER { get; set; }
        [Required]
        public string GREETING { get; set; }
    }
}
