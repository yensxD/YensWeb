using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yens.DataAccess.Repository.IRepository;
using Yens.Models;

namespace YensWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(x => x.Id == id);
        }

        public async Task<ActionResult> OnPost() {
            if (ModelState.IsValid) {
                _unitOfWork.FoodType.Update(FoodType);
                _unitOfWork.Save();
                TempData["success"] = "FooType updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
