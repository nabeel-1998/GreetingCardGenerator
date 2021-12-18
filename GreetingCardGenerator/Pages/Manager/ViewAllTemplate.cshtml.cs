using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreetingCardGenerator.Core;
using GreetingCardGenerator.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreetingCardGenerator.Pages.Manager
{
    public class ViewAllTemplateModel : PageModel
    {
        private readonly IAppData appData;

        public List<Template> Templates { get; set; }

        [TempData]
        public string DelMsg { get; set; }

        public ViewAllTemplateModel(IAppData appData)
        {
            this.appData = appData;
        }
        public void OnGet()
        {

            Templates = appData.ViewAllTemplates();
        }
    }
}
