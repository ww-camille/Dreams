// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnKindle.Model
{

    public class Greetings
    {
        //HEY, ADD A UNIQUE IDENTIFIER
        [Key]
        public int? ID { get; set; }


        [DisplayName("To: *Name (First & Last")]
        [Display(Prompt = "SuperHeros Name* (First & Last)")]
        [Required(ErrorMessage = "Required!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter between 3 to 100 characters")]
        public string Recipientname { get; set; }


        [DisplayName("To: *Email")]
        [Display(Prompt = "SuperHeros Email")]
        [Required(ErrorMessage = "Required!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter a valid email")]
        public string Recipientemail { get; set; }

        [DisplayName("*Your Name")]
        [Display(Prompt = "Your Name: SupremeBeing")]
        [Required(ErrorMessage = "Required!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter between 3 to 100 characters")]
        public string Sendersname { get; set; }

        [DisplayName("*Your Email")]
        [Display(Prompt = "Your Email: SupremeBeing@domain.com")]
        [Required(ErrorMessage = "Required!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter a valid email")]
        public string Sendersemail { get; set; }

        [DisplayName("*Subject")]
        [Display(Prompt = "Subject: Inspiring Others")]
        [Required(ErrorMessage = "Required!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string Subject { get; set; }

        [DisplayName("*Message")]
        [Display(Prompt = "Message: Always reach for the Stars!")]
        [Required(ErrorMessage = "Required!")]
        [StringLength(750, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 750 characters")]
        public string Mesgfromuser { get; set; }




        public string CreateDate { get; set; }



        public string CreateIP { get; set; }



        public string SendDate { get; set; }
        public string SendIP { get; set; }

        public string ReCaptcha { get; set; }
    }




}
