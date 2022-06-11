using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yens.DataAccess.Repository.IRepository;
using Yens.Models;

namespace YensWeb.Pages.Admin.Categorie
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
        }

        public async Task<ActionResult> OnPost() {
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == Category.Id);
            if (categoryFromDb != null) {
                _unitOfWork.Category.Remove(categoryFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
