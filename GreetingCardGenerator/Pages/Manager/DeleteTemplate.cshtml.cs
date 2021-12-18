using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreetingCardGenerator.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreetingCardGenerator.Pages.Manager
{
    public class DeleteTemplateModel : PageModel
    {
        private readonly IAppData appData;

        public DeleteTemplateModel(IAppData appData)
        {
            this.appData = appData;
        }
        public IActionResult OnGet(int templateId)
        {
            appData.DeleteATemplate(templateId);
            TempData["DelMsg"] = "Template has been deleted";
            return RedirectToPage("./ViewAllTemplate");
        }
    }
}
