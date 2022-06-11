using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yens.DataAccess.Repository.IRepository;
using Yens.Models;

namespace YensWeb.Pages.Admin.Categorie
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnPost() {
            if (Category.Name == Category.DisplayOrder.ToString()) {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid) {
                _unitOfWork.Category.Add(Category);
                _unitOfWork.Save();
                TempData["Success"] = "Categoy created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }

        public void OnGet()
        {
        }
    }
}
