using EnKindle.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace EnKindle.Pages
{
    public class UpdateModel : PageModel

    {
        private DB _DB;
        private readonly ILogger _logger;
        public string Message { get; set; }

        //////knows where to map your form... tells the onpost where to map your database table to update.... changed to _Greetings
        [BindProperty]
        public Greetings _Greetings { get; set; }

        //public UpdateModel(
        //    DB dB,
        //    ILogger<UpdateModel> logger
        //    )
        //{
        //    _DB = dB;
        //    _logger = logger;
        //}

        private IConfiguration _myConfiguration { get; set; }
        public UpdateModel(DB myDB, IConfiguration myConfiguration)
        {
            _DB = myDB;
            _myConfiguration = myConfiguration;

        }

        public IActionResult OnGet(int id = 0)
        {
            if (id > 0)
            {
                _Greetings = _DB.Greetings.Find(id);
                return Page();
            }

            else
            {
                return RedirectToPage("Index");
            }

        }

        public IActionResult OnPost()
        {
            try

            {
                //UPDATE RECORD ON THE DB
                _DB.Greetings.Update(_Greetings);
                _DB.SaveChanges();

                return RedirectToPage("Preview", new { id = _Greetings.ID });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update OnPost {ex.Message}", ex);
                return Page();
            }
        }
    }
}
