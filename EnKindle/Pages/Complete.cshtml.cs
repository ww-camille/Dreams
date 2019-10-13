using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnKindle.Pages
{
    public class CompleteModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
        }
    }
}
