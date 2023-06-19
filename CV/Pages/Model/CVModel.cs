using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV.Pages.Model
{
    public class CVModel
    {
        [Key]
        public uint Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [Display(Name = "Date of Birth")]
        public DateTime date { get; set; }



        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string SelectedGender { get; set; }


   
        // This is for nationality ..
        [Required(ErrorMessage = "At least one nationality is required")]
        [Display(Name = "Nationality")]
        public string nationality { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Select at least one skill")]
        public List<string> SelectedSkills { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [NotMapped]
        [Display(Name = "Confirm Email")]
        [Required(ErrorMessage = "Confirm Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Compare("Email", ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }

        [BindProperty]
        public int Grade { get; set; }


        // this for uploading photo
        [NotMapped]
        [Display(Name = "Photo")]
        [DataType(DataType.Upload)]
        public IFormFile? PhotoFile { get; set; }

        // This is in database that will retrieve path from it
        public string? PhotoPath { get; set; }

        /*
        [Required(ErrorMessage = "Password is required")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 8 characters")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]+$", ErrorMessage = "Password must contain at least one letter, one digit, and one special symbol")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string Password { get; set; }
        */

    }
}
