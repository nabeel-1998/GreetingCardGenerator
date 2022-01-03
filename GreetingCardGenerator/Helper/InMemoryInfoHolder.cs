using GreetingCardGenerator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCardGenerator.Helper
{
    public class InMemoryInfoHolder
    {
        public static int AdminID { get; set; }
        public static List<BoldString> SelectedGreeting { get; set; }
        public static int UserId { get; set; }
        public static int SelectedTemplateId { get; set; }
        public static float x { get; set; } = 500;
        public static float y { get; set; } = 350;
 
        public static string CardImage { get; internal set; }

        public static OCCASSION Occassion = OCCASSION.BIRTHDAY;

    }
}
