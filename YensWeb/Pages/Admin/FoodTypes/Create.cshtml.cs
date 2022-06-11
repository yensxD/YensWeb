using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yens.DataAccess.Repository.IRepository;
using Yens.Models;

namespace YensWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ActionResult> OnPost() {
            if (ModelState.IsValid) {
                _unitOfWork.FoodType.Add(FoodType);
                _unitOfWork.Save();
                TempData["success"] = "FoodType create successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
