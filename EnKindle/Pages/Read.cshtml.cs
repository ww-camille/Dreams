using EnKindle.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnKindle.Pages
{
    public class ReadModel : PageModel
    {
        //public string Message { get; set; }.....added the messeage in the try catch in the event the page does not load....the actual text I had attached to this is in my OnGet()

        public void OnGet()
        {
            //Message = "Your application description page. This was here just so I could see the page...can delete later";
        }
        // DEFAULT MODE ... if id is bigger than zero, connect my greetings and database...if  Bridgegreetings is equal to null/zero so if there is no Bridge send user to index page.
        public IActionResult OnGet(int id = 0)
        {
            if (id > 0)
            {
                BridgeGreetings = _myDB.Greetings.Find(id);

            }
            if (BridgeGreetings == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        // BRIDGE TO GREETINGS MODEL...connect my Greetings model to this so it can read it/use it 
        [BindProperty]
        public Greetings BridgeGreetings { get; set; }



        // HEY, CONNECT MY DATABASE TO THIS MODEL
        private DB _myDB;
        public ReadModel(DB myDB)
        {
            _myDB = myDB;
        }



        // EMAIL-RELATED
        public string Message { get; set; }
        public IActionResult OnPost()
        {


            try
            {
                // DB-RELATED: UPDATE RECORD ON THE DATABASE 
                _myDB.Greetings.Update(BridgeGreetings);
                _myDB.SaveChanges();

                return RedirectToPage("read", new { ID = BridgeGreetings.ID });
            }
            catch
            {
                Message = "Yikes, your card did not load. Please try again.";
            }


            return Page();
        }


    }
}
