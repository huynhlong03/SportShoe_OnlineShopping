using Microsoft.AspNetCore.Mvc;
using SportShoes.Helpers;
using SportShoes.Models.ViewModel;

namespace SportShoes.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
            return View("CartPanel", new CartModel
            {
                iQuantity = cart.Sum(x => x.Quantity),
                dTotal = cart.Sum(p => p.Total)
            });;
        }
    }
}
