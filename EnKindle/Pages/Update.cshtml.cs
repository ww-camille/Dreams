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
        // SECTION 1 -- DECLARATIONS GO HERE (TOP)
        private DB _DB;
        private readonly ILogger _logger;
        //private IConfiguration _myConfiguration { get; set; } // CA: WHY?

        public string Message { get; set; }

        // TELL ONPOST WHAT DATABASE TABLE TO UPDATE
        [BindProperty]
        public Greetings _Greetings { get; set; }

        // SECTION 2 -- CONSTRUCTORS 
        // THIS IS THE CONSTRUCTOR.  VERY IMPORTANT!  YOU CAN GO OFFSCRIPT LIKE YOU DID BELOW, BUT I CAN TELL YOU ARE JUST COPYING CODE WITHOUT UNDERSTANDING WHAT IT REALLY DOES, BECAUSE YOU'RE USING THE CONSTRUCTOR INCORRECTLY.  PLEASE LEARN THIS.
        public UpdateModel(
            //DB myDB, // CA: WHY?
            //IConfiguration myConfiguration // CA: WHY?
            DB dB,
            ILogger<UpdateModel> logger
            )
        {
            //_DB = myDB; // CA: WHY?
            //_myConfiguration = myConfiguration; // CA: WHY?
            _DB = dB;
            _logger = logger;
        }

        // BELOW IS YOUR CODE.  PLEASE LOOK ABOVE THIS LINE ON HOW THIS CODE SHOULD HAVE BEEN PLACED.  WHY DO YOU HAVE "myConfiguration"?  DO YOU KNOW WHAT THAT DOES?
        //private IConfiguration _myConfiguration { get; set; }
        //public UpdateModel(DB myDB, IConfiguration myConfiguration)
        //{
        //    _DB = myDB;
        //    _myConfiguration = myConfiguration;
        //}






        // SECTION 3 -- ONGET, BEFORE THE PAGE LOADS
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




        // SECTION 4 -- ONPOST, WHAT HAPPENS WHEN THE FORM ON THE PAGE IS SUBMITTED
        // PATTERN IS BELOW:
        // (A) GET THE RECORD FROM THE TABLE ON THE DATABASE YOU WISH TO UPDATE USING THE "[BindProperty]" DECLARED IN SECION 1 ABOVE.
        // (B) ONCE YOU FIND THE RECORD, ASSIGN IT TO A TEMPORARY VARIABLE.
        // (C) UPDATE THE TEMPORARY VARIABLE WITH THE FORM FIELDS USING THE "[BindProperty]" DECLARED IN SECION 1 ABOVE.
        // (D) USE YOUR "_DB" TO UPDATE THE DATABASE.
        // (E) USE YOUR "_DB" TO SAVE THE CHANGES SUBMITTED FROM THE FORM.        
        
        
        public async Task<IActionResult> OnPost() // LOOK BELOW, LINE 89. IF YOU USE VERSION 1, YOU MUST USE "async Task<>"
        //public IActionResult OnPost() // LOOK BELOW, LINE 92. IF YOU USE VERSION 2.
        {
            try
            {
                var tempGreetings = _DB.Greetings.Find(_Greetings.ID); // READ PATTERN ABOVE. THIS IS (A) + (B)

                if (ModelState.IsValid) {
                
                    // VERSION 1: THIS IS THE NEW VERSION AND SIMPLE                
                    await TryUpdateModelAsync(tempGreetings, "_Greetings"); // READ PATTERN ABOVE. THIS IS (C)

                    // VERSION 2: THIS IS THE OLD STYLE, MAPPING EACH FIELD (TEDIOUS).  SAMPLE BELOW IS JUST ONE FIELD
                    //if (tempGreetings.name != _Greetings.name) {
                    //    tempGreetings.name = _Greetings.name;
                    //}

                    _DB.Greetings.Update(_Greetings); // READ PATTERN ABOVE. THIS IS (D)
                    _DB.SaveChanges(); // READ PATTERN ABOVE. THIS IS (E)

                    return RedirectToPage("Preview", new { id = _Greetings.ID });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update OnPost {ex.Message}", ex);
                return Page();
            }
        }
    }
}
