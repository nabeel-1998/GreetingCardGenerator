using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreetingCardGenerator.Core;
using GreetingCardGenerator.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreetingCardGenerator.Helper;
using Microsoft.Extensions.Configuration;

namespace GreetingCardGenerator.Pages.User
{
    public class ChooseTemplateModel : PageModel
    {
        public ChooseTemplateModel(IAppData appData)
        {
            this.appData = appData;
            
        }
        public List<Helper.BoldString> greetings = new List<BoldString>();
        private readonly IAppData appData;
        

        public List<Template> Templates { get; set; }

        public void OnGet(string greeting)
        {
            Templates = appData.ViewAllTemplates();
            foreach(var item in greeting.Split(','))
            {
                if(item!="")
                {
                    var boldLetter = item.Substring(0, 1);
                    var RemainingLetters = item.Substring(1);
                    greetings.Add(new BoldString() { BoldLetter = boldLetter.ToCharArray()[0], RemainingString = RemainingLetters });
                }
               
            }
            Helper.InMemoryInfoHolder.SelectedGreeting = greetings;
            
        }
    }
}
