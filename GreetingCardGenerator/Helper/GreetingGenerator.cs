﻿using GreetingCardGenerator.Core;
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
                    Random r = new Random();
                    var RandomIndex = r.Next(0, list.Count());
                    var text = list[RandomIndex];
                    greeting += text + " ";
                    final.Add(greeting);
                }
            }

            return final;
           
        }
    }

    
}