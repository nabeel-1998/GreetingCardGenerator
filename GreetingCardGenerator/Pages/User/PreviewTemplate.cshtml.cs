using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreetingCardGenerator.Core;
using GreetingCardGenerator.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreetingCardGenerator.Pages.User
{
    public class PreviewTemplateModel : PageModel
    {
        private readonly IAppData appData;
        
        public string CardImage { get; set; }
        public Template SelectedTemplate { get; set; }

        public PreviewTemplateModel(IAppData appData)
        {
            this.appData = appData;
        }
        public void OnGet(int templateid)
        {
            SelectedTemplate = appData.GetTemplateById(templateid);
            //Card Generation will be done here
            CardImage = Helper.CardGenerator.CreateCard(SelectedTemplate);
        }
    }
}
