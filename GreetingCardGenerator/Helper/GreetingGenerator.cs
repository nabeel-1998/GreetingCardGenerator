using GreetingCardGenerator.Core;
using GreetingCardGenerator.Data;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public List<BoldString>[] CreateGreetingForName(string Name)
        {
            List<BoldString>[] GreetingsArray = new List<BoldString>[6];
            for(int i=0; i<GreetingsArray.Length; i++)
            {
                
                var Sequence = Name.ToCharArray();

                List<BoldString> SingleGreeting = new List<BoldString>();
                List<UsedIndex> UsedIndex = new List<UsedIndex>();
                for (int j = 0; j < Sequence.Length; j++)
                {
                    var list = appData.GetGreetingByLetter(Sequence[j]);
                    if(list.Count()!=0)
                    {
                        
                        if (list.Count() > 1)
                        {
                        FindNext:
                            int RandomIndex = Randomizor.GetSomeRandomNumber(0, list.Count() - 1);
                            var CIndex = new UsedIndex
                            {
                                Index = RandomIndex,
                                Character = Sequence[j]
                            };
                            if (UsedIndex.Where(x=>x.Index==CIndex.Index && x.Character==CIndex.Character).FirstOrDefault()!=null)
                            {
                                goto FindNext;
                            }
                            UsedIndex.Add(CIndex);
                            var text = list[RandomIndex];
                            var Boldstring = new BoldString()
                            {
                                BoldLetter = text.ToCharArray()[0],
                                RemainingString = text.Substring(1)
                            };
                            SingleGreeting.Add(Boldstring);
                        }
                        else
                        {
                            var RandomIndex = 0;
                            var text = list[RandomIndex];
                            var Boldstring = new BoldString()
                            {
                                BoldLetter = text.ToCharArray()[0],
                                RemainingString = text.Substring(1)
                            };
                            SingleGreeting.Add(Boldstring);
                        }
                    }
                   
                    
                    
                }
                GreetingsArray[i] = SingleGreeting;
            }

            return GreetingsArray;
           
        }
    }

    

    public class BoldString
    {
        public char BoldLetter { get; set; }
        public string RemainingString { get; set; }
        public char splitchar = ',';
    }

    class UsedIndex 
    {
        public int Index { get; set; }
        public char Character { get; set; }

      
    }
    
}
