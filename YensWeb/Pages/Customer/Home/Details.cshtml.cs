using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yens.DataAccess.Repository.IRepository;
using Yens.Models;

namespace YensWeb.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }
        public void OnGet(int id)
        {
            ShoppingCart = new()
            {
                MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(x=>x.Id==id, includeProperties: "Category,FoodType"),
                MenuItemId= id
            };

        }

        public IActionResult OnPost() {
            if (ModelState.IsValid) { 
                //ShoppingCart shoppingCartFromDb = _unitOfWork.sho
            }

            return Page();
        }
    }
}
