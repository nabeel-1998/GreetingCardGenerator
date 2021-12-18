using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GreetingCardGenerator.Core
{
    public class Member
    {
        [Key]
        public int USER_ID { get; set; }
        [Required, MaxLength(15),MinLength(2)]
        public string USER_NAME { get; set; }
        [Required,EmailAddress]
        public string EMAIL { get; set; }

        [MinLength(8), NotMapped]
        public string PASSWORD { get; set; }

        [Required]
        public int PASSWORD_HASH
        {
            get; set;
        }

        public void ConvertToHashCode()
        {
            PASSWORD_HASH = PASSWORD.GetHashCode();
        }
    }
}
