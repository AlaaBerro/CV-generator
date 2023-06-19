using CV.Pages.Data;
using CV.Pages.Model;
using CV.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text;

namespace CV.Pages.CVO
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CVModel Input { get; set; }

        private readonly CVDbContext _db;

        private readonly ComputeGradeService _service;


        public IEnumerable<SelectListItem> items { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem{Value="Lebanon" , Text="Lebanon"},
                new SelectListItem{Value="Spain" , Text="Spain"},
                new SelectListItem{Value="Syria" , Text="Syria"},
                new SelectListItem{Value="Italy" , Text="Italy"},
                new SelectListItem{Value="USA" , Text="USA"},
            };

        public List<string> Skills { get; set; } = 
         new List<string>
        {
            "Java",
            "Python",
            "C#",
            "C++",
            "C"
        };


        public CreateModel(CVDbContext db , ComputeGradeService service)
        {
            _db = db;
            _service = service;
        }

        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check if PhotoFile is not null and the file is an image
            if (Input.PhotoFile != null && IsImageFile(Input.PhotoFile))
            {
                // Process the uploaded file 
                // Example: Save the file to wwwroot/images folder
                var fileName = Guid.NewGuid().ToString() + "_" + Input.PhotoFile.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Input.PhotoFile.CopyTo(stream);
                }

                // Update the photo path property
                Input.PhotoPath = "/images/" + fileName;

                // Access the selected skills from the Input model
                List<string> selectedSkills = Input.SelectedSkills ?? new List<string>();

                // Call the CalculateGradeService method and pass the selectedSkills list
                int result = _service.CalculateGrade(selectedSkills, Input.SelectedGender);

                Input.Grade = result;

                // saving to database :
                await _db.cv.AddAsync(Input);
                await _db.SaveChangesAsync();

                return RedirectToPage("/CVO/Summary", new { id = Input.Id });
            }

            // Add error to the div if the image is ivalid
            if(Input.PhotoFile != null && !IsImageFile(Input.PhotoFile))
            {
                ModelState.AddModelError(string.Empty, "Invalid file format. Only image files (PNG, JPG) are allowed.");
                return Page();
            }
            // Add error that shows that there is no upload 
            else
            {
                ModelState.AddModelError(string.Empty, "The Photo Field is required");
                return Page();
            }

        }

        private bool IsImageFile(IFormFile file)
        {
            // Define the allowed content types for images
            var allowedContentTypes = new[] { "image/png", "image/jpeg" };

            // Check if the file's content type is in the allowed list
            return file.ContentType != null && allowedContentTypes.Contains(file.ContentType);
        }

    }


}


