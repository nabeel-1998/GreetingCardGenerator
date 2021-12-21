using GreetingCardGenerator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCardGenerator.Helper
{
    public class InMemoryInfoHolder
    {
        public static List<BoldString> SelectedGreeting { get; set; }
        public static int UserId { get; set; }
        public static int SelectedTemplateId { get; set; }

        public static OCCASSION Occassion = OCCASSION.BIRTHDAY;

    }
}
