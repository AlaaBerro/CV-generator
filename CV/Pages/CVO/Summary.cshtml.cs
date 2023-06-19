using CV.Pages.Data;
using CV.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CV.Pages.CVO
{
    public class SummaryModel : PageModel
    {

        [BindProperty]
        public CVModel Input { get; set; }

        private readonly CVDbContext _db;

        public CVModel cv { get; set; }


        public SummaryModel(CVDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Input = _db.cv.FirstOrDefault(u => u.Id == id);
             cv = _db.cv.Find(Input.Id);
        }


    }

}


