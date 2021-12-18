using GreetingCardGenerator.Core;
using GreetingCardGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCardGenerator.Helper
{
    public class GreetingGenerator
    {
        private readonly IAppData appData;

        public GreetingGenerator(IAppData appData)
        {
            this.appData = appData;
        }
        public List<string> CreateGreetingForName(string Name)
        {
            List<string> final = new List<string>();
            for(int i=0; i<6; i++)
            {
                string greeting = "";
                var Sequence = Name.ToCharArray();
                for (int j = 0; j < Sequence.Length; j++)
                {
                    var list = appData.GetGreetingByLetter(Sequence[j]);
                    if(list.Count()!=0)
                    {
                        Random r = new Random();
                        if (list.Count() > 1)
                        {
                            var RandomIndex = r.Next(0, list.Count() - 1);
                            var text = list[RandomIndex];
                            greeting += text + " ";
                        }
                        else
                        {
                            var RandomIndex = 0;
                            var text = list[RandomIndex];
                            greeting += text + " ";
                        }
                    }
                   
                    
                    
                }
                final.Add(greeting);
            }

            return final;
           
        }
    }

    
}
