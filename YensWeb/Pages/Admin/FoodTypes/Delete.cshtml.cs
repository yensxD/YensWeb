using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yens.DataAccess.Repository.IRepository;
using Yens.Models;

namespace YensWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(x => x.Id == id);
        }
        public async Task<ActionResult> OnPost()
        {
            var CategoryFromDb = _unitOfWork.FoodType.GetFirstOrDefault(x => x.Id == FoodType.Id);
            if (CategoryFromDb != null) {
                _unitOfWork.FoodType.Remove(CategoryFromDb);
                _unitOfWork.Save();
                TempData["success"] = "FoodType deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
