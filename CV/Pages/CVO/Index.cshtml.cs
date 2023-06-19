using CV.Pages.Data;
using CV.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CV.Pages.CVO
{
    public class IndexModel : PageModel
    {
        private readonly CVDbContext _db;

        public IEnumerable<CVModel> CVS { get; set; }

        public IndexModel(CVDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CVS = _db.cv;
        }

       
    }
}
