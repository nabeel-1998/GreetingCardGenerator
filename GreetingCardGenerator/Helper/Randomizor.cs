using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCardGenerator.Helper
{
    public class Randomizor
    {
        private static Random random = new Random();

        public static int GetSomeRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
