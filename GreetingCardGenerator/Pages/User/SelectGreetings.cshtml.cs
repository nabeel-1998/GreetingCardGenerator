using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreetingCardGenerator.Helper;
using GreetingCardGenerator.Data;

namespace GreetingCardGenerator.Pages.User
{
    public class SelectGreetingsModel : PageModel
    {
        private readonly IAppData appData;

        public SelectGreetingsModel(IAppData appData)
        {
            this.appData = appData;
        }
        public List<string> Greetings { get; set; }
        public void OnGet(string gname)
        {
            GreetingGenerator GG = new GreetingGenerator(appData);
            Greetings = GG.CreateGreetingForName(gname);
        }
    }
}
