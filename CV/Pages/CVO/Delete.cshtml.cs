using CV.Pages.Data;
using CV.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CV.Pages.CVO
{
    public class DeleteModel : PageModel
    {

        [BindProperty]
        public CVModel Input { get; set; }

        private readonly CVDbContext _db;

        public DeleteModel(CVDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            var cv = _db.cv.FirstOrDefault(u => u.Id == id);
            if(cv != null)
            {
                Input = cv;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var cv = _db.cv.Find(Input.Id);
            if(cv != null)
            {
                _db.cv.Remove(cv);
                await _db.SaveChangesAsync();
            }
            return Redirect("/CVO/");
        }
    }
}
