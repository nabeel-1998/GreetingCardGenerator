using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GreetingCardGenerator.Data;
using System.Collections.Generic;
using GreetingCardGenerator.Core;
using System.IO;
using System.Threading.Tasks;
using GreetingCardGenerator.Helper;

namespace GreetingCardGenerator.Pages.Manager
{
    public class UploadTemplateModel : PageModel
    {
        private readonly IHtmlHelper htmlHelper;
        private readonly IAppData appData;


        public IEnumerable<SelectListItem> Occassions { get; set; }

        [BindProperty]
        public IFormFile TemplateImage { get; set; }
        [BindProperty]
        public Template Template { get; set; }

        public UploadTemplateModel(IHtmlHelper htmlHelper, IAppData appData)
        {
            this.htmlHelper = htmlHelper;
            this.appData = appData;
        }
        public void OnGet()
        {
            Occassions = htmlHelper.GetEnumSelectList<OCCASSION>();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Template.IMAGE = await ImageHelper.ConvertIFormFIleToString(TemplateImage);
            appData.AddNewTemplate(Template);
            return RedirectToPage("./ViewAllTemplate");
        }

       
    }
}
