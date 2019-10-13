using EnKindle.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EnKindle.Pages
{
    public class PreviewModel : PageModel

    {

        // TEST MESSAGE
        //public string Message { get; set; }

        //public void OnGet()
        //{
        //    Message = "Review your Message! show the information that the user typed in it's final state. Info from Preview cs is showing! This is where I'm going to add the useres message here.";
        //}

        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        // DEFAULT MODE
        //public IActionResult OnGet(int id = 0)
        //{
        //    if (id > 0)
        //    {
        //        BridgeGreetings = _myDB.Greetings.Find(id);

        //    }

        //}

        // HEY, CONNECT MY DATABASE TO THIS MODEL
        private DB _DB;


        private readonly ILogger _logger;

        public IActionResult OnGet(int id = 0)
        {
            if (id > 0)
            {
                _Greetings = _DB.Greetings.Find(id);

            }
            if (_Greetings == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }




        // BRIDGE TO GREETINGS MODEL... connect Greetings Model so it can use it
        [BindProperty]
        public Greetings _Greetings { get; set; }

        public PreviewModel(
           DB dB,
           ILogger<UpdateModel> logger
           )
        {
            _DB = dB;
            _logger = logger;
        }


        private IConfiguration _myConfiguration { get; set; }

        
        //public PreviewModel(DB myDB, IConfiguration myConfiguration)
        //{
        //    _DB = DB;
        //    _myConfiguration = myConfiguration;

        //}

     
        // EMAIL-RELATED
        public string Message { get; set; }
        public IActionResult OnPost()
        {
            try
            {
                // DB-RELATED: UPDATE RECORD ON THE DATABASE 
                _DB.Greetings.Update(_Greetings);
                _DB.SaveChanges();

                return RedirectToPage("Update", new { id = _Greetings.ID });
            }
            catch
            {
                Message = "Yikes, your greeting can't be sent. Please check your spelling and try again.";
            }
            return Page();
        }
    }
}
