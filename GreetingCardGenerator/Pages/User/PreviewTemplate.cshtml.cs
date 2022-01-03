using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreetingCardGenerator.Core;
using GreetingCardGenerator.Data;
using GreetingCardGenerator.Helper;
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
        public IActionResult OnGet(int templateid)
        {
            
            if(templateid==0)
            {
                SelectedTemplate = appData.GetTemplateById(InMemoryInfoHolder.SelectedTemplateId);
                //Card Generation will be done here
                CardImage = CardGenerator.CreateCard(SelectedTemplate, InMemoryInfoHolder.x, InMemoryInfoHolder.y);
                InMemoryInfoHolder.CardImage = CardImage;
            }
            else
            {
                InMemoryInfoHolder.SelectedTemplateId = templateid;
                SelectedTemplate = appData.GetTemplateById(templateid);
                //Card Generation will be done here
                CardImage = CardGenerator.CreateCard(SelectedTemplate, InMemoryInfoHolder.x, InMemoryInfoHolder.y);
                InMemoryInfoHolder.CardImage = CardImage;
            }

            return Page();
        }

       public void OnPostXp()
        {
            InMemoryInfoHolder.x += 10;
            OnGet(0);
          
        }

        public void OnPostXm()
        {
            InMemoryInfoHolder.x -= 10;
            OnGet(0);
        }
        public void OnPostYp()
        {
            InMemoryInfoHolder.y += 10;
            OnGet(0);
            
        }

        

        public void OnPostYm()
        {
            InMemoryInfoHolder.y -= 10;
            OnGet(0);
        }

        

        public IActionResult OnPostPay()
        {
            return RedirectToPage("./DoPayment");
        }
    }
}
