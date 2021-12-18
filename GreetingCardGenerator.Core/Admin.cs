using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GreetingCardGenerator.Core
{
    public class Admin
    {
        [Key]
        public int ADMIN_ID { get; set; }
        [Required]
        public string ADMIN_NAME { get; set; }
        [Required]
        public string EMAIL { get; set; }
        [MinLength(8),NotMapped]
        public string PASSWORD { get; set; }

        [Required]
        public int PASSWORD_HASH
        {
            get;set;
        }

        public void ConvertToHashCode()
        {
            PASSWORD_HASH = PASSWORD.GetHashCode();
        }
    }
}
